using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(new int[3, 3] { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } });
            Matrix B = new Matrix(new int[3, 3] { { 1, 2, 0 }, { 4, 0, 0 }, { 7, 8, 0 } });

            if (A.SumOfDiaElem > B.SumOfDiaElem)
            {
                for (int i = 0; i < B.GetLenght(0); i++)
                {
                    for (int j = 0; j < B.GetLenght(1); j++)
                    {
                        if (B[i, j] == 0)
                        {
                            B[i, j] = A.SumOfDiaElem;
                        }
                    }
                }

                Console.WriteLine("Матрица B после замены элементов: " + B);
            }
            else
            {
                Console.WriteLine("Сумма элементов диагоналей матрицы B = " + B.SumOfDiaElem);
            }

            Console.ReadKey();
        }
    }
}