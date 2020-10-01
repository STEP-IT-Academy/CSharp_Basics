using System;
using HW_1.Batteries;
using HW_5;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать объект фабрики
            FlashlightFactory flashlightFactory = new FlashlightFactory();

            // Ввести количество фонариков, которое требуется  произвести на фабрике
            Console.Write("Введите необходимое количество фонариков для их производства: ");
            int countFlashLights = int.Parse(Console.ReadLine());

            /* 
             * Cформировать массив объектов IIlluminant, причем, каждый раз при создании фонарика тип батарейки определяется
             * случайным образом (поставки батареек на фабрику хаотичны и нестабильны).
             * Обусловимся, что 1 - батарейка типа Duracell, а 2 - типа China
             */

            if (countFlashLights > 0)
            {
                IIlluminant[] illuminants = new IIlluminant[countFlashLights];
                Random random = new Random();

                for (int i = 0; i < illuminants.Length; i++)
                {
                    switch (random.Next(1, 3))
                    {
                        case 1: illuminants[i] = flashlightFactory.GetFlashlight(new DuracellBattery()); break;
                        case 2: illuminants[i] = flashlightFactory.GetFlashlight(new ChinaBattery()); break;
                    }
                }

                // Определить общее количество включений фонариков до их полной разрядки.
                int commonCountTurnsOnBeforeDischarged = 0;
                foreach (IIlluminant item in illuminants)
                {
                    item.On();
                    while (item.IsLight())
                    {
                        item.Off();
                        commonCountTurnsOnBeforeDischarged++;
                        item.On();
                    }
                }

                Console.WriteLine("Общее количество включений фонариков до их полной разрядки = " + commonCountTurnsOnBeforeDischarged);
            }
            else throw new Exception("Ошибка! Количество батареек не может быть равным 0 или отрицательным!");

            Console.ReadKey();
        }
    }
}