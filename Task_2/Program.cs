using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Series> sourceSeries = new List<Series>()
            {
                new Series { Name = "Game of Thrones", ProducerSurname = "David Nutter", Genre = "Fantasy, Drama", NumberOfEpisodes = 80 },
                new Series{ Name = "Breaking bad", ProducerSurname = "Michelle MacLaren", Genre = "Thriller, Crime", NumberOfEpisodes = 62}
            };
            List<Series> seriesFromFile = new List<Series>();

            try
            {
                // Запись внесенной в таблицу информации о фильмах в структурированный файл c помощью класса BinaryWriter.
                WriteData(sourceSeries);

                FileInfo file = new FileInfo("Series.txt");

                // Для отслеживания изменений с файлом
                FileSystemWatcher fw = new FileSystemWatcher(@"C:\Users\kotka\source\repos\Task_2");
                fw.IncludeSubdirectories = true;

                // Если будет запись в него или изменен его размер
                fw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
                fw.Changed += new FileSystemEventHandler(OnChanged);
                fw.EnableRaisingEvents = true;


                // Считывание информации из файла c помощью класса BinaryReader  
                ReadData(seriesFromFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Вывод информации в виде таблицы  
            ShowInfo(seriesFromFile);

            // Изменение любой записи в таблице и сохранение измененной строки таблицы в соответствующем месте файла, осуществляя прямой доступ.
            // Допустим, что мы хотим изменить поле "ProducerSurname" у сериала "Игра престолов" c текущего на "Иванов"
            string newSurname = "Ivanov";
            newSurname = newSurname.PadRight(12);

            byte[] input = Encoding.Default.GetBytes(newSurname);
            try
            {
                using (FileStream fstream = File.OpenWrite("Series.txt"))
                {
                    // Зная структуру нашего файла, мы можем переместиться на нужную позицию
                    fstream.Seek(seriesFromFile[0].Name.Length + 3, SeekOrigin.Begin);

                    // И изменить запись
                    fstream.Write(input, 0, input.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Убеждаемся, что изменения были корректны
            seriesFromFile.Clear();

            try
            {
                ReadData(seriesFromFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ShowInfo(seriesFromFile);
            Console.ReadKey();
        }

        // Запись внесенной в таблицу информации о фильмах в структурированный файл c помощью класса BinaryWriter.
        static void WriteData(List<Series> series)
        {
            // Запись внесенной в таблицу информации о фильмах в структурированный файл c помощью класса BinaryWriter.
            using (BinaryWriter bw = new BinaryWriter(File.Open("Series.txt", FileMode.Create)))
            {
                foreach (Series item in series)
                {
                    bw.Write(item.Name);
                    bw.Write('\n');
                    bw.Write(item.ProducerSurname);
                    bw.Write('\n');
                    bw.Write(item.Genre);
                    bw.Write('\n');
                    bw.Write(item.NumberOfEpisodes);
                    bw.Write('\n');
                }
            }
        }

        // Считывание информации из файла c помощью класса BinaryReader  
        static void ReadData(List<Series> series)
        {
            using (BinaryReader br = new BinaryReader(File.Open("Series.txt", FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    string name = br.ReadString();
                    br.ReadByte();
                    string producerSurname = br.ReadString();
                    br.ReadByte();
                    string genre = br.ReadString();
                    br.ReadByte();
                    int numberOfEpisodes = br.ReadInt32();
                    br.ReadByte();
                    series.Add(new Series { Name = name, ProducerSurname = producerSurname, Genre = genre, NumberOfEpisodes = numberOfEpisodes });
                }
            }
        }

        // Вывод информации в виде таблицы  
        static void ShowInfo(List<Series> series)
        {
            Console.WriteLine("╔══════════════╦════════════════╦════════════════════════╦════════════════════╦════════════════════╗");
            Console.WriteLine("║      №       ║     Название   ║    Фамилия режиссера   ║  Количество серий  ║        Жанр        ║");
            Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╬════════════════════╣");

            int i = 1;
            foreach (Series item in series)
            {
                Console.WriteLine($"║{i,14}║{item.Name,16}║{item.ProducerSurname,24}║{item.NumberOfEpisodes,20}║{item.Genre,20}║");
                if (i == series.Count)
                {
                    Console.WriteLine("╚══════════════╩════════════════╩════════════════════════╩════════════════════╩════════════════════╝");
                }
                else
                {
                    Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╬════════════════════╣");
                }
                i++;
            }
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                FileInfo file = new FileInfo(e.FullPath);
                Console.WriteLine($"Измение в файле {file.Name}, размер которого составляет {file.Length}, а дата последнего изменения: {file.LastWriteTime}");
            }
        }
    }
}