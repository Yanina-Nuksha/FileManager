using System;
using System.IO;
using System.Linq;

namespace FileManager._1
{
    public class FolderService : FilesService
    {
        public FolderService() { }
        public FolderService(string path) : base(path) { }
        public override void Replace(string currentDirectory)
        {
            if (!(String.Concat(currentDirectory, "\\", Name) == FilePath))
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(FilePath, currentDirectory + "\\" + Name, true);
        }
        public override bool Copy(string currentDirectory)
        {
            try
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(currentDirectory + "\\" + Name);
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(FilePath, currentDirectory + "\\" + Name, false);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public override bool Rename(string newName)
        {
            try
            {
                Directory.Move(FilePath, Path.GetDirectoryName(FilePath) + "\\" + newName);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public string CreateFolder(string filePath)
        {
            int version = 0;
            foreach (string file in Directory.GetDirectories(filePath).Concat(Directory.GetFiles(filePath)).ToArray())
            {
                var startOfName = file.LastIndexOf("\\");
                var fileName = file.Substring(startOfName + 1, file.Length - (startOfName + 1));
                string[] fileNameArr = fileName.Split(' ');
                if (fileNameArr.Length == 3)
                    if (fileNameArr[0] == "Новая" && fileNameArr[1] == "папка" && fileNameArr[2].Length >= 3)
                    {
                        if (fileNameArr[2][0] == '(' && fileNameArr[2][fileNameArr[2].Length - 1] == ')' && fileNameArr[2].Substring(1, fileNameArr[2].Length - 2).All(char.IsDigit))
                        {
                            int thisVersion = Convert.ToInt32(fileNameArr[2].Substring(1, fileNameArr[2].Length - 2));
                            if (thisVersion > version) version = thisVersion;
                        }
                    }
            }
            if (version != 0) version++;
            if (version > 1)
            {
                Directory.CreateDirectory(filePath + "\\Новая папка (" + version + ")");
                return filePath + "\\Новая папка (" + version + ")";
            }
            else if (Directory.Exists(filePath + "\\Новая папка"))
            {
                Directory.CreateDirectory(filePath + "\\Новая папка (1)");
                return filePath + "\\Новая папка (1)";
            }
            else
                Directory.CreateDirectory(filePath + "\\Новая папка");
            return filePath + "\\Новая папка";
        }
        public override string ToString() 
        {
            return base.ToString() + $"";
        }
    }
}
