using System;

namespace HW_2_T3
{
    class UniformItem
    {
        private PhysicalItem physicalItemObject;

        public string UniformItemName { get; set; }

        public double Volume { get; set; }

        public UniformItem(string nameOfUniformItem, string nameOfPhysItem, double denstiy, double volume)
        {
            physicalItemObject = new PhysicalItem(nameOfPhysItem, denstiy);
            UniformItemName = nameOfUniformItem;
            Volume = volume;
        }

        public override string ToString()
        {
            Console.WriteLine(UniformItemName + "; " + physicalItemObject.NameOfPhysItem + "; " + physicalItemObject.Density + "; " + Volume + "; " + GetMass());
            return UniformItemName + "; " + physicalItemObject.NameOfPhysItem + "; " + physicalItemObject.Density + "; " + Volume + "; " + GetMass();
        }

        public double GetMass()
        {
            return physicalItemObject.Density * Volume;
        }
    }
}