using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class Program
    {
        static void Main(string[] args)
        {
            GEVLog.ReadLog();
            Console.WriteLine(GEVLog.FindLog("DirInfo"));
            GEVLog.LongLog();
            GEVLog.LogForTheLastHours();
            GEVLog.ReadLog();
            GEVLog.LongLog();

            GEVFileInfo.FileInfo();

            GEVDirInfo.DirInfo();

            GEVDiskInfo.DriverInfo();

            GEVFileManager.FirstManager("G:\\");
            GEVFileManager.SecondManager("G:\\");

            Console.ReadKey();
        }
    }
}


//Каждый класс в данном проекте должен начинаться(Префикс) с ваших
//инициалов ФИО(AVF, JK,….).
