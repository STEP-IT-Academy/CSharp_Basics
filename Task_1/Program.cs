using System;
using HW_6.GeometricFigures;

namespace HW_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon[] polygons = new Polygon[4];
            polygons[0] = new Triangle("треугольник", 5, 3, 4);
            polygons[1] = new Triangle("треугольник", 6, 4, 5);
            polygons[2] = new Rectangle("прямоугольник", 4, 2);
            polygons[3] = new Rectangle("прямоугольник", 5, 3);

            Array.Sort(polygons);

            Polygon.ShowFigures(polygons);

            double userValueForSquareCompare = 8.5;
            Console.WriteLine("Заданная величина: " + userValueForSquareCompare + ". Количество фигур, площадь которых меньше заданной = " + CountFiguresWithSquareLessThanUserValue(polygons, userValueForSquareCompare));

            Console.ReadKey();
        }

        /// <summary>
        ///  Определение количества фигур, площадь которых меньше заданной
        /// </summary>
        static int CountFiguresWithSquareLessThanUserValue(Polygon[] polygons, double userValueForSquareCompare)
        {
            short countObjects = 0;
            foreach (Polygon item in polygons)
            {
                if (item.GetSquare() < userValueForSquareCompare) countObjects++;
            }
            return countObjects;
        }
    }
}