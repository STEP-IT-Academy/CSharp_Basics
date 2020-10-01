using System;
using System.IO;
using System.Linq;
using System.Text;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Полный путь до директории
            string userRoot = @"C:\Users\kotka\source\repos\HW_Files";
            DirectoryInfo root = new DirectoryInfo(userRoot);

            // Заданная пользовательская маска
            string userMask = "a*";

            // Диапазон(дата последнего изменения) для поиска файлов
            DateTime minRange = new DateTime(2020, 01, 11);   // 11.01.2020 
            DateTime maxRange = new DateTime(2020, 01, 12);   // 11.01.2020 

            // Поиск файлов в указанном каталоге и его подкаталогах
            FileInfo[] files = root.GetFiles(userMask, SearchOption.AllDirectories).Where(f => f.LastWriteTime > minRange && f.LastWriteTime < maxRange).ToArray();

            // Результат поиска сбрасываем в файл отчета
            short i = 1;
            if (files.Length != 0)
            {
                try
                {
                    FileStream fileStream = File.Create("Report.txt");

                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default))
                    {
                        foreach (FileInfo file in files)
                        {
                            streamWriter.WriteLine(file.Name);
                        }
                    }

                    // Также необходимо вывести найденную информацию на экран в компактном виде(с нумерацией объектов)
                    foreach (FileInfo file in files)
                    {
                        Console.WriteLine($"{i}. {file.Name};");
                        i++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else Console.WriteLine("Файлов, соответствующих заданной маске и дате последней модфикации, входящих в указанный диапазон, не найдено!");

            // Запросить у пользователя дальнейшие действия
            // 1. удалить все найденное
            // 2. удалить указанный файл (каталог)
            // 3. удалить диапазон файлов (каталогов)

            try
            {
                byte choice = 0;
                while (choice < 5)
                {
                    Console.Clear();
                    Console.WriteLine("Нажмите 1 для удаления всего найденного.");
                    Console.WriteLine("Нажмите 2 для удаленния указанного файла.");
                    Console.WriteLine("Нажмите 3 для удаления диапазона файлов.");
                    Console.WriteLine("Нажмите 4 для выхода.");
                    Console.Write("Сделайте выбор: ");
                    choice = Convert.ToByte(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                // Удалить все найденное
                                //foreach (FileInfo file in files)
                                //{
                                //    File.Delete(file.Name);
                                //}

                                if (files.Length == 0) Console.WriteLine("Удаление прошло успешно.");
                                else Console.WriteLine("Удалить не получилось!");
                                Console.ReadKey();

                                break;
                            }
                        case 2:
                            {
                                // Удалить указанный файл
                                string fileNameForDelete = "Имя файла, который нужно удалить.";
                                //File.Delete(fileNameForDelete);

                                if (File.Exists(fileNameForDelete))
                                {
                                    //File.Delete(fileNameForDelete);
                                }
                                else
                                {
                                    Console.WriteLine("Указанного файла не существует.");
                                    Console.ReadKey();
                                    break;
                                }

                                if (!File.Exists(fileNameForDelete)) Console.WriteLine("Удаление прошло успешно!");

                                Console.ReadKey();

                                break;
                            }
                        case 3:
                            {
                                // Удалить диапазон файлов
                                DateTime minRange2 = new DateTime(2022, 01, 11, 17, 13, 08);   // 11.01.2020 17:13:08
                                DateTime maxRange2 = new DateTime(2029, 01, 12, 17, 13, 08);   // 11.01.2020 17:13:08
                                File.Delete(files.Where(f => f.LastWriteTime > minRange2 && f.LastWriteTime < maxRange2).Select(f => new { f.Name }).ToString());
                                Console.WriteLine("Удаление прошло успешно!");
                                Console.ReadKey();

                                break;
                            }
                        case 4: return;
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