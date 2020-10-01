using System;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double amountOfMoney = rand.Next(100, 500); // Капитал игрока
            double guessedNumber; // Загаднное(Random) число
            double enteredNumber; // Введенное пользователем число
            double percentMinus; // Процент от суммы, начиная с которого будет вычитаться при неудачных попытках
            double percentPlus; // Процент от суммы, начиная с которого будет прибавляться при удачных попытках
            int attempts; // Кол-во попыток

            /*
                Если введенное число совпало с загаданным с первого раза - к капиталу игрока прибавляется 50 % от его текущей суммы
                Если введенное число не совпало с загаданным с первого раза - с капитала игрока убавляется 55 % от его текущей суммы
                Начиная со 2-го раза к числу будет прибавляться уже (50 / кол-во попыток) и убавляться - (55 / кол-во попыток)
           */

            do
            {
                try
                {
                    Console.WriteLine("Загаданное число = " + (guessedNumber = rand.Next(0, 100))); // Загадываем число
                    Console.WriteLine("Ваша текущая сумма = " + amountOfMoney + " рублей");
                    Console.Write("Введите количество попыток для угадывания числа: ");
                    attempts = int.Parse(Console.ReadLine());
                    percentMinus = 55;
                    percentPlus = 50;

                    for (int i = 0; i < attempts; ++i)
                    {
                        Console.Write("Введите число: ");
                        enteredNumber = int.Parse(Console.ReadLine());

                        if (enteredNumber == guessedNumber)
                        {
                            Console.WriteLine("Вы угадали число с " + (i + 1) + "-ой попытки!");

                            amountOfMoney += (percentPlus * amountOfMoney) / 100;
                            amountOfMoney = Math.Floor(amountOfMoney);

                            i = attempts;
                        }
                        else
                        {
                            percentPlus /= attempts;
                            percentMinus /= attempts;

                            amountOfMoney -= (percentMinus * amountOfMoney) / 100;
                            amountOfMoney = Math.Floor(amountOfMoney);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (amountOfMoney > 0 && amountOfMoney < 1000);

            if (amountOfMoney >= 1000)
            {
                Console.WriteLine("Игра окончена! Вы - победитель!");
            }
            else
            {
                Console.WriteLine("Игра окончена! Вы - банкрот!");
            }

            Console.ReadKey();
        }
    }
}