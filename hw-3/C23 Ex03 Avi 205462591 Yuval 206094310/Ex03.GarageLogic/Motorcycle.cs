using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseType
        {
            A,
            A1,
            A2,
            AB
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacityInCubicCentimeter;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_CurrentPercentageOfEnergyRemaining,
            eLicenseType i_LicenseType, int i_EngineCapacityInCubicCentimeter)
            : base(i_ModelName, i_LicenseNumber, i_CurrentPercentageOfEnergyRemaining, 2)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacityInCubicCentimeter = i_EngineCapacityInCubicCentimeter;
        }

        public eLicenseType MotorcycleLicenseType
        {
            get { return this.m_LicenseType; }
            set { this.m_LicenseType = value; }
        }

        public int EngineCapacityInCubicCentimeter
        {
            get { return m_EngineCapacityInCubicCentimeter; }
            set { m_EngineCapacityInCubicCentimeter = value; }

        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        public override bool Equals(Object i_Obj)
        {
            return false;
        }
    }
}

