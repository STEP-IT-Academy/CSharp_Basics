using System;

namespace Task_3
{
    [Serializable]
    class Sportsman
    {
        public string Surname { get; set; }

        public int Birthday { get; set; }

        public string KindOfSport { get; set; }

        public double Rating { get; set; }
    }
}