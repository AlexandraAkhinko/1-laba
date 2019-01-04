/*Продукт, кондитерское изделие, Товар, Цветы,Торт, Часы, Конфеты*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5
{
    class Program
    {//В проекте должны быть абстрактные класс(ы)(шаблон для наследования)
        public abstract class Product//класс Продукт
        {
           public int Kol { get; set; }
            public int Price { get; set; }
            public string Foryou { get; set; }

            public Product(int kol, int price, string foru)//конструктор класса Продукт
            {
                Kol = kol;//количество
                Price = price;//цена
                Foryou = foru;//для кого
            }
            public virtual void Info()//виртуальный метод может быть переопределен в одном или нескольких производных классах.
            {
                Console.WriteLine($"Количество: {Kol}");
                Console.WriteLine($"Цена: {Price} рублей");
                Console.WriteLine($"Для кого: {Foryou}");
            }

            public class Pastry : Product//кондитерское изделие
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
                //в проекте должны быть интерфейсы(ссылочный тип, кот. определяет набор методов и свойств, но не реализует их)
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
                public class Flower : Product//цветы
                {
                    public string Name { get; set; }
                    public string Color;
                    public bool Smell { get; set; }
                    public Flower(int kol, int price, string foru, string name, string color, bool smell) : base(kol, price, foru)
                    {
                        Name = name;//имя
                        Color = color;//цвет
                        Smell = smell;//запах
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
                        return Price + ", " + Kol + ", " + Foryou+","+Name+","+Color+","+Smell;
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
                public class Cake : Product//торт
                {
                    public int X { get; set; }//кол-во слоёв
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
                class Clock : Product//часы
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
                        return Price + ", " + Kol + ", " + Foryou + "," + Metall ;
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
                //Сделайте один из классов герметизированным(бесплодным)(от него нельзя ничего наследовать)
                sealed class Goods : Product, ITesto, IMyka//товары
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
                         
                        Console.WriteLine();
                    }
                    void IMyka.Sostav()
                    {
                        Console.WriteLine("Ванильные");
                        Console.WriteLine();
                    }

                    void Sostavv()//метод
                    {
                        Console.WriteLine("Конфликт");
                    }

                    //добавьте в интерфейсы одноименные методы
                    public override void Info()
                    {
                        base.Info();
                        Console.WriteLine($"Еда: {Food}");
                        Console.WriteLine($"Состав : {Sostav}");
                        Console.WriteLine();
                    }
                    //во всех классах переопределить метод ToString, кот. выводит инф. о типе объекта и его текущих знаениях.
                    public override string ToString()
                    {
                        if (Foryou != " ")
                            return base.ToString();
                        return Price + ", " + Kol + ", " + Foryou + "," + Food+ "," + Sostav ;
                    }
                }
                //Создайте дополнительный класс Printer
                class Printer
                {//с полиморфным методом iAmPrinting
                    public virtual void iAmPrinting(Product G)//формальным параметром метода должна быть ссылка на абстрактный класс
                    {//В методе iAmPrinting определите тип объекта и вызовите ToString
                        Console.WriteLine(G.GetType().ToString());
                    }
                }




                static void Main(string[] args)
                {//Поработать с объектами через ссылки на абстрактные классы и интерфейсы
                    Pastry pastry = new Pastry(1, 50, "и М и Ж", "шоколадный");
                    pastry.Info();
                    Flower flower1 = new Flower(15, 30, "девушкам", "Розы", "Красные", true);//создаем объект класса Flower
                    flower1.Info();
                    Flower flower2 = new Flower(15, 50, "девушкам", "Лилии", "Белые", true);
                    flower2.Info();

                    flower1.Equals(flower2);
                    flower1.ToString();
                    flower2.GetHashCode();

                    Cake cake = new Cake(2, 100, "Для всех", "Ванильный", 3);
                    cake.Info();
                    Clock clock = new Clock(1, 150, "Для мужчины", "серебрянные");
                    clock.Info();
                    Sweet sweet = new Sweet(50, 7, "Для ребенка", "леденцы");
                    sweet.Info();

                    Goods goods = new Goods(5, 15, "для всех", false, "металл");
                    goods.Info();

                    Goods myka = new Goods(7, 25, "детям", true, "ваниль");
                    IMyka mykaa = myka as IMyka;
                    mykaa.Info();
                   mykaa.Sostav();

                    ITesto testo = new Goods(1, 100, "девушкам", false, "шоколадный");
                    testo.Info();
                    testo.Sostav();
                    //Создайте массив, содержащий ссылки на разнотипные объекты ваших классов, а также объект класса Printer и последовательно вызовите его метод iAmPrinting
                    Printer splinter = new Printer();
                    Product[] mas = { pastry, flower1, flower2, cake, sweet };
                    Console.WriteLine("Информация: ");
                    for (int i = 0; i < mas.Length; i++)
                        if (splinter is Printer)
                            splinter.iAmPrinting(mas[i]);


                }
            }
        }
    }
}
