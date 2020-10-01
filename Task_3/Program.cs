using System;
using HW_2_T3;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Circle[] cr = new Circle[3];
            cr[0] = new Circle();
            cr[1] = new Circle(3, 5, 2);
            cr[2] = new Circle(3, 4, 3);
            Circle.ShowInfo(cr);

            if (Circle.CmpCircles(cr[1], cr[2]) == true)
            {
                Console.WriteLine("Окружность № 2 и № 3 пересекаются");
            }
            else
            {
                Console.WriteLine("Окружность № 2 и № 3 не пересекаются");
            }

            Console.WriteLine("Для перемещения окружности № 1 нажмите 1, для увеличения радиуса нажмите 2");
            Console.Write("Ваш выбор: ");
            int choice1 = int.Parse(Console.ReadLine());

            switch (choice1)
            {
                case 1:
                {
                    Console.WriteLine("Нажмите 1, если хотите переместить окружность по вертикали вниз");
                    Console.WriteLine("Нажмите 2, если хотите переместить окружность по горизонтали влево");
                    Console.Write("Ваш выбор: ");
                    int choice2 = int.Parse(Console.ReadLine());

                    Console.Write("Введите значение, на которое надо переместить: ");
                    double userValue = double.Parse(Console.ReadLine());

                    cr[0].Moving(userValue, choice2);
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Введите значение, на которое увеличить радиус: ");
                    double someValue = double.Parse(Console.ReadLine());

                    cr[0].IncreaseRadius(someValue);
                    break;
                }
            }

            Circle.ShowInfo(cr[0]);
            Console.ReadKey();
        }
    }
}