namespace HW6_T3.Transportations.Cargo
{
    /// <summary>
    /// Тип тары для груза
    /// </summary>
    abstract class TypeOfTara : IGetWeight
    {
        /// <summary>
        /// Тип груза
        /// </summary>
        protected TypeOfCargo typeOfCargo; 

        /// <summary>
        /// Наименование типа тары
        /// </summary>
        protected string TaraName { get; private set; }

        public TypeOfTara(string taraName)
        {
            TaraName = taraName;
        }

        public override string ToString()
        {
            return TaraName;
        }

        public abstract double GetWeight();
    }
}
