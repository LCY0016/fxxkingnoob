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
      public partial class Form2 : Form
    {
        public List<OrderItem> orderItems = new List<OrderItem>();

       /* public Form2(string id,string customer, List<OrderItem> orderItems)
        {
            InitializeComponent();
            this.textBox1.Text = id;
            this.textBox2.Text = customer;
            this.orderItems = orderItems;
            orderItemBindingSource.DataSource = orderItems;
            textBox1.Visible = false;
        }*/
        public Form2()
        {
            InitializeComponent();

            orderItemBindingSource.DataSource = orderItems;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double.TryParse(textBox4.Text, out double price);
            uint.TryParse(textBox5.Text, out uint count);
            orderItems.Add(new OrderItem(textBox3.Text, price, count));
            orderItemBindingSource.ResetBindings(false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            uint.TryParse(textBox1.Text, out uint orderID);
            Order orderModify = new Order(orderID, textBox2.Text, orderItems);
            Form1 form1 = (Form1)this.Owner;
            form1.newOrder = orderModify;
            this.Close();
        }
    }
}
