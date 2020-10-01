namespace HW_1.Batteries
{
    public abstract class Battery
    {
        /// <summary>
        /// Текущий заряд
        /// </summary>
        internal int currentCharge;

        /// <summary>
        /// Уменьшение заряда батарейки
        /// </summary>
        public abstract bool ReduceBatteryCharge();
    }
}
