using HW8_T2.Hospital;
using System;

namespace HW8_T2
{
    public delegate void ChangeInCabinetNumberEventHandler(Doctor doctor);

    public class Doctor
    {
        /// <summary>
        /// Событие, вызывающееся при изменении номера кабинета у врача
        /// </summary>
        public event EventHandler ChangedInCabinetNumber;

        /// <summary>
        /// Фамилия врача
        /// </summary>
        public string Surname { get; private set; }
        
        /// <summary>
        /// Время приема
        /// </summary>
        public DateTime DateAndTimeOfReceipt { get; private set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        ushort cabinetNumber;

        public ushort CabinetNumber 
        {
            get => cabinetNumber;

            set
            {
                cabinetNumber = value;
                ChangedInCabinetNumber?.Invoke(this, new DoctorEventArgs($"Номер кабинета у врача {Surname} изменился на {value}", value));
            }
        }

        public Doctor(string surname, DateTime dateAndTimeOfReceipt, ushort cabinetNumber)
        {
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            DateAndTimeOfReceipt = dateAndTimeOfReceipt;
            CabinetNumber = cabinetNumber;
        }
    }
}
