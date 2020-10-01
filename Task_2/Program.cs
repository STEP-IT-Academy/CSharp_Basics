using HW4_T2;
using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseGoods[] purchaseGoods = new PurchaseGoods[6];
            purchaseGoods[0] = new PurchaseGoods("Батончики", 1.56m, 22);
            purchaseGoods[1] = new PurchaseGoods("Печенье", 1.15m, 10);
            purchaseGoods[2] = new FixDiscountOnPrice("Шампунь", 3.35m, 5);
            purchaseGoods[3] = new FixDiscountOnPrice("Стулья", 40.5m, 33);
            purchaseGoods[4] = new FixDiscount("Шпалы", 120m, 100);
            purchaseGoods[5] = new FixDiscount("Ручки", 0.69m, 41);

            decimal maxCostPurchase = 0;
            int maxPurchaseIndex = 0;
            bool equalPurchases = true;

            for (int i = 0; i < purchaseGoods.Length; i++)
            {
                Console.WriteLine(purchaseGoods[i]);

                if (purchaseGoods[i].GetCost() > maxCostPurchase)
                {
                    maxCostPurchase = purchaseGoods[i].GetCost();
                    maxPurchaseIndex = i;
                }

                if (i > 0 && equalPurchases)
                {
                    equalPurchases = purchaseGoods[i - 1].Equals(purchaseGoods[i]);
                }

                if (i == (purchaseGoods.Length - 1))
                {
                    Console.WriteLine("Покупка с максимальной стоимостью: " + purchaseGoods[maxPurchaseIndex]);

                    if (equalPurchases) Console.WriteLine("Все покупки равны!");
                    else Console.WriteLine("Покупки не равны!");
                }
            }

            Console.ReadKey();
        }
    }
}