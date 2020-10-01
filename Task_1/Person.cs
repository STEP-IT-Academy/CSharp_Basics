using System;

namespace HW_Attributes
{
    [Serializable]
    [Secret("#", Status = true)]
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int YearOfBirth { get; set; }

        public Person() { }

        public Person(string name, string surname, int yearOfBirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.YearOfBirth = yearOfBirth;
        }

        public override string ToString() => $"{Name} {Surname} {YearOfBirth} года рождения";
    }
}
