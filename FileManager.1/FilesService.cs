using System.IO;

namespace FileManager._1
{
    public abstract class FilesService
    {
        public string Name { get; protected set; }
        public string FilePath { get; protected set; }
        public FilesService() { }
        public FilesService(string path)
        {
            FilePath = path;
            Name = Path.GetFileName(path);
        }
        public abstract bool Rename(string newName);
        public abstract void Replace(string newName);
        public abstract bool Copy(string newName);
        public override string ToString()
        {
            return $"Имя: {Name} \n\nПуть: {FilePath} \n\n";
        }
    }  
}
