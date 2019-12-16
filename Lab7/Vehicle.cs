using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    enum State
    {
        State_Stationary,
        State_Moving
    };

    abstract class Vehicle : IMoving, IFuel
    {
        protected int m_meanSpeed { get; set; }
        protected State m_state;

        protected int m_fuel, m_fuelAmount;

        public bool IsMoving()
        {
            if (m_state == State.State_Moving)
                return true;
            else
                return false;
        }

        public bool IsEmpty()
        {
            return m_fuel == 0;
        }

        public void Refuel()
        {
            m_fuel = m_fuelAmount;
        }

        public int GetFuel()
        {
            return m_fuel;
        }

        public int Speed
        {
            get
            {
                return m_meanSpeed;
            }
            set
            {
                m_meanSpeed = value;
                if (value != 0)
                    m_state = State.State_Moving;
                else
                    m_state = State.State_Stationary;
            }
        }

        public abstract String GetVehicleType();

        public void FuelDecrease()
        {
            m_fuel--;
        }
    }
}
