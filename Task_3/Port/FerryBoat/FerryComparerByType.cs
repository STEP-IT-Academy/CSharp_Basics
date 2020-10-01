using System;
using System.Collections.Generic;

namespace HW6_T3.Transportations.FerryBoat
{
    class FerryComparerByType : IComparer<IGetWeight>
    {
        private string[] types = { "Person", "RectangularContainer", "Platform", "CylindricalTanks" };

        /// <summary>
        /// Отсортировать содержимое массива по людям и видам транспортировки грузам 
        /// (сначала люди, затем грузы в контейнерах, на платформах, в цистернах).
        /// </summary>
        public int Compare(IGetWeight ferry1, IGetWeight ferry2)
        {
            string obj1 = ferry1.GetType().Name;
            string obj2 = ferry2.GetType().Name;

            int indexObj1 = Array.IndexOf(types, obj1);
            int indexobj2 = Array.IndexOf(types, obj2);

            return indexObj1 - indexobj2;
        }
    }
}
