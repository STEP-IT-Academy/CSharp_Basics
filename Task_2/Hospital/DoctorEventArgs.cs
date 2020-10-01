using System;

namespace HW8_T2.Hospital
{
    class DoctorEventArgs : EventArgs
    {
        /// <summary>
        /// Строка для информирования о изменении номера кабинета врача
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Измененный номер кабинета врача
        /// </summary>
        public ushort NewCabinetNumber { get; }

        public DoctorEventArgs(string message, ushort newCabinetNumber)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            NewCabinetNumber = newCabinetNumber;
        }
    }
}