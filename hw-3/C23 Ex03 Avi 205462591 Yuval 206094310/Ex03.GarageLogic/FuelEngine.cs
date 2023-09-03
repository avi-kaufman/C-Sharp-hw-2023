using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType)
            : base(i_CurrentEnergy, i_EngineCapcity)
        {
            if (!Enum.IsDefined(typeof(eFuelType), i_FuelType))
            {
                throw new ArgumentException("Invalid gas type.");
            }
            m_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public void AddFuel(float i_FuelToAdd, string i_FuelType)
        {
            if (!i_FuelType.Equals(m_FuelType.ToString())) //need to check if this works
            {
                throw new ArgumentException("Invalid gas type.");
            }
            else
            {
                base.AddEnergy(i_FuelToAdd);
            }
        }
        public override string ToString()
        {
            return string.Format("Fuel type: {0}\nAmount of fuel left: {1}", m_FuelType, this.m_CurrentEnergy);
        }
    }
}

