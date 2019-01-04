using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace lr_10
{
    class Student
    {
        string name;
        
        public Student(string n)
        {
            name = n;
        }
    }

    public class Confiction : IComparable, IComparer
    {
        public int Weight { get; set; }
        public string Candies { get; set; }
        
        public int CompareTo (object obj)
        {
            Confiction t = obj as Confiction;

            if (t != null)
                return this.Candies.CompareTo(t.Candies);
            else
                throw new Exception("Невозможно сравнить объекты");
        }

        public int Compare(object x, object y)
        {
            Confiction one = new Confiction();
            Confiction two = new Confiction();

            if (one.Candies.Length > two.Candies.Length)
                return 1;
            else if (one.Candies.Length < two.Candies.Length)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static public void ShowSweets(Dictionary<int, string> sweets)
        {
            foreach (KeyValuePair<int, string> keyValue in sweets)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.WriteLine();
        }


        private static void CollectionChangeMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Обработчик события");
        }


        static void Main(string[] args)
        {
            #region Task 1
            Console.Write("Task 1\n");

            ArrayList arr1 = new ArrayList();

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                arr1.Add(random.Next(50));
            }

            arr1.Add("string");

            Student student = new Student("");
            arr1.Add(student);

            Console.WriteLine("\nВывод коллекции: ");
            foreach (object o in arr1)
                Console.Write(o + "\t");
            Console.WriteLine();

            Console.Write("Номер элемента для удаления: ");
            int x = int.Parse(Console.ReadLine());
            arr1.RemoveAt(--x);

            Console.WriteLine("\nВывод коллекции после удаления элемента: ");
            foreach (object o in arr1)
                Console.WriteLine(o + "\t");

            Console.WriteLine("Количество элементов коллекции: " + arr1.Count);

            Console.Write("Найти элемент: ");
            x = int.Parse(Console.ReadLine());
            if (arr1.Contains(x))
            {
                Console.WriteLine("Элемент существует\n");
            }
            else
            {
                Console.WriteLine("Элемент не существует\n");
            }

            #endregion

            #region Task 2
            Console.WriteLine("Task 2");

            int length = 5;

            Dictionary<int, string> sweets = new Dictionary<int, string>();
            sweets.Add(1, "Chocolate");
            sweets.Add(2, "Candy");
            sweets.Add(3, "Caramel");
            sweets.Add(4, "Cookies");
            sweets.Add(5, "Cake");

            Console.WriteLine("\nВывод коллекции: ");
            ShowSweets(sweets);


            Stack<string> stack = new Stack<string>();

            foreach (KeyValuePair<int, string> i in sweets)
            {
                stack.Push(i.Value);
            }


            for (int keyValue = 2; keyValue < length; keyValue++)
            {
                sweets.Remove(keyValue);
            }

            Console.WriteLine("\nВывод коллекции после удаления элементов: ");
            ShowSweets(sweets);


            foreach (string i in stack)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Найти элемент: ");
            string str = Console.ReadLine();
            if (stack.Contains(str))
            {
                Console.WriteLine("Элемент существует");
            }
            else
            {
                Console.WriteLine("Элемент не существует");
            }

            #endregion

            #region Task 3
            Console.WriteLine("\nTask 3");

            Dictionary<int, Confiction> dict = new Dictionary<int, Confiction>();

            dict.Add(1, new Confiction { Candies = "Chamomile", Weight = 12 });
            dict.Add(2, new Confiction { Candies = "Cow", Weight = 12 });
            dict.Add(3, new Confiction { Candies = "Barberry", Weight = 12 });
            dict.Add(4, new Confiction { Candies = "Ladybug", Weight = 12 });
            dict.Add(5, new Confiction { Candies = "Chocolate_paws", Weight = 12 });

            Stack<String> stck = new Stack<String>();

            Console.WriteLine("\nВывод коллекции: ");
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine(dict[i].Candies + "  " + dict[i].Weight);
                stck.Push(dict[i].Candies);
            }

            Console.WriteLine("\nВывод коллекции: ");
            foreach (String i in stck)
            {
                Console.WriteLine(i);
            }

            for (int i = 2; i < length; i++)
            {
                stck.Pop();
            }

            Console.WriteLine("\nВывод коллекции после удаления элементов: ");
            foreach (String i in stck)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Найти элемент: ");
            string str1 = Console.ReadLine();
            if (stck.Contains(str1))
            {
                Console.WriteLine("Элемент существует");
            }
            else
            {
                Console.WriteLine("Элемент не существует");
            }

            #endregion

            #region Task 4
            Console.WriteLine("\nTask 4");

            ObservableCollection<Confiction> observableCollectionConfiction = new ObservableCollection<Confiction>();
            observableCollectionConfiction.CollectionChanged += CollectionChangeMethod;
            observableCollectionConfiction.Add(new Confiction { Candies = "A", Weight = 17 });
            observableCollectionConfiction.Add(new Confiction { Candies = "B", Weight = 11 });
            observableCollectionConfiction.Add(new Confiction { Candies = "C", Weight = 14 });
            observableCollectionConfiction.Add(new Confiction { Candies = "D", Weight = 10 });

            observableCollectionConfiction.RemoveAt(1);
            observableCollectionConfiction.RemoveAt(2);

            foreach (Confiction i in observableCollectionConfiction)
                Console.Write($"\n{i.Candies} {i.Weight}"); 

            #endregion

            Console.ReadKey();
        }
    }
}
