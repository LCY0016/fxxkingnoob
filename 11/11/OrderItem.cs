using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class OrderItem
    {
        public int OrderId { get; set; }
        public String Detail { get; set; }

        public override string ToString()
        {
            return $"{nameof(Detail)}: {Detail}";
        }

        public override bool Equals(object obj)
        {
            OrderItem orderItem=obj as  OrderItem;
            return orderItem.Detail == Detail;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
