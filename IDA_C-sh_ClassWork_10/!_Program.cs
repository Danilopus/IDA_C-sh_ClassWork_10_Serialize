// ClassWork template 1.2 // date: 29.09.2023

using Service;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;



// ClassWork 10 : [C sharp Serialisation, XML] 23.10.2023 --------------------------------

/// 
/*
System.Xml
System.Text.Json
*/

namespace IDA_C_sh_ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Class -> JSON
            Task_1();

            // Class -> XML
            // Task_2();

            // Practice XML
            //Task_3();

            // Practice JSON
            //Task_4();

            Console.ReadKey();

        }

        public static void Task_1() 
        {
            List<Person> employees = new List<Person>
            {
                new Person("Tom", 37, "Microsoft"),
                new Person("Bob", 48, "Google")
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                IgnoreReadOnlyFields = true
            };

            var data_to_json_string = JsonSerializer.Serialize(employees[0]);

            string path = Directory.GetCurrentDirectory() + "\\JSON_test.json";

            new FileStream(path, FileMode.OpenOrCreate).Close();
            StreamWriter streamWriter_1 = new StreamWriter(path);            
                streamWriter_1.WriteLine(data_to_json_string);
            streamWriter_1.Close();

            StreamReader streamReader_1 = new StreamReader(path);
            string read_result = streamReader_1.ReadToEnd();
            Console.WriteLine(read_result);

        }
        public static void Task_2() 
        {
            List<Person> for_XML_list = new List<Person>
            {
                new Person("Serg", 27, "Yandex"),
                new Person("Paul", 33, "Yahoo")
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            var file_stream_1 = new FileStream("XML_test.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(file_stream_1, for_XML_list[0]);


        }
       public static void Task_3() 
        {
            Console.WriteLine("\nXML DEMO\n\n");

            var order = new Order("monitor", 399, "mouse", 19, "hdd", 78);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Order));
            var file_stream_1 = new FileStream("XML_task_3.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(file_stream_1, order);
            file_stream_1.Close();

            string path = "XML_task_3.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            // получим корневой элемент
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    Console.Write(xnode.Name);
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                        Console.Write(childnode.InnerText);                    
                    Console.WriteLine();
                }
            }
        }

        public static void Task_4()
        {
            Console.WriteLine("\nJSON DEMO\n\n");

            var order = new Order("monitor", 399, "mouse", 19, "hdd", 78);
            var data_to_json_string = JsonSerializer.Serialize(order);

            new FileStream("JSON_task_4.xml", FileMode.OpenOrCreate).Close();
            using (StreamWriter streamWriter_1 = new StreamWriter("JSON_task_4.xml"))
            {
                streamWriter_1.WriteLine(data_to_json_string);
            }

            string read_result;
            StreamReader streamReader_1 = new StreamReader("JSON_task_4.xml");            
            read_result = streamReader_1.ReadToEnd();

            Console.WriteLine(read_result);

        }


} // class Programm

    public class Person
    {
        public string Name_ { get; set; }
        public int Age_ { get; set; }
        public string Company_ { get; set; }

        public Person(string Name, int Age, string Company)
        { Name_ = Name; Age_ = Age; Company_ = Company; }
        public Person() { }
    }

    public class Order
    {
        public string Good1_name_ { get; set; }
        public double Price1_ { get; set; }
        public string Good2_name_ { get; set; }
        public double Price2_ { get; set; }
        public string Good3_name_ { get; set; }
        public double Price3_ { get; set; }


        public Order(string name1, double price1, string name2, double price2, string name3, double price3)
        {
            Good1_name_ = name1; Price1_ = price1;
            Good2_name_= name2; Price2_ = price2;
            Good3_name_= name3; Price3_ = price3;
        }
        public Order() { }
    }
    public class order_list
    {
        public Order[] orders { get; set; } = new Order[100];
    }

}// namespace

