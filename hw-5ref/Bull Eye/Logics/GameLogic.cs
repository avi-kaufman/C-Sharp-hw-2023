namespace Bull_Eye.Logics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Bull_Eye.Models;

    public class GameLogic
    {
        private string m_SecretCode;
        public const int m_MinGuess = 4;
        public const int m_MaxGuess = 10;
        private const string m_StartGuess = "####";
        public const char m_FirstChar = 'A';
        public const int m_MaxCount = 4;
        public const int m_MinRange = 0;
        public const int m_MaxRange = 7;
        private List<PlayerGuess> m_GeussList;
        private int m_MaxOfGeusses;
        private int m_CurrentGuess;

        public GameLogic()
        {
            m_CurrentGuess = 0;
            m_GeussList = new List<PlayerGuess>();
            m_GeussList.Add(new PlayerGuess(m_StartGuess, string.Empty));
            SecretCodeGenerate();
        }

        public int MaxOfGeuss
        {
            get
            {
                return m_MaxOfGeusses;
            }

            set
            {
                m_MaxOfGeusses = value;
            }
        }

        private void SecretCodeGenerate()
        {
            StringBuilder secretCode = new StringBuilder();
            char RandomChar = char.MinValue;

            secretCode.Append((char)(m_FirstChar + new Random().Next(m_MinRange, m_MaxRange)));
            for (int Count = 1; Count < m_MaxCount; Count++)
            {
                bool DiffrentChars = false;

                while (!DiffrentChars)
                {
                    RandomChar = (char)(m_FirstChar + new Random().Next(m_MinRange, m_MaxRange));
                    if (secretCode.ToString().Contains(RandomChar))
                    {
                        DiffrentChars = false;
                    }
                    else
                    {
                        DiffrentChars = true;
                    }
                }

                secretCode.Append(RandomChar);
            }

            m_SecretCode = secretCode.ToString();
        }

        public string IsBull(string i_UserGuess, string i_SecretCode)
        {
            const char o_Bull = 'V';
            StringBuilder o_printBull = new StringBuilder();

            foreach (char Char in i_UserGuess)
            {
                if (i_SecretCode.Contains(Char) && i_SecretCode.IndexOf(Char) == i_UserGuess.IndexOf(Char))
                {
                    o_printBull.Append(o_Bull);
                }
            }

            return o_printBull.ToString();
        }

        public string IsPgia(string i_UserGuess, string i_SecretCode)
        {
            const char o_Pgia = 'X';
            StringBuilder o_PrintPgia = new StringBuilder();

            foreach (char Char in i_UserGuess)
            {
                if (i_SecretCode.Contains(Char) && i_SecretCode.IndexOf(Char) != i_UserGuess.IndexOf(Char))
                {
                    o_PrintPgia.Append(o_Pgia);
                }
            }

            return o_PrintPgia.ToString();
        }

        public string ResultOfGuess(string i_SecretCode, string i_UserGuess)
        {
            string pgia = IsPgia(m_SecretCode, i_UserGuess);
            string bulls = IsBull(m_SecretCode, i_UserGuess);
            string resultOfGuess = bulls + pgia;

            return resultOfGuess;
        }

        public bool isVictory(string i_Result)
        {
            bool victory = false;
            const string victoryString = "VVVV";
            if (i_Result.Equals(victoryString))
            {
                victory = true;
            }

            return victory;
        }

        public bool isFail()
        {
            int numOfGeuss = NumberOfGuesses();
            bool fail = false;

            if (numOfGeuss == m_MaxOfGeusses)
            {
                m_GeussList.ElementAt(0).Geuss = m_SecretCode;
                fail = true;
            }

            return fail;
        }

        public void AddGuess(string i_Guess)
        {
            string GuessResult = ResultOfGuess(m_SecretCode, i_Guess);
            PlayerGuess currentGeuss = new PlayerGuess(i_Guess, GuessResult);

            m_GeussList.Add(currentGeuss);
        }

        public int NumberOfGuesses()
        {
            return m_GeussList.Count - 1;
        }

        public PlayerGuess LastGuess()
        {
            return m_GeussList.ElementAt(m_GeussList.Count - 1);
        }

        public List<PlayerGuess> ListOfGuesses
        {
            get
            {
                return m_GeussList;
            }
        }

        public int CurrentGuess
        {
            get
            {
                return m_CurrentGuess;
            }

            set
            {
                m_CurrentGuess = value;
            }
        }

        public void PlayAgain()
        {
            m_GeussList.Clear();
            Ex02.ConsoleUtils.Screen.Clear();
            m_GeussList.Add(new PlayerGuess(m_StartGuess, string.Empty));
            SecretCodeGenerate();
        }

        public string SecretCode
        {
            get
            {
                return m_SecretCode;
            }
        }
    }
}
