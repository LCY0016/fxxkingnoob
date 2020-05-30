using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace homework5
{
    class Program
    {
        static void Main(string[] args)
        {

            var Goodslist = new List<Order>()
                {
                    new Order()
                    {
                        Customer = "我",
                        GoodsNumber = 1,
                        GoodName = "梨",
                        Money = 10,
                        DetailList =new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Detail = "第一个订单"
                            }
                        }
                    },
                    new Order()
                    {
                        Customer = "我",
                        GoodsNumber = 2,
                        GoodName = "苹果",
                        Money = 5,
                        DetailList =new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Detail = "第二个订单"
                            }
                        }
                    },
                    new Order()
                    {
                        Customer = "他",
                        GoodsNumber = 3,
                        GoodName = "桃",
                        Money = 4,
                        DetailList =new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Detail = "第三个订单"
                            }
                        }
                    },
                    new Order()
                    {
                        Customer = "他",
                        GoodsNumber = 4,
                        GoodName = "苹果",
                        Money = 50,
                        DetailList =new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Detail = "第四个订单"
                            }
                        }
                    }
                };
            //增
            using (var context=new OrdeContext()) 
            {
                Goodslist.ForEach(g => context.Orders.Add(g));
                context.SaveChanges();
            }
            //查
            using (var context = new OrdeContext())
            {
                var order = context.Orders
                    .SingleOrDefault(b => b.GoodsNumber == 1);
                if (order != null) Console.WriteLine(order.GoodName);
            }
            //改
            using (var context = new OrdeContext())
            {
                var order = new Order()
                {
                    Customer = "他",
                    GoodsNumber = 3,
                    GoodName = "桃",
                    Money = 344444
                };
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
            //删
            using (var context = new OrdeContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.GoodsNumber == 2);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }
    }
}
