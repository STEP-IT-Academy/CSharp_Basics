using System;
using System.Linq;
using System.Text;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string someString = "Первое предложение. Кто прав,а кто виноват? Я здесь. Ветер перемен.";
            Console.WriteLine("Исходная строка: Первое предложение. Кто прав,а кто виноват? Я здесь. Ветер перемен.");
            Console.Write("Результирующая строка: ");
            string[] result = OperationWithString(someString);
            foreach (string item in result)
            {
                Console.Write(item);
            }

            Console.ReadKey();
        }

        static string[] OperationWithString(string userString)
        {
            string[] wordSeptarators = { " ", ",", ";" };
            string[] sentencesSeparators = { ".", "!", "?" };

            StringBuilder stringBuilder = new StringBuilder(userString.ToLower(), userString.Length * 2);
            for (int i = 0; i < stringBuilder.Length - 1; i++)
            {
                if (!sentencesSeparators.Contains(stringBuilder[i].ToString()) && wordSeptarators.Contains(stringBuilder[i + 1].ToString()))
                {
                    stringBuilder.Insert(i + 1, "$");
                    i++;
                }

                if (sentencesSeparators.Contains(stringBuilder[i + 1].ToString()))
                {
                    stringBuilder.Insert(i + 1, "$");
                    i++;
                }
            }

            string[] result = stringBuilder.ToString().Split(new char[] { '.', '!', '?', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}