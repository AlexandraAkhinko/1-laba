using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    public partial class Part//разделяемый класс Часть 2
    {
        public int price = 15;
        public string ForU = "Unisex";

        public void Part2()
        {
            Console.WriteLine("Цена: " + price + " руб");
            Console.WriteLine("Для кого: " + ForU);

        }
    }
}
