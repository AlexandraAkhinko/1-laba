using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class GEVDiskInfo
    {
        static public void DriverInfo()
        {
            Console.WriteLine("Information about disk");

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == "D:\\")
                {
                    Console.WriteLine("Disk name: " + drive.Name);
                    Console.WriteLine("File system: " + drive.DriveFormat);
                    Console.WriteLine("Volume Label: " + drive.VolumeLabel);
                    Console.WriteLine("Free disk space: " + drive.TotalFreeSpace);
                    Console.WriteLine("Total size: " + drive.TotalSize);
                    Console.WriteLine("Available: " + drive.AvailableFreeSpace);
                    Console.WriteLine();
                }
            }

            GEVLog.WriteLog("use DriverInfo");
        }
    }
}


//        2. Создать класс XXXDiskInfo c методами для вывода информации о
//            a.свободном месте на диске
//            b. Файловой системе
//            c.Для каждого существующего диска - имя, объем, доступный
//            объем, метка тома.
//            d.Продемонстрируйте работу класса