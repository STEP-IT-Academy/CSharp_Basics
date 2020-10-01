using System;
using System.Linq;
using System.IO;

namespace HW3_T1
{
    class StudentsCollection
    {

        private Student[] students;

        public StudentsCollection()
        {
            try
            {
                Console.Write("Введите количество студентов, данные о которых Вы хотите заполнить: ");
                int countStudents = int.Parse(Console.ReadLine());

                students = new Student[countStudents];

                for (int i = 0; i < countStudents; ++i)
                {
                    students[i] = new Student();
                }
            }
            catch(IOException io)
            {
                Console.WriteLine(io.Message);
            }
            catch(ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            catch(OutOfMemoryException oom)
            {
                Console.WriteLine(oom.Message);
            }
        }

        public StudentsCollection(Student[] students)
        {
            this.students = students;
        }

        public int CountStudents => students.Length;

        public Student[] Students => students;

        // Добавление
        public void Add(Student newStudent)
        {
            try
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = newStudent;
            }
            catch(ArgumentOutOfRangeException aoor)
            {
                Console.WriteLine(aoor.Message);
            }
            catch(OverflowException of)
            {
                Console.WriteLine(of.Message);
            }
        }

        // Определение количества студентов, получивших больше двух оценок 10 в массиве
        public int CountStuentsWithGrades_10_More_2()
        {
            int count10 = 0;
            int result = 0;

            foreach (Student item1 in students)
            {
                count10 = 0;

                foreach (int item2 in item1.Grades)
                {

                    if (item2.Equals(10))
                    {
                        count10++;
                    }

                    if (count10 >= 2)
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        // Компаратор для фунции Sort
        public static int Compare(Student obj1, Student obj2)
        {
            return Math.Sign(obj1.AverageMark - obj2.AverageMark);
        }

        // Вывод списка двоечников в заданной группе
        public void ShowQuarters(string group)
        {
            bool flag = false;

            foreach (Student item in students)
            {
                if(group == item.GroupName && item.ExcellentOrQuarter() == "Двоечник")
                {
                    flag = true;
                    ShowStudent(item);
                }
            }

            if(!flag)
            {
                Console.WriteLine("В группе " + group + " двоечников нет!");
            }
        }

        // Вывод всех студентов
        public void ShowStudents()
        {

            Array.Sort(students, Compare);

            foreach (Student item1 in students)
            {
                Console.Write("Фамилия студента: " + item1.Surname + ", группа: " + item1.GroupName + ", оценки: ");

                foreach (int item2 in item1.Grades)
                {
                    Console.Write(item2 + ",");
                }

                Console.WriteLine(" средний балл = " + item1.AverageMark + ";");
            }
        }

        // Вывод одного студента
        public void ShowStudent(Student student)
        {

            Console.Write("Фамилия студента: " + student.Surname + ", группа: " + student.GroupName + ", оценки: ");

            foreach (int item in student.Grades)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(", средний балл = " + student.AverageMark + ";");
        }
    }
}