using HW8_T2.Hospital;
using System;

namespace HW8_T2
{
    class Patient
    {
        /// <summary>
        /// Фамилия пациента
        /// </summary>
        public string Surname { get; private set; }

        /// <summary>
        /// Диагноз
        /// </summary>
        public string Diagnosis { get; private set; }

        /// <summary>
        /// Дата и время приема
        /// </summary>
        public DateTime DateAndTimeOfReceipt { get; private set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        public ushort CabinetNumber { get; private set; }

        public Patient(string surname, string dIagnosis, DateTime dateAndTimeOfReceipt, ushort cabinetNumber)
        {
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Diagnosis = dIagnosis ?? throw new ArgumentNullException(nameof(dIagnosis));
            DateAndTimeOfReceipt = dateAndTimeOfReceipt;
            CabinetNumber = cabinetNumber;
        }

        /// <summary>
        /// Обработчик события из класса Doctor, вызывающийся в случае изменения номера кабинета у врача
        /// </summary>
        /// <param name="o"></param>
        /// <param name="eventArgs"></param>
        public void ChangeCabinetNumber(object o, EventArgs eventArgs)
        {
           CabinetNumber = ((DoctorEventArgs)eventArgs).NewCabinetNumber;
        }
    }
}