using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using HW_Attributes;

namespace HW_1
{
    class Program
    {
        /// <summary>
        /// Метод для вывода коллекций
        /// </summary>
        static void Show(object collection)
        {
            object[] attributes = CheckForAttributes(collection);

            if (attributes != null)
            {
                if (collection is List<Person>)
                {
                    foreach (Person item in collection as List<Person>)
                    {
                        Console.WriteLine(ChangeSign(item.ToString(), (attributes[0] as SecretAttribute).SecretSymbol));
                    }
                }

                if (collection is List<SomeonesCar>)
                {
                    foreach (SomeonesCar item in collection as List<SomeonesCar>)
                    {
                        Console.WriteLine("Владелец: " + ChangeSign(item.Owner.ToString(), (attributes[0] as SecretAttribute).SecretSymbol) + item.ToString());
                    }
                }
            }
            else
            {
                if (collection is List<Car>)
                {
                    foreach (Car item in collection as List<Car>)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Метод, возвращающий атрибуты
        /// </summary>
        /// <param name="collection"></param>
        static object[] CheckForAttributes(object collection)
        {
            object[] attributes = null;

            if (collection is List<Person>)
            {
                foreach (Person item in collection as List<Person>)
                {
                    return attributes = item.GetType().GetCustomAttributes(typeof(SecretAttribute), false);
                }
            }

            if (collection is List<Car>)
            {
                return null;
            }

            if (collection is List<SomeonesCar>)
            {
                foreach (SomeonesCar item in collection as List<SomeonesCar>)
                {
                    attributes = item.Owner.GetType().GetCustomAttributes(typeof(SecretAttribute), false);
                    return attributes;
                }
            }

            return null;
        }

        /// <summary>
        /// Метод для смены знака
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        static StringBuilder ChangeSign(string str, string sign)
        {
            StringBuilder tmp = new StringBuilder(str.ToString());
            for (int i = 0; i < tmp.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(tmp[i].ToString()) == true) continue;
                else
                {
                    tmp[i] = char.Parse(tmp[i].ToString().Replace(tmp[i], char.Parse(sign)));
                }
            }
            return tmp;
        }

        static void Main(string[] args)
        {
            // Потенциальные автовладельцы
            List<Person> people = new List<Person>
            {
                new Person("Иван", "Иванов", 1959),
                new Person("Анатолий", "Дятлов", 1971),
                new Person("Василий", "Ваисльев", 1981)
            };

            Console.WriteLine(people.GetType().Attributes);

            // Три автомобиля разной марки
            List<Car> cars = new List<Car>
            {
                new Car("Жигули", 1600, 900),
                new Car("Волга", 2300, 1200),
                new Car("Лада", 1800, 2500)
            };

            // Список автомобилей с владельцами 
            List<SomeonesCar> someonesCars = new List<SomeonesCar>
            {
                new SomeonesCar(people[0], cars[0], 1996, "синем"),
                new SomeonesCar(people[1], cars[1], 2017, "красном"),
                new SomeonesCar(people[2], cars[2], 2008, "сером"),
            };

            // Вывести информацию из этих массивов с помощью метода Show
            Show(people);
            Show(cars);
            Show(someonesCars);

            try
            {
                // Коллекцию  автовладельцев сериализовать в файл в бинарном формате
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("СarOwners.dat", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    binaryFormatter.Serialize(fileStream, people);
                }

                // Коллекцию автомобилей с владельцами сериализовать в файл в формате Xml (Марку машины и цвет сохранять как атрибуты элемента)
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SomeonesCar>));
                using (FileStream fileStream = new FileStream("SomeonesCars.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fileStream, someonesCars);
                }

                // Информацию об автомобилях красного цвета не старше 5 лет и не дороже 5000 сохранить в текстовый файл в формате csv
                using (StreamWriter streamWriter = new StreamWriter("CarOwners.txt", true, Encoding.Default))
                {
                    foreach (SomeonesCar item in someonesCars.Where(c => c.Color == "красном" && c.FindTheAgeOfTheCar() < 6 && c.Price < 5000))
                    {
                        streamWriter.WriteLine($"{item.Owner.Name};{item.Owner.Surname};{item.Owner.YearOfBirth};{item.Mark};{item.EngineCapacity};{item.Price};{item.YearOfIssue};{item.Color}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}