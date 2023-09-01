using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle 
    {
        private bool m_RefrigeratedTruck;
        private float m_CargoVolume;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentPercentageOfEnergyRemaining, bool i_RefrigeratedTruck ,float i_CargoVolume)
            : base(i_ModelName, i_LicenseNumber, i_CurrentPercentageOfEnergyRemaining, 12) 
        {
            this.m_RefrigeratedTruck = i_RefrigeratedTruck; 
            this.m_CargoVolume = i_CargoVolume;
        }
        
        public bool RefrigeratedTruck
        {
            get { return m_RefrigeratedTruck;}
            set { m_RefrigeratedTruck= value;}
        }
        public float CargoVolume
        {
            get { return m_CargoVolume;}
            set { m_CargoVolume = value;}
        }
        /// <summary>
        /// /////////////////////////
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
