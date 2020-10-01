using System;
using HW3_T1;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вариант ввода данных в массив студенов с клавиатуры

            // StudentsCollection studentsCollection = new StudentsCollection();

            // Вариант с уже заполенными данными

            Student[] studentsArray = new Student[3];
            studentsArray[0] = new Student("Иванов", "P11018", 2, 10, 4, 9);
            studentsArray[1] = new Student("Петров", "P11018", 5, 6, 2, 10);
            studentsArray[2] = new Student("Сидоров", "P11020", 10, 7, 5, 10);

            StudentsCollection studentsCollection = new StudentsCollection(studentsArray);

            // Вывод списка всех студентов с указанием среднего балла каждого студента в порядке возрастания среднего балла
            studentsCollection.ShowStudents();

            // Определение количества студентов, получивших больше двух оценок 10 в массиве
            Console.WriteLine("Количество студентов, получивших больше двух оценок 10 = " + studentsCollection.CountStuentsWithGrades_10_More_2());

            // Вывод списка двоечников в заданной группе
            studentsCollection.ShowQuarters("P11018");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}