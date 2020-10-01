using System;
using System.IO;
using System.Linq;

namespace HW3_T1
{
    class Student
    {
        private string surname;
        private string groupName;
        private int[] grades;
        private double averageMark;

        public Student()
        {
            try
            {
                Console.Write("Введите фамилию студента: ");
                surname = Console.ReadLine();

                Console.Write("Введите группу студента: ");
                groupName = Console.ReadLine();

                Console.Write("Введите количество оценок студента: ");
                int countGrades = int.Parse(Console.ReadLine());
                grades = new int[countGrades];

                for (int i = 0; i < grades.Length; i++)
                {
                    Console.Write("Введите " + (i + 1) + "-ую оценку: ");
                    grades[i] = int.Parse(Console.ReadLine());
                }

                averageMark = grades.Average();
            }
            catch(OutOfMemoryException oofm)
            {
                Console.WriteLine(oofm.Message);
            }
            catch(ArgumentOutOfRangeException aoor)
            {
                Console.WriteLine(aoor.Message);
            }
            catch(ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            catch(OverflowException of)
            {
                Console.WriteLine(of.Message);
            }
            catch(IOException io)
            {
                Console.WriteLine(io.Message);
            }
            catch(InvalidOperationException io)
            {
                Console.WriteLine(io.Message);
            }
        }

        public Student(string surname, string groupName, params int[] marks)
        {
            this.surname = surname;
            this.groupName = groupName;
            grades = marks;
            averageMark = grades.Average();
        }

        public string Surname => surname;

        public string GroupName => groupName;

        public int[] Grades => grades;

        public double AverageMark => averageMark;
    }
}