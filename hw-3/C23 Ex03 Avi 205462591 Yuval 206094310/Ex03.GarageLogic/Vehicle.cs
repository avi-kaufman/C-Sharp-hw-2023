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
        ///private Engine = m_Engine;
        private float m_PercentageOfEnergyRemaining;  
        private List<Wheel> m_WheelsList;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_CurrentPercentageOfEnergyRemaining, int i_NumOfWheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            ////this.m_Engine = i_Engine;
            this.m_PercentageOfEnergyRemaining = i_CurrentPercentageOfEnergyRemaining;
            this.m_WheelsList = new List<Wheel>(i_NumOfWheels);
            for(int i = 0;i < i_NumOfWheels; i++)
            {
                this.m_WheelsList[i] = new Wheel();
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        //public Engine Engine
        //{
        //    get { return i_Engine}
        //}

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
            get { return this.m_WheelsList.Count; }
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return "";
        }
        public override bool Equals(Object obj)
        {
            return false;
        }
    }
}
