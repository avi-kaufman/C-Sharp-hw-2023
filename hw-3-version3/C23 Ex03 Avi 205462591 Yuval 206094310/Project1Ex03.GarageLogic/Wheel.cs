using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel()
        {
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }    
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }


        public void PumpToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public void AddAirPressure(float i_AirToAdd)
        {
            if (i_AirToAdd + m_CurrentAirPressure > m_MaxAirPressure || i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException("air addition", 0, m_MaxAirPressure - m_CurrentAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format("Tire air pressure: {0}, Tire maximum air pressure: {1}, Tire manufacturer: {2}"
                , m_CurrentAirPressure, m_MaxAirPressure, m_Manufacturer);
        }
    }
}
