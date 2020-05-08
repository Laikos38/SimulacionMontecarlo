using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulacionMontecarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtQuantity.Text = "";
            this.txtFrom.Text = "";
            this.txtTo.Text = "";
            this.dgv31Reservations.Rows.Clear();
            this.dgv32Reservations.Rows.Clear();
            this.dgv33Reservations.Rows.Clear();
            this.dgv34Reservations.Rows.Clear();
        }
    }
}
