using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Shell32;

namespace FileManager._1
{
    public partial class FileManager : Form
    {
        private static List<string> folderHistory = new List<string>();
        private static string selectedFile = "";
        private static string changingFile = "";
        private static bool copyMode; 
        private enum SortTipe { Name, LastAccessTime, CreationTime, Size }
        SortTipe sortTipe = SortTipe.Name;
        public FileManager()
        {
            InitializeComponent();
            folderHistory.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            treeView.BeforeSelect += TreeViewBeforeSelect;
            treeView.BeforeExpand += TreeViewBeforeExpand;
            FillDriveNodes();
        }

        private void TreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void TreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new TreeNode(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    DisplayFiles(e.Node.FullPath);
                }
            }
            catch (Exception ex) { }
        }
        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name };
                    FillTreeNode(driveNode, drive.Name);
                    treeView.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex) { }
        }
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception ex) { }
        }

        private void Desktop_Click(object sender, EventArgs e)
        {
            DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
        private void Documents_Click(object sender, EventArgs e)
        {
            DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }
        private void Pictures_Click(object sender, EventArgs e)
        {
            DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }
        private void Videos_Click(object sender, EventArgs e)
        {
            DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        } 
        private void AccessMenuButtons()
        {
            if (selectedFile == "" && changingFile == "")
            {
                Delete.Enabled = false;
                Copy.Enabled = false;
                Put.Enabled = false;
                CutOut.Enabled = false;
                Delete.BackColor = Color.LightSteelBlue;
                Copy.BackColor = Color.LightSteelBlue;
                Put.BackColor = Color.LightSteelBlue;
                CutOut.BackColor = Color.LightSteelBlue;
            }
            else if (selectedFile == "")
            {
                Delete.Enabled = false;
                Copy.Enabled = false;
                Put.Enabled = true;
                CutOut.Enabled = false;
                Delete.BackColor = Color.LightSteelBlue;
                Copy.BackColor = Color.LightSteelBlue;
                Put.BackColor = Color.White;
                CutOut.BackColor = Color.LightSteelBlue;
            }
            else
            {
                Delete.Enabled = true;
                Copy.Enabled = true;
                Put.Enabled = true;
                CutOut.Enabled = true;
                Delete.BackColor = Color.White;
                Copy.BackColor = Color.White;
                Put.BackColor = Color.White;
                CutOut.BackColor = Color.White;
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            folderHistory.RemoveAt(folderHistory.Count - 1);
            if (folderHistory.Count != 0)
            {
                DisplayFiles(folderHistory[folderHistory.Count - 1]);
            }
            else
            {
                folderHistory.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                DisplayFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Name;
            selectedLabel.Text = "";
            selectedFile = "";
            AccessMenuButtons();
            if (Path.GetExtension(filePath).ToLower() == ".lnk")
            {
                string pathOnly = Path.GetDirectoryName(filePath);
                string filenameOnly = Path.GetFileName(filePath);
                Shell shell = new Shell();
                Folder folder = shell.NameSpace(pathOnly);
                FolderItem folderItem = folder.ParseName(filenameOnly);
                if (folderItem != null)
                {
                    ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                    filePath = link.Path;
                }
            }
            if (Directory.Exists(filePath))
            {
                DisplayFiles(filePath);
            }
            else
            {
                try
                {
                    var process = new Process();
                    process.StartInfo = new ProcessStartInfo() { UseShellExecute = true, FileName = filePath };
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Choose_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            string filePath = pictureBox.Name;
            selectedFile = filePath;
            var fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.Length - (filePath.LastIndexOf("\\") + 1));
            selectedLabel.Text = "Выбрано: " + fileName;
            AccessMenuButtons();
        }

        private void CreateFileContextMenu(PictureBox pictureBox)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem copyItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem cutOutItem = new ToolStripMenuItem("Вырезать");
            ToolStripMenuItem propertiesItem = new ToolStripMenuItem("Свойства");
            ToolStripMenuItem renameItem = new ToolStripMenuItem("Переименовать");
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                copyItem, deleteItem, cutOutItem, propertiesItem, renameItem
            });
            copyItem.Click += Copy_Click;
            deleteItem.Click += Delete_Click;
            cutOutItem.Click += CutOut_Click;
            propertiesItem.Click += Properties_Click;
            renameItem.Click += Rename_Click;
            contextMenu.BringToFront();
            pictureBox.ContextMenuStrip = contextMenu;
        }
        private void CreateFile(string filePath)
        {
            FileService fileService = new FileService(filePath);
            var startOfName = filePath.LastIndexOf("\\");
            var fileName = filePath.Substring(startOfName + 1, filePath.Length - (startOfName + 1));
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = filePath;
            CreateFileContextMenu(pictureBox);
            Label name = new Label();
            name.Text = fileName;
            name.BorderStyle = BorderStyle.None;
            name.BackColor = Color.AliceBlue;
            name.Size = new Size(840, 30);
            pictureBox.Image = Image.FromFile(fileService.GetFileExtensionImg());
            pictureBox.Size = new Size(30, 30);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.MouseDoubleClick += Open_Click;
            pictureBox.MouseDown += Choose_Click;
            LayoutPanel.Controls.Add(pictureBox);
            LayoutPanel.Controls.Add(name);
            Control lastControl = name;
            if (File.Exists(filePath))
            {
                FileService file = new FileService(filePath);
                name.Size = new Size(730, 30);
                TextBox size = new TextBox();
                size.Text = file.GetSizeOfFile();
                size.TextAlign = HorizontalAlignment.Right;
                size.Location = new Point(100, 110);
                size.BorderStyle = BorderStyle.None;
                LayoutPanel.Controls.Add(size);
                lastControl = size;
            }
            LayoutPanel.SetFlowBreak(lastControl, true);
        }
        private void CreatePictureFile(string filePath)
        {
            var startOfName = filePath.LastIndexOf("\\");
            var fileName = filePath.Substring(startOfName + 1, filePath.Length - (startOfName + 1));
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = filePath;
            CreateFileContextMenu(pictureBox);
            Label name = new Label();
            name.Text = fileName;
            name.BorderStyle = BorderStyle.None;
            name.BackColor = Color.AliceBlue;
            FileStream stream = new FileStream(filePath, FileMode.Open);
            try
            { pictureBox.Image = Image.FromStream(stream); }
            catch (Exception ex)
            {
                FileService fileService = new FileService(filePath);
                pictureBox.Image = Image.FromFile(fileService.GetFileExtensionImg());
            }
            stream.Close();
            pictureBox.Size = new Size(pictureBox.Image.Width / 20, pictureBox.Image.Height / 20);
            if (pictureBox.Image.Width < 60 || pictureBox.Image.Height < 60)
                pictureBox.Size = new Size(pictureBox.Image.Width, pictureBox.Image.Height);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            name.Size = new Size(750 - pictureBox.Size.Width, 30);
            pictureBox.MouseDoubleClick += Open_Click;
            pictureBox.MouseDown += Choose_Click;
            LayoutPanel.Controls.Add(pictureBox);
            LayoutPanel.Controls.Add(name);
            FileService file = new FileService(filePath);
            TextBox size = new TextBox();
            size.Text = file.GetSizeOfFile();
            size.TextAlign = HorizontalAlignment.Right;
            size.Location = new Point(100, 110);
            size.BorderStyle = BorderStyle.None;
            LayoutPanel.Controls.Add(size);
            LayoutPanel.SetFlowBreak(size, true);
        }
        private void DisplayFiles(string filePath)
        {
            LayoutPanel.SuspendLayout();
            if (!(folderHistory[folderHistory.Count - 1] == filePath))
                folderHistory.Add(filePath);
            currentDirectoryLabel.Text = filePath;
            selectedLabel.Text = "";
            selectedFile = "";
            AccessMenuButtons();

            string[] filesList = Directory.GetDirectories(filePath).Concat(Directory.GetFiles(filePath)).ToArray();

            if (sortTipe == SortTipe.Name)
                filesList = filesList.OrderBy(f => new FileInfo(f).Name).ToArray();
            if (sortTipe == SortTipe.LastAccessTime)
                filesList = filesList.OrderBy(f => new FileInfo(f).LastAccessTime).ToArray();
            if (sortTipe == SortTipe.CreationTime)
                filesList = filesList.OrderBy(f => new FileInfo(f).CreationTime).ToArray();
            LayoutPanel.Controls.Clear();

            if (filesList.Length == 0)
            {
                Label newLabel = new Label();
                newLabel.Text = "папка пуста";
                LayoutPanel.Controls.Add(newLabel);
            }
            else
            {
                for (int i = 0; i < filesList.Count() - 1; i++)
                {
                    bool isHidden = ((File.GetAttributes(filesList[i]) & FileAttributes.Hidden) == FileAttributes.Hidden);

                    if (!isHidden || (isHidden && checkBox.Checked))
                    {
                        List<string> ImageExtensions = new List<string> { ".jpg", ".jpe", ".bmp", ".gif", ".png" };
                        if (ImageExtensions.Contains(Path.GetExtension(filesList[i])))
                            CreatePictureFile(filesList[i]);
                        else CreateFile(filesList[i]);
                    }
                }
            }
            LayoutPanel.ResumeLayout();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(selectedFile))
                {
                    DialogResult result = MessageBox.Show("Удалить папку " + selectedFile + "?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Directory.Delete(selectedFile, true);
                        changingFile = "";
                        DisplayFiles(folderHistory[folderHistory.Count - 1]);
                    }
                }
                if (File.Exists(selectedFile))
                {
                    DialogResult result = MessageBox.Show("Удалить файл " + selectedFile + "?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(selectedFile);
                        changingFile = "";
                        DisplayFiles(folderHistory[folderHistory.Count - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Не удалось удалить " + selectedFile);
            }
        }
        private void Properties_Click(object sender, EventArgs e)
        {
            FilesService file;
            if (File.Exists(changingFile))
                file = new FileService(changingFile);
            else
                file = new FolderService(changingFile);
            MessageBox.Show(file.ToString(), "Свойства");
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            string currentDirectory = folderHistory[folderHistory.Count - 1];
            FilesService file;
            if (File.Exists(changingFile))
                file = new FileService(changingFile);
            else
                file = new FolderService(changingFile);
            if (copyMode)
            {
                if(!file.Copy(currentDirectory))
                {
                    DialogResult result = MessageBox.Show("Файл с таким именем уже существует в папке." + '\n' + "Заменить его?", "Не удалось копировать файл", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            file.Replace(currentDirectory);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Не удалось копировать");
                        }
                    }
                }
            }
            else
            {
                try { file.Copy(currentDirectory); }
                catch
                {
                    DialogResult result = MessageBox.Show("Файл с таким именем уже существует в папке." + '\n' + "Заменить его?", "Не удалось вставить файл", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            file.Replace(currentDirectory);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось перенести");
                        }
                    }
                }
                try
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(changingFile);
                }
                catch (Exception ex) { }
                try
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(changingFile, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents);
                }
                catch(Exception ex) { }
                changingFile = "";
            }
            DisplayFiles(currentDirectory);
        }
        private void CutOut_Click(object sender, EventArgs e)
        {
            changingFile = selectedFile;
            copyMode = false;
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            changingFile = selectedFile;
            copyMode = true;
        }
        private void Rename_Click(object sender, EventArgs e)
        {
            FilesService file;
            if (File.Exists(selectedFile))
                file = new FileService(selectedFile);
            else
                file = new FolderService(selectedFile);
            string newName = Interaction.InputBox("Введите имя", "Новое имя", Path.GetFileNameWithoutExtension(selectedFile));
            if (!file.Rename(newName)) MessageBox.Show("Имя уже существует");
            DisplayFiles(folderHistory[folderHistory.Count - 1]);
        }
        private void CreateFolder_Click(object sender, EventArgs e)
        {
            FolderService folder = new FolderService();
            string filePath = folder.CreateFolder(folderHistory[folderHistory.Count - 1]);
            CreateFile(filePath);
        }
        private void Sort_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem nameSortItem = new ToolStripMenuItem("Сортировать по названию");
            ToolStripMenuItem lastAccessTimeSortItem = new ToolStripMenuItem("Сортировать по дате последнего доступа");
            ToolStripMenuItem creationTime = new ToolStripMenuItem("Сортировать по дате создания");
            contextMenu.Items.AddRange(new ToolStripItem[]{
                nameSortItem,
                lastAccessTimeSortItem,
                creationTime
            });
            nameSortItem.Click += NameSortItem_Click;
            lastAccessTimeSortItem.Click += LastAccessTimeSortItem_Click;
            creationTime.Click += CreationTime_Click;
            button.ContextMenuStrip = contextMenu;
            button.ContextMenuStrip.Show(button, new Point(40, 30), ToolStripDropDownDirection.BelowRight);
        }

        private void CreationTime_Click(object sender, EventArgs e)
        {
            sortTipe = SortTipe.CreationTime;
            DisplayFiles(folderHistory[folderHistory.Count - 1]);
        }
        private void NameSortItem_Click(object sender, EventArgs e)
        {
            sortTipe = SortTipe.Name;
            DisplayFiles(folderHistory[folderHistory.Count - 1]);
        }
        private void LastAccessTimeSortItem_Click(object sender, EventArgs e)
        {
            sortTipe = SortTipe.LastAccessTime;
            DisplayFiles(folderHistory[folderHistory.Count - 1]);
        }

        private void FlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            panel.Click += Panel_Click;
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem createFolderItem = new ToolStripMenuItem("Создать папку");
            contextMenu.Items.Add(createFolderItem);
            contextMenu.SendToBack();
            panel.ContextMenuStrip = contextMenu;
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            selectedLabel.Text = "";
            selectedFile = "";
            AccessMenuButtons();
        } 
        private void FileManager_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(Delete, "Удалить");
            t.SetToolTip(Copy, "Копировать");
            t.SetToolTip(Put, "Вставить");
            t.SetToolTip(Sort, "Сортировать");
            t.SetToolTip(CutOut, "Вырезать");
        }
    }
}
