using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal enum eCarColor
        {
            Black,
            White,
            Red,
            Blue,
        }

        internal enum eNumOfDoors
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

        public eCarColor Color
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }
        ///need to fis to string enum.ToString
        public override string ToString()
        {
            return string.Format("{0}\nColor: {1}\nNumOfDoors: {2}", base.ToString(), this.m_CarColor.ToString(), this.m_NumOfDoors.ToString());
        }
    }
}
