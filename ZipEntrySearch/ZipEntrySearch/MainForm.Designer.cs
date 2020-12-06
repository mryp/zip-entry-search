
namespace ZipEntrySearch
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderPathRefButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchTypeMenuButton = new System.Windows.Forms.Button();
            this.searchTextContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDoubleBytes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDbFile = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(109, 12);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.Size = new System.Drawing.Size(574, 27);
            this.folderPathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "フォルダパス：";
            // 
            // folderPathRefButton
            // 
            this.folderPathRefButton.Location = new System.Drawing.Point(689, 11);
            this.folderPathRefButton.Name = "folderPathRefButton";
            this.folderPathRefButton.Size = new System.Drawing.Size(94, 29);
            this.folderPathRefButton.TabIndex = 2;
            this.folderPathRefButton.Text = "参照";
            this.folderPathRefButton.UseVisualStyleBackColor = true;
            this.folderPathRefButton.Click += new System.EventHandler(this.folderPathRefButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "検索文字列：";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 89);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(771, 51);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "処理開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 146);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(770, 29);
            this.progressBar.TabIndex = 6;
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.AutoSize = true;
            this.progressStatusLabel.Location = new System.Drawing.Point(12, 178);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.progressStatusLabel.TabIndex = 7;
            this.progressStatusLabel.Text = "未処理";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(109, 45);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(574, 27);
            this.searchTextBox.TabIndex = 8;
            // 
            // searchTypeMenuButton
            // 
            this.searchTypeMenuButton.Location = new System.Drawing.Point(689, 44);
            this.searchTypeMenuButton.Name = "searchTypeMenuButton";
            this.searchTypeMenuButton.Size = new System.Drawing.Size(94, 29);
            this.searchTypeMenuButton.TabIndex = 9;
            this.searchTypeMenuButton.Text = "▼";
            this.searchTypeMenuButton.UseVisualStyleBackColor = true;
            this.searchTypeMenuButton.Click += new System.EventHandler(this.searchTypeMenuButton_Click);
            // 
            // searchTextContextMenuStrip
            // 
            this.searchTextContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.searchTextContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDoubleBytes,
            this.menuItemDbFile});
            this.searchTextContextMenuStrip.Name = "searchTextContextMenuStrip";
            this.searchTextContextMenuStrip.Size = new System.Drawing.Size(186, 52);
            // 
            // menuItemDoubleBytes
            // 
            this.menuItemDoubleBytes.Name = "menuItemDoubleBytes";
            this.menuItemDoubleBytes.Size = new System.Drawing.Size(185, 24);
            this.menuItemDoubleBytes.Text = "全角文字を検索";
            // 
            // menuItemDbFile
            // 
            this.menuItemDbFile.Name = "menuItemDbFile";
            this.menuItemDbFile.Size = new System.Drawing.Size(185, 24);
            this.menuItemDbFile.Text = ".db拡張子を検索";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 232);
            this.Controls.Add(this.searchTypeMenuButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.progressStatusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folderPathRefButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderPathTextBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Zip entry search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.searchTextContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button folderPathRefButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressStatusLabel;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchTypeMenuButton;
        private System.Windows.Forms.ContextMenuStrip searchTextContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemDoubleBytes;
        private System.Windows.Forms.ToolStripMenuItem menuItemDbFile;
    }
}

