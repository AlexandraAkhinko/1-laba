using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr9
{
    class Program
    {
        public delegate void Doing();
        class Programist
        {
            public static Func<string, string> StrFunc; //возвращает результат действия
            public static Action<string> action; //является обобщенным, принимает параметры и возвращает значение void
            public string name;
            public int kurs;

            public event Doing Delete; //событие для удаления
            public event Doing Mytaciya;//событие для мутации
            public Programist(string Name, int Kurs)
            {
                name = Name;
                kurs = Kurs;
            }
            public void Del()
            {
                Console.WriteLine("Удаление");
                Delete?.Invoke();

            }
            public void Mytac()
            {
                Console.WriteLine("Мутирование");
                Mytaciya?.Invoke();
            }
            public void Myt()
            {
                name = "Игорь";
                if (name == "Игорь")
                    Console.WriteLine("Мутация прошла успешно");
                else
                    Console.WriteLine("Мутация не прошла ");

            }
            public void Delet()
            {
                name = null;
                kurs = 0;
                Console.WriteLine("Запись удалена");
            }
            public void Print()
            {
                Console.WriteLine("Имя: " + name);
                Console.WriteLine("Курс: " + kurs);
                Console.WriteLine("////////////////");

            }
            public static string AddToch(string str)//Добавляем точку
            {
                str += ".";
                return str;
            }
            public static void Out(string str)//выводим
            {
                Console.WriteLine(str);
            }
            public static string Zadanie1(string str)//меняем 
            {
                return str.Replace(" ", "_");
            }
            public static string Zadanie2(string str)//меняем 
            {
                return str.Replace(",", "-");
            }
            public static string Zaglavnaya(string str)//меняем на заглавную
            {
                return str.ToUpper();
            }
            public static void Upgrade(string str)
            {
                StrFunc = Zadanie2;
                string temp = StrFunc.Invoke(str);
                StrFunc += Zaglavnaya;
                temp = StrFunc.Invoke(temp);
                StrFunc += Zadanie1;
                temp = StrFunc.Invoke(temp);
                StrFunc += AddToch;
                temp = StrFunc.Invoke(temp);
                action = Out;
                action(str);

                Console.WriteLine(StrFunc(temp));
            }
        }
        static void Main(string[] args)
        {
            Programist ls1 = new Programist("Паша", 1);
            Programist ls2 = new Programist("вика", 3);
            Programist ls3 = new Programist("Семен", 2);

            ls1.Print();ls2.Print();ls3.Print();

            Console.WriteLine();
            ls1.Delete += new Doing(ls1.Delet);
            ls2.Delete += new Doing(ls1.Myt);
            ls1.Del();
            ls1.Mytac();

            ls2.Mytaciya += new Doing(ls2.Myt);
            ls2.Del();
            Console.WriteLine();
            ls1.Print(); ls2.Print(); ls3.Print();

            //string str = "fdgvfd,fdf,";
            //Console.WriteLine(Programist.AddToch(str));
            //Console.WriteLine(Programist.Zadanie2(str));
            //Console.WriteLine(Programist.Zaglavnaya(str));

            string str = "Лабораторная работа №9, по ООП";
            Programist.Upgrade(str);
        }
    }
}
