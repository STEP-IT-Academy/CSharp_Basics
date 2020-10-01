/*
 * Разработать первый производный класс, для покупки товара с фиксированной скидкой от цены 
 * и переопределить нужные методы GetCost() и ToString()
 */

using HW4_T2;

namespace Task_2
{
    class FixDiscountOnPrice : PurchaseGoods
    {
        private decimal FixDiscountPrice { get; set; } = 15;

        private decimal Discount { get; set; } = 0;

        public FixDiscountOnPrice(string goodsName, decimal price, int countGoods) : base(goodsName, price, countGoods)
        {
            // Скидка 30%, если цена более 15р

            if (Price > FixDiscountPrice)
            {
                Discount = 30;
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