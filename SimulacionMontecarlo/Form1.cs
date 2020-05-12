using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Error: Los datos ingresados no son correctos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Simulator simulator = new Simulator();
            int quantity = Convert.ToInt32(this.txtQuantity.Text);
            int from = Convert.ToInt32(this.txtFrom.Text);
            int to = from + 100;
            if (to > quantity)
                to = quantity;
            this.txtTo.Text = to.ToString();

            IList<StateRow> rowsToShow31Seats = simulator.simulate(quantity, from, 31);
            IList<StateRow> rowsToShow32Seats = simulator.simulate(quantity, from, 32);
            IList<StateRow> rowsToShow33Seats = simulator.simulate(quantity, from, 33);
            IList<StateRow> rowsToShow34Seats = simulator.simulate(quantity, from, 34);

            // Poblar grid
            
            this.dgv31Reservations.Rows.Clear();
            this.dgv32Reservations.Rows.Clear();
            this.dgv33Reservations.Rows.Clear();
            this.dgv34Reservations.Rows.Clear();
            this.dgvResult.Rows.Clear();
            for (int i=0; i<rowsToShow31Seats.Count; i++)
            {
                this.dgv31Reservations.Rows.Add(
                    rowsToShow31Seats[i].iterationNum,
                    rowsToShow31Seats[i].rndNumber,
                    rowsToShow31Seats[i].currentPassengers,
                    rowsToShow31Seats[i].deniedSeats,
                    rowsToShow31Seats[i].totalEarnings,
                    rowsToShow31Seats[i].extraPassengersCost,
                    rowsToShow31Seats[i].totalProfit,
                    rowsToShow31Seats[i].acumProfit
                );

                this.dgv32Reservations.Rows.Add(
                    rowsToShow32Seats[i].iterationNum,
                    rowsToShow32Seats[i].rndNumber,
                    rowsToShow32Seats[i].currentPassengers,
                    rowsToShow32Seats[i].deniedSeats,
                    rowsToShow32Seats[i].totalEarnings,
                    rowsToShow32Seats[i].extraPassengersCost,
                    rowsToShow32Seats[i].totalProfit,
                    rowsToShow32Seats[i].acumProfit
                );

                this.dgv33Reservations.Rows.Add(
                    rowsToShow33Seats[i].iterationNum,
                    rowsToShow33Seats[i].rndNumber,
                    rowsToShow33Seats[i].currentPassengers,
                    rowsToShow33Seats[i].deniedSeats,
                    rowsToShow33Seats[i].totalEarnings,
                    rowsToShow33Seats[i].extraPassengersCost,
                    rowsToShow33Seats[i].totalProfit,
                    rowsToShow33Seats[i].acumProfit
                );

                this.dgv34Reservations.Rows.Add(
                    rowsToShow34Seats[i].iterationNum,
                    rowsToShow34Seats[i].rndNumber,
                    rowsToShow34Seats[i].currentPassengers,
                    rowsToShow34Seats[i].deniedSeats,
                    rowsToShow34Seats[i].totalEarnings,
                    rowsToShow34Seats[i].extraPassengersCost,
                    rowsToShow34Seats[i].totalProfit,
                    rowsToShow34Seats[i].acumProfit
                );

                
            }


            this.dgvResult.Rows.Add(
                    31,
                    rowsToShow31Seats.Last().acumProfit
                );
            this.dgvResult.Rows.Add(
                    32,
                    rowsToShow32Seats.Last().acumProfit
                );
            this.dgvResult.Rows.Add(
                    33,
                    rowsToShow33Seats.Last().acumProfit
                );
            this.dgvResult.Rows.Add(
                    34,
                    rowsToShow34Seats.Last().acumProfit
                );

            
        }


            

        private void AllowPositiveIntegerNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidateInputs()
        {
            if (String.IsNullOrEmpty(txtQuantity.Text) || txtQuantity.Text == "0" || String.IsNullOrEmpty(txtFrom.Text) || (Convert.ToInt32(txtQuantity.Text)) < (Convert.ToInt32(txtFrom.Text)))
            {
                return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
