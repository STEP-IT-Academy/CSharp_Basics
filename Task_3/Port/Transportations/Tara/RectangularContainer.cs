using HW6_T3.Transportations.Cargo;
using System;

namespace HW6_T3.Transportations.Tara
{
    /// <summary>
    /// Прямоугольный контейнер
    /// </summary>
    class RectangularContainer : TypeOfTara
    {
        /// <summary>
        /// Ширина
        /// </summary>
        private double Width { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        private double Height { get; set; }

        /// <summary>
        /// Длина
        /// </summary>
        private double Length { get; set; }

        /// <summary>
        /// Объем
        /// </summary>
        private double Volume { get; set; }

        public RectangularContainer(string taraName, double width, double height, double length, string cargoName, double cargoDensity) : base(taraName)
        {
            typeOfCargo = new UniformSolidMaterial(cargoName, cargoDensity);
            Width = width;
            Height = height;
            Length = length;

            Volume = Math.Round(Width * Length * Height, 2);
        }

        public override string ToString()
        {
            return base.ToString() + "; Ширина: " + Width + "; Высота: " + Height + "; Длина: " + Length + "; Объем: " + Volume + "; Вес: " + GetWeight();
        }

        public override double GetWeight()
        {
            return Math.Round(Volume * typeOfCargo.GetCargoDensity(), 2);
        }
    }
}
