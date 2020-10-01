using System;

namespace HW7.Hospital
{
    struct InfoService
    {
        Patient[] patients;
        public InfoService(Patient[] patients)
        {
            this.patients = patients;
            Array.Sort(patients, (p1, p2) => p1.GetDaysOfStay.CompareTo(p2.GetDaysOfStay));
        }

        public void ShowInfo(string userChoice)
        {
            switch (userChoice)
            {
                case "home":
                    {
                        int i = 1;
                        Console.WriteLine("╔══════════════╦════════════════╦══════════════╗");
                        Console.WriteLine("║      №       ║     Фамилия    ║    Возраст   ║");
                        Console.WriteLine("╠══════════════╬════════════════╬══════════════╣");

                        foreach (Patient item in patients)
                        {
                            Console.WriteLine($"║{i,14}║{item.Surname,16}║{item.GetAge,14}║");
                            if(i == patients.Length)
                            {
                                Console.WriteLine("╚══════════════╩════════════════╩══════════════╝");
                            }
                            else
                            {
                                Console.WriteLine("╠══════════════╬════════════════╬══════════════╣");
                            }
                            i++;
                        }
                        break;
                    }
                case "end":
                    {
                        int i = 1;
                        Console.WriteLine("╔══════════════╦════════════════╦════════════════════════╦════════════════════╗");
                        Console.WriteLine("║      №       ║     Фамилия    ║     Дата постуления    ║    Год рождения    ║");
                        Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╣");

                        foreach (Patient item in patients)
                        {
                            Console.WriteLine($"║{i,14}║{item.Surname,16}║{item.Receipt.ToLongDateString(),24}║{DateTime.Now.Year-item.GetAge,20}║");
                            if (i == patients.Length)
                            {
                                Console.WriteLine("╚══════════════╩════════════════╩════════════════════════╩════════════════════╝");
                            }
                            else
                            {
                                Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╣");
                            }
                            i++;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine(userChoice);
                        int i = 1;

                        // Проверка на наличие пациентов с таким диагнозом
                        if (Array.Exists(patients, x => x.Disease.ToString().Equals(userChoice)))
                        {
                            Console.WriteLine("╔══════════════╦════════════════╦════════════════════════╦════════════════════╗");
                            Console.WriteLine("║      №       ║     Фамилия    ║     Продолжительность  ║      Возраст       ║");
                            Console.WriteLine("║              ║                ║     пребывания в       ║                    ║");
                            Console.WriteLine("║              ║                ║     больнице           ║                    ║");
                            Console.WriteLine("╠══════════════╬════════════════╬════════════════════════╬════════════════════╣");

                            foreach (Patient item in patients)
                            {
                                if (item.Disease.ToString().Equals(userChoice))
                                {
                                    Console.WriteLine($"║{i,14}║{item.Surname,16}║{item.GetDaysOfStay,24}║{item.GetAge,20}║");
                                    Console.WriteLine("╚══════════════╩════════════════╩════════════════════════╩════════════════════╝");
                                    i++;
                                }
                            }
                        }
                        else Console.WriteLine("Больные не обнаружены");
                        break;
                    }
            }
        }
    }
}
