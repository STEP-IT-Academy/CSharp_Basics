using System;

namespace HW_6.GeometricFigures
{
    abstract class Polygon : IComparable
    {
        /// <summary>
        /// название фигуры
        /// </summary>
        public string FigureName { get; private set; }

        /// <summary>
        /// массив сторон
        /// </summary>
        public double[] Sides { get; private set; }

        public Polygon(string figureName, params double[] sides)
        {
            FigureName = figureName;
            Sides = sides;
        }

        public override string ToString()
        {

            string str = "Фигура: " + FigureName + ", стороны: ";
            foreach (int item in Sides)
            {
                Console.Write(item + " ");
            }
            return str;
        }

        /// <summary>
        /// Вычисление площади многоугольника
        /// </summary>
        abstract public double GetSquare();

        /// <summary>
        /// Сравнение по площади многоугольников
        /// </summary>
        public int CompareTo(object obj)
        {
            Polygon polygon = obj as Polygon;
            if (polygon != null) return -(GetSquare().CompareTo(polygon.GetSquare()));
            else throw new Exception("Не удается сравнить 2 объекта!");
        }

        abstract public void ShowFigure();

        public static void ShowFigures(params Polygon[] polygons)
        {
            Console.WriteLine("╔══════════════╦════════════════╦══════════════╦═══════════════╗");
            Console.WriteLine("║    Фигура    ║     Стороны    ║    Площадь   ║    Периметр   ║");
            Console.WriteLine("╠══════════════╬════════════════╬══════════════╬═══════════════╣");

            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].ShowFigure();

                if (i == polygons.Length - 1) 
                {
                    Console.WriteLine("╚══════════════╩════════════════╩══════════════╩═══════════════╝");
                }
                else Console.WriteLine("╠══════════════╬════════════════╬══════════════╬═══════════════╣");
            }
        }
    }
}
