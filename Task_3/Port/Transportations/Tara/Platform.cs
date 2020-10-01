using System;
using HW6_T3.Transportations.Cargo;

namespace HW6_T3.Transportations.Tara
{
    /// <summary>
    /// Платформа
    /// </summary>
    class Platform : TypeOfTara
    {
        /// <summary>
        /// Наименование груза 
        /// </summary>
        private string CargoName { get; set; }

        /// <summary>
        /// Вес груза 
        /// </summary>
        private double CargoMass { get; set; }

        public Platform(string taraName, string cargoName, double cargoMass) : base(taraName)
        {
            CargoName = cargoName;
            CargoMass = cargoMass;
        }

        public override string ToString()
        {
            return base.ToString() + "; " + CargoName + "; Вес: " + CargoMass;
        }

        public override double GetWeight()
        {
            return Math.Round(CargoMass, 2);
        }
    }
}
