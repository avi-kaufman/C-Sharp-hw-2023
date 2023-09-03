using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        private float m_CurrentEnergy;
        private float m_EngineCapcity;

        public Engine(float i_CurrentEnergy, float i_EngineCapcity)
        {
            if (i_CurrentEnergy < 0)
            {
                throw new ArgumentException("The reminder of the engine energy cannot be negative!");
            }
            else
            {
                m_CurrentEnergy = i_CurrentEnergy;
            }

            if (i_EngineCapcity <= 0)
            {
                throw new ArgumentException("The capacity of the engine must be positive!");
            }
            else
            {
                m_EngineCapcity = i_EngineCapcity;
            }
        }

        public virtual void AddEnergy(float i_EnergyToAdd)
        {
            if (m_CurrentEnergy + i_EnergyToAdd > m_EngineCapcity || i_EnergyToAdd < 0)
            {
                throw new ValueOutOfRangeException("Energy addition", 0, m_EngineCapcity - m_CurrentEnergy);
            }
            else
            {
                m_CurrentEnergy += i_EnergyToAdd;
            }
        }
    }
}