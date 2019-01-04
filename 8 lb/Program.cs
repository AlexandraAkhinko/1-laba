using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lr8
{
    interface Obobsh<T>// where T : class
    {
        void Add(T obj);
        void Remove(T obj);
        void Print();
    }
    public class Collection<T> : Obobsh<T> //where T : class //ограничение на ссылочный тип
    {
        private int cc = 0;
        List<T> list = new List<T>();
        public void Add(T obj)
        {
            list.Add(obj);
            cc++;
        }
        public void Remove(T obj)
        {
            list.Remove(obj);
        }
        public void Print()
        {
            foreach (T obj in list)
            {
                Console.WriteLine($"Просмотр = {obj}");
            }
        }

        public static void File(T obj)
        {
            string writePath = @"C:\Users\stsia\Desktop\универ\2 курс\3 семемтр\ООП\ЛР\lr8\shrek.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(obj);
            }
            string readPath = @"C:\Users\stsia\Desktop\универ\2 курс\3 семемтр\ООП\ЛР\lr8\shrek.txt";
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
    public class Exception1: Coll2
    {
        string str;
     public Exception1(object str)
        {
            if(str.GetType()!=typeof(string))
            {
                throw new Exception("Ошибка класса 1");
            }
            this.str =str.ToString();
        }
        public override string ToString()
        {
            return this.str.ToString();
        }
    }


    public class Exception2 : Coll2
    {
        int str;
        public Exception2(object str)
        {
            if(str.GetType()!=typeof(int))
            {
                throw new Exception("Ошибка класса 2");
            }
            this.str = (int)str;
        }
        public override string ToString()
        {
                return this.str.ToString();
            
        }
    }
    public class Coll2
    {

    }
        class Program
    {
        static void Main(string[] args)
        {
            Exception2 ls = new Exception2(123);
            Console.WriteLine(ls.GetType());
            Console.WriteLine(ls.ToString());

            Collection<int> i = new Collection<int>();
            i.Add(2);
            i.Add(3);
            i.Print();
            Collection<string> str = new Collection<string>();
            str.Add("hello");
            str.Print();
            i.Remove(2);
            Console.WriteLine();
            i.Print();
           /* try
            {
                Collection<Coll2> cl = new Collection<Coll2>();
                Exception1 ex1 = new Exception1("123");
                Exception2 ex2 = new Exception2(345);
                Exception1 ex3 = new Exception1("write");
                cl.Add(ex1);
                cl.Add(ex2);
                cl.Print();
                cl.Remove(ex1);
                cl.Print();
                Collection <Coll2>.File(ex3);
                  
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Зaвершение");
            }*/



        }
    }
}

