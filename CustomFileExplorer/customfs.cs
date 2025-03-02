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
using System.IO.Compression;











namespace CustomFileExplorer
{
    public partial class CustomFileExplorer: Form
    {


        private Stack<string> navigationHistory = new Stack<string>();
        private string currentPath = "";


        public CustomFileExplorer()
        {
            InitializeComponent();
            listViewFiles.MouseDoubleClick += ListViewFiles_MouseDoubleClick;
            btnSearch.Click += btnSearch_Click;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadIcons();
            LoadDrives();
            InitializeListView();
        }







        
        
        // Icons
        private void LoadIcons()
        {
            imageListIcons.Images.Clear();

            Icon folderIcon = ExtractFolderIcon();
            imageListIcons.Images.Add("folder", folderIcon);
            imageListIcons.Images.Add("file", SystemIcons.Application);

            treeViewDirectories.ImageList = imageListIcons;
            listViewFiles.SmallImageList = imageListIcons; // For Details mode
            listViewFiles.LargeImageList = imageListIcons; // For Large Icon mode
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




        // File view

        private void LoadFiles(string path)
        {
            if (!string.IsNullOrEmpty(currentPath))
            {
                navigationHistory.Push(currentPath); // Store the previous path
            }

            currentPath = path; // Update current path
            listViewFiles.Items.Clear();

            try
            {
                // Load Folders
                foreach (var dir in Directory.GetDirectories(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0);
                    item.Tag = dir;
                    item.SubItems.Add(""); // Placeholder for file size (folders don't have sizes)
                    item.SubItems.Add("Folder");
                    item.SubItems.Add(dirInfo.LastWriteTime.ToString()); // Last modified date

                    int specialIconIndex = GetSpecialFolderIconIndex(dir);
                    if (specialIconIndex != -1)
                        item.ImageIndex = specialIconIndex;

                    listViewFiles.Items.Add(item);
                }

                // Load Files
                foreach (var file in Directory.GetFiles(path))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string ext = fileInfo.Extension.ToLower();

                    int iconIndex = GetFileIconIndex(ext);
                    ListViewItem item = new ListViewItem(fileInfo.Name, iconIndex);
                    item.Tag = file;
                    item.SubItems.Add(fileInfo.Length.ToString("N0") + " bytes"); // File size
                    item.SubItems.Add(fileInfo.Extension.ToUpper() + " File");   // File type
                    item.SubItems.Add(fileInfo.LastWriteTime.ToString()); // Last modified date
                    listViewFiles.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GoBack();
            }
        }


        private void GoBack()
        {
            if (navigationHistory.Count > 0)
            {
                string previousPath = navigationHistory.Pop();
                textBoxPath.Text = previousPath;
                LoadFiles(previousPath);
            }
            else
            {
                MessageBox.Show("No previous directory to go back to.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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




        private void InitializeListView()
        {
            listViewFiles.View = View.Details; // Ensure it's in Details mode
            listViewFiles.Columns.Add("Name", 250);
            listViewFiles.Columns.Add("Size", 100);
            listViewFiles.Columns.Add("Type", 150);
            listViewFiles.Columns.Add("Last Modified", 150);
            listViewFiles.FullRowSelect = true;
        }

        private void listViewFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) return;


            string oldPath = listViewFiles.Items[e.Item].Tag.ToString();
            string newPath = Path.Combine(Path.GetDirectoryName(oldPath), e.Label);


            try
            {
                if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                }
                else if (File.Exists(oldPath))
                {
                    File.Move(oldPath, newPath);
                }
                else
                {
                    MessageBox.Show($"File/Directory not found:\n{oldPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                listViewFiles.Items[e.Item].Text = e.Label;
                listViewFiles.Items[e.Item].Tag = newPath;

                LoadFiles(Path.GetDirectoryName(newPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renaming: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.CancelEdit = true;
            }
        }


        private void ListViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
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


        private void ChangeListViewMode(View viewMode)
        {
            listViewFiles.View = viewMode;
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

















        // UI click events

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



        private void toolStripMenuItem1_Click(object sender, EventArgs e) // openContextMenu_Click
        {
            openFileFolder();
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
            deleteFileFolder();
        }

        private void contextMenuFiles_Rename_Click(object sender, EventArgs e)
        {
            init_rename();
        }

        private void contextMenuFiles_NewFolder_Click(object sender, EventArgs e)
        {
            new_Folder();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnQuickAccessDocuments_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }

        private void btnQuickAccessDesktop_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }

        private void btnQuickAccessImages_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }

        private void btnQuickAccessVideos_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }

        private void btnQuickAccessMusic_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }






        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            new_Folder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteFileFolder();
        }

        private void button1_Click(object sender, EventArgs e) // btnRename_Click
        {
            init_rename();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("to be implemented");
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("to be implemented");
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            MessageBox.Show("to be implemented");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileFolder();
        }

        private void btnDetailsView_Click(object sender, EventArgs e)
        {
            ChangeListViewMode(View.Details);
        }

        private void btnLargeView_Click(object sender, EventArgs e)
        {
            ChangeListViewMode(View.LargeIcon);
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            ExtractZipFile();
        }


        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Custom File Explorer\n " +
                $"\nCreated by Tobias Kisling\n" +
                $"Copyright (c) 2023-2025 Tobias Kisling ('tk_dev','hasderhi')\n " +
                $"\nThis is my very basic implementation of a file explorer\n" +
                $"in C# using the .NET WFS. Mostly a playground for me to practice C#.\n " +
                $"\nFound a bug or want a feature? Let me know by contacting me on\n" +
                $"Github (/hasderhi) or by sending an email to tobias.kisling@icloud.com!\n " +
                $"\nVersion 1.0.3", "Information / About this application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchFilesAndFolders(textBoxSearch.Text);
        }

        private void btnReload_Click(object sender, EventArgs e)
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





        // file handling

        private void ExtractZipFile()
        {
            if (listViewFiles.SelectedItems.Count == 0) return;

            string zipPath = listViewFiles.SelectedItems[0].Tag.ToString();
            if (!File.Exists(zipPath) || Path.GetExtension(zipPath).ToLower() != ".zip")
            {
                MessageBox.Show("Please select a valid ZIP file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string extractFolderPath = Path.Combine(Path.GetDirectoryName(zipPath), Path.GetFileNameWithoutExtension(zipPath));

            try
            {
                if (Directory.Exists(extractFolderPath))
                {
                    MessageBox.Show("A folder with the same name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Directory.CreateDirectory(extractFolderPath);
                ZipFile.ExtractToDirectory(zipPath, extractFolderPath);
                LoadFiles(Path.GetDirectoryName(zipPath)); // Refresh the view

                MessageBox.Show("ZIP file extracted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting ZIP file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void openFileFolder()
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

        private void init_rename()
        {
            if (listViewFiles.SelectedItems.Count == 0) return;
            listViewFiles.SelectedItems[0].BeginEdit();
        }

        private void new_Folder()
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

        private void deleteFileFolder()
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

        private void SearchFilesAndFolders(string query)
        {
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(currentPath))
            {
                LoadFiles(currentPath); // Reset to full directory listing if query is empty
                return;
            }

            listViewFiles.Items.Clear(); // Clear existing items

            try
            {
                // Search directories
                foreach (var dir in Directory.GetDirectories(currentPath))
                {
                    if (Path.GetFileName(dir).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0)
                        {
                            Tag = dir
                        };
                        item.SubItems.Add("");
                        item.SubItems.Add("Folder");

                        int specialIconIndex = GetSpecialFolderIconIndex(dir);
                        if (specialIconIndex != -1)
                            item.ImageIndex = specialIconIndex;

                        listViewFiles.Items.Add(item);
                    }
                }

                // Search files
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        int iconIndex = GetFileIconIndex(fileInfo.Extension);
                        ListViewItem item = new ListViewItem(fileInfo.Name, iconIndex)
                        {
                            Tag = file
                        };
                        item.SubItems.Add(fileInfo.Length.ToString("N0") + " bytes");
                        item.SubItems.Add(fileInfo.Extension.ToUpper() + " File");
                        listViewFiles.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching files: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RevealInExplorer(string filePath)
        {
            if (File.Exists(filePath) || Directory.Exists(filePath))
            {
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            else
            {
                MessageBox.Show("File not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Icons


        private Dictionary<string, int> specialFolderIcons = new Dictionary<string, int>();

        private int GetSpecialFolderIconIndex(string folderPath)
        {
            string[] specialFolders = 
                {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                };

            if (specialFolders.Contains(folderPath) && !specialFolderIcons.ContainsKey(folderPath))
            {
                Icon folderIcon = ExtractFolderIcon(folderPath);
                imageListIcons.Images.Add(folderPath, folderIcon);
                specialFolderIcons[folderPath] = imageListIcons.Images.Count - 1;
            }

            return specialFolderIcons.ContainsKey(folderPath) ? specialFolderIcons[folderPath] : -1;
        }

        private Icon ExtractFolderIcon(string folderPath)
        {
            IntPtr hIcon = WinAPI.SHGetFileInfo(
                folderPath,
                0,
                out WinAPI.SHFILEINFO shinfo,
                (uint)Marshal.SizeOf(typeof(WinAPI.SHFILEINFO)),
                WinAPI.SHGFI_ICON | WinAPI.SHGFI_LARGEICON
            );

            return Icon.FromHandle(shinfo.hIcon);
        }

        private void btnReveilInExplorer_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                string selectedPath = listViewFiles.SelectedItems[0].Tag.ToString();
                RevealInExplorer(selectedPath);
            }
            else
            {
                MessageBox.Show("Please select a file or folder first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnQuickAccessPersonal_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            textBoxPath.Text = path;
            LoadFiles(path);
            HighlightTreeViewPath(path);
        }
    }


}




// WinAPI class for icons
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
