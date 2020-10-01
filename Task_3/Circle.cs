using System;

namespace HW_2_T3
{
    class Circle
    {
        private double x;
        private double y;
        private double radius;

        public double X => x;

        public double Y => y;

        public double Radius => radius;

        // Свойство для определения длины окружности
        public double Circumference => Math.Round(2 * Math.PI * radius, 2);

        public Circle()
        {
            x = 0;
            y = 0;
            radius = 1;
        }

        public Circle(double x, double y, double radius)
        {
            try
            {
                if (radius < 0)
                {
                    throw new Exception("Ошибка! Радиус не может быть меньше 0!");
                }
                else
                {
                    this.x = x;
                    this.y = y;
                    this.radius = radius;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        // Метод, результатом которого является true, если окружность целиком лежит в одной координатной четверти
        public bool OneQuarter()
        {
            return ((Math.Abs(X) - Radius >= 0) && (Math.Abs(Y) - Radius >= 0)) ? true : false;
        }

        // Метод для перемещения окружности по вертикали вниз или по горизонтали влево на заданную величину
        public void Moving(double userValue, int userChoice)
        {
            switch (userChoice)
            {
                case 1: x -= userValue; break;
                case 2: y -= userValue; break;
            }
        }

        // Метод для увеличения радиуса окружности на заданную величину
        public void IncreaseRadius(double someValue)
        {
            radius += someValue;
        }

        // Статический метод для проверки, пересекаются ли две окружности 
        public static bool CmpCircles(Circle obj1, Circle obj2)
        {
            double tmp = Math.Sqrt(obj1.x - obj2.x) + Math.Sqrt(obj1.y - obj2.y);
            return (Math.Abs(obj1.Radius - obj2.Radius) <= tmp) && (tmp <= (obj1.Radius + obj2.Radius)) ? true : false;
        }

        // Вывод информации по всем элементам массива
        public static void ShowInfo(Circle[] objArray)
        {
            Console.WriteLine("╔══════════════╦════════════════╦══════════════╦═══════════════╦════════════════════════════╗");
            Console.WriteLine("║    № п/п     ║     Центр      ║    Радиус    ║     Длина     ║ Лежит ли в одной плоскости ║");
            Console.WriteLine("╠══════════════╬════════════════╬══════════════╬═══════════════╬════════════════════════════╣");
            for (int i = 0; i <= objArray.Length - 1; ++i)
            {
                string result = objArray[i].OneQuarter() == true ? "Да" : "Нет";
                Console.WriteLine($"║{i + 1,13} ║ {"(" + objArray[i].X + ";" + objArray[i].Y + ")",14} ║ {objArray[i].Radius,12} ║ {objArray[i].Circumference,13} ║ {result,26} ║");

                if (i == (objArray.Length - 1))
                {
                    Console.WriteLine("╚══════════════╩════════════════╩══════════════╩═══════════════╩════════════════════════════╝");
                }
                else
                {
                    Console.WriteLine("╠══════════════╬════════════════╬══════════════╬═══════════════╬════════════════════════════╣");
                }
            }
        }

        // Вывод информации одной окружности
        public static void ShowInfo(Circle obj)
        {
            string result;
            if (obj.OneQuarter() == true) result = "Да";
            else result = "Нет";

            Console.WriteLine("╔══════════════╦════════════════╦══════════════╦═══════════════╦════════════════════════════╗");
            Console.WriteLine("║    № п/п     ║     Центр      ║    Радиус    ║     Длина     ║ Лежит ли в одной плоскости ║");
            Console.WriteLine("╠══════════════╬════════════════╬══════════════╬═══════════════╬════════════════════════════╣");
            Console.WriteLine($"║{1,13} ║ {"(" + obj.X + ";" + obj.Y + ")",14} ║ {obj.Radius,12} ║ {obj.Circumference,13} ║ {result,26} ║");
            Console.WriteLine("╚══════════════╩════════════════╩══════════════╩═══════════════╩════════════════════════════╝");
        }
    }
}
