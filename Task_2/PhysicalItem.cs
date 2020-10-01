namespace HW_2_T3
{
    class PhysicalItem
    {
        public PhysicalItem(string nameOfPhysItem, double density)
        {
            NameOfPhysItem = nameOfPhysItem;
            Density = density;
        }

        public string NameOfPhysItem { get; set; }

        public double Density { get; set; }

        public override string ToString()
        {
            return NameOfPhysItem + "; " + Density;
        }

    }
}