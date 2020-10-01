using System;

namespace Task_4
{
    class Program
    {
        static readonly string[] firstLetter = new[] { "cто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        static readonly string[] secondLetter = new[] { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        static readonly string[] thirdLetter = new[] { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        static readonly string[] exceptions = new[] { "Сто одиннадцать", "Сто двенадцать", "Сто тринадцать", "Сто четырнадцать", "Сто пятнадцать", "Сто шестнадцать", "Сто семнадцать", "Сто восемнадцать", "Сто девятнадцать" };

        static int Main()
        {

            Console.Write("Введите число в диапазоне 100-999 включительно: ");
            string num = Console.ReadLine();
            string result = null;

            if (num.Length > 3 || num.Length < 3)
            {
                Console.WriteLine("Ошибка при вводе данных!");
                Console.ReadKey();
                return 0;
            }

            // Поскольку все числа, кроме 111,112,113,114,115,116,117,118 и 119, можно вывести без особых проблем, то для этих 9-ти чисел сделан массив exceptions(10 строка) и соответствующий вывод чисел
            int n1 = int.Parse(num[1].ToString());
            if (n1 == 1 && num != "110")
            {
                n1 = ((int.Parse(num[1].ToString())) + (int.Parse(num[2].ToString())));

                Console.WriteLine(num + " - " + "<< " + (result = exceptions[n1 - 2]) + " >>");
                Console.ReadKey();
                return 0;
            }

            for (int i = 0; i < num.Length; ++i)
            {
                switch (i)
                {
                    case 0:
                        {
                            n1 = (int.Parse(num[i].ToString()) - 1);
                            if (n1 >= 0) result += firstLetter[n1] + " ";
                            break;
                        }
                    case 1:
                        {
                            n1 = (int.Parse(num[i].ToString()) - 1);
                            if (n1 >= 0) result += secondLetter[n1] + " ";
                            break;
                        }
                    case 2:
                        {
                            n1 = (int.Parse(num[i].ToString()) - 1);
                            if (n1 >= 0) result += thirdLetter[n1];
                            break;
                        }
                }
            }

            Console.WriteLine(num + " - " + "<< " + result + ">>");
            Console.ReadKey();
            return 0;
        }
    }
}