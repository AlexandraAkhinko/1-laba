using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Определите переменные всех возможных примитивных типов С#  и проинициализируйте их. ");
            Console.WriteLine("____________________");
            Byte b = 1; // хранит целое число от 0 до 255 и занимает 1 байт
            Type bType = b.GetType();
            Console.WriteLine("Тип byte: {0}", bType);
            SByte sb = 2; //хранит целое число от -128 до 127 и занимает 1 байт
            Type sbType = sb.GetType();
            Console.WriteLine("Тип sbute: {0}", sbType);
            short s = 3; //хранит целое число от -32768 до 32767 и занимает 2 байта
            Type sType = s.GetType();
            Console.WriteLine("Тип short: {0}", sType);
            ushort us = 4; //хранит целое число от 0 до 65535 и занимает 2 байта
            Type usType = us.GetType();
            Console.WriteLine("Тип ushort: {0}", usType);
            int i = 5; //хранит целое число от -2147483648 до 2147483647 и занимает 4 байта
            Type iType = i.GetType();
            Console.WriteLine("Тип int: {0}", iType);
            uint ui = 6; //хранит целое число от 0 до 4294967295 и занимает 4 байта
            Type uiType = ui.GetType();
            Console.WriteLine("Тип uint: {0}", uiType);
            long l = 7; //хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт
            Type lType = l.GetType();
            Console.WriteLine("Тип long: {0}", lType);
            ulong ul = 8; //хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт
            Type ulType = ul.GetType();
            Console.WriteLine("Тип ulong: {0}", ulType);
            char c = 'a'; //хранит одиночный символ в кодировке Unicode и занимает 2 байта
            Type cType = c.GetType();
            Console.WriteLine("Тип char: {0}", cType);
            string str = "string"; //хранит набор символов Unicode
            Type strType = str.GetType();
            Console.WriteLine("Тип string: {0}", strType);
            object o = 9; // хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе и 8 байт на 64-разрядной платформе
            Type oType = o.GetType();
            Console.WriteLine("Тип object: {0}", oType);
            decimal d = 10;
            Type dType = d.GetType();
            Console.WriteLine("Тип decimal: {0}", dType);
            double dbl = 11; //хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта. 
            Type dblType = dbl.GetType();
            Console.WriteLine("Тип double: {0}", dblType);
            float f = 12; //хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта
            Type fType = f.GetType();
            Console.WriteLine("Тип float: {0}", fType);
            bool bo; //хранит значение true или false
            bo = false;
            Console.WriteLine("bo is " + bo);
            bo = true;
            Console.WriteLine("bo is now " + bo);
            Type boType = bo.GetType();
            Console.WriteLine("Тип bool: {0}", boType);

            Console.WriteLine("5 операций явного и 5 неявного приведения");

            long q = i;
            Type qType = q.GetType();
            Console.WriteLine("Тип int -> long : {0}", qType);//неявное приведение
            double w = f;
            Type wType = w.GetType();
            Console.WriteLine("Тип float -> double: {0}", wType);//неяв.
            long e = s;
            Type eType = e.GetType();
            Console.WriteLine("Тип short -> long: {0}", eType);//неяв.
            int r = s;
            Type rType = r.GetType();
            Console.WriteLine("Тип short -> int: {0}", rType);//неяв.
            short t = b;
            Type tType = t.GetType();
            Console.WriteLine("Тип byte -> short: {0}", tType);//неяв.
            int y = (int)s;
            Type yType = y.GetType();
            Console.WriteLine("Тип short -> int: {0}", yType);//явное преобразование
            double u = (double)f;
            Type uType = u.GetType();
            Console.WriteLine("Тип float -> double: {0}", uType);//яв.
            byte p = (byte)s;
            Type pType = p.GetType();
            Console.WriteLine("Тип short -> byte: {0}", pType);//яв.
            int a = (int)d;
            Type aType = a.GetType();
            Console.WriteLine("Тип decimal -> int: {0}", aType);//яв.
            object g = (object)f;
            Type gType = g.GetType();//яв.

            //упаковка и распаковка
            int box = 123;
            object ubox = box;//упаковка
            ubox = 123;
            double bbox = (int)ubox;//распаковка
            Console.WriteLine("\n Распаковка: "+bbox);

            //неявнотипизированная переменная
            var _int = 123;
            var _string = "hello";
            var arr = new[] {1,2,3};
            Console.WriteLine("\n неявнотипизированная переменная var int: " +_int);
            Console.WriteLine("\n неявнотипизированная переменная var string: " + _string);
            for(int ii=0; ii<3; ii++)
            {
                Console.WriteLine("\n неявнотипизированная переменная var arr: " + arr[ii]);
            }

            //Nullable

            Nullable<int> z1 = 5;
            int? z2 = null;
            Console.WriteLine("\n nullable:  " + z1.Value);//выводит значение z1
            //Console.WriteLine("\n " + z2.Value); выведет ошибку
            Console.WriteLine("\n " + z2.HasValue);//проверяет допустимое ли значение 

            Console.WriteLine("_________________Строки________________");
            Console.WriteLine("_Объявите строковые литералы. Сравните их. _");
            string s1 = "asdf";
            string s2 = "ASDF"; //юникод? 
            string s3 = "xx";
            Console.WriteLine(s1 == s2);
            Console.WriteLine("_Создайте три строки на основе String. Выполните:_");
            string s4 = String.Join(s1, s2, s3);//сцепление
            Console.WriteLine(s4);
            string s5 = String.Copy(s4); //копирование
            Console.WriteLine(s5);
            string s6 = s4.Substring(6, 4);//выделение подстроки
            Console.WriteLine(s6 + "\n");

            string s0 = "asd fgh,jkl";
            string[] s8 = s0.Split(' ', ',');  //разделение строки на слова
            foreach (string s9 in s8)
            {
                Console.WriteLine(s9);
            }
            string s10 = s0.Insert(2, "S"); // вставкa подстроки в заданную позицию
            Console.WriteLine(s10);
            string s11 = s0.Remove(3, 4);// удаление заданной подстроки
            Console.WriteLine(s11);
            Console.WriteLine("_Создайте пустую и null строку. Продемонстрируйте что можно выполнить с такими строками_");
            string q1 = "";
            string q2 = null;
            Console.WriteLine(q1 == q2);//сравнение
            Console.WriteLine("_Создайте строку на основе StringBuilder_");
            Console.WriteLine("_Удалите определенные позиции и добавьте новые символы в начало и конец строки_");
            StringBuilder myStr = new StringBuilder("my name is Tanya", 20);
            Console.WriteLine(myStr);
            myStr.Remove(11, 5);
            Console.WriteLine(myStr);
            myStr.Append("Lena");
            Console.WriteLine(myStr);
            myStr.Insert(0, "Hello, ");
            Console.WriteLine(myStr);


            Console.WriteLine("____________________Массивы_____________________");
            Console.WriteLine("_Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица)_");
            int[,] ms = new int[3, 3];
            Random ran = new Random();
            for (int h = 0; h < 3; h++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ms[h, j] = ran.Next(1, 9);
                    Console.Write("{0}\t", ms[h, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("_ Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива_");
            string[] ms2 = { "one", "two", "three", "four", "five", "six" };
            foreach (string x in ms2)
                Console.WriteLine(x);
            Console.WriteLine("длина: {0}", ms2.Length);
            Console.WriteLine("_ Поменяйте произвольный элемент (пользователь определяет позицию и значение). _");
            Console.Write("позиция: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("значение:");
            string cс = Console.ReadLine();
            ms2[z - 1] = cс;
            foreach (string x in ms2) Console.Write("{0} ", x);
            Console.WriteLine();
            Console.WriteLine("_Создайте ступечатый массив вещественных чисел с 3-мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно. _");
            double[][] ms3 = { new double[2], new double[3], new double[4] };
            Console.WriteLine("Введите значения ");
            for (int h = 0; h < 2; h++)
            {
                ms3[0][h] = Convert.ToDouble(Console.ReadLine());
            }
            for (int h = 0; h < 3; h++)
            {
                ms3[1][h] = Convert.ToDouble(Console.ReadLine());
            }
            for (int h = 0; h < 4; h++)
            {
                ms3[2][h] = Convert.ToDouble(Console.ReadLine());
            }
            foreach (double[] x in ms3)
            {
                foreach (float bb in x)
                { Console.Write("\t" + bb); }
                Console.WriteLine();
            }
            Console.WriteLine("_Создайте неявно типизированные переменные для хранения массива и строки_");
            var ms4 = new[] { 1, 2, 3, 4, 5, 6 };
            var ms5 = new[] { "Ghbdtn?", null, "bvh!" };
            foreach (var n in ms4)
                Console.Write(" " + n);
            Console.WriteLine();
            foreach (var m in ms5)
                Console.Write(" " + m);
            Console.WriteLine();
                Console.WriteLine("________________Кортежи_________________");
                Console.WriteLine("_Задайте кортеж из 5 элементов с типами int, string, char, string, ulong _");
                Console.WriteLine("_Сделайте именование его элементов_");

                (int first, string second, char three, string four, ulong five) tuple = ( 125, "home", 'k', "dog", 33);//задаем кортеж



                Console.WriteLine("_Выведите кортеж на консоль целиком и выборочно (1, 3, 4  элементы)_");
                Console.WriteLine(tuple);
                Console.WriteLine($"{tuple.Item1}, {tuple.three}, {tuple.four} ");//Item - имена по умолчанию
                Console.WriteLine("_Выполните распаковку кортежа в переменные_");
                (int one, string two, char three, string four, ulong five) = tuple;
                Console.WriteLine($"two :"+ two);
                Console.WriteLine("_Сравните два кортежа_");
                 var t1 = Tuple.Create(1, 3, 6, "qwe");
                var t2 = Tuple.Create(1, 3, 6, "qw");
                Console.WriteLine(t1.Equals(t2));
                Console.WriteLine("__");
                Console.WriteLine("____________ 5. __________");
                //Создайте локальную функцию в main и вызовите ее. Формальные параметры функции – массив целых и строка.
                //Функция должна вернуть кортеж, содержащий: максимальный и минимальный элементы массива, сумму элементов массива и первую букву строки . 
                var tuple3 = Get(new int[] { 3, 4, 5, 6, 1, 2 }, "");

            Console.ReadKey();
        }

            private static (int min, int max, int sum, string first) Get(int[] arr, string Str)
            {
                var result = (min : 100, max : 0, sum : 0, first : "");
                for(int i=0; i<arr.Length; i++ )
                {
                    if (result.min > arr[i]) //находим минимальный элемент 
                        result.min = arr[i];

                    if (result.max < arr[i])//находим максимальный элемент
                        result.max = arr[i];

                    result.sum += arr[i];//находим сумму элементов между min и max
                }
               Console.Write("Строка: "); string gg = Console.ReadLine();
                result.first = gg.Remove(1);
                Console.WriteLine(result);
                return result;
              

            
        }
    }
}
