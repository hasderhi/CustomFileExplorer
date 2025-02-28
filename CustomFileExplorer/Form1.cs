using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;










namespace CustomFileExplorer
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadIcons();
            LoadDrives();
            InitializeListView();
        }

        private void LoadIcons()
        {
            imageListIcons.Images.Clear();

            Icon folderIcon = ExtractFolderIcon();
            imageListIcons.Images.Add("folder", folderIcon);

            imageListIcons.Images.Add("file", SystemIcons.Application);

            treeViewDirectories.ImageList = imageListIcons;
            listViewFiles.SmallImageList = imageListIcons;
        }


        private Icon ExtractFolderIcon()
        {
            IntPtr hIcon = WinAPI.SHGetFileInfo(
                "C:\\Windows",
                0,
                out WinAPI.SHFILEINFO shinfo,
                (uint)Marshal.SizeOf(typeof(WinAPI.SHFILEINFO)),
                WinAPI.SHGFI_ICON | WinAPI.SHGFI_LARGEICON
            );

            return Icon.FromHandle(shinfo.hIcon);
        }



        private void InitializeListView()
        {
            listViewFiles.View = View.Details; // Ensure it's in Details mode
            listViewFiles.Columns.Add("Name", 250);
            listViewFiles.Columns.Add("Size", 100);
            listViewFiles.Columns.Add("Type", 150);
            listViewFiles.FullRowSelect = true;
        }

        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) return; // if no change

            string oldPath = listViewFiles.Items[e.Item].Tag.ToString();
            string newPath = Path.Combine(Path.GetDirectoryName(oldPath), e.Label);

            try
            {
                if (Directory.Exists(oldPath))
                    Directory.Move(oldPath, newPath);
                else if (File.Exists(oldPath))
                    File.Move(oldPath, newPath);

                listViewFiles.Items[e.Item].Tag = newPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }


        private void LoadDrives()
        {
            treeViewDirectories.Nodes.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeNode node = new TreeNode(drive.Name, 0, 0) { Tag = drive.Name };
                    node.Nodes.Add("Loading...");
                    treeViewDirectories.Nodes.Add(node);
                }
            }
        }

        private void treeViewDirectories_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            node.Nodes.Clear();

            string path = node.Tag.ToString();
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    TreeNode childNode = new TreeNode(Path.GetFileName(dir), 0, 0) { Tag = dir };
                    childNode.Nodes.Add("Loading...");
                    node.Nodes.Add(childNode);
                }
            }
            catch { }
        }


        private void treeViewDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.Tag.ToString();
            textBoxPath.Text = selectedPath;
            LoadFiles(selectedPath);
        }

        private void LoadFiles(string path)
        {
            listViewFiles.Items.Clear();

            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0); // Folder icon
                    item.Tag = dir;
                    item.SubItems.Add("");
                    item.SubItems.Add("Folder");
                    listViewFiles.Items.Add(item);
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string ext = fileInfo.Extension.ToLower();

                    int iconIndex = GetFileIconIndex(ext);
                    ListViewItem item = new ListViewItem(fileInfo.Name, iconIndex);
                    item.Tag = file;
                    item.SubItems.Add(fileInfo.Length.ToString("N0") + " bytes");
                    item.SubItems.Add(fileInfo.Extension.ToUpper() + " File");
                    listViewFiles.Items.Add(item);
                }
            }
            catch { }
        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text;
            if (Directory.Exists(path))
            {
                LoadFiles(path);
                HighlightTreeViewPath(path);
            }
            else
            {
                MessageBox.Show("Invalid Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightTreeViewPath(string path)
        {
            foreach (TreeNode node in treeViewDirectories.Nodes)
            {
                if (node.Tag.ToString().Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    treeViewDirectories.SelectedNode = node;
                    node.Expand();
                    return;
                }
            }
        }


        private Dictionary<string, int> iconCache = new Dictionary<string, int>();

        private int GetFileIconIndex(string extension)
        {
            if (iconCache.ContainsKey(extension))
                return iconCache[extension];

            Icon icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); // Default

            string tempFile = Path.Combine(Path.GetTempPath(), "icon" + extension);
            try
            {
                File.WriteAllText(tempFile, ""); // Create tempfile
                icon = Icon.ExtractAssociatedIcon(tempFile);
            }
            catch { }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }

            imageListIcons.Images.Add(extension, icon);
            int index = imageListIcons.Images.Count - 1;
            iconCache[extension] = index;
            return index;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) // I sadly cannot rename this without breaking the whole app apart
        {
            {
                if (listViewFiles.SelectedItems.Count == 0) return;

                string path = listViewFiles.SelectedItems[0].Tag.ToString();

                if (Directory.Exists(path))
                {
                    textBoxPath.Text = path;
                    LoadFiles(path);
                    HighlightTreeViewPath(path);
                }
                else if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                }
            }
        }

        private void contextMenuFiles_Copy_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            Clipboard.SetText(listViewFiles.SelectedItems[0].Tag.ToString());
        }

        private string cutFilePath = null;

        private void contextMenuFiles_Cut_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            cutFilePath = listViewFiles.SelectedItems[0].Tag.ToString();
        }

        private void contextMenuFiles_Paste_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cutFilePath)) return;

            string destinationPath = Path.Combine(textBoxPath.Text, Path.GetFileName(cutFilePath));

            try
            {
                File.Move(cutFilePath, destinationPath);
                cutFilePath = null;
                LoadFiles(textBoxPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuFiles_Delete_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;

            string path = listViewFiles.SelectedItems[0].Tag.ToString();
            if (MessageBox.Show("Are you sure you want to delete this?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (Directory.Exists(path))
                        Directory.Delete(path, true);
                    else if (File.Exists(path))
                        File.Delete(path);

                    LoadFiles(textBoxPath.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuFiles_Rename_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            listViewFiles.SelectedItems[0].BeginEdit();
        }

        private void contextMenuFiles_NewFolder_Click(object sender, EventArgs e)
        {
            string currentPath = textBoxPath.Text;
            if (string.IsNullOrEmpty(currentPath) || !Directory.Exists(currentPath))
            {
                MessageBox.Show("Invalid directory selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newFolderPath;
            int count = 1;

            do
            {
                newFolderPath = Path.Combine(currentPath, $"New Folder {count}");
                count++;
            } while (Directory.Exists(newFolderPath));

            try
            {
                Directory.CreateDirectory(newFolderPath);
                LoadFiles(currentPath); // Refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }


}

public class WinAPI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SHGetFileInfo(
        string pszPath,
        uint dwFileAttributes,
        out SHFILEINFO psfi,
        uint cbFileInfo,
        uint uFlags
    );

    public const uint SHGFI_ICON = 0x000000100;
    public const uint SHGFI_LARGEICON = 0x000000000;
}
