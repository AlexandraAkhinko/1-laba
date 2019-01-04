using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class GEVDirInfo
    {
        static string path = "G:\\2 курс\\ООП\\Labs\\lr_13";

        static DirectoryInfo dirInf = new DirectoryInfo(path);

        static public void DirInfo()
        {
            Console.WriteLine("Information about directory");
            Console.WriteLine("Number of files in the directory: " + dirInf.GetFiles().Length);
            Console.WriteLine("Time of creation: " + dirInf.CreationTime);
            Console.WriteLine("Number of subdirectories: " + dirInf.GetDirectories().Length);
            Console.WriteLine("Parent directory list: " + dirInf.Parent);
            Console.WriteLine();

            GEVLog.WriteLog("use DirInfo");
        }

        
    }
}


//        4. Создать класс XXXDirInfo c методами для вывода информации о конкретном
//        директории
//            a. Количестве файлов
//            b.Время создания
//            c.Количестве поддиректориев
//            d.Список родительских директориев
//            e. Продемонстрируйте работу класса