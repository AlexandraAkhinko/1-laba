/*Собрать Подарок. Рассчитать цену подарка.
 Найти в подарке компонент с наименьшей массой.
 Произвести сортировку компонентов по габаритам.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr6
{
    class Program
    {//к имеющимся классам добавить структуру(могут хранить состояние в виде переменных и определять поведение в виде методов.)
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
        //к имеющимся классам добавить перечисление(набор логически связных констант, по умолчанию используется int, а так после имени следует тип перечисления(целочисленный))
        enum Day
        {
            HB,
            NewYear,
            Cristsmas,
            Hallowen
        }

        public abstract class Product//абстрактный класс(шаблон)
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
                } //интерфейсы(ссылочный тип, кот. определяет набор методов и свойств, но не реализует их)
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
                public class Toy : Product//игрушки
                {
                    public string name { get; set; }//наименование игрушки
                    public string Foru { get; set; }//для кого
                    public int Price { get; set; }//цена
                    public int Kol { get; set; }//количество
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

                    //Определить класс-Контейнер
                    public class Podarok
                    {
                        public int Kol { get; set; }
                        public int Price { get; set; }      
                        public string Foryou { get; set; }
                        public List<Toy> list = new List<Toy>();//создаем список, все элементы которого принадлежат Toy

                        public void AddToy(Toy toy)//добавляем элемент в список
                        {
                            list.Add(toy);
                        }

                        public void RemoveFromelst(int index)
                        {
                            list.RemoveAt(index);//удаление элемента по указанному индексу
                        }
                      
                        public void Print()
                        {
                            foreach (Toy t in list)
                            {
                                Console.WriteLine("Количество игрушек: "+t.Kol + ",");
                                Console.WriteLine("Цена: "+t.Price + ".rub,");
                                Console.WriteLine("Для кого: "+t.Foryou);
                                Console.WriteLine("Игрушка: " + t.name);
                                Console.WriteLine();
                            }
                        }                       
                    }
                    //Определить класс-Контроллер
                    public class Controller
                    {
                        public void PricePodarok(Podarok pod)
                        {
                            int UlPrice = 0;
                            foreach (Toy t in pod.list)
                            {
                                UlPrice += t.Price*t.Kol;
                            }
                            Console.WriteLine("Стоимость подарка :" + UlPrice + ".rub");
                        }
                        //Произвети сортировку компонентов по габаритам
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
                    static void Main(string[] args)
                    {
                        Client alex;
                        alex.name = "Люба";
                        alex.age = 19;
                        alex.koll = 1;
                        alex.ClientleInfo();
                        int lubaL = (int)Day.HB;
                        if (lubaL == 0)
                            Console.WriteLine($"{alex.name} купила {alex.koll} подарок на День  Рождение ");
                        Console.WriteLine();

                        Client dima;
                       dima.name = "Дима";
                        dima.age = 19;
                        dima.koll = 1;
                        dima.ClientleInfo();
                        int dimaD = (int)Day.HB;
                        if (dimaD == 0)
                            Console.WriteLine($"{dima.name} купил {dima.koll} подарок на Рождество ");
                        Console.WriteLine();

                        /////////////////Один из классов сделайте pertial и разместите его в разных файлах.
                        Part podarok = new Part();
                         podarok.Part1();
                         podarok.Part2();
                        /////////////////

                        Console.WriteLine();
                        Podarok listpod = new Podarok();
                        Console.WriteLine("Какое количество подарков?");
                        int _koll = int.Parse(Console.ReadLine());
                        for (int i = 0; i < _koll; i++)
                        {
                            Console.WriteLine("Введите количество игрушек");
                            int Kol = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите стоимость игрушки");
                            int Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите для кого игрушка");
                            string Foru = Console.ReadLine();
                            Console.WriteLine("Введите название игрушки");
                            string name = Console.ReadLine();
                            Toy toy = new Toy(Kol, Price, Foru, name);
                            listpod.AddToy(toy);
                            Console.WriteLine();
                        }
                      
                        Console.WriteLine("Подарок: ");
                        listpod.Print();

                        Controller controller = new Controller();
                        controller.PricePodarok(listpod);
                        Console.WriteLine();

                        Console.WriteLine("Сортировка по цене: ");
                        controller.Sorting(listpod);
                        listpod.Print();

                        Console.WriteLine();
                       
                        try
                        {
                            Console.WriteLine("Введите индекс объекта для удаления");
                            int obj = int.Parse(Console.ReadLine());
                            listpod.RemoveFromelst(obj);
                         
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("Индекс выходит за пределы");
                          
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"{ ex.Message}");
                        }
                        try
                        {

                            Console.WriteLine("Подсчет среднего");
                            int result = listpod.Kol / 0;
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine("Деление на 0");
                            Console.WriteLine($"{ ex.Message}");

                        }
                    }
                }
            }
        }
    }
}
