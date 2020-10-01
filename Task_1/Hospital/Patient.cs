using System;

namespace HW7
{
    /// <summary>
    /// Диагнозы заболеваний
    /// </summary>
    internal enum Diagnosis { Грипп, Ангина, Пневмония };

    struct Patient
    {
        /// <summary>
        /// Фамилия пациента
        /// </summary>
        public string Surname { get; private set; }

        /// <summary>
        /// Дата рождения пациента
        /// </summary>
        public DateTime Birthday { get; private set; }

        /// <summary>
        /// Дата поступления пациента
        /// </summary>
        public DateTime Receipt { get; private set; }

        /// <summary>
        /// Диагноз заболевания пациента
        /// </summary>
        public Diagnosis Disease { get; private set; }

        public Patient(string surname, DateTime birthday, DateTime receipt, Diagnosis disease)
        {
            Surname = surname;
            Birthday = birthday;
            Receipt = receipt;
            Disease = disease;
        }

        /// <summary>
        /// Нахождение кол-ва дней пребывания пациента
        /// </summary>
        public int GetDaysOfStay => (DateTime.Now - Receipt).Days;

        /// <summary>
        /// Нахождение возраста пациента
        /// </summary>
        public int GetAge => DateTime.Now.Year - Birthday.Year;

        public override string ToString()
        {
            return "Фамилия пациента: " + Surname + ", дата рождения: " + Birthday.ToLongDateString() + ", возраст: " 
                + GetAge + ", дата поступления: " + Receipt.ToLongDateString() + ", дней пребывания: " + GetDaysOfStay + 
                ", диагноз: "  + Disease;
        }
    }
}
