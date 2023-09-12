using System;

namespace Ex04.Menus.Delegates
{
    public class ValueOutOfRangeException : Exception
    {
        int MaxValue;
        int MinValue;
        public ValueOutOfRangeException(int i_MinValue, int i_MaxValue) :
            base(string.Format("please enter values between {0} - {1}", i_MinValue, i_MaxValue))
        {
            this.MaxValue = i_MaxValue;
            this.MinValue = i_MinValue;
        }
    }
}
