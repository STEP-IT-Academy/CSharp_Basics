using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double xBegin = InputNumber("Введите начальное значение аргумента:");
            double xEnd = InputNumber("Введите конечное значение аргумента:");
            double xStep = InputNumber("Введите шаг изменений аргумента:");
            double a = InputNumber("Введите значение для переменной a:");

            if (xBegin <= xEnd && xStep > 0)
            {
                Console.WriteLine("╔══════════════╦════════════════╗");
                Console.WriteLine("║      x       ║      f(x)      ║");
                Console.WriteLine("╠══════════════╬════════════════╣");

                for (double x = xBegin; x <= xEnd; x += xStep)
                {
                    double f = ((x + Math.Pow(a, 2)) / 1.4 * a) - x;
                    Console.WriteLine($"║{x,13:f2} ║{f,15:f2} ║");
                }

                Console.WriteLine("╚══════════════╩════════════════╝");
            }
            else
            {
                Console.WriteLine("Ошибка при вводе данных!");
            }

            Console.ReadKey();
        }

        static double InputNumber(string query)
        {
            Console.Write(query + " ");
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}