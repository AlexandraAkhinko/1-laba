using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace lr_12
{
    class Program
    {
        interface IConf
        {
            void info(string str);
        }

        interface IConfiction
        {
            string size { get; set; }
            string color { get; set; }
            string calories { get; set; }
            string components { get; set; }

            void info();
        }

        abstract class Confiction : IConf, IConfiction
        {
            public string size { get; set; }
            public string color { get; set; }
            public string calories { get; set; }
            public string components { get; set; }
            public bool glaze { get; set; }

            public int one = 0;
            

            void info()
            {
                if (glaze)
                {
                    Console.WriteLine("Изделие глазированное");
                }
                else
                {
                    Console.WriteLine("Изделие неглазированное");
                }
            }

            void IConfiction.info()
            {
                throw new NotImplementedException();
            }

            public void info(string str)
            {
                Console.WriteLine(str);
            }

            public virtual void Add()
            {
                Console.WriteLine("Размер конфеты: ");
                size = Console.ReadLine();
                Console.WriteLine("Цвет конфеты: ");
                color = Console.ReadLine();
                Console.WriteLine("Калорийность конфеты: ");
                calories = Console.ReadLine();
                Console.WriteLine("Состав конфеты: ");
                components = Console.ReadLine();
                Console.WriteLine("Глазированная/неглазированная конфета: ");
                string s = Console.ReadLine();
                if (s == "y" || s == "Y")
                {
                    glaze = true;
                }
            } 
           
            public virtual void Type()
            {
                Console.WriteLine("Кондитерские изделия");
            }
            
            public Confiction()
            {
                size = "null";
                color = "null";
                calories = "null";
                components = "null";
                glaze = false;
            }

            public string Str(string str)
            {
                return str;
            }
        }

        class Candy : Confiction
        {
            string f { get; set; }

            public override void Type()
            {
                Console.WriteLine("Конфета");
            }
        }

        class Reflector
        {
            public static void AllInfo(object o)
            {
                StreamWriter sw = new StreamWriter(@"file.txt");
                Type t = o.GetType();
                sw.WriteLine("Информация о классе");
                sw.WriteLine("Full name = " + t.FullName);
                sw.WriteLine("Base type = " + t.BaseType);
                sw.WriteLine("Is saled = " + t.IsSealed);
                sw.WriteLine("Is class = " + t.IsClass);

                foreach (Type i in t.GetInterfaces())
                {
                    sw.WriteLine(i.Name);
                }

                foreach (FieldInfo f in t.GetFields())
                {
                    sw.WriteLine("Filed = " + f.Name);
                }

                sw.Close();

            }

            public static void MethodInfo(object o)
            {
                Type t = o.GetType();

                Console.WriteLine('\n');

                foreach (MethodInfo f in t.GetMethods())
                {
                    Console.WriteLine("Method = " + f);
                }
            }
            
            public static void FieldInfo(object obj)
            {
                Type t = obj.GetType();

                Console.WriteLine('\n');

                foreach (FieldInfo f in t.GetFields())
                {
                    Console.WriteLine("Field = " + f.Name);
                }

                Console.WriteLine('\n');

                foreach (PropertyInfo p in t.GetProperties())
                {
                    Console.WriteLine("Property = " + p);
                }
            }
            
            public static void InterfaceInfo(object o)
            {
                Type t = o.GetType();

                Console.WriteLine('\n');

                foreach (Type i in t.GetInterfaces())
                {
                    Console.WriteLine("Interface = " + i.Name);
                }
            }
            
            public static void ParamsInfo(object o, string str)
            {
                Type t = o.GetType();

                Console.WriteLine('\n');

                foreach (MethodInfo f in t.GetMethods())
                {
                    foreach (ParameterInfo p in f.GetParameters())
                    {
                        if (p.Name.Contains(str))
                        {
                            Console.WriteLine(f.Name);
                        }
                    }
                }
            }

            public static void ParamsFromFile(object o, string str)
            {
                StreamReader sr = new StreamReader("file.txt");

                string param = sr.ReadLine();

                Type t = o.GetType();

                MethodInfo mt = t.GetMethod(str);

                object obj = Activator.CreateInstance(typeof(Candy));

                mt.Invoke(obj, new object[1] { param });
            }
        }

        static void Main(string[] args)
        {
            Candy conf = new Candy();

            Reflector.AllInfo(conf);
            Reflector.MethodInfo(conf);
            Reflector.FieldInfo(conf);
            Reflector.InterfaceInfo(conf);
            Reflector.ParamsInfo(conf, "str");
            Reflector.ParamsFromFile(conf, "Str");

            Console.ReadKey();
        }
    }
}
