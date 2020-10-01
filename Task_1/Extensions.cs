using System;
using System.Linq;

namespace HW3_T1
{
    static class Extensions
    {
        // Определение студентов-отличников и двоечников
        public static string ExcellentOrQuarter(this Student obj)
        {
            try
            {
                return obj.Grades.Average() > 8 ? "Отличник" : "Двоечник";
            }
            catch(ArgumentOutOfRangeException aoor)
            {
                Console.WriteLine(aoor.Message);
            }
            catch(InvalidOperationException io)
            {
                Console.WriteLine(io.Message);
            }

             return null;
        }
    }
}