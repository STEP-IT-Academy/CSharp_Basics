using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Массив объектов класса Sportsman
            List<Sportsman> sportsmen = new List<Sportsman>();

            string[] dataFromFile;

            // •	Чтение из текстового файла в формате csv информации о спортсменах в массив объектов класса Sportsman.
            try
            {
                using (StreamReader sr = new StreamReader("Sportsmen.txt", Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        dataFromFile = sr.ReadLine().Split(';');
                        sportsmen.Add(new Sportsman { Surname = dataFromFile[0], Birthday = Convert.ToInt32(dataFromFile[1]), KindOfSport = dataFromFile[2], Rating = Convert.ToDouble(dataFromFile[3]) });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // •	Вывод информации в виде таблицы.
            Console.WriteLine("╔══════════════╦════════════════╦════════════════════════╦════════════════════╦════════════════════╗");
            Console.WriteLine("║      №       ║     Фамилия    ║       Год рождения     ║    Вид спорта      ║       Рейтинг      ║");
            Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╬════════════════════╣");

            int i = 1;
            foreach (Sportsman item in sportsmen)
            {
                Console.WriteLine($"║{i,14}║{item.Surname,16}║{item.Birthday,24}║{item.KindOfSport,20}║{item.Rating,20}║");
                if (i == sportsmen.Count)
                {
                    Console.WriteLine("╚══════════════╩════════════════╩════════════════════════╩════════════════════╩════════════════════╝");
                }
                else
                {
                    Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╬════════════════════╣");
                }
                i++;
            }

            // •	Сериализация информации о спортсменах, рейтинг которых превышает заданный, в файл в бинарном формате.
            double userRating = 5.5;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using (FileStream fs = new FileStream("Sportsmen.dat", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    binaryFormatter.Serialize(fs, sportsmen.Where(s => s.Rating > userRating).ToList());
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