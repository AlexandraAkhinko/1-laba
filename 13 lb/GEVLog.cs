using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr_13
{
    class GEVLog
    {
        static string path = "Log.txt";
               
        static public void WriteLog(string text, bool bl = true)
        {
            StreamWriter sw = new StreamWriter(path, bl);
            sw.WriteLine(DateTime.Now + " : " + text);
            sw.Close();
        }

        static public void ReadLog()
        {
            StreamReader sr = new StreamReader(path);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

        static public string FindLog(string date)
        {
            string str = " ";

            foreach (string s in File.ReadLines(path))
            {
                if (s.Contains(date))
                {
                    str += s + "\n";
                }
            }

            return str;
        }

        static public void LongLog()
        {
            int i = 0;
            foreach (string s in File.ReadLines(path))
            {
                i++;
            }
            Console.WriteLine("File is written " + i + " logs");
        }

        static public void LogForTheLastHours()
        {
            Console.WriteLine("lll");
            string date = DateTime.Now.ToString("dd.MM.yyy") + " " + DateTime.Now.Hour;
            Console.WriteLine("\n" + date);

            string LFTLH = FindLog(date);

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(LFTLH);
            sw.Close();

        }
    }
}


//        1. Создать класс XXXLog.Он должен отвечать за работу с текстовым файлом
//        xxxlogfile.txt.в который записываются все действия пользователя и
//        соответственно методами записи в текстовый файл, чтения, поиска нужной
//        информации.
//            a.Используя данный класс выполните запись всех
//            последующих действиях пользователя с указанием действия,
//            детальной информации(имя файла, путь) и времени
//            (дата/время)