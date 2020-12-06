using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipEntrySearch
{
    public partial class MainForm : Form
    {
        protected class WorkerParam
        {
            public string FolderPath { get; set; } = "";
            public string SearchText { get; set; } = "";

            public override string ToString()
            {
                return $"{FolderPath},${SearchText}";
            }
        }

        /// <summary>
        /// デフォルトのエンコード
        /// </summary>
        private static Encoding _zipEntryDefaultEncoding = Encoding.UTF8;

        /// <summary>
        /// SJISのエンコード
        /// </summary>
        private static Encoding _zipEntrySjisEncoding = Encoding.UTF8;

        public MainForm()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _zipEntrySjisEncoding = Encoding.GetEncoding("Shift_JIS");

            menuItemDoubleBytes.Click += menuItemDoubleBytes_Click;
            menuItemDbFile.Click += menuItemDbFile_Click;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Log.Info("アプリケーション起動");
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info("アプリケーション終了");
        }

        private void folderPathRefButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void menuItemDoubleBytes_Click(object? sender, EventArgs e)
        {
            searchTextBox.Text = @"[^\x01-\x7E]";
        }

        private void menuItemDbFile_Click(object? sender, EventArgs e)
        {
            searchTextBox.Text = @".+\.db";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                return;
            }

            var folderPath = folderPathTextBox.Text;
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("フォルダパスが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("フォルダパスが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var searchText = searchTextBox.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("検索文字列が入力されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startButton.Enabled = false;
            bgWorker.RunWorkerAsync(new WorkerParam()
            {
                FolderPath = folderPath,
                SearchText = searchText,
            });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                Log.Error("sender is not BackgroundWorker");
                e.Result = "処理パラメーターエラー";
                return;
            }
            if (e.Argument is not WorkerParam param)
            {
                Log.Error("e.Argument is not WorkerParam");
                e.Result = "処理パラメーターエラー";
                return;
            }

            Log.Info($"処理開始 param={param}");
            var zipFileList = Directory.GetFiles(param.FolderPath, "*.zip", SearchOption.AllDirectories);
            if (zipFileList.Length == 0)
            {
                Log.Warn("フォルダ内にZIPファイルが見つからない");
                e.Result = "指定されたフォルダ内にZIPファイルが見つかりません";
                return;
            }

            worker.ReportProgress(zipFileList.Length);
            var pos = 0;
            var hitFileList = new List<string>();
            foreach (var zipFile in zipFileList)
            {
                pos++;
                worker.ReportProgress(pos, Path.GetFileName(zipFile));
                if (worker.CancellationPending)
                {
                    Log.Info("処理キャンセル検知");
                    e.Cancel = true;
                    return;
                }

                Log.Info($"処理ファイル={zipFile}");
                if (searchZip(zipFile, param.SearchText, _zipEntrySjisEncoding))
                {
                    Log.Info($"ヒット file={zipFile}");
                    hitFileList.Add(zipFile);
                }
            }

            var saveFileName = $"logs/hit_{DateTime.Now:yyyyMMddHHmmss}.txt";
            if (hitFileList.Count > 0)
            {
                try
                {
                    File.WriteAllLines(saveFileName, hitFileList.ToArray());
                }
                catch (Exception err)
                {
                    Log.Error(err, "結果ファイル保存失敗");
                    e.Result = "結果ファイルの作成失敗しました";
                    return;
                }
            }

            Log.Info("処理完了");
            if (hitFileList.Count == 0)
            {
                e.Result = "処理結果 見つかりませんでした";
            }
            else
            {
                e.Result = $"処理結果 ヒット={hitFileList.Count}\n{saveFileName}に結果を保存しました";
            }
        }

        private bool searchZip(string zipFile, string searchText, Encoding enc)
        {
            try
            {
                using var archive = ZipFile.Open(zipFile, ZipArchiveMode.Read, enc);
                foreach (var entry in archive.Entries)
                {
                    if (entry == null)
                    {
                        continue;
                    }

                    Log.Info($"Name={entry.Name}");
                    if (Regex.IsMatch(entry.Name, searchText))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "例外発生");
                return false;
            }

            return false;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = "";
            if (e.UserState != null)
            {
                message = e.UserState.ToString();
            }

            if (message == "")
            {
                progressBar.Maximum = e.ProgressPercentage;
                progressBar.Value = 0;
                progressStatusLabel.Text = "";
            }
            else
            {
                progressBar.Value = e.ProgressPercentage;
                progressStatusLabel.Text = message;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
            if (e.Cancelled)
            {
                MessageBox.Show("キャンセルされました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                progressStatusLabel.Text = "キャンセルされました";
            }
            else if (e.Result == null)
            {
                MessageBox.Show("想定外のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressStatusLabel.Text = "想定外のエラーが発生しました";
            }
            else
            {
                MessageBox.Show(e.Result.ToString(), "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressStatusLabel.Text = e.Result.ToString();
            }
        }

        private void searchTypeMenuButton_Click(object sender, EventArgs e)
        {
            searchTextContextMenuStrip.Show(Cursor.Position);
        }
    }
}
