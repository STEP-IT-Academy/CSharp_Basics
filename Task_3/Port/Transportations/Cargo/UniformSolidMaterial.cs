namespace HW6_T3.Transportations.Cargo
{
    /// <summary>
    /// Однородный твердый материал
    /// </summary>
    class UniformSolidMaterial : TypeOfCargo
    {
        public UniformSolidMaterial(string cargoName, double density) : base(cargoName, density) { }

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
