using System;
using HW7;
using HW7.Hospital;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Patient[] patients = new Patient[4];
            patients[0] = new Patient("Петров", birthday: DateTime.Parse("1968-12-01"), receipt: DateTime.Parse("2019-11-11"), Diagnosis.Ангина);
            patients[1] = new Patient("Козлов", birthday: DateTime.Parse("1986-03-09"), receipt: DateTime.Parse("2019-11-01"), Diagnosis.Ангина);
            patients[2] = new Patient("Соколов", birthday: DateTime.Parse("1996-12-12"), receipt: DateTime.Parse("2019-11-25"), Diagnosis.Пневмония);
            patients[3] = new Patient("Сидоров", birthday: DateTime.Parse("2001-07-22"), receipt: DateTime.Parse("2019-11-01"), Diagnosis.Пневмония);

            InfoService infoService = new InfoService(patients);
            MainMenu menu = new MainMenu();
            menu.Start(infoService);
        }
    }
}