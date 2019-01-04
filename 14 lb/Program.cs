using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace lr_14
{
    interface IConf
    {
        void info();
    }

    interface IConfiction
    {
        string color { get; set; }
        string components { get; set; }

        void info();

    }

    [Serializable]
    public abstract class Confiction : IConf, IConfiction
    {
        public string color { get; set; }
        public string components { get; set; }

        void IConf.info()
        {

        }

        void IConfiction.info()
        {
            Console.WriteLine(components);
        }

        public void info(string str)
        {
            Console.WriteLine(str);
        }

        public virtual void addInfo()
        {
            Console.WriteLine("Введите цвет конфеты");
            color = Console.ReadLine();
            Console.WriteLine("Введите состав конфеты");
            components = Console.ReadLine();
        }

        public virtual void Type()
        {
            Console.WriteLine("Кондитерские изделия");
        }

        public Confiction()
        {
            color = "null";
            components = "null";
        }
    }
    
    [Serializable]
    public class Candy : Confiction
    {
        string forms { get; set; }

        public override void Type()
        {
            Console.WriteLine("Конфета");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Candy candy = new Candy();
            Candy candy2 = new Candy();
            Candy[] sweets = new Candy[] { candy, candy2 };

            candy.addInfo();
            candy2.addInfo();

            BinarySerialize(candy);
            BinaryDesirialaize();
            SOAPSerialize(candy);
            SOAPDeserialize();
            XMLSerialize(candy);
            XMLDeserialize();
            JSONSerialize(candy);
            JSONDeserialize();
            JSONArraySerialize(sweets);
            JSONArrayDeserialize();
            XMLArraySerialize(sweets);
            XMLArrayDeserialize();
            XPath();
            XmlLinq();

            Console.ReadKey();
        }

        static public void BinarySerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("candy.dat", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, obj);

                Console.WriteLine("Сериализация binary завершена");

            }
        }

        static public void BinaryDesirialaize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("candy.dat", FileMode.OpenOrCreate))
            {
                Candy candy = (Candy)formatter.Deserialize(fs);
                
                Console.Write("Объект десериализован ");
                candy.Type();
            }
        }

        static public void SOAPSerialize(object obj)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("candy.soap", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, obj);

                Console.WriteLine("Сериализация SOAP завершена");

            }
        }

        static public void SOAPDeserialize()
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("candy.soap", FileMode.OpenOrCreate))
            {
                Candy candy = (Candy)formatter.Deserialize(fs);

                Console.Write("Объект десериализован ");
                candy.Type();
            }
        }

        static public void XMLSerialize(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Candy));

            using (FileStream fs = new FileStream("candy.xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);

                Console.WriteLine("Сериализация XML завершена");
            }
        }

        static public void XMLDeserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Candy));

            using (FileStream fs = new FileStream("candy.xml", FileMode.OpenOrCreate))
            {
                Candy candy = (Candy)serializer.Deserialize(fs);
                Console.Write("Объект десериализован ");
                candy.Type();
            }
        }

        static public void XMLArraySerialize(object[] obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Candy[]));

            using (FileStream fs = new FileStream("candyArray.xml", FileMode.Create))
            {
                serializer.Serialize(fs, obj);

                Console.WriteLine("Сериализация XML завершена");
            }
        }

        static public void XMLArrayDeserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Candy[]));

            using (FileStream fs = new FileStream("candyArray.xml", FileMode.OpenOrCreate))
            {
                Candy[] candy = (Candy[])serializer.Deserialize(fs);
                Console.WriteLine("Объект десериализован ");
                foreach (Candy c in candy)
                {
                    c.Type();
                }
            }
        }

        static public void JSONSerialize(object obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy));

            using (FileStream fs = new FileStream("candy.json", FileMode.Create))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Сериализация Json завершена");
            }
        }

        static public void JSONDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy));

            using (FileStream fs = new FileStream("candy.json", FileMode.OpenOrCreate))
            {
                Candy candy = (Candy)json.ReadObject(fs);
                Console.Write("Объект десериализован ");
                candy.Type();
            }
        }
        static public void JSONArraySerialize(object[] obj)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy[]));

            using (FileStream fs = new FileStream("candyArray.json", FileMode.Create))
            {
                json.WriteObject(fs, obj);
                Console.WriteLine("Сериализация Json завершена");
            }
        }

        static public void JSONArrayDeserialize()
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Candy[]));

            using (FileStream fs = new FileStream("candyArray.json", FileMode.OpenOrCreate))
            {
                Candy[] candy = (Candy[])json.ReadObject(fs);
                Console.WriteLine("Объект десериализован ");

                foreach (Candy c in candy)
                {
                    c.Type();
                }
            }
        }

        static public void XPath()
        {
            Console.WriteLine();

            XmlDocument Doc = new XmlDocument();
            Doc.Load("Xpath.xml");
            XmlElement Root = Doc.DocumentElement;

            XmlNodeList childnodes = Root.SelectNodes("user");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.SelectSingleNode("@name").Value);

            XmlNode childnode = Root.SelectSingleNode("user[company='Microsoft']");
            if (childnode != null)
                Console.WriteLine(childnode.SelectSingleNode("@name").Value);
        }

        static public void XmlLinq()
        {
            XDocument xdoc = new XDocument();

            XElement coffee = new XElement("drink");
            // создаем атрибут
            XAttribute coffeeAttribute = new XAttribute("size", "big");
            XElement capuccino = new XElement("price", "4");
            XElement latte = new XElement("company", "Cafe");
            // добавляем атрибут и элементы в первый элемент
            coffee.Add(coffeeAttribute);
            coffee.Add(capuccino);
            coffee.Add(latte);

            XElement tea = new XElement("drink");
            XAttribute teaAttribute = new XAttribute("size", "small");
            XElement greenTea = new XElement("price", "5");
            XElement blackTea = new XElement("company", "Сладкий Домик");
            tea.Add(teaAttribute);
            tea.Add(greenTea);
            tea.Add(blackTea);

            // создаем корневой элемент
            XElement drinks = new XElement("drinks");
            drinks.Add(coffee);
            drinks.Add(tea);

            xdoc.Add(drinks);
            xdoc.Save("LinqXml.xml");
            
            //запрос
            XDocument xmlDoc = XDocument.Load("LinqXml.xml");
            Console.WriteLine("\n\nLINQ to XML");
            foreach (XElement drinkElement in xmlDoc.Element("drinks").Elements("drink"))
            {
                XAttribute nameAttribute = drinkElement.Attribute("size");
                XElement price = drinkElement.Element("price");
                XElement company = drinkElement.Element("company");


                if (nameAttribute != null && price != null && company != null)
                {
                    Console.WriteLine("Размер напитка: {0}", nameAttribute.Value);
                    Console.WriteLine("Цена: {0}", price.Value);
                    Console.WriteLine("Кофейня: {0}", company.Value);
                }
                Console.WriteLine();
            }
        }

    }
}


//1. Из лабораторной №5 выберите класс с наследованием и/или
//композицией/агрегацией для сериализации.Выполните
//сериализацию/десериализацию объекта используя
//    a.бинарный,
//    b.SOAP,
//    c.JSON,
//    d.XML формат.

//2. Создайте коллекцию (массив) объектов и выполните
//сериализацию/десериализацию.

//3. Используя XPath напишите два селектора для вашего XML документа.

//4. Используя Linq to XML (или Linq to JSON) создайте новый xml(json) -
//документ и напишите несколько запросов.