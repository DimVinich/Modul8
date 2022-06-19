using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Modul8
{
    public class Drive
    {
        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }
        DriveType DriveType;

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder(name));
        }
    }

    public class Folder
    {
        public Folder(string name)
        {
            Name = name;
        }

        string Name { get; set; }
        List<string> Files { get; set; } = new List<string>();

        public void AddFile(string name)
        {
            if (!Files.Contains(name))
                Files.Add(name);
        }
    }

    enum DriveType
    {
        USB,
        HDD,
        CD
    }
}
