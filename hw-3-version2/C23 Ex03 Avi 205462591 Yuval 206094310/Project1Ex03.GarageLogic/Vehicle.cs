using System.Collections.Generic;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private Engine m_Engine;
        private List<Wheel> m_WheelsList;
        private eCurrentCarStatus m_CurrentStatus;

        internal enum eCurrentCarStatus
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
            this.m_CurrentStatus = eCurrentCarStatus.NotFixedYet;
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
            this.m_CurrentStatus = eCurrentCarStatus.NotFixedYet;
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
            get { return m_Engine; }
            set { m_Engine = value; }
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
            get { return m_CurrentStatus; }
            set { this.m_CurrentStatus = value; }
        }

        public override string ToString()
        {
            string wheelsListToString = "";
            for (int i = 0; i < this.Wheels.Count; i++)
            {
                wheelsListToString = string.Format("{0}Wheel {1}: {2}\n", wheelsListToString, i + 1, this.m_WheelsList[i]);
            }

            return string.Format("ModelName: {0}\nLicenseNumber: {1}\n{2}\n{3}\nCurrentStatus: {4}", this.m_ModelName, this.m_LicenseNumber, this.Engine.ToString(), wheelsListToString, this.m_CurrentStatus);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle vehicle)
            {
                return this.m_LicenseNumber == vehicle.m_LicenseNumber;
            }
            return false;
        }


        public static bool AreEqual(Vehicle i_Vehicle1, Vehicle i_Vehicle2)
        {
            return i_Vehicle1.m_LicenseNumber == i_Vehicle2.m_LicenseNumber;
        }

        public override int GetHashCode()
        {
            return m_LicenseNumber?.GetHashCode() ?? 0;
        }

    }
}
