using System;

namespace HW_6.GeometricFigures
{
    class Triangle : Polygon
    {
        // Свойства для чтения сторон
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }

        public Triangle(string figureName, params double[] sides) : base(figureName, sides)
        {
            Side1 = (double)sides.GetValue(0);
            Side2 = (double)sides.GetValue(1);
            Side3 = (double)sides.GetValue(2);
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double GetSquare()
        {
            double halfPerimeter = (Side1 + Side2 + Side3) / 2;
            return Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - Side1) * (halfPerimeter - Side2) * (halfPerimeter - Side3)), 2);
        }

        /// <summary>
        /// Вычисление периметра треугольника
        /// </summary>
        public double GetPerimetr()
        {
            return (Side1 + Side2 + Side3);
        }

        public override string ToString()
        {
            return base.ToString() + ", площадь: " + GetSquare() + ", периметр: " + GetPerimetr();
        }

        public override void ShowFigure()
        {
            Console.Write($"║{FigureName, 14}║");
            foreach (int item in Sides)
            {
                Console.Write(" " + item + " ");
            }
            Console.WriteLine($"       ║{GetSquare(),14}║ {GetPerimetr(), 14}║");
        }
    }
}
