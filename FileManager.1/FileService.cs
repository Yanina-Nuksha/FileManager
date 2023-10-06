using System;
using System.IO;
using System.Linq;

namespace FileManager._1
{
    public class FileService : FilesService
    {
        private string Extension;
        private string FilePathWithoutExtension;
        public FileService() { }
        public FileService(string path) : base(path)
        {
            Extension = Path.GetExtension(path);
            FilePathWithoutExtension = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path);
        }
        public string GetFileExtensionImg()
        {
            string fileExtension = Extension.ToUpper();
            string currentDirectiry = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            switch (fileExtension)
            {
                case ".MP3":
                case ".MP2":
                    return currentDirectiry + "\\Resources\\mp3.png";
                case ".EXE":
                    return currentDirectiry + "\\Resources\\exe.png";
                case ".MP4":
                    return currentDirectiry + "\\Resources\\mp4.png";
                case ".AVI":
                    return currentDirectiry + "\\Resources\\avi.png";
                case ".PDF":
                    return currentDirectiry + "\\Resources\\pdf.jpg";
                case ".DOC":
                    return currentDirectiry + "\\Resources\\doc.jpg";
                case ".DOCX":
                    return currentDirectiry + "\\Resources\\docx.png";
                case ".PNG":
                case ".JPG":
                case ".JPEG":
                    return currentDirectiry + "\\Resources\\images.png";
                case ".TXT":
                    return currentDirectiry + "\\Resources\\txt.jpg";
                default:
                    return currentDirectiry + "\\Resources\\folder_.jpg";
            }
        }
        public string GetSizeOfFile()
        {
            long size = new FileInfo(FilePath).Length;
            string[] suf = { "Байт", "КБ", "МБ", "ГБ" };
            if (size == 0)
                return "";
            int place = Convert.ToInt32(Math.Floor(Math.Log(size, 1024)));
            double num = Math.Round(size / Math.Pow(1024, place), 1);
            return (Math.Sign(size) * num).ToString() + " " + suf[place];
        }
        public override void Replace(string currentDirectory)
        {
            Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(FilePath, currentDirectory + "\\" + Name, true);
        }
        public override bool Copy(string currentDirectory)
        {
            string newPath = currentDirectory + "\\" + Name;
            try
            {
                if (newPath == FilePath)
                {
                    newPath = FilePathWithoutExtension + " — копия" + Extension;
                    string[] filesList = Directory.GetDirectories(currentDirectory).Concat(Directory.GetFiles(currentDirectory)).ToArray();
                    int version = 0;
                    foreach (string file in filesList)
                    {
                        string[] fileNameArr = Path.GetFileNameWithoutExtension(file).Split(' ');
                        if (fileNameArr.Length >= 3)
                        {
                            if (fileNameArr[fileNameArr.Length - 2] == "—" && fileNameArr.Last() == "копия")
                                newPath = FilePathWithoutExtension + " — копия (1)" + Extension;
                        }
                        if (fileNameArr.Length >= 4)
                            if (fileNameArr[fileNameArr.Length - 2] == "копия" && fileNameArr[fileNameArr.Length - 3] == "—" && fileNameArr.Last().Length >= 3)
                            {
                                if (fileNameArr.Last()[0] == '(' && fileNameArr.Last()[fileNameArr.Last().Length - 1] == ')' && fileNameArr.Last().Substring(1, fileNameArr.Last().Length - 2).All(char.IsDigit))
                                {
                                    int thisVersion = Convert.ToInt32(fileNameArr.Last().Substring(1, fileNameArr.Last().Length - 2));
                                    if (thisVersion > version) version = thisVersion;
                                }
                            }
                    }
                    if (version != 0) version++;
                    if (version > 1)
                        newPath = FilePathWithoutExtension.Substring(0, FilePathWithoutExtension.Length) + " — копия (" + version + ")" + Extension;
                }
                Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(FilePath, newPath, false);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public override bool Rename(string newName)
        {
            try
            {
                File.Move(FilePath, Path.GetDirectoryName(FilePath) + "\\" + newName + Extension);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"";
        }
    }
}
