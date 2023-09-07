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

        public eColorOfCar CarColor
        {
            get { return m_CarColor; }
            set
            {
                if (!Enum.IsDefined(typeof(eColorOfCar), value))
                {
                    throw new ArgumentException("Invalid car color provided.");
                }
                m_ColorOfCar = value;
            }
        }


        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set
            {
                if (value < 2 || value > 5)
                {
                    throw new ValueOutOfRangeException($"Number of doors provided {value} is out of range.", 2, 5);
                }
                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\nColor: {1}\nNumOfDoors: {2}", base.ToString(), this.m_CarColor, this.m_NumOfDoors);
        }
    }
}
