using System;

namespace HW8_T2.Hospital
{
    class InfoService
    {
        /// <summary>
        /// Врачи
        /// </summary>
        Doctor[] doctors;

        /// <summary>
        /// Пациенты
        /// </summary>
        Patient[] patients;

        public InfoService(Doctor[] doctors, Patient[] patients)
        {
            this.doctors = doctors ?? throw new ArgumentNullException(nameof(doctors));
            this.patients = patients ?? throw new ArgumentNullException(nameof(patients));
        }

        /// <summary>
        /// Вывод первоначальной информации о пациентах 
        /// </summary>
        public void ShowPatientInfo()
        {
            int i = 1;
            foreach (Doctor item1 in doctors)
            {
                i = 1;
                Console.WriteLine($"Врач {item1.Surname}, кабинет № {item1.CabinetNumber}");
                Console.WriteLine("╔══════════════╦════════════════╦══════════════════╦══════════════════╗");
                Console.WriteLine("║      №       ║     Фамилия    ║    Дата приема   ║      Диагноз     ║");
                Console.WriteLine("╠══════════════╬════════════════╬══════════════════╬══════════════════╣");

                foreach (Patient item2 in patients)
                {
                    if(item2.CabinetNumber.Equals(item1.CabinetNumber))
                    {
                        Console.WriteLine($"║{i,14}║{item2.Surname,16}║{item1.DateAndTimeOfReceipt.ToLongDateString(),18}║ {item2.Diagnosis,17}║");
                        Console.WriteLine("╚══════════════╩════════════════╩══════════════════╩══════════════════╝");
                        i++;
                    }
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вывод измененной информации о пациентах
        /// </summary>
        public void ShowChangedInfo()
        {

            Console.WriteLine("╔══════════════╦════════════════╦══════════════════╦═══════════════════╦═══════════════════╦══════════════════╦════════════════╗");
            Console.WriteLine("║      №       ║     Фамилия    ║  Номер кабинета  ║    Дата приема    ║   Время приема    ║   Фамилия врача  ║    Диагноз     ║");
            Console.WriteLine("╠══════════════╬════════════════╬══════════════════╬═══════════════════╬═══════════════════╬══════════════════╬════════════════╣");

            int doctorIndex = 0;
            for (int i = 0; i < patients.Length; i++)
            {
                doctorIndex = Array.FindIndex(doctors, x => x.CabinetNumber.Equals(patients[i].CabinetNumber));

                Console.WriteLine($"║{i + 1,14}║{patients[i].Surname,16}║{patients[i].CabinetNumber,18}║ {patients[i].DateAndTimeOfReceipt.ToLongDateString(),18}" +
                    $"║{patients[i].DateAndTimeOfReceipt.ToLongTimeString(),19}║{doctors[doctorIndex].Surname,18}║ {patients[i].Diagnosis,14} ║");
                if (i == patients.Length - 1)
                {
                    Console.WriteLine("╚══════════════╩════════════════╩══════════════════╩═══════════════════╩═══════════════════╩══════════════════╩════════════════╝");
                }
                else Console.WriteLine("╠══════════════╬════════════════╬══════════════════╬═══════════════════╬═══════════════════╬══════════════════╬════════════════╣");
            }
        }
    }
}