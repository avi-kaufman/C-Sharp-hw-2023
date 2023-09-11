using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_RefrigeratedTruck;
        private float m_CargoVolume;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType, bool i_RefrigeratedTruck, float i_CargoVolume, int i_CurrentAirPresure)
            : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_EngineCapcity, i_FuelType, 12)
        {
            this.m_RefrigeratedTruck = i_RefrigeratedTruck;
            this.m_CargoVolume = i_CargoVolume;
            foreach (Wheel wheel in this.Wheels)
            {
                wheel.CurrentAirPressure = i_CurrentAirPresure;
                wheel.MaxAirPressure = 27;
            }
        
        }

        public bool RefrigeratedTruck
        {
            get { return m_RefrigeratedTruck; }
            set { m_RefrigeratedTruck = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override string ToString()
        {
            string RefrigeratedTruckToString = m_RefrigeratedTruck ? "Support" : "Dosn't support";
            return string.Format("{0}\nRefrigeratedTruck: {1}\nCargoVolume: {2}", base.ToString(), RefrigeratedTruckToString, this.m_CargoVolume);
        }
    }
}
