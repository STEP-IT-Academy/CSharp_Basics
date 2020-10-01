using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_T3.Transportations.FerryBoat

{
    class Ferry
    {
        /// <summary>
        /// Грузоподъемность
        /// </summary>
        public double Carrying { get; private set; } = 6000000;

        /// <summary>
        /// Общий массив для грузов и людей
        /// </summary>
        public IGetWeight[] array { get; private set; }

        public Ferry(IGetWeight[] getWeights)
        {
            array = getWeights;
        }

        /// <summary>
        /// Проверка возможности перевозки груза
        /// </summary>
        public bool IsAbleToTransport()
        {
            double currentWeight = 0;

            foreach (IGetWeight item in array)
            {
                currentWeight += item.GetWeight();
            }

            return currentWeight < Carrying ? true : false;
        }
    }
}
