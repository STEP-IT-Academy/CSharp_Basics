/*
 * Разработать базовый класс, определяющий покупку товара:
 * Поля:
 *      ●	название товара;		
 *      ●	цена в рублях;
 *      ●	кол-во единиц товара.
 * Конструкторы:
 *      ●	по умолчанию;
 *      ●	с параметрами.
 * Методы:
 *      ●	установки/считывания полей;
 *      ●	GetCost() – вычисляет стоимость покупки;
 *      ●	ToString() – переводит объект в строку с разделителями «;»;
 *      ●	Equals() – сравнивает две продажи(считаются равными, если совпадают название и цена).
 */

using System.Collections.Generic;

namespace HW4_T2
{
    class PurchaseGoods
    {
        protected string GoodsName { get; set; }
        protected decimal Price { get; set; }
        protected int CountGoods { get; set; }

        public PurchaseGoods()
        {
            GoodsName = null;
            Price = 0;
            CountGoods = 0;
        }

        public PurchaseGoods(string goodsName, decimal price, int countGoods)
        {
            GoodsName = goodsName;
            Price = price;
            CountGoods = countGoods;
        }

        public virtual decimal GetCost()
        {
            return (Price * CountGoods);
        }

        public override string ToString()
        {
            return (GoodsName + "; " + Price + "; " + CountGoods + ";");
        }

        public override bool Equals(object obj)
        {
            PurchaseGoods pg = obj as PurchaseGoods;

            return ((GoodsName == pg.GoodsName) && (Price == pg.Price)) ? true : false;
        }

        public override int GetHashCode()
        {
            var hashCode = 2124438946;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + CountGoods.GetHashCode();
            return hashCode;
        }
    }
}
