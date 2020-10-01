using System;

namespace HW_6.GeometricFigures
{
    class Rectangle : Polygon
    {
        // Свойства для чтения сторон
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(string figureName, params double[] sides) : base(figureName, sides)
        {
            Width = (double)sides.GetValue(0);
            Height = (double)sides.GetValue(1);
        }

        public override double GetSquare()
        {
            return (Width * Height);
        }

        public override void ShowFigure()
        {
            
            Console.Write($"║{FigureName, 14}║");
            foreach (int item in Sides)
            {
                Console.Write(" " + item + " ");
            }
            Console.WriteLine($"          ║{GetSquare(),14}║{"-",15}║");
        }

        public override string ToString()
        {
            return base.ToString() + ", площадь: " + GetSquare();
        }
    }
}
