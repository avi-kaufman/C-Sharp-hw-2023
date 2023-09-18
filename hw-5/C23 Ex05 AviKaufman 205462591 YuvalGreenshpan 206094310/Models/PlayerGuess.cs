using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    public class PlayerGuess
    {
        private string m_Result;
        private const string m_QuitGame = "Q";
        private string m_Geuss;


        public PlayerGuess(string i_Guess)
        {
            m_Geuss = i_Guess;
        }

        public PlayerGuess(string i_Guess, string i_Result)
        {
            m_Geuss = i_Guess;
            m_Result = i_Result;
        }

        public string Geuss
        {
            get
            {
                return m_Geuss;
            }

            set
            {
                m_Geuss = value;
            }
        }

        public string Result
        {
            get
            {
                return m_Result;
            }

            set
            {
                m_Result = value;
            }
        }

        public static bool GeussValidation(string i_ValidationString)
        {
            bool o_Status = true;

            if (i_ValidationString.Length != GameLogic.m_MaxCount)
            {
                if (i_ValidationString.ToUpper().Equals(m_QuitGame))
                {
                    o_Status = true;
                }
                else
                {
                    o_Status = false;
                }
            }
            else
            {
                if (!isDiffrentChars(i_ValidationString) || !isValidRange(i_ValidationString))
                {
                    o_Status = false;
                }
            }

            return o_Status;
        }


        private static bool isDiffrentChars(string i_StringDiffrentCharacters)
        {
            bool o_DiffrentChars = true;
            int NumberOfDiffrent = 0;

            foreach (char Char in i_StringDiffrentCharacters)
            {
                int Index = Char - GameLogic.m_FirstChar;

                if ((NumberOfDiffrent & (1 << Index)) > 0)
                {
                    o_DiffrentChars = false;
                }

                NumberOfDiffrent = NumberOfDiffrent | (1 << Index);
            }

            return o_DiffrentChars;
        }

        private static bool isValidRange(string i_StringRange)
        {
            bool o_Range = true;

            foreach (char validateChar in i_StringRange)
            {
                if ((int)char.ToUpper(validateChar) - GameLogic.m_FirstChar < GameLogic.m_MinRange ||
                    (int)char.ToUpper(validateChar) - GameLogic.m_FirstChar > GameLogic.m_MaxRange)
                {
                    o_Range = false;
                }
            }

            return o_Range;
        }


    }
}