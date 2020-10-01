using System.Xml.Serialization;

namespace HW_Attributes
{
    /// <summary>
    /// Класс Машина
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Марка
        /// </summary>
        [XmlAttribute]
        public string Mark { get; set; }

        /// <summary>
        /// Объем двигателя
        /// </summary>
        public double EngineCapacity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        public Car() { }

        public Car(string mark, double engineCapacity, decimal price)
        {
            this.Mark = mark;
            this.EngineCapacity = engineCapacity;
            this.Price = price;
        }

        public override string ToString() => $"{Mark} с объемом двигателя {EngineCapacity}м3, ценой {Price}$";
    }
}
