namespace HW6_T3.Transportations.People
{
    class Person : IGetWeight
    {
        /// <summary>
        /// ФИО
        /// </summary>
        private string PersonName { get; set; }

        /// <summary>
        /// Вес человека
        /// </summary>
        private double PersonWeight { get; set; }

        /// <summary>
        /// Статус человека на пароме(пассажир, капитан парома и т.д.)
        /// </summary>
        private string PersonPosition { get; set; }

        public Person(string position, string name, double weight)
        {
            PersonName = name;
            PersonWeight = weight;
            PersonPosition = position;
        }

        public double GetWeight()
        {
            return PersonWeight;
        }

        public override string ToString()
        {
            return "Статус: " + PersonPosition + "; ФИО: " + PersonName + "; Вес: " + PersonWeight;
        }
    }
}
