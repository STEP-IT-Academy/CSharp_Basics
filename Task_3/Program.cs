using HW6_T3.Port;
using HW6_T3.Transportations;
using HW6_T3.Transportations.FerryBoat;
using HW6_T3.Transportations.People;
using HW6_T3.Transportations.Tara;
using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            IGetWeight[] getWeights = new IGetWeight[8];
            getWeights[0] = new RectangularContainer("Прямоугольный контейнер", 15, 10, 5, "Карбин", 1900);
            getWeights[1] = new RectangularContainer("Прямоугольный контейнер", 9, 13, 4, "Алмазы", 3510);
            getWeights[2] = new Platform("Платформа", "Автомобили", 10000);
            getWeights[3] = new Platform("Платформа", "Мебель", 2200);
            getWeights[4] = new CylindricalTanks("Цилиндрическая цистерна", 10, 4, "Кислота азотная", 1502);
            getWeights[5] = new CylindricalTanks("Цилиндрическая цистерна", 5, 2, "Ртуть", 13596);
            getWeights[6] = new Person("Пассажир", "Иванов Иван Иванович", 66);
            getWeights[7] = new Person("Помощник капитана", "Васильев Василий Васильевич", 101);

            Ferry ferry = new Ferry(getWeights);

            Array.Sort(getWeights, new FerryComparerByType());

            InformationService.ShowFerryInfo(getWeights);

            if (ferry.IsAbleToTransport())
            {
                Console.WriteLine("Паром успешно отплывает!");
            }
            else Console.WriteLine("Паром не может отплыть! Перегруз!");

            Console.ReadKey();
        }
    }
}