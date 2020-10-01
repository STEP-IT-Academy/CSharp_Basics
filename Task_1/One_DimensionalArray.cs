/*
 * Создать класс «Одномерный массив», в котором описать следующие элементы: 
 *      •	закрытое поле – массив целых чисел
 *      •	свойство для определения длины массива
 *      •	индексатор для доступа к элементам поля-массива
 *      •	конструктор с параметрами
 *      •	метод ToString()
 *      •	статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах 
 *      •	операции  умножения массива на целое число и числа на массив
 *      •	унарная операция - (знаки элементов меняются на противоположные)
 *      •	операция неявного преобразования строки в объект этого класса 
 *          (Например, строка вида «1 2 -4 3 -2» преобразуется в объект класса Одномерный массив с полем-массивом (1 2 -4 3 -2)). 
 *          При попытке неявного преобразования строки неправильного формата должно генерироваться исключение.
 */

using System;

namespace HW_1
{
    class One_DimensionalArray
    {
        // закрытое поле – массив целых чисел
        private int[] array;

        public int[] GetArray => array;

        // свойство для определения длины массива   
        public int GetLength => array.Length; 

        // индексатор для доступа к элементам поля массива
        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < array.Length)
                {
                    return array[i];
                }
                else
                {
                    throw new IndexOutOfRangeException("Ошибка! Указанный Вами индекс не находится в приемлемом диапазоне!");
                }
            }

            set
            {
                if (i >= 0 && i < array.Length)
                {
                    array[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Ошибка! Указанный Вами индекс не находится в приемлемом диапазоне!");
                }
            }
        }

        // Конструктор по умолчанию
        public One_DimensionalArray()
        {
            Console.Write("Введите размерность массива: ");
            int sizeOfArray = int.Parse(Console.ReadLine());
            array = new int[sizeOfArray];

            if (sizeOfArray < 0) throw new Exception("Ошибка! Размер массива не может быть <= 0!"); 

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите [" + (i + 1) + "] элемент: ");
                array[i] = int.Parse(Console.ReadLine());
            }
        }

        // конструкторы с параметрами
        public One_DimensionalArray(params int[] array)
        {
            this.array = array;
        }

        public One_DimensionalArray(int size)
        {
            if (size > 0)
            {
                array = new int[size];

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("Введите [" + (i + 1) + "] элемент: ");
                    array[i] = int.Parse(Console.ReadLine());
                }
            }
            else
            {
                throw new Exception("Ошибка! Размер массива не может быть <= 0!");
            }
        }

        // метод ToString()
        public override string ToString()
        {
            string str = "";

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    str = str + array[i].ToString() + " ";
                }

                return str;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return str;
        }

        // статический метод с переменным числом параметров для вычисления общей суммы отрицательных элементов в нескольких массивах
        public static int TotalSumOFNegativeElements(params One_DimensionalArray[] arrays)
        {
            try
            {
                int result = 0;

                foreach (One_DimensionalArray item in arrays)
                {
                    for (int i = 0; i < item.array.Length; i++)
                    {
                        if (item.array[i] < 0)
                        {
                            result += item.array[i];
                        }
                    }
                }

                return result;

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return -1;
        }

        // операции умножения массива на целое число и числа на массив
        public static One_DimensionalArray operator*(One_DimensionalArray obj, int value)
        {
            One_DimensionalArray oda = new One_DimensionalArray(obj.array);
            try
            {
                for (int i = 0; i < oda.GetArray.Length; i++)
                {
                    oda.array[i] *= value;
                }

                return oda;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return oda;
        }

        public static One_DimensionalArray operator*(int value, One_DimensionalArray obj)
        {
            return obj * value;
        }

        // унарная операция - (знаки элементов меняются на противоположные)
        public static One_DimensionalArray operator-(One_DimensionalArray obj)
        {
            One_DimensionalArray oda = new One_DimensionalArray(obj.array);

            try
            {
                for (int i = 0; i < oda.array.Length; i++)
                {
                    oda.array[i] *= -1;
                }

                return oda;
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return oda;
        }

        /*
         * операция неявного преобразования строки в объект этого класса (Например, строка вида «1 2 -4 3 -2» преобразуется 
         * в объект класса Одномерный массив с полем-массивом (1 2 -4 3 -2) ). 
         * При попытке неявного преобразования строки неправильного формата должно генерироваться исключение
        */

        public static implicit operator One_DimensionalArray(string someString)
        {
            // Поскольку изначально строка имеет пробелы между цифрами - мы должны посчтиать количество цифр без пробелов 
            try
            {
                int countSpaces = 0; // Для подсчета количества пробелов
                for (int i = 0; i < someString.Length; i++)
                {
                    if (someString[i].ToString() == " ")
                    {
                        countSpaces++;
                    }
                };

                int sizeWOSpaces = someString.Length - countSpaces; // Определение нужного размера для выделения памяти(то есть без пробелов)
                int[] tmpArray = new int[sizeWOSpaces];
                tmpArray = Array.ConvertAll(someString.Split(), int.Parse); // преобразуем нашу строку в массив

                One_DimensionalArray array = new One_DimensionalArray(tmpArray);
                return array;
            }
            catch (ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException of)
            {
                Console.WriteLine(of.Message);
            }

            return null;
        }

        // Замена отрицательных элементов, в случае большинства суммы отрицательных элементов одного из массива
        public void ChangeNegElem()
        {
            /* 
             * Сначала выситываем сумму отрицательных элементов исходного массива, 
             * потом меняем знаки элементов этого же массива и считаем еще раз сумму отрицательных элементов
             */

            try
            {
                int sumNegObj1 = 0; // Сумма отрицательных элементов до унарного -
                int sumNegObj2 = 0; // После проведения операции унарного -
                bool flag = false;
                bool statusEqual = false;

                foreach (int item in array)
                {
                    if (item < 0)
                    {
                        sumNegObj1 += item;
                    }
                }

                foreach (int item in (this.ChangeSign()))
                {
                    if (item < 0)
                    {
                        sumNegObj2 += item;
                    }
                }

                if (Math.Abs(sumNegObj1) < Math.Abs(sumNegObj2))
                {
                    flag = true;
                    Array.Sort(array);

                    for (int i = 1; i < array.Length; i++)
                    {
                        if (array[i] == array[i - 1] && array[i] < 0)
                        {
                            statusEqual = true;
                            array[i] = sumNegObj1;
                            array[i - 1] = sumNegObj1;
                        }
                    }
                }

                if (flag && statusEqual)
                {
                    Console.WriteLine("Сумма отр. элем. массива -А больше суммы отр. элем. массива А, поэтому была произведена(ы) замена(ы).");
                }
                else if (flag)
                {
                    Console.WriteLine("Сумма отр. элем. массива -А больше суммы отр. элем. массива А, однако не было найдено одинаковых отрци. элемен, поэтому замен(ы) не было.");
                }
                else
                {
                    Console.WriteLine("Сумма отр. элем. массива -А меньше суммы отр. элем. массива А, поэтому замен(ы) не было.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        // Вывод некоторых массивов
        public static void ShowArrays(params One_DimensionalArray[] arrays)
        {
            foreach (One_DimensionalArray item in arrays)
            {
                Console.WriteLine(item);
            }
        }
    }
}