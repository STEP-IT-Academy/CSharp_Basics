using System;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод и вывод трех массивов A, В и С;
            // Вариант 1. Ввод пользователем

            /*
            One_DimensionalArray[] arrays = new One_DimensionalArray[3];

            for (int i = 0; i < 3; i++)
            {
                arrays[i] = new One_DimensionalArray();
            }

            One_DimensionalArray.ShowArrays(arrays);
            */

            // Вариант 2. Уже готовые данные

            One_DimensionalArray A = new One_DimensionalArray(5, -10, 15, -1, -1);
            One_DimensionalArray B = new One_DimensionalArray(-5, 4, -26);
            One_DimensionalArray C = new One_DimensionalArray(-10, 7, 33);
            One_DimensionalArray.ShowArrays(A, B, C);

            // Вычисление общей суммы отрицательных элементов в массивах 5 * A и С
            Console.Write("Вычисление общей суммы отрицательных элементов в массивах 5 * A и С = ");
            int sumOfNegElem = One_DimensionalArray.TotalSumOFNegativeElements((5 * A), C);
            Console.Write(sumOfNegElem);

            Console.WriteLine();

            // Вычисление общей суммы отрицательных элементов в массивах 2 * В, -А и С * 4
            Console.Write("Вычисление общей суммы отрицательных элементов в массивах 2 * В, -А и С * 4 = ");
            sumOfNegElem = One_DimensionalArray.TotalSumOFNegativeElements((2 * B), -A, (C * 4));
            Console.WriteLine(sumOfNegElem);

            /* Если сумма отрицательных элементов в массиве –А больше суммы отрицательных элементов в массиве А,
             * заменить все отрицательные повторяющиеся элементы этого массива на значение этой суммы
             */
            A.ChangeNegElem();
            Console.WriteLine(A);

            Console.ReadKey();
        }
    }
}