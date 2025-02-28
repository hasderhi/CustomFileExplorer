namespace CustomFileExplorer
{
    partial class Form1
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
            this.treeViewDirectories = new System.Windows.Forms.TreeView();
            this.btnGo = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.contextMenuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuFiles_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFiles_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuFiles_NewFolder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuFiles.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeViewDirectories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnGo);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPath);
            this.splitContainer1.Panel2.Controls.Add(this.listViewFiles);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewDirectories
            // 
            this.treeViewDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDirectories.Location = new System.Drawing.Point(0, 0);
            this.treeViewDirectories.Name = "treeViewDirectories";
            this.treeViewDirectories.Size = new System.Drawing.Size(215, 450);
            this.treeViewDirectories.TabIndex = 0;
            this.treeViewDirectories.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDirectories_BeforeExpand);
            this.treeViewDirectories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewDirectories_AfterSelect);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(489, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(92, 20);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxPath.Location = new System.Drawing.Point(0, 0);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(581, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // listViewFiles
            // 
            this.listViewFiles.ContextMenuStrip = this.contextMenuFiles;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.LabelEdit = true;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(581, 450);
            this.listViewFiles.TabIndex = 0;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
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
            this.contextMenuFiles.Size = new System.Drawing.Size(181, 180);
            this.contextMenuFiles.TabStop = true;
            // 
            // contextMenuFiles_Open
            // 
            this.contextMenuFiles_Open.Name = "contextMenuFiles_Open";
            this.contextMenuFiles_Open.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Open.Text = "Open";
            this.contextMenuFiles_Open.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // contextMenuFiles_Copy
            // 
            this.contextMenuFiles_Copy.Name = "contextMenuFiles_Copy";
            this.contextMenuFiles_Copy.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Copy.Text = "Copy";
            this.contextMenuFiles_Copy.Click += new System.EventHandler(this.contextMenuFiles_Copy_Click);
            // 
            // contextMenuFiles_Cut
            // 
            this.contextMenuFiles_Cut.Name = "contextMenuFiles_Cut";
            this.contextMenuFiles_Cut.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Cut.Text = "Cut";
            this.contextMenuFiles_Cut.Click += new System.EventHandler(this.contextMenuFiles_Cut_Click);
            // 
            // contextMenuFiles_Paste
            // 
            this.contextMenuFiles_Paste.Name = "contextMenuFiles_Paste";
            this.contextMenuFiles_Paste.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Paste.Text = "Paste";
            this.contextMenuFiles_Paste.Click += new System.EventHandler(this.contextMenuFiles_Paste_Click);
            // 
            // contextMenuFiles_Delete
            // 
            this.contextMenuFiles_Delete.Name = "contextMenuFiles_Delete";
            this.contextMenuFiles_Delete.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Delete.Text = "Delete";
            this.contextMenuFiles_Delete.Click += new System.EventHandler(this.contextMenuFiles_Delete_Click);
            // 
            // contextMenuFiles_Rename
            // 
            this.contextMenuFiles_Rename.Name = "contextMenuFiles_Rename";
            this.contextMenuFiles_Rename.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_Rename.Text = "Rename";
            this.contextMenuFiles_Rename.Click += new System.EventHandler(this.contextMenuFiles_Rename_Click);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuFiles_NewFolder
            // 
            this.contextMenuFiles_NewFolder.Name = "contextMenuFiles_NewFolder";
            this.contextMenuFiles_NewFolder.Size = new System.Drawing.Size(180, 22);
            this.contextMenuFiles_NewFolder.Text = "New Folder";
            this.contextMenuFiles_NewFolder.Click += new System.EventHandler(this.contextMenuFiles_NewFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuFiles.ResumeLayout(false);
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
    }
}

