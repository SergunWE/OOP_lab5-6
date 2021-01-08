using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_lab5_6
{
    public partial class Tutorial : Form
    {
        public Tutorial()
        {
            InitializeComponent();
            label1.Text = "Вам необходимо ввести два треугольника. На их основе будет построен треугольник-наследник, который вам необходимо угадать. Чтобы получить ответ, делайте попытки и используйте подсказки. Удачи!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
