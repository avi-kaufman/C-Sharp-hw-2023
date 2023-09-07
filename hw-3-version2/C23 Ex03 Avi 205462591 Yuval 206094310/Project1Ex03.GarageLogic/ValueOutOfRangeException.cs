using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }
        public float MinValue
        {
            get { return m_MinValue; }
        }


        public ValueOutOfRangeException(string i_Parameter, float i_MinValue, float i_MaxValue)
            : base(String.Format("Error. The allowed values of {0} are between {1} to {2}.", i_Parameter, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}

