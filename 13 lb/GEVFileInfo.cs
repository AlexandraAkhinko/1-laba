using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class GEVFileInfo
    {
        static public void FileInfo()
        {
            string path = "G:\\BOOTEX.LOG";
            FileInfo fileInf = new FileInfo(path);
            Console.WriteLine("Information about file");

            if (fileInf.Exists)
            {
                Console.WriteLine("Full path: " + Path.GetFullPath(path));
                Console.WriteLine("File name: " + fileInf.Name);
                Console.WriteLine("File size: " + fileInf.Length);
                Console.WriteLine("File extension: " + fileInf.Extension);
                Console.WriteLine("Time of creation: " + fileInf.CreationTime);
                Console.WriteLine();
            }

            GEVLog.WriteLog("use FileInfo");
        }
    }
}


//        3. Создать класс XXXFileInfo c методами для вывода информации о
//        конкретном файле
//            a. Полный путь
//            b.Размер, расширение, имя
//            c. Время создания
//            d.Продемонстрируйте работу класса