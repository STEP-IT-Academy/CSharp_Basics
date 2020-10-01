namespace HW_1.Batteries
{
    public class DuracellBattery : Battery
    {
        /// <summary>
        /// Количеств раз, во соклько батарея типа Durcaell работет лучше батареи типа China
        /// </summary>
        private const int NumberOfTimesInHowMuchDuracellBetterWorks = 10;

        /// <summary>
        /// Заряд самой лучшей китайской батарейки
        /// </summary>
        private const int MaxChinaBatteryCharge = 7;

        public DuracellBattery()
        {
            currentCharge = NumberOfTimesInHowMuchDuracellBetterWorks * MaxChinaBatteryCharge;
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
