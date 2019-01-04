using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    class Program
    {
        struct Client
        {
            public string name;
            public int age;
            public int koll;
            public void ClientleInfo()
            {
                Console.WriteLine($"Имя: {name} , Возраст: {age} , Количество : {koll}");
            }
        }
        enum Day
        {
            HB, NewYear, Cristsmas, Hallowen
        };
        public abstract class Product
        {
            public int Kol { get; set; }
            public int Price { get; set; }
            public string Foryou { get; set; }

            public Product(int kol, int price, string foru)
            {
                Kol = kol;
                Price = price;
                Foryou = foru;
            }
            public virtual void Info()
            {
                Console.WriteLine($"Количество: {Kol}");
                Console.WriteLine($"Цена: {Price} рублей");
                Console.WriteLine($"Для кого: {Foryou}");
            }

            public class Pastry : Product
            {
                public string Sostav { get; set; }
                public Pastry(int kol, int price, string foru, string sostav) : base(kol, price, foru)
                {
                    Sostav = sostav;
                }
                public override void Info()
                {
                    base.Info();
                    Console.WriteLine($"Состав : {Sostav}");
                    Console.WriteLine();
                }
                interface ITesto
                {
                    void Sostav();
                    void Info();
                }
                interface IMyka
                {
                    int Kol { get; set; }
                    int Price { get; set; }
                    string Foryou { get; set; }
                    void Sostav();
                    void Info();
                }
                public class Flower : Product
                {
                    public string Name { get; set; }
                    public string Color;
                    public bool Smell { get; set; }
                    public Flower(int kol, int price, string foru, string name, string color, bool smell) : base(kol, price, foru)
                    {
                        Name = name;
                        Color = color;
                        Smell = smell;
                    }

                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Название цветка: {Name}");
                        Console.WriteLine($"Цвет цветка: {Color}");
                        Console.WriteLine($"Запах: {Smell}");
                        Console.WriteLine();
                    }
                    public override bool Equals(object obj)
                    {
                        if (obj == null)
                            return false;
                        Flower flower = (Flower)obj;
                        return (this.Price == flower.Price);
                    }
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + Name + "," + Color + "," + Smell;
                    }
                    private string id = "312338382";
                    public int Value { get; set; } = 1;
                    public override int GetHashCode()
                    {
                        id = Foryou;
                        int hash = 322;
                        hash = string.IsNullOrEmpty(id) ? 0 : id.GetHashCode();
                        hash = (hash * 47) + Value.GetHashCode();
                        return hash;
                    }

                }
                public class Cake : Product
                {
                    public int X { get; set; }
                    public string Sostav { get; set; }
                    public Cake(int kol, int price, string foru, string sostav, int x) : base(kol, price, foru)
                    {
                        Sostav = sostav;
                        X = x;

                    }
                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Состав торта: {Sostav}");
                        Console.WriteLine($"Количество слоев: {X}");
                        Console.WriteLine();
                    }
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + X + "," + Sostav;
                    }
                }
                class Clock : Product
                {
                    public string Metall { get; set; }
                    public Clock(int kol, int price, string foru, string metall) : base(kol, price, foru)
                    {
                        Metall = metall;

                    }
                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Какой металл : {Metall}");
                        Console.WriteLine();
                    }
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + Metall;
                    }
                }
                class Sweet : Product
                {
                    string Sostav { get; set; }
                    public Sweet(int kol, int price, string foru, string sosta) : base(kol, price, foru)
                    {
                        Sostav = sosta;

                    }
                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Какие конфеты : {Sostav}");
                        Console.WriteLine();
                    }
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + Sostav;
                    }
                }
                sealed class Goods : Product, ITesto, IMyka
                {
                    public bool Food { get; set; }
                    public string Sostav { get; set; }
                    public Goods(int kol, int price, string foru, bool food, string sostav) : base(kol, price, foru)
                    {
                        Food = food;
                        Sostav = sostav;
                    }
                    void ITesto.Sostav()
                    {
                        Console.WriteLine("Шоколадные");
                        Console.WriteLine();
                    }
                    void IMyka.Sostav()
                    {
                        Console.WriteLine("Ванильные");
                        Console.WriteLine();
                    }

                    void Sostavv()
                    {
                        Console.WriteLine("Конфликт");
                    }


                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Еда: {Food}");
                        Console.WriteLine($"Состав : {Sostav}");
                        Console.WriteLine();
                    }
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + Food + "," + Sostav;
                    }
                }
                public class Toy : Product
                {
                    public string name { get; set; }
                    public string Foru { get; set; }
                    public int Price { get; set; }
                    public int Kol { get; set; }
                    public Toy(int kol, int price, string foru, string Name) : base(kol, price, foru)
                    {

                        Kol = kol;
                        Price = price;
                        Foru = foru;
                        name = Name;
                    }
                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine("Игрушка: " + name);
                    }
                    public class Podarok
                    {
                        public int Kol { get; set; }
                        public int Price { get; set; }
                        public string Foryou { get; set; }
                        public List<Toy> list = new List<Toy>();
                        public void AddToy(Toy toy)
                        {
                            list.Add(toy);
                        }
                        public void RemoveFromelst(int index)
                        {
                            list.RemoveAt(index);
                        }
                        public void Print()
                        {
                            foreach (Toy t in list)
                            {
                                Console.WriteLine("Количество игрушек: " + t.Kol + ",");
                                Console.WriteLine("Цена: " + t.Price + ".rub,");
                                Console.WriteLine("Для кого: " + t.Foryou);
                                Console.WriteLine("Игрушка: " + t.name);

                                Console.WriteLine();
                            }
                        }
                    }
                    public class Controller
                    {
                        public void PricePodarok(Podarok pod)
                        {
                            int UlPrice = 0;
                            foreach (Toy t in pod.list)
                            {
                                UlPrice += t.Price * t.Kol;
                            }
                            Console.WriteLine("Стоимость подарка :" + UlPrice + ".rub");
                        }
                        public void Sorting(Podarok pod)
                        {
                            pod.list.Sort((Toy t1, Toy t2) => t1.Price.CompareTo(t2.Price));

                        }
                    }
                    class Printer
                    {
                        public virtual void iAmPrinting(Product G)
                        {
                            Console.WriteLine(G.GetType().ToString());
                        }
                    }
                
                //Создать иерархию классов исключений
                    public class Ex1 : Exception//1 класс исключений
                    {
                        public Ex1(string message) : base(message) { }

                        public class Ex2 : Ex1
                        {
                            public Ex2(string message) : base(message) { }
                        }
                        public class Ex3 : Ex1
                        {
                            public Ex3(string message) : base(message) { }
                        }
                    }
                    /////////////////////////////////////////////
                    public class Ball : Exception//2 класс исключений
                    {
                        public Ball(string message) : base(message) { }
                    }
                    ///////////////1 исключительная ситуация
                    static int balls(int _balls)
                        {
                            _balls = _balls / 0;
                          return Convert.ToInt32(_balls);
                        }
                    public class Ball1 : Exception//3 класс исключений
                    {
                        public Ball1(string message) : base(message) { }
                    }

                    ///////////////2 исключительная ситуация
                    static int ball1s(int _ball1s)
                    {
                        int[] _bal =new[]{ 1,2,3,4};
                        return (_bal[_ball1s]);
                    }
                    public class Ball2 : Exception// класс исключений
                    {
                        public Ball2(string message) : base(message) { }
                    }

                    ///////////////3 исключительная ситуация
                     static int ball2s(int kol)
                    {
                        if(kol<0)
                        {
                            Ball2 _kol = new Ball2("");
                            throw _kol;
                        }
                        return kol;
                    }
                    public class Ball3 : Exception// класс исключений
                    {
                        public Ball3(string message) : base(message) { }
                    }

                    ///////////////4 исключительная ситуация

                    static int ball3s(string _ball3s)
                    {
                        if(_ball3s=="")
                        {
                            Ball3 _ball3 = new Ball3("");
                            throw _ball3;
                        }
                        return Convert.ToInt32(_ball3s);
                    }
                    public class Ball4 : Exception// класс исключений
                    {
                        public Ball4(string message) : base(message) { }
                    }
                    ///////////////5 исключительная ситуация


                    static int ball4s(int _age)
                    {
                        Client Luba;
                        Luba.age = _age;
                        if(Luba.age<18)
                        {
                            Ball4 _ball4 = new Ball4("");
                            throw _ball4;
                        }
                        return _age;
                    }



                    public static void Main(string[] args)
                    {
                       //////////////////////// Ball 0      
                        try
                        {
                            Console.Write("Введите число: ");
                            balls(int.Parse(Console.ReadLine()));
                        }
                       
                        catch(DivideByZeroException ex)///деление на 0
                       {
                          Console.WriteLine("DivideByZeroException");
                          Console.WriteLine($"Message : {ex.Message} ");
                          Console.WriteLine($"Source : {ex.Source}");
                          Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();

                        }
                        catch (FormatException ex)//обрабатывает некорректно введенное число
                        {
                            Console.WriteLine("FormatException");
                            Console.WriteLine($"Message : {ex.Message} ");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();

                        }
                        //// ------------------------------- BAll 1
                        try
                        {
                            Console.Write("Введите число: ");
                            ball1s(int.Parse(Console.ReadLine()));                         
                        }
                        catch (IndexOutOfRangeException ex) //// индекс вне диапазона
                        {
                            Console.WriteLine("Индекс выходит за пределы");
                            Console.WriteLine($"Message : {ex.Message} ");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();
                        }
                        catch (FormatException ex)//обрабатывает некорректно введенное число
                        {
                            Console.WriteLine("FormatException");
                            Console.WriteLine($"Message : {ex.Message} ");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();

                        }
                        /// --------------------------- BAll 2      
                        try
                        {
                            Console.Write("Введите стоимость: ");
                            ball2s(int.Parse(Console.ReadLine()));
                        }
                        catch (Ball2 ex)
                        {
                            Console.WriteLine($"Стоимость не может быть меньше 0");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();
                        }
                        catch (FormatException ex)//обрабатывает некорректно введенное число
                        {
                            Console.WriteLine("FormatException");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();

                        }
                        // --------------------------------- Ball 3
                        try
                        {
                            Console.Write("Введите строку: ");
                            ball3s(Console.ReadLine());

                        }
                        catch (Ball3 ex)
                        {
                            Console.WriteLine("Пустая строка");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();
                        }
                        // ----------------------------------  Ball 4     
                        try
                        {
                            Console.Write("Введите количеcтво  лет: ");
                            ball4s(int.Parse(Console.ReadLine()));
                        }
                        catch (Ball4 ex)
                        {
                            Console.WriteLine("Недостатоно лет для покупки алкоголя");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();
                        }
                        catch (FormatException ex)//обрабатывает некорректно введенное число
                        {
                            Console.WriteLine("FormatException");
                            Console.WriteLine($"Source : {ex.Source}");
                            Console.WriteLine($"TargetSite : {ex.TargetSite}");
                            Console.WriteLine();

                        }
                        finally
                        {
                            Console.WriteLine("Конец программы");
                        }
                        /// ASSERT
                        Console.WriteLine("Введите строку");
                        string str = Console.ReadLine();
                            Debug.Assert(str==null, "Ошибка!Строка не может быть пустой");
                    }
                }
            }
        }
    }
}
