using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

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

        public string FuelType
        {
            get { return m_FuelType.ToString(); }
            set
            {
                if (Enum.TryParse<eFuelType>(value, out eFuelType parsedFuelType))
                {
                    m_FuelType = parsedFuelType;
                }
                else
                {
                    throw new ArgumentException("Invalid fuel type string.");
                }
            }
        }


        public void AddFuel(float i_FuelToAdd, string i_FuelType)
        {
            if (!i_FuelType.Equals(m_FuelType.ToString())) 
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
            return string.Format("Fuel type: {0}\nAmount of fuel left: {1}", m_FuelType, this.CurrentEnergy);
        }
    }
}

