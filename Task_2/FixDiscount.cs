/*
 * Разработать второй производный класс (от базового) со скидкой к цене, 
 * если количество единиц товара не меньше некоторой константы подкласса. Переопределить нужные методы. 
 */

using HW4_T2;

namespace Task_2
{
    class FixDiscount : PurchaseGoods
    {

        private const int CountGoodsForDiscount = 10;

        private decimal Discount { get; set; } = 0;

        public FixDiscount(string goodsName, decimal price, int countGoods) : base(goodsName, price, countGoods)
        {
            // Скидка 20%, если количество единиц товара более 10

            if (CountGoods > CountGoodsForDiscount)
            {
                Discount = 20;
            }
        }

        public override decimal GetCost()
        {
            return (base.GetCost() - ((Discount * base.GetCost()) / 100));
        }

        public override string ToString()
        {
            return (base.ToString() + " " + Discount); 
        }
    }
}
