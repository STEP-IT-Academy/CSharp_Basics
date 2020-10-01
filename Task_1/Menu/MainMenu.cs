using HW7.Hospital;
using HW7.Menu;
using System;

namespace HW7
{
    class MainMenu
    {
        public void Start(InfoService infoService)
        {
            bool isNoChoice = true;
            while(isNoChoice)
            {
                Console.Clear();
                Console.WriteLine("Нажмите клавишу Home для вывода информации о фамилии и возрасте пациента. " +
                 "\nНажмите клавишу End для вывода информации о фамилии, дате поступления и годе рождения. " +
                 "\nНажмите клавишу D для выбора диагноза." +
                 "\nНажмите клавишу Enter для выхода.");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Enter: isNoChoice = false; break;
                    case ConsoleKey.Home: Console.Clear(); infoService.ShowInfo((consoleKeyInfo.Key.ToString().Trim().ToLower())); Console.ReadKey(); break;
                    case ConsoleKey.End: Console.Clear(); infoService.ShowInfo((consoleKeyInfo.Key.ToString().Trim().ToLower())); Console.ReadKey(); break;
                    case ConsoleKey.D: Console.Clear(); DiagnosisMenu diagnosisMenu = new DiagnosisMenu(); diagnosisMenu.Start(infoService); Console.ReadKey(); break;
                }
            }
        }
    }
}
