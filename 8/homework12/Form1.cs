using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework12
{
    public partial class Form1 : Form
    {
        OrderService os;

        public string id { get; set; }

        public Order newOrder { get; set; }

        public Form1()
        {
            InitializeComponent();
            os = new OrderService();

            OrderItem car = new OrderItem("car", 20, 1);
            OrderItem truck = new OrderItem("truck", 50, 2);
            OrderItem suv = new OrderItem("suv", 30, 1);

            Order order1 = new Order(1, "张三", new List<OrderItem> { car, suv });
            Order order2 = new Order(2, "李四", new List<OrderItem> { truck, suv });

            os.AddOrder(order1);
            os.AddOrder(order2);

            orderBindingSource.DataSource = os.Orders;
            textBox1.DataBindings.Add("Text", this, "id");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Owner = this;
            form2.ShowDialog();
            os.Orders.Add(newOrder);
            MessageBox.Show(newOrder.ToString());
            orderBindingSource.DataSource = os.Orders;
            orderBindingSource.ResetBindings(false);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Order currentOrder = orderBindingSource.Current as Order;
            os.RemoveOrder(currentOrder.OrderId);
            orderBindingSource.ResetBindings(false);
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            uint.TryParse(id, out uint result);
            orderBindingSource.DataSource = os.Orders.Where(s => s.OrderId == result);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                os.Import(openFileDialog.FileName);
                orderBindingSource.DataSource = os.Orders;
                orderBindingSource.ResetBindings(false);
                MessageBox.Show("导入成功");
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                os.Export(saveFileDialog.FileName);
                MessageBox.Show("导出成功");
            }
        }
    }
}
