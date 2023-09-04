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
        private Engine = m_Engine;
        private List<Wheel> m_WheelsList;
        private eCurrentCarStatus m_CurrentStatus;

        public enum eCurrentCarStatus
        {
            NotFixedYet,
            Fixed,
            Paid,
        }
        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, int i_NumOfWheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = new ElectricEngine(i_CurrentEnergy, i_EngineCapcity);
            this.m_WheelsList = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                this.m_WheelsList[i] = new Wheel();
            }
            this.m_CurrentCarStatus = eCurrentCarStatus.NotFixedYet;
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType, int i_NumOfWheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Engine = new FuelEngine(i_CurrentEnergy, i_EngineCapcity, i_FuelType);
            this.m_WheelsList = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                this.m_WheelsList[i] = new Wheel();
            }
            this.m_CurrentCarStatus = eCurrentCarStatus.NotFixedYet;
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }    
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }    
        }

        public Engine Engine
        {
            get { return m_Engine}
            set { m_Engine  = value; }  
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

        public eCurrentCarStatus CurrentStatus
        {
            get { return m_CurrentCarStatus; }
            set { this.m_CurrentCarStatus = value; }
        }

        /// need to fix to string engine and wheels
        public override string ToString()
        {
            WheelsListToString = "";
            for (int i = 0; i < this.Wheels.Count; i++)
            {
                WheelsListToString += whell(i+1) + (this.Wheels[i].ToString() + "\n");
            }
            return string.Format("ModelName: {0}\nLicenseNumber: { 1}\n{2}\n{3}\nCurrentStatus: {4}", this.m_ModelName, this.m_LicenseNumber, this.Engine.ToString, WheelsListToString, this.m_CurrentStatus);
        }

        public override bool Equals(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_obj1.m_LicenseNumber == i_Vehicle2.m_LicenseNumber;
        }
    }
}
