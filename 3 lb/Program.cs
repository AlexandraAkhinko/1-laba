/*Создать класс Customer: id, Фамилия, Имя , Отчество, Адрес, Номер кредитной карточки, баланс.
 Свойства и конструкторы должны обеспечивать проверку корректности. Добавить методы зачисления и списания сумм на счет.
 Создать массив объектов. Вывести:
 а) список покупателей в алфавитном порядке;
 б) список покупателей, у которых номерикредитной карточки находится в заданном интервале.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_3
{
    //сделайте класс partial
    public partial class Customer//вторая часть разделяемого класса
    {
        //поле константа
        public const int constant = 23;
        //поле только для чтения
        public readonly double K = 23;
    }

    public partial class Customer//первая часть разделяемого класса
    {
                static int numbers = 0;//статическое поле, хранит количество созданных объектов

        public int ID;
        private string surName; // фамилия
        public string name;//имя
        public string midle_name; // отчество
        public string address; //адрес
        public int card_num; // номер кредитки
        public double balance; // баланс

        //свойства get, set
        public string SurName
        {
            get//с помощью гет получают данные
            {
                return surName;
            }

            set// с помощью  сет записывают данные
            {
                surName = value;
            }
        }

        //Не менее 3 конструкторов(с параметрами и без, а также с параметрами по умолчанию)     
        public Customer()
        {
            numbers++;
            Console.WriteLine("конструктор 1  "+numbers);
        }
        public Customer(int id, string surNam, string nam, string mNam, string addr, int cNum, double balc)
        {
            ID = id;
            surName = surNam;
            name = nam;
            midle_name = mNam;
            address = addr;
            card_num = cNum;
            balance = balc;
            numbers++;
            Console.WriteLine("конструктор 2  " + numbers);
        }
        public Customer(int init) 
        {
            ID = 1;
            surName = "Pavlov";
            name = "Alexandr";
            midle_name = "Alexeyevich";
            address = "pr.Mira-13_123";
            card_num = 5609;
            balance = 475.6;
            numbers++;
        }
        //статический конструктор(конструктор типа)
        static Customer()
        {
            Console.WriteLine("Static class create.");
        }

        //определите закрытый конструктор; предложите вариатны его вызова
        private Customer(char aa)//закрытый метод, мы не можем его использовать или получить к нему доступ 
        {//можем получить к нему доступ внутри нашего класса Customer
           
        }
        

        public double Credit(ref double balanc_in, out double balanc_out)//метод, считающий сколькл средств стало на балансе после добавления
        {
          
            double i = balanc_in;
            double plus;
            Console.WriteLine("\nВведите количество зачисленных средств:");
            plus = Convert.ToDouble(Console.ReadLine());
            balanc_out = balanc_in + plus;
            
            return i;
        }
        public double Withdrawal(ref double balanc_in, out double balanc_out)//метод, считающий сколько средств осталось на балансе
        {
            double i = balanc_in;
            double minus;
            Console.WriteLine("\nВведите количество списанных средств:");
            minus = Convert.ToDouble(Console.ReadLine());
            balanc_out = balanc_in - minus;

            return i;
        }
        //статический метод
        public static void Info()//метод,выводящий номер объкта
        {
            Console.WriteLine("Number of objects: " + numbers);
        }
        /*
         *public override bool Equals(object obj)
{
if (obj == null)
return false;
Customer m = obj as Customer; // возвращает null если объект нельзя привести к типу Money 
if (m as Customer == null)
return false;
return m.A == this.a && m.B == this.b;
}*/
        
        public override string ToString()//здесь происходит переопределения строки с помощью модификатора override(требуется для расширения или изменения абстрактной или виртуальной реализации унаследованного метода)
        {
            return ("\nID: " + ID + "\nФамилия: " + SurName +
                "\nИмя: " + name + "\nОтчество: " + midle_name +
                "\nАдресс: " + address + "\nНомер кредитной карты: " + card_num + "\nБаланс: " + balance);
        }

        // Сортировка по фамилии

        public static void Sort_SurName(Customer[] arr)
        {
            Customer[] array2 = new Customer[arr.Length];

            string[] Sur_Name = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)//цикл , который присваивает значения SurNam массива arr массиву Sur_Name
            {
                Sur_Name[i] = arr[i].SurName;
            }

            Array.Sort(Sur_Name);// сортировка по фамилии с помощью метода Sort

            for (int i = 0; i < Sur_Name.Length; i++)// вывод отсортированных фамилий
            {
                Console.WriteLine(Sur_Name[i]);
            }

            for (int i = 0; i < Sur_Name.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].SurName == Sur_Name[i])//если элемент массива arr равен элементу массива Sur_Name
                    {
                        array2[i] = arr[j];// то присваиваем значение аrr[j] переменной array2[i]
                    }
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }

        }

        public static void Card_Num(Customer[] arr)// сортировка по номеру кредитной карты
        {
            Customer[] array2 = new Customer[arr.Length];

            string[] Sur_Name = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                Sur_Name[i] = arr[i].SurName;
            }

            Array.Sort(Sur_Name);

            for (int i = 0; i < Sur_Name.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].SurName == Sur_Name[i])
                    {
                        array2[i] = arr[j];
                    }
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                if ((array2[i].card_num > 4000) && (array2[i].card_num < 6000))// если сумма на карте больше 4000 и меньше 6000
                {
                    Console.WriteLine(array2[i]);
                }
            }
        }

    }

    public partial class Customer//третья часть разделяемого класса
    {
        public void InfoPartial()//метод, выводящий строку
        {
            Console.WriteLine("This is a partial class method.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer Alex = new Customer(1);// создание объекта типа Customer 
            
            double bal_in, bal_out;

            bal_in = Alex.balance;

            Alex.Credit(ref bal_in, out bal_out);// это метод, в котором параметры передаются по ссылке(ref передаёт только на инициализированную!!!)
            Console.WriteLine("\nOrigin balance: " + bal_in + "\nChanged balance: " + bal_out);

            Customer Oleg = new Customer(2, "Bulahov", "Oleg", "Dmitrievich", "st.Lenina-18_34", 3457, 641.5);// создание объекта с параметрами

            Oleg.Withdrawal(ref bal_in, out bal_out);
            Console.WriteLine("\nOrigin balance: " + bal_in + "\nWithdrawal balance: " + bal_out);

            Customer.Info();

            Oleg.InfoPartial();

            Console.WriteLine(Oleg);
            Console.WriteLine(Alex);

            // сравнение

            Customer Cust1 = new Customer();
            Cust1.name = "Ivan";
            Cust1.balance = 34;
            Customer Cust2 = new Customer();
            Cust2.name = "Ivan";
            Cust2.balance = 30;
            
            Console.WriteLine("\nUsing Equals: " + Cust1.Equals(Cust2));// сравнение
            Console.WriteLine("\n Тип объекта Gust1: " + Cust1.GetType());//вывод типа

            Customer.Info();

            Customer Max = new Customer();
            Max.ID = 3;
            Max.SurName = "Balinov";
            Max.name = "Maxim";
            Max.midle_name = "Vasilievich";
            Max.address = "st.Victory-4_52";
            Max.card_num = 4381;
            Max.balance = 821.3;

            Customer Veranica = new Customer(2, "Ilinskaya", "Veranika", "Glebovna", "pr.Independence-11_73", 8931, 911.4);

            Customer[] array = new Customer[4];
            array[0] = Alex;
            array[1] = Oleg;
            array[2] = Max;
            array[3] = Veranica;

            // Сортировка по фамилиям
            Console.WriteLine("\nСортировка по фамилиям: ");
            Customer.Sort_SurName(array);

            // список покупателей, у которых номер кредитной карточки находится в заданном интервале

            Console.WriteLine("\nсписок покупателей, у которых " + "\nномер кредитной карточки находится в заданном интервале");
            Customer.Card_Num(array);
            
            var Nik = new { SurName = "Pochkov" }; //создаем анонимный тип

            Console.WriteLine("\n Аннонимный объкт " + Nik.SurName); //вывод анонимного типа
            Console.ReadKey();
        }
    }
}

