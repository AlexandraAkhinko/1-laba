/*Класс - однонаправленный список List. Дополнительно перегрузить следующие операции:+ - объединить два списка; -- - удалить элемент из начала(--list);
  = = - проверка на равенство; true - проверка пустой ли список. Методы расширения:
  1) Выделение последнего числа содержащегося в строке; 2) Удаление заданного элемента из списка.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лр4
{
    class Program
    {//Класс - однонаправленный список List.
        class List
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public List() { }
            public List(int x, int y, int z)//конструктор list
            {
                X = x;
                Y = y;
                Z = z;
            }
            public void Print()//метод выводящий значения наших x, y, z
            {
                Console.WriteLine($"Список: x={X},y={Y},z={Z}");
            }
            //Дополнительно перегрузить следующие операции:+ - объединить два списка;
            public static List operator +(List el, List el2)//перегрузка - переопределение оператора, чтоб он выполнял какие-то новые функции для нашего класса
            {
                int[] l = { el.X, el.Y, el.Z,el2.X, el2.Y, el2.Z };
                Console.Write("Слияние списков: ");
                for (int i = 0; i < l.Length; i++)
                    Console.Write(l[i] + " ");
                Console.WriteLine();
                return el;
            }
            //Дополнительно перегрузить следующие операции:-- - удалить элемент из начала(--list);
            public static List operator --(List el)
            {
                int[] l = { el.Y, el.Z };
                Console.Write("Строка без первого элемента: ");

                for (int i = 0; i < l.Length; i++)
                    Console.Write(l[i] + " ");
                Console.WriteLine();
                return el;

            }
            public override bool Equals(object obj)//сравниваем строки, если строка = 0, то false, ничего не произойдет
            {
                if (obj == null)
                    return false;
                List list = (List)obj;
                return (this.X == list.X);
            }
            //Дополнительно перегрузить следующие операции:= = - проверка на равенство;
            public static bool operator ==(List el, List el2)
            {                
                return el.Equals(el2);
            }
            public static bool operator !=(List el, List el2)//если сравниваем равно, то надо надо сравнить и не равно(!=)
            {               
                return !el.Equals(el2);
            }
            // Дополнительно перегрузить следующие операции:true - проверка пустой ли список.
            public static bool operator true(List el)
            {
                int[] l = { el.X, el.Y, el.Z };
                if (l == null)
                    return true;
                else
                    return false;
            }
            public static bool operator false(List el)
            {
                int[] l = { el.X, el.Y, el.Z };
                if (l != null)
                    return false;
                else return true;
            }
            //добавьте в свой класс вложенный объект Owner, который содержит Id.
            public class Owner
            {
                public string Id;
            }
            //добавьте в свой класс вложенный объект Date 
            public class Date
            {
               public int Years;
                public int Month;
               public int Day;
                public Date() { }
            }
        }
        //создайте статический класс содержащий 3 метода для работы с вашим классом:
        class Operation
        {//поиск максимального и минимального, подсчет кол-ва элементов
            public static List MINMAX(List el)
            {
                int min = 100, max = 0, kol =0;
                int[] l = { el.X, el.Y, el.Z };
                for(int i=0;i<l.Length;i++)
                {
                    if (l[i] > max)
                        max = l[i];
                }
                Console.WriteLine("максимальный элемент: "+max);
                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i] < min)
                        min = l[i];
                }
            Console.WriteLine("минимальный элемент: "+min);
           Console.WriteLine("Количесвто элементов: " + l.Length + "\n");
                return el;

            }
            //выделение последнего элемента
            public static List Videlenie(List el)
               {
                int pos = 0;
                int[] l = { el.X, el.Y, el.Z };
                
                    pos =l[l.Length-1];
                Console.Write("Выделение последнего элемента: ");
                Console.WriteLine(pos);
                return el;
               }
            //удаление элемента
            public static List Ydalenie(List el, int index)
            {
                
                int[] l = { el.X, el.Y, el.Z };
                Console.Write("Список с удаление элемента по значению: ");

                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i] == index)
                        for (int j = i; j < 2 ; j++)
                        {
                            l[j] = l[j + 1];
                            Console.Write(l[j]+  " ");
                        }                    
                }          
                return el ;
            }

        }
        
        static void Main(string[] args)
        {
            
            List ls = new List(1,2,3);
            ls.Print();
            List ls2 = new List(8, 5, 9);
            ls2.Print();
            Console.WriteLine();
            List ls3 = new List(20,5,39);
            ls3.Print();
            Console.WriteLine();

            Console.WriteLine(ls + ls2+"\n");
            Console.WriteLine(--ls + "\n");
            Console.WriteLine($"Списки равны: { ls == ls2}");
            Console.WriteLine($"Списки не равны: { ls != ls2}" + "\n");

            if (ls)
                Console.WriteLine("Список: ");
            ls.Print();
            Console.WriteLine();

            Console.WriteLine(Operation.Ydalenie(ls, 1));
            Console.WriteLine();

            Console.WriteLine(Operation.Videlenie(ls2));
            Console.WriteLine();
            Console.WriteLine(Operation.MINMAX(ls3));
            Console.WriteLine();

            //инициализируем Owner 
            List.Owner Tom = new List.Owner();//создаем объект вложенного класса Owner
            Tom.Id = "Олег Верещагин";
            Console.WriteLine("Создатель: "+Tom.Id);
            //инициализируем Date
            List.Date day = new List.Date();
            day.Years = 2018;
            day.Month = 11;
            day.Day = 8;
            Console.WriteLine($"Дата создания: {day.Day}.{day.Month}.{day.Years}");



        }
    }
}
