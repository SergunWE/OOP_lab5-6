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
    public partial class IGuessForm : Form
    {
        protected int _numberAttempt;
        protected int _numberPrompts;
        public IGuessForm()
        {
            InitializeComponent();
        }

        protected virtual void buttonReply_Click(object sender, EventArgs e)
        {

        }

        protected virtual void buttonGetPrompted_Click(object sender, EventArgs e)
        {

        }
    }
}
