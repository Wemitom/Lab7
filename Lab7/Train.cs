using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Train : Vehicle, IPath
    {
        protected int m_capacity { get; set; }

        protected List<String> m_path { get; } = new List<String>();

        public Train(int speed, int capacity, int fuelAmount)
        {
            m_meanSpeed = speed;
            if (speed != 0)
                m_state = State.State_Moving;
            else
                m_state = State.State_Stationary;

            m_capacity = capacity;

            m_fuelAmount = fuelAmount;
        }

        public int Capacity
        {
            get
            {
                return m_capacity;
            }
        }

        public List<String> Path
        {
            get
            {
                return m_path;
            }
        }

        public override string GetVehicleType()
        {
            return "Поезд";
        }

        public void AddAStop(String stop)
        {
            m_path.Add(stop);
        }

        public void RemoveAStop(String stop)
        {
            var stopIndex = 0;
            var pathLength = m_path.Count;
            while (m_path[stopIndex] != stop && stopIndex < pathLength)
            {
                stopIndex++;
            }
            m_path.RemoveAt(stopIndex);
        }
    }
}
