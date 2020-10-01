using System;
using System.Xml.Serialization;

namespace HW_Attributes
{
    /// <summary>
    /// Класс чей-то машины
    /// </summary>
    public class SomeonesCar : Car
    {
        /// <summary>
        /// Год выпуска
        /// </summary>
        public int YearOfIssue { get; set; }

        /// <summary>
        /// Владлеце
        /// </summary>
        public Person Owner { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        [XmlAttribute]
        public string Color { get; set; }

        public SomeonesCar() { }

        public SomeonesCar(Person owner, Car car, int carYearOfIssue, string carColor) : base(car.Mark, car.EngineCapacity, car.Price)
        {
            Owner = owner;
            YearOfIssue = carYearOfIssue;
            Color = carColor;
        }

        public override string ToString() => $" автомобиля: {base.ToString()} и {YearOfIssue} года выпуска в {Color} цвете.";

        /// <summary>
        /// Метод, определяющий возраст автомобиля.
        /// </summary>
        public int FindTheAgeOfTheCar() => DateTime.Now.Year - YearOfIssue;
    }
}