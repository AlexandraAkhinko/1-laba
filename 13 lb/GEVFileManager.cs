using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class GEVFileManager
    {
        static public void FirstManager(string path)
        {
            DirectoryInfo dir1 = new DirectoryInfo(path + "GEVInspect");
            DirectoryInfo dir2 = new DirectoryInfo(path);
            dir1.Create();
            StreamWriter sw = new StreamWriter(path + "/GEVInspect/GEVDirInfo.txt");
            sw.WriteLine("Number of directories: " + dir2.GetDirectories().Length);
            sw.WriteLine("Number of files: " + dir2.GetFiles().Length);
            sw.Close();
            FileInfo file = new FileInfo(path + "/GEVInspect/GEVDirInfo.txt");
            file.CopyTo(path + "/GEVInspect/GEVSecondDirInfo.txt", true);
            file.Delete();

            Console.WriteLine("Operation completed");
            GEVLog.WriteLog("use FirstManager");
        }

        static public void SecondManager(string path)
        {
            DirectoryInfo dir1 = new DirectoryInfo(path + "GEVFiles");
            dir1.Create();
            DirectoryInfo dir2 = new DirectoryInfo("G:\\textFiles");
            foreach (FileInfo file in dir2.GetFiles())
            {
                if (file.Extension == ".txt")
                {
                    file.CopyTo(path + "GEVFiles\\" + file.Name);
                }
            }
            dir1.MoveTo("G:\\GEVInspect\\GEVFiles");
            Console.WriteLine("Operation completed");
            GEVLog.WriteLog("use SecondManager");

        }
    }
}


//        5. Создать класс XXXFileManager.Набор методов определите
//        самостоятельно. С его помощью выполнить следующие действия:
//            a.Прочитать список файлов и папок заданного диска.Создать
//            директорий XXXInspect, создать текстовый файл
//            xxxdirinfo.txt и сохранить туда информацию.Создать
//            копию файла и переименовать его. Удалить
//            первоначальный файл.
//            b.Создать еще один директорий XXXFiles.Скопировать в
//            него все файлы с заданным расширением из заданного
//            пользователем директория. Переместить XXXFiles в
//            XXXInspect.
//            c.Сделайте архив из файлов директория XXXFiles.
//            Разархивируйте его в другой директорий.