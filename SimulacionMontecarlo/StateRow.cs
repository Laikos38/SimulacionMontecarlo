using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMontecarlo
{
    class StateRow
    {
        public int iterationNum { get; set; }
        public double rndNumber { get; set; }
        public int currentPassengers { get; set; }
        public int deniedSeats { get; set; }
        public int totalEarnings { get; set; }
        public int extraPassengersCost { get; set; }
        public int totalProfit { get; set; }
        public int acumProfit { get; set; }

    }
}
