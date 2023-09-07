using System;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        public enum eCarColor
        {
            Black,
            White,
            Red,
            Blue,
        }

        public enum eNumOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5,
        }

        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;
        public Car(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_EngineCapcity, 5)
        {
            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergy, float i_EngineCapcity, eFuelType i_FuelType, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicenseNumber, i_CurrentEnergy, i_EngineCapcity, i_FuelType, 5)
        {
            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set
            {
                if (!Enum.IsDefined(typeof(eCarColor), value))
                {
                    throw new ArgumentException("Invalid car color provided.");
                }
                m_CarColor = value;
            }
        }


        public eNumOfDoors NumberOfDoors
        {
            get { return m_NumOfDoors; }
            set
            {
                if (value >= eNumOfDoors.TwoDoors && value <= eNumOfDoors.FiveDoors)
                {
                    m_NumOfDoors = value;
                }
                else
                {
                    throw new ValueOutOfRangeException($"Number of doors provided {value} is out of range.", 2, 5);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\nColor: {1}\nNumOfDoors: {2}", base.ToString(), this.m_CarColor, this.m_NumOfDoors);
        }
    }
}
