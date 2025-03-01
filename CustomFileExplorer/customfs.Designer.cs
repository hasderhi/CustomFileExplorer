namespace CustomFileExplorer
{
    partial class CustomFileExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuickAccessDesktop = new System.Windows.Forms.Button();
            this.btnQuickAccessMusic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuickAccessVideos = new System.Windows.Forms.Button();
            this.btnQuickAccessImages = new System.Windows.Forms.Button();
            this.btnQuickAccessDocuments = new System.Windows.Forms.Button();
            this.treeViewDirectories = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLargeView = new System.Windows.Forms.Button();
            this.btnDetailsView = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.contextMenuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuFiles_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_NewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnExtract = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuFiles.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.treeViewDirectories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.listViewFiles);
            this.splitContainer1.Size = new System.Drawing.Size(940, 493);
            this.splitContainer1.SplitterDistance = 252;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnQuickAccessDesktop);
            this.panel2.Controls.Add(this.btnQuickAccessMusic);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnQuickAccessVideos);
            this.panel2.Controls.Add(this.btnQuickAccessImages);
            this.panel2.Controls.Add(this.btnQuickAccessDocuments);
            this.panel2.Location = new System.Drawing.Point(0, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 248);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "v1.0.1";
            // 
            // btnQuickAccessDesktop
            // 
            this.btnQuickAccessDesktop.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnQuickAccessDesktop.Location = new System.Drawing.Point(0, 29);
            this.btnQuickAccessDesktop.Name = "btnQuickAccessDesktop";
            this.btnQuickAccessDesktop.Size = new System.Drawing.Size(252, 23);
            this.btnQuickAccessDesktop.TabIndex = 5;
            this.btnQuickAccessDesktop.Text = "Desktop";
            this.btnQuickAccessDesktop.UseVisualStyleBackColor = true;
            this.btnQuickAccessDesktop.Click += new System.EventHandler(this.btnQuickAccessDesktop_Click);
            // 
            // btnQuickAccessMusic
            // 
            this.btnQuickAccessMusic.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnQuickAccessMusic.Location = new System.Drawing.Point(0, 117);
            this.btnQuickAccessMusic.Name = "btnQuickAccessMusic";
            this.btnQuickAccessMusic.Size = new System.Drawing.Size(252, 23);
            this.btnQuickAccessMusic.TabIndex = 4;
            this.btnQuickAccessMusic.Text = "Music";
            this.btnQuickAccessMusic.UseVisualStyleBackColor = true;
            this.btnQuickAccessMusic.Click += new System.EventHandler(this.btnQuickAccessMusic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "CustomFileExplorer";
            // 
            // btnQuickAccessVideos
            // 
            this.btnQuickAccessVideos.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnQuickAccessVideos.Location = new System.Drawing.Point(0, 88);
            this.btnQuickAccessVideos.Name = "btnQuickAccessVideos";
            this.btnQuickAccessVideos.Size = new System.Drawing.Size(252, 23);
            this.btnQuickAccessVideos.TabIndex = 3;
            this.btnQuickAccessVideos.Text = "Videos";
            this.btnQuickAccessVideos.UseVisualStyleBackColor = true;
            this.btnQuickAccessVideos.Click += new System.EventHandler(this.btnQuickAccessVideos_Click);
            // 
            // btnQuickAccessImages
            // 
            this.btnQuickAccessImages.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnQuickAccessImages.Location = new System.Drawing.Point(0, 59);
            this.btnQuickAccessImages.Name = "btnQuickAccessImages";
            this.btnQuickAccessImages.Size = new System.Drawing.Size(252, 23);
            this.btnQuickAccessImages.TabIndex = 2;
            this.btnQuickAccessImages.Text = "Images";
            this.btnQuickAccessImages.UseVisualStyleBackColor = true;
            this.btnQuickAccessImages.Click += new System.EventHandler(this.btnQuickAccessImages_Click);
            // 
            // btnQuickAccessDocuments
            // 
            this.btnQuickAccessDocuments.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickAccessDocuments.Location = new System.Drawing.Point(0, 0);
            this.btnQuickAccessDocuments.Name = "btnQuickAccessDocuments";
            this.btnQuickAccessDocuments.Size = new System.Drawing.Size(252, 23);
            this.btnQuickAccessDocuments.TabIndex = 0;
            this.btnQuickAccessDocuments.Text = "Documents";
            this.btnQuickAccessDocuments.UseVisualStyleBackColor = true;
            this.btnQuickAccessDocuments.Click += new System.EventHandler(this.btnQuickAccessDocuments_Click);
            // 
            // treeViewDirectories
            // 
            this.treeViewDirectories.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeViewDirectories.Location = new System.Drawing.Point(0, 0);
            this.treeViewDirectories.Name = "treeViewDirectories";
            this.treeViewDirectories.Size = new System.Drawing.Size(252, 245);
            this.treeViewDirectories.TabIndex = 0;
            this.treeViewDirectories.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDirectories_BeforeExpand);
            this.treeViewDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirectories_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 93);
            this.panel3.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 85);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.btnOpen);
            this.tabPage1.Controls.Add(this.btnRename);
            this.tabPage1.Controls.Add(this.btnPaste);
            this.tabPage1.Controls.Add(this.btnCut);
            this.tabPage1.Controls.Add(this.btnCopy);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnNewFolder);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 56);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnOpen.Location = new System.Drawing.Point(297, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(92, 50);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(199, 29);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(92, 24);
            this.btnRename.TabIndex = 9;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(199, 4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(92, 23);
            this.btnPaste.TabIndex = 8;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(101, 29);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(92, 24);
            this.btnCut.TabIndex = 7;
            this.btnCut.Text = "Cut";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(101, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 24);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 24);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Location = new System.Drawing.Point(3, 3);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(92, 24);
            this.btnNewFolder.TabIndex = 4;
            this.btnNewFolder.Text = "New Folder";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLargeView);
            this.tabPage2.Controls.Add(this.btnDetailsView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 56);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLargeView
            // 
            this.btnLargeView.Location = new System.Drawing.Point(3, 30);
            this.btnLargeView.Name = "btnLargeView";
            this.btnLargeView.Size = new System.Drawing.Size(92, 23);
            this.btnLargeView.TabIndex = 13;
            this.btnLargeView.Text = "Large";
            this.btnLargeView.UseVisualStyleBackColor = true;
            this.btnLargeView.Click += new System.EventHandler(this.btnLargeView_Click);
            // 
            // btnDetailsView
            // 
            this.btnDetailsView.Location = new System.Drawing.Point(3, 3);
            this.btnDetailsView.Name = "btnDetailsView";
            this.btnDetailsView.Size = new System.Drawing.Size(92, 23);
            this.btnDetailsView.TabIndex = 12;
            this.btnDetailsView.Text = "Details";
            this.btnDetailsView.UseVisualStyleBackColor = true;
            this.btnDetailsView.Click += new System.EventHandler(this.btnDetailsView_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(676, 56);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.textBoxPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 23);
            this.panel1.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnGo.Location = new System.Drawing.Point(609, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 24);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 24);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(88, 1);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(521, 22);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // listViewFiles
            // 
            this.listViewFiles.ContextMenuStrip = this.contextMenuFiles;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewFiles.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.LabelEdit = true;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(684, 386);
            this.listViewFiles.TabIndex = 0;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewFiles_AfterLabelEdit);
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            // 
            // contextMenuFiles
            // 
            this.contextMenuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuFiles_Open,
            this.contextMenuFiles_Copy,
            this.contextMenuFiles_Cut,
            this.contextMenuFiles_Paste,
            this.contextMenuFiles_Delete,
            this.contextMenuFiles_Rename,
            this.contextMenuFiles_NewFolder});
            this.contextMenuFiles.Name = "contextMenuFiles";
            this.contextMenuFiles.Size = new System.Drawing.Size(135, 158);
            this.contextMenuFiles.TabStop = true;
            // 
            // contextMenuFiles_Open
            // 
            this.contextMenuFiles_Open.Name = "contextMenuFiles_Open";
            this.contextMenuFiles_Open.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Open.Text = "Open";
            this.contextMenuFiles_Open.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // contextMenuFiles_Copy
            // 
            this.contextMenuFiles_Copy.Name = "contextMenuFiles_Copy";
            this.contextMenuFiles_Copy.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Copy.Text = "Copy";
            this.contextMenuFiles_Copy.Click += new System.EventHandler(this.contextMenuFiles_Copy_Click);
            // 
            // contextMenuFiles_Cut
            // 
            this.contextMenuFiles_Cut.Name = "contextMenuFiles_Cut";
            this.contextMenuFiles_Cut.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Cut.Text = "Cut";
            this.contextMenuFiles_Cut.Click += new System.EventHandler(this.contextMenuFiles_Cut_Click);
            // 
            // contextMenuFiles_Paste
            // 
            this.contextMenuFiles_Paste.Name = "contextMenuFiles_Paste";
            this.contextMenuFiles_Paste.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Paste.Text = "Paste";
            this.contextMenuFiles_Paste.Click += new System.EventHandler(this.contextMenuFiles_Paste_Click);
            // 
            // contextMenuFiles_Delete
            // 
            this.contextMenuFiles_Delete.Name = "contextMenuFiles_Delete";
            this.contextMenuFiles_Delete.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Delete.Text = "Delete";
            this.contextMenuFiles_Delete.Click += new System.EventHandler(this.contextMenuFiles_Delete_Click);
            // 
            // contextMenuFiles_Rename
            // 
            this.contextMenuFiles_Rename.Name = "contextMenuFiles_Rename";
            this.contextMenuFiles_Rename.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_Rename.Text = "Rename";
            this.contextMenuFiles_Rename.Click += new System.EventHandler(this.contextMenuFiles_Rename_Click);
            // 
            // contextMenuFiles_NewFolder
            // 
            this.contextMenuFiles_NewFolder.Name = "contextMenuFiles_NewFolder";
            this.contextMenuFiles_NewFolder.Size = new System.Drawing.Size(134, 22);
            this.contextMenuFiles_NewFolder.Text = "New Folder";
            this.contextMenuFiles_NewFolder.Click += new System.EventHandler(this.contextMenuFiles_NewFolder_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnExtract);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(676, 56);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Extract";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(3, 3);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(92, 23);
            this.btnExtract.TabIndex = 17;
            this.btnExtract.Text = "Extract .zip";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // CustomFileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 493);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomFileExplorer";
            this.Text = "CustomFileExplorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuFiles.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewDirectories;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.ContextMenuStrip contextMenuFiles;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Open;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Copy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Cut;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Paste;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Delete;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_Rename;
        private System.Windows.Forms.ToolStripMenuItem contextMenuFiles_NewFolder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuickAccessDesktop;
        private System.Windows.Forms.Button btnQuickAccessMusic;
        private System.Windows.Forms.Button btnQuickAccessVideos;
        private System.Windows.Forms.Button btnQuickAccessImages;
        private System.Windows.Forms.Button btnQuickAccessDocuments;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDetailsView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnLargeView;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnExtract;
    }
}

