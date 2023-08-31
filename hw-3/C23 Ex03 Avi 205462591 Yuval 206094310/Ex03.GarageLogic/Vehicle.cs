using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_PercentageOfEnergyRemaining;
        private int m_NumOfWheels;
        private List<Wheel> m_WheelsList;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_CurrentPercentageOfEnergyRemaining, int i_NumOfWheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_PercentageOfEnergyRemaining = i_CurrentPercentageOfEnergyRemaining;
            this.m_NumOfWheels = i_NumOfWheels; 
            this.m_WheelsList = new List<Wheel>(i_NumOfWheels);
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public float PercentageOfEnergyRemaining
        {
            get { return m_PercentageOfEnergyRemaining; }
        }

        public List<Wheel> Wheels
        {
            get { return this.m_WheelsList; } 
            set { this.m_WheelsList = value; }
        }
        public int NumOfWheels
        {
            get { return this.m_NumOfWheels; }
        }
    }
}
