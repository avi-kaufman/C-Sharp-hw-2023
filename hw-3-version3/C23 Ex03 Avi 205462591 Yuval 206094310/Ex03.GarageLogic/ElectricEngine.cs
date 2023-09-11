using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergy, float i_EngineCapcity)
            : base(i_CurrentEnergy, i_EngineCapcity) { }

        public void ChargeEngine(float i_HoursToCharge)
        {
            AddEnergy(i_HoursToCharge);
        }

        public override string ToString()
        {
            return string.Format("Amount of energy left: {0}", this.CurrentEnergy);
        }
    }
}

