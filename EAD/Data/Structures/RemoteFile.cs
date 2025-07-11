using EAD.Interfaces;
using System.IO;

namespace EAD.Data.Structures
{
    public struct RemoteFile : IValidable
    {
        public RemoteFile(string path)
        {
            Name = System.IO.Path.GetFileName(path);
            Path = path;
        }

        public RemoteFile(string path, string name)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Path)
                && File.Exists(Path);
        }
    }
}