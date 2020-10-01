using System;

namespace HW_1.Batteries
{
    public class ChinaBattery : Battery
    {
        public ChinaBattery()
        {
            Random random = new Random();
            currentCharge = random.Next(1, 8);
        }

        public override bool ReduceBatteryCharge()
        {
            if (currentCharge > 0)
            {
                currentCharge--;
                return true;
            }
            else return false;
        }
    }
}
