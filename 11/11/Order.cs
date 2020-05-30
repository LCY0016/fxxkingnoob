using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Order
    {
        [Key]
        public int GoodsNumber { get; set; }
        public String GoodName { get; set; }
        public String Customer { get; set; }
        public int Money { get; set; }

        public List<OrderItem> DetailList { get; set; }


        public override bool Equals(object obj)
        {
            return GoodsNumber == ((dynamic) obj).GoodsNumber;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var Detail = "";
            DetailList.ForEach(d=>Detail+=d);
            return $"{nameof(GoodsNumber)}: {GoodsNumber}, {nameof(GoodName)}: {GoodName}, {nameof(Customer)}: {Customer}, {nameof(Money)}: {Money}, {nameof(DetailList)}: {Detail}";
        }
    }
}
