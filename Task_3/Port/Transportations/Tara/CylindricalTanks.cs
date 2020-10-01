using HW6_T3.Transportations.Cargo;
using System;

namespace HW6_T3.Transportations.Tara
{
    /// <summary>
    /// Цилиндрические цисетрны
    /// </summary>
    class CylindricalTanks : TypeOfTara
    {
        /// <summary>
        /// Высота
        /// </summary>
        private double Height { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        private double Volume { get; set; }

        /// <summary>
        /// Радиус
        /// </summary>
        private double Radius { get; set; }

        public CylindricalTanks(string taraName, double height, double radius, string cargoName, double cargoDensity) : base(taraName)
        {
            typeOfCargo = new Liquid(cargoName, cargoDensity);
            Height = height;
            Radius = radius;

            Volume = Math.Round(Math.PI * Radius * Radius * Height, 2);
        }

        public override string ToString()
        {
            return base.ToString() + "; Высота: " + Height + "; Радиус: " + Radius + "; Объем: " + Volume + "; Вес: " + GetWeight();
        }

        public override double GetWeight()
        {
            return Math.Round(Volume * typeOfCargo.GetCargoDensity(), 2);
        }
    }
}
