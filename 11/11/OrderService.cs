using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class OrderService
    {
        public List<Order> Goodslist { get; set; }

        public dynamic OrderBy(Func<Order,dynamic> f)
        {
            return Goodslist.OrderBy(f);
        }

        public void OrderBy()
        {
            Goodslist.OrderBy(g=>g.GoodsNumber);
        }

        public bool Add(Order order)
        {
            if (Goodslist.Exists(g => g.GoodsNumber == order.GoodsNumber))
            {
                return false;
            }
            Goodslist.Add(order);
            return true;
        }

        public bool Delete(int number)
        {
            Order order;
            try
            {
                order = Goodslist.Find(g =>g.GoodsNumber==number);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                return false;
            }
            Goodslist.Remove(order);
            return true;
        }

        public List<Order> Find(Predicate<Order> f)
        {
            return Goodslist.FindAll(f);
        }

        public bool Modify(Order order)
        {
            if (Delete(order.GoodsNumber))
            {
                Add(order);
                return true;
            }
            return false;
        }
    }
}
