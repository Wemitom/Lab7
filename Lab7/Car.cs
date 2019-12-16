using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    enum Blinkers
    {
        Blinkers_Off,
        Blinkers_Left,
        Blinkers_Right
    }

    class Car : Vehicle, IBlinkers
    {
        private Blinkers m_blinkers = Blinkers.Blinkers_Off;

        private String m_brand { get;}

        public Car(int speed, String brand, int fuelAmount)
        {
            m_meanSpeed = speed;
            if (speed != 0)
                m_state = State.State_Moving;
            else
                m_state = State.State_Stationary;

            m_brand = brand;

            m_fuelAmount = fuelAmount;
        }

        public bool BlinkersLeft(int state)
        {
            if(state == 0)
                m_blinkers = Blinkers.Blinkers_Left;
            return m_blinkers == Blinkers.Blinkers_Left;
        }

        public bool BlinkersRight(int state)
        {
            if (state == 0)
                m_blinkers = Blinkers.Blinkers_Right;
            return m_blinkers == Blinkers.Blinkers_Right;
        }

        public bool BlinkersOff(int state)
        {
                        if(state == 0)
            m_blinkers = Blinkers.Blinkers_Off;
            return m_blinkers == Blinkers.Blinkers_Off;
        }

        public String CarBrand
        {
            get
            {
                return m_brand;
            }
        }

        public override string GetVehicleType()
        {
            return "Легковой автомобиль";
        }
    }
}