using HW8_T2;
using HW8_T2.Hospital;
using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем два объекта класса Врач.
            Doctor[] doctors = new Doctor[2];
            doctors[0] = new Doctor("Самохвалов", DateTime.Parse("29.12.19"), 13);
            doctors[1] = new Doctor("Резков", DateTime.Parse("11.11.19"), 5);

            // Создает четыре объекта класса Пациент: два лечатся у одного врача, два у другого. Каждый пациент должен быть «зарегистрирован» в «своем» объекте класса Врач
            Patient[] patients = new Patient[4];
            patients[0] = new Patient("Петров", "перелом", DateTime.Parse("29.12.19 15:40"), 13);
            patients[1] = new Patient("Иванов", "ушиб", DateTime.Parse("11.12.19 11:25"), 5);
            patients[2] = new Patient("Сидоров", "вывих", DateTime.Parse("01.02.19 8:00"), 13);
            patients[3] = new Patient("Козлов", "грипп", DateTime.Parse("25.06.19 18:35"), 5);

            // Регистрируем у соответствующего врача соответствующего ему пациента
            doctors[0].ChangedInCabinetNumber += patients[0].ChangeCabinetNumber;
            doctors[0].ChangedInCabinetNumber += patients[2].ChangeCabinetNumber;
            doctors[1].ChangedInCabinetNumber += patients[1].ChangeCabinetNumber;
            doctors[1].ChangedInCabinetNumber += patients[3].ChangeCabinetNumber;

            // Вывод информации о пациентах
            InfoService infoService = new InfoService(doctors, patients);
            infoService.ShowPatientInfo();

            // Изменяем номер кабинета у определенного врача
            doctors[0].CabinetNumber = 8;

            // Выводим измененную информацию о пациентах
            infoService.ShowChangedInfo();

            Console.ReadKey();
        }
    }
}