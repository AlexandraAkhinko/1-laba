using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    public partial class Part//разделяемый класс Часть 1
    {
        public string name { get; set; } //название игрушки
        public string color { get; set; } //цвет
        public Part()
        {
            name= "Конструктор";
            color= "Разноцветный";
        }
        public void Part1()
        {
            Console.WriteLine("Наименование игрушки: " + name);
            Console.WriteLine("Цвет: " + color);

        }
    }
}
