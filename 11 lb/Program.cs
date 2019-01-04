using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_11
{
    class Program
    {
        public class Student
        {
            public static int tId = 0;

            int ID;
            public string name;
            public string secondName;
            public string surName;
            public int date;
            public int age;
            public int group;
            public string adress;
            public string faculty;
            private int course;
            const int year = 2018;


            public int Course
            {
                get; set;
            }

            public int getAge(int num)
            {

                return (year - num);
            }

            public Student(String name, String secondName, String surName, int date, String faculty, int course, int group, String adress) : this()
            {
                this.name = name;
                this.secondName = secondName;
                this.surName = surName;
                this.adress = adress;
                this.faculty = faculty;
                this.date = date;
                this.age = getAge(date);
                this.course = course;
                this.group = group;
            }

            public Student()
            {
                tId++;
                ID = tId * 852647;
            }



            public void info()
            {
                Console.WriteLine(ID);
                Console.WriteLine("{0} {1} {2}", name, secondName, surName);
                Console.WriteLine(date);
                Console.WriteLine(age);
                Console.WriteLine(adress);
                Console.WriteLine(faculty);
                Console.WriteLine(course);
            }
        }

            static void Main(string[] args)
        {
            #region Task 1
            Console.WriteLine("Task 1\n");

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.Write("Введите длину названия месяца: ");
            int n = int.Parse(Console.ReadLine());

            var selMonth = from m in months
                           where m.Length == n
                           select m;

            foreach (var i in selMonth)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            selMonth = from m in months
                       where m == "December" || m == "January" || m == "February" || m == "June" || m == "July" || m == "August"
                       select m;

            foreach (var i in selMonth)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            selMonth = from m in months
                       orderby m
                       select m;

            foreach (var i in selMonth)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            selMonth = from m in months
                       where m.Contains('u') && m.Length > 3
                       select m;

            foreach (var i in selMonth)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n");

            #endregion

            #region Task 2-3
            Console.WriteLine("Task 2-3\n");

            List<Student> students = new List<Student>();

            var yulya = new Student("Yulya", "Vladimirovna", "Buraya", 18, "FIT", 2, 3, "Bobruiskaya_25");
            var marina = new Student("Marina", "Olegovna", "Rogozik", 18, "TOV", 2, 2, "Bobruiskaya_25");
            var sasha = new Student("Sasha", "Alexandrovna", "Ahinko", 17, "FIT", 1, 3, "NeBobruiskaya_25");

            students.Add(yulya);
            students.Add(marina);
            students.Add(sasha);

            Console.WriteLine("Список студентов заданной специальности\n");

            var selStudent = from s in students
                             where s.faculty == "TOV"
                             select s;

            foreach (var i in selStudent)
            {
                i.info();
                Console.WriteLine();
            }

            Console.WriteLine("\nСписок студентов заданной учебной группы\n");

            selStudent = from s in students
                         where s.@group == 3
                         select s;

            foreach (var i in selStudent)
            {
                i.info();
                Console.WriteLine();
            }

            Console.WriteLine("\nСамый молодой студент\n");

            selStudent = from s in students
                         orderby s.age
                         select s;

            selStudent.First().info();

            Console.WriteLine("\nСписок студентов заданной группы упорядоченных по фамилии\n");

            selStudent = from s in students
                         where s.@group == 3
                         orderby s.surName
                         select s;

            foreach (var i in selStudent)
            {
                i.info();
                Console.WriteLine();
            }

            Console.WriteLine("\nПервый студент по заданному имени    \n");

            selStudent = from s in students
                         where s.name == "Sasha"
                         select s;

            selStudent.First().info();

            Console.WriteLine("\n");

            #endregion

            #region Task 4
            Console.WriteLine("Task 4\n");
            
            //проекция
            var names = from t in students select t.name; 

            foreach (string p in names)
                Console.WriteLine(p);

            Console.WriteLine();

            //min
            int[] number = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            var min = number.Min(); // минимальный возраст
            Console.WriteLine(min);

            Console.WriteLine();

            //группировка
            var studGroups = students.GroupBy(t => t.age).Select(g => new { Name = g.Key, Count = g.Count() });
            foreach (var group in studGroups)
                Console.WriteLine("{0} : {1}", group.Name, group.Count);

            Console.WriteLine();

            //кванторы
            bool result = students.All(t => t.age < 18); // true
            if (result)
                Console.WriteLine("У всех пользователей возраст больше 18");
            else
                Console.WriteLine("Есть пользователи с возрастом меньше 18");

            Console.WriteLine();

            //операторы Take и Skip
            int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            IEnumerable<int> first = numbers.Take(7);

            foreach (int t in first)
                Console.Write(t + " ");

            Console.WriteLine();

            IEnumerable<int> last = numbers.Skip(7);

            foreach (int t in last)
                Console.Write(t + " ");

            Console.WriteLine("\n");
                       
            #endregion

            #region Task 5
            Console.WriteLine("Task 5\n");

            Dictionary<string, int> faculties = new Dictionary<string, int>();
            Dictionary<string, string> wizards = new Dictionary<string, string>();

            faculties.Add("Hufflepuff", 9);
            faculties.Add("Ravenclaw", 8);
            faculties.Add("Gryffindor", 8);
            faculties.Add("Slytherin", 10);

            wizards.Add("Hufflepuff", "Cedric Diggory");
            wizards.Add("Gryffindor", "Ronald Weasley");

            var union = from f in faculties
                         join w in wizards on f.Key equals w.Key
                         orderby f.Value descending
                         select new { name = w.Value, faculty = f.Key, cours = f.Value };

            foreach (var i in union)
            {
                Console.WriteLine($"{i.name}: {i.faculty}, {i.cours}");
            }

            #endregion

            Console.ReadKey();

        }
    }
}
