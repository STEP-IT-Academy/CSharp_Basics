using System;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double z = InputNumber("Введите значение для переменной Z:");
            double x = InputNumber("Введите значение для переменной X:");

            if (z > -5 && z <= 0)
            {
                Console.WriteLine("Результат выражения = " + (Math.Pow(x, 2) + z));
            }
            else if (z <= -5)
            {
                Console.WriteLine("Результат выражения = " + (2.5 * z));
            }
            else
            {
                Console.WriteLine("Результат выражения = " + (Math.Pow(x, 3) + 1.3) / z);
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