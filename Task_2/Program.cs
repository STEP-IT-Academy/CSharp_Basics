using System;
using System.Text;
using System.Threading;
using GameCar;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;

            try
            {
                Console.Write("Введите количество машин(от 2 до 7 включительно): ");
                int countCars = int.Parse(Console.ReadLine());
                if (countCars < 2 || countCars > 7) throw new Exception("Введенно неправильное количество машин!");
                Console.Write("Укажите номер машины, на который вы будете ставить: ");
                int betCarNumber = int.Parse(Console.ReadLine());
                Car[] cars = new Car[countCars];
                int start = 0;
                int i, j;
                for (i = 0, j = 0; i < cars.Length; i++, j += 2)
                {
                    cars[i] = new Car(ConsoleColor.Red, i + 1, start, i + j);
                    cars[i].View();
                }
                Console.SetCursorPosition(0, j + 3);
                Console.WriteLine("Для старта нажмите клавишу");
                Console.ReadKey();
                Console.SetCursorPosition(0, j + 3);
                Console.WriteLine("                               ");
                //гонка
                Random random = new Random();
                int finish = Console.WindowWidth - cars[0].Length - 2;
                int[] winers = new int[cars.Length];//победители
                bool gameOver = false;
                while (!gameOver)
                {
                    for (i = 0; i < cars.Length; i++)
                    {
                        int dx = random.Next(5);

                        if (cars[i].X + dx <= finish)
                            cars[i].Move(dx);
                        else
                        {
                            cars[i].Move(finish - cars[i].X);
                            winers[i] = 1;
                            if (winers[i] == betCarNumber)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Вы выйграли!");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Вы проиграли!");
                            }
                            gameOver = true;
                        }
                    }
                    Thread.Sleep(100);
                }

                Console.WriteLine("\nПобедители:");
                for (i = 0; i < winers.Length; i++)
                {
                    if (winers[i] == 1)
                        Console.WriteLine("Машинка № " + (i + 1));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //car.Color = ConsoleColor.Red;
            Console.WriteLine("Все работает");
            Console.ReadKey();
        }
    }
}