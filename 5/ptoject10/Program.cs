using System;
using System.Collections.Generic;
using System.Linq;

namespace ptoject10
{
    class Order : IComparable
    {
        public int number { set; get; }
        public string customer { set; get; }
        public List<OrderItem> OrderItems{set; get;}
        public int total
        {
            get {
                int total = 0;
                OrderItems.ForEach(s => total += s.price);
                return total;
                 }
        }
        public Order(int number,string customer,List<OrderItem> x)
        {
            this.number = number;
            this.customer = customer;
            OrderItems = x;
        }
        public override string ToString()
        {
            return number + "-" + customer;
        }

        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m == null && m.number == number;
        }
        public int Compare(Order x)
        {
            return total > x.total ? 1 : -1;
        }

        public int CompareTo(object obj)
        {
            Order s = obj as Order;
            if (s == null)
                throw new System.ArgumentException();
            return this.number.CompareTo(s.number);
        }
    }
    class OrderItem
    {
        public int number { get; set; }
        public int price { get; set; }
        public string goods { get; set; }

        public OrderItem(int number,int price,string goods)
        {
            this.number = number;
            this.price = price;
            this.goods = goods;
        }

        public override string ToString()
        {
            return number + "-" + price+"-"+goods;
        }
        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m == null && m.number == number&&m.price==price &&m.goods==goods;
        }
    }
    class OrderService
    {
        List<Order> orders = new List<Order>() { };
        public OrderService(List<Order> orders)
        {
            this.orders= orders;
        }

        public OrderService()
        {
        }

        public void Query(int number)
        {
            var query = orders.Where(s => s.number < number).OrderBy(s=>s.total);
            List<Order> x= query.ToList();
            x.ForEach(s => Console.WriteLine(s.ToString()));
        }
        public void Querybynumber(int number)
        {
            var query = orders.Where(s => s.number == number);
            List<Order> x = query.ToList();
            x.ForEach(s => Console.WriteLine(s.ToString()));
        }
        public void Querybyname(string name)
        {
            var query = orders.Where(s => s.customer==name);
            List<Order> x = query.ToList();
            x.ForEach(s => Console.WriteLine(s.ToString()));
        }
        public void Compare1()
        {
            orders.Sort();
        }
        public void Compare2()
        {
            orders.Sort((p1, p2) => p1.total - p2.total);
        }
        public bool Add(Order order)
        {
          foreach(Order order1 in orders)
                if(order1.Equals(order))
                {
                    return false;
                }
            orders.Add(order);
            return true;
        }
        public void Display()
        {
            foreach (Order s in orders)
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine();
            }
        }
        public void Delete()
        {
            orders.Clear();
        }
    }
    class Program
    {
     static void Main(string[] args)
        {
            List<OrderItem> items1 = new List<OrderItem>();
            List<OrderItem> items2 = new List<OrderItem>();
            items1.Add(new OrderItem(1000,2,"bigcar"));
            items1.Add(new OrderItem(100000,3,"expensivecar"));
            items1.Add(new OrderItem(500,2,"cheapcar"));
            items2.Add(new OrderItem(1000,1, "bigcar"));
            items2.Add(new OrderItem(100000,1, "expensivecar"));
            items2.Add(new OrderItem(500,1, "cheapcar"));
            OrderService order = new OrderService();
            order.Add(new Order(1, "tang", items1));
            order.Add(new Order(2, "jun", items2));
            order.Compare2();
            order.Display();
            order.Query(3);
            order.Querybynumber(1);
            order.Querybyname("tang");
        }
    }
}
