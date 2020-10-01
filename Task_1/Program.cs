using System;

namespace HW_1
{
    class Program
    {
        static void MatrixOperations(int[,] someMatrix, Action<int> action)
        {
            Console.Write("Исходная матрица: ");
            foreach (int item in someMatrix)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.Write("Положительные элементы в мартице: ");
            foreach (int item in someMatrix)
            {
                if (item > 0)
                {
                    action(item);
                }
            }
        }

        static void IsPositive(int matrixItem)
        {
            Console.Write(matrixItem + " ");
        }

        static void Main(string[] args)
        {
            int[,] matrix = { { -1, 2, 3 }, { 4, -5, 6 }, { 7, -8, 9 } };
            MatrixOperations(matrix, IsPositive);

            Console.ReadKey();
        }
    }
}