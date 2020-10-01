namespace HW6_T3.Transportations.Cargo
{
    /// <summary>
    /// Тип перевозимых грузов
    /// </summary>
    abstract class TypeOfCargo
    {
        /// <summary>
        /// Название типа груза
        /// </summary>
        protected string CargoName { get; private set; }

        /// <summary>
        /// Плотность груза
        /// </summary>
        protected double Density { get; private set; }

        protected TypeOfCargo(string cargoName, double density)
        {
            CargoName = cargoName;
            Density = density;
        }

        public abstract double GetCargoDensity();

        public override string ToString()
        {
            return CargoName + "; Плотность: " + Density;
        }
    }
}
