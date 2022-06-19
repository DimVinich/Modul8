using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Modul8
{
    class Program
    {
        static void Main(string[] args)
        {

            //PrintDrive();
            //GetCatalogs("C:\\");
            //CreateFolder();
            //CreateMoveToTrashFolder();



            static void PrintDrive()
            {
                // получим системные диски
                DriveInfo[] drives = DriveInfo.GetDrives();

                // Пробежимся по дискам и выведем их свойства
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"Название: {drive.Name}");
                    Console.WriteLine($"Тип: {drive.DriveType}");
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Объем: {drive.TotalSize}");
                        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                        Console.WriteLine($"Метка: {drive.VolumeLabel}");
                    }
                }
            }

            static void GetCatalogs(string aDrive)
            {
                string dirName = aDrive; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    Console.WriteLine("Папки:");
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                    foreach (string d in dirs) // Выведем их все
                        Console.WriteLine(d);

                    Console.WriteLine();
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                    foreach (string s in files)   // Выведем их все
                        Console.WriteLine(s);

                    Console.WriteLine("\n\n Всего файлов {0}  , всего папок {1}", files.Length, dirs.Length);
                }
            }

            static void CreateFolder()
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo("C:\\" /* Или С:\\ для Windows */ );
                    if (dirInfo.Exists)
                    {
                        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                    }

                    DirectoryInfo newDirectory = new DirectoryInfo("C:\\newDirectory");
                    if (!newDirectory.Exists)
                        newDirectory.Create();
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);

                    newDirectory.Delete(true);
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            static void CreateMoveToTrashFolder()
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\home10\Desktop");
                    DirectoryInfo newDirectory = new DirectoryInfo("C:\\Users\\home10\\Desktop\\NewFolder");
                    if (!newDirectory.Exists)
                        newDirectory.Create();
                    string trashFolder = @"C:\$Recycle.Bin";

                    newDirectory.MoveTo(trashFolder);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
