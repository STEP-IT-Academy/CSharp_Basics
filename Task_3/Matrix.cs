/*
 * Для решения задачи создать класс Matrix, содержащий:
 *      закрытое поле-массив для хранения данных
 *      конструктор без параметров для создания единичной матрицы 3×3
 *      конструктор с параметрами (параметр – матрица целых чисел)
 *      метод  ToString(), возвращающий строковое представление  матрицы
 *      индексатор для доступа к элементам поля-массива
 *      метод GetLenth – аналог одноименного метода из Array
 *      закрытый (private) метод, возвращающий true, если столбец состоит из положительных элементов (параметр – номер столбца)
 *      метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов
 *      свойство, возвращающее сумму элементов диагоналей матрицы
 */

using System;

namespace Task_3
{
    class Matrix
    {
        // закрытое поле-массив для хранения данных
        private int[,] matrix;

        // конструктор без параметров для создания единичной матрицы 3×3
        public Matrix()
        {
            matrix = new int[,] { { 1, 1 }, { 1, 1 }, { 1, 1 } };
        }

        //конструктор с параметрами(параметр – матрица целых чисел)
        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        // метод  ToString(), возвращающий строковое представление  матрицы
        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == 0) str += "| ";
                    str = str + matrix[i, j] + " ";
                    if (j == matrix.GetLength(1) - 1) str += "|";
                }
            }

            return str;
        }

        // индексатор для доступа к элементам поля-массива
        public int this[int i, int j] { get => matrix[i, j]; set => matrix[i, j] = value; }

        // метод GetLength – аналог одноименного метода из Array
        public int GetLenght(int value) => (int)Math.Sqrt(matrix.Length);
       
        // закрытый (private) метод, возвращающий true, если столбец состоит из положительных элементов (параметр – номер столбца)
        private bool PositiveColumn(int columnNumber)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columnNumber] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        // метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов
        public int SumElemOfPosColumns()
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(PositiveColumn(j))
                    {
                        result += matrix[i, j];
                    }
                }
            }

            if (result == 0)
            {
                Console.WriteLine("В исходной матрице отсутствуют столбцы, полностью состоящие из положительных элементов!");
                return -1;
            }
            else return result;
        }

        // свойство, возвращающее сумму элементов диагоналей матрицы
        public int SumOfDiaElem
        {
            get
            {
                int result = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            result += matrix[i, j];
                        }
                    }
                }

                return result;
            }
        }
    }
}
