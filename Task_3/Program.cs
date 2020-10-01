using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double startDistance = 3;
            double commonDistance = startDistance;
            int countDays5km = 1;
            int countDays30km = 1;

            do
            {

                if (startDistance < 5)
                {
                    countDays5km++;
                }

                startDistance += (startDistance * 10) / 100;
                commonDistance += startDistance;
                countDays30km++;

            } while (commonDistance < 30);

            Console.WriteLine(countDays5km + " дней нужно для того, чтобы пловец начал проплывать за день более 5 км.");
            Console.WriteLine("К " + countDays30km + " дню он суммарно проплывет более 30 км.");
            Console.ReadKey();
        }
    }
}