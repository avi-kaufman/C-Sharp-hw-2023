using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        enum eCarColor
        {
            
        }

       enum eNumOfDoors
        {
            2,
            3,
            4,
            5,
        }
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;
        public Car(string i_ModelName, string i_LicenseNumber, float i_CurrentPercentageOfEnergyRemaining, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicenseNumber, i_CurrentPercentageOfEnergyRemaining,5)
        {
            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
        }

        public eCarColor CarColor 
        { 
            get { return m_CarColor; } 
            set { m_CarColor = value; } 
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value;}
        }
    }
}
