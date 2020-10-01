namespace HW6_T3.Transportations.Cargo
{
    /// <summary>
    /// Жидкость
    /// </summary>
    class Liquid : TypeOfCargo
    {
        public Liquid(string cargoName, double density) : base(cargoName, density) { }

        public override double GetCargoDensity()
        {
            return Density;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
