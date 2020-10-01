using HW6_T3.Transportations;
using System;

namespace HW6_T3.Port
{
    /// <summary>
    /// Информационный сервис порта
    /// </summary>
    class InformationService  
    {
        /// <summary>
        /// Вывод информации о пароме
        /// </summary>
        public static void ShowFerryInfo(IGetWeight[] array)
        {
            Console.WriteLine("Информация о пароме:");
            foreach (IGetWeight item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
