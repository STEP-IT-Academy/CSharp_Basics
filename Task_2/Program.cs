using System;
using HW_2_T3;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UniformItem ui = new UniformItem("Провод", "Сталь", 7850, 0.03);
            ui.ToString();

            ui = new UniformItem("Провод", "Медь", 8500, 0.03);
            ui.ToString();

            Console.ReadKey();
        }
    }
}