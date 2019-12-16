using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Express : Train, ITicket
    {
        private int m_ticketCostPerStop { get; set; }

        public Express(int speed, int capacity, int cost, int fuelAmount) : base (speed,capacity, fuelAmount)
        {
            m_ticketCostPerStop = cost;
        }

        public int TicketCost
        {
            get
            {
                return m_ticketCostPerStop;
            }
            set
            {
                m_ticketCostPerStop = value;
            }
        }

        public int GetTicketCost(int nStops)
        {
            return nStops * m_ticketCostPerStop;
        }

        public override string GetVehicleType()
        {
            return "Экспресс";
        }
    }
}
