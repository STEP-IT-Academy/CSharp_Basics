using System;

namespace GameCar
{
    class Car
    {
        public ConsoleColor Color { get; set; }
        public int Number { get; }
        int x;
        int y;
        Car unvisibleCar; //машинка для закрашивания

        public Car(ConsoleColor color = ConsoleColor.Yellow, int number = 111, int x = 2, int y = 2)
        {
            Color = color;
            Number = number;
            if (x < 0 || y < 0)
                throw new Exception("Здесь машинки не ездят");
            this.x = x;
            this.y = y;
            Length = 6 + Number.ToString().Length;
            unvisibleCar = new Car();
            unvisibleCar.Color = Console.BackgroundColor;
        }
        public Car()
        {

        }
        public int X => x;
        public int Y => y;
        public int Length { get; }
        public void View()
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(x, y);
            Console.Write($"{Number}┌─▄_");
            //┌ 218 ─ 196 ■ 254  └ 192  ┘ 217  ◄ 17 ▄ 220
            Console.SetCursorPosition(x, y + 1);
            int n = Number.ToString().Length;
            Console.Write("{0," + n + "}└O─O┘◄", ' ');
            Console.ForegroundColor = temp;
        }
        public static Car operator ++(Car car)
        {
            car.unvisibleCar.x = car.x;
            car.unvisibleCar.y = car.y;
            car.unvisibleCar.View();

            car.x++;

            car.View();

            return car;
        }
        public void Move(int offset)
        {
            unvisibleCar.x = x;
            unvisibleCar.y = y;
            unvisibleCar.View();
            x += offset;
            View();
        }
    }
}
