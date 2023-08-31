using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private enum eLicenseType
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
            : base(i_ModelName, i_LicenseNumber, i_CurrentPercentageOfEnergyRemaining)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineCapacityInCubicCentimeter = i_EngineCapacityInCubicCentimeter;
            this.NumOfWheels = new List<Wheel>(2);
        }

        public enum LicenseType
        {
            get {return 
        }

    }

}

