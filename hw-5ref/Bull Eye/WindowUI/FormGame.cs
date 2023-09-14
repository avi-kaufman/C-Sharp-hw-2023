using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bull_Eye.Models;
using Bull_Eye.Logics;

namespace Bull_Eye.WindowUI
{
    public partial class FormGame : Form
    {
        private const int k_NumberOfValues = 4;
        private GameLogic m_GameLogics;
        private List<List<Button>> m_Guesses = new List<List<Button>>();
        private List<Button> m_GuessArrow = new List<Button>();
        private List<List<Button>> m_Answers = new List<List<Button>>();
        private Dictionary<string, string> m_ColorsToChar;
        
        public FormGame()
        {
            m_GameLogics = new GameLogic();
            m_GameLogics.MaxOfGeuss = FormSettings.NumberOfChances;

            InitializeComponent();
            GuessesComponent();
            InitializeColorsToChar();
        }

        private void InitializeColorsToChar()
        {
            m_ColorsToChar = new Dictionary<string, string>();
            m_ColorsToChar.Add("Purple", "A");
            m_ColorsToChar.Add("Red", "B");
            m_ColorsToChar.Add("Lime", "C");
            m_ColorsToChar.Add("Cyan", "D");
            m_ColorsToChar.Add("Blue", "E");
            m_ColorsToChar.Add("Yellow", "F");
            m_ColorsToChar.Add("Brown", "G");
            m_ColorsToChar.Add("White", "H");
        }

        private void GuessesComponent()
        {
            int topLocation = 70;
            const int k_additionToTopLocation = 30;
            const int k_additionToRightLocation = 49;

            for (int i = 0; i < FormSettings.NumberOfChances; i++)
            {
                List<Button> tempList = new List<Button>();
                int rightLocation = 20;
                for (int j = 0; j < k_NumberOfValues; j++)
                {
                    Button tempGuessButton = new Button();
                    tempGuessButton.Enabled = false;
                    tempGuessButton.Location = new System.Drawing.Point(rightLocation, topLocation);
                    rightLocation += k_additionToRightLocation;
                    tempGuessButton.Name = string.Format("buttonGuess{0}Place{1}", i, j);
                    tempGuessButton.Size = new System.Drawing.Size(43, 43);
                    tempGuessButton.UseVisualStyleBackColor = false;
                    this.Controls.Add(tempGuessButton);
                    tempGuessButton.Click += new System.EventHandler(this.GuessButton_Click);
                    tempList.Add(tempGuessButton);
                }

                m_Guesses.Add(tempList);
                {
                    Button tempArrowButton = new Button();
                    tempArrowButton.Enabled = false;
                    tempArrowButton.Location = new System.Drawing.Point(rightLocation, topLocation + ((tempList[0].Bottom - tempList[0].Top) / 4));
                    rightLocation += k_additionToRightLocation;
                    tempArrowButton.Name = string.Format("buttonArrow{0}", i);
                    tempArrowButton.Text = "-->>";
                    tempArrowButton.Size = new System.Drawing.Size(43, 20);
                    tempArrowButton.UseVisualStyleBackColor = false;
                    tempArrowButton.Click += new System.EventHandler(this.ArrowButton_Click);

                    this.Controls.Add(tempArrowButton);
                    m_GuessArrow.Add(tempArrowButton);
                }
                
                int additionToRightAnswerLocation = 25;

                tempList = new List<Button>();
                for (int j = 0; j < k_NumberOfValues / 2; j++)
                {
                    int rightAnswerLocation = m_GuessArrow[0].Right + 10;
                    for (int k = 0; k < k_NumberOfValues / 2; k++)
                    {
                        Button tempAnswerButton = new Button();
                        tempAnswerButton.Enabled = false;
                        tempAnswerButton.Location = new System.Drawing.Point(rightAnswerLocation, topLocation);
                        rightAnswerLocation += additionToRightAnswerLocation;
                        tempAnswerButton.Name = string.Format("buttonAnswer{0},Place{1},Line{2}", i, j, k);
                        tempAnswerButton.Size = new System.Drawing.Size(20, 20);
                        tempAnswerButton.UseVisualStyleBackColor = false;
                        this.Controls.Add(tempAnswerButton);
                        tempList.Add(tempAnswerButton);
                    }

                    topLocation += k_additionToTopLocation - 5;
                }

                m_Answers.Add(tempList);
                topLocation += 10;
            }

            this.Height = m_Guesses[FormSettings.NumberOfChances - 1][k_NumberOfValues - 1].Bottom + 50;
            for (int i = 0; i < k_NumberOfValues; i++)
            {
                m_Guesses[m_GameLogics.CurrentGuess][i].Enabled = true;
            }
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            Button currentButtonClicked = sender as Button;
            Color guessColor = GetGuessColorFromUser(currentButtonClicked.BackColor);
            if (isNewGuessColor(guessColor))
            {
                currentButtonClicked.BackColor = guessColor;
                if (isTheRowFullyFilled())
                {
                    m_GuessArrow[m_GameLogics.CurrentGuess].Enabled = true;
                }
            }
        }

        private bool isNewGuessColor(Color i_GuessColor)
        {
            bool haveOneColor = true;

            for (int i = 0; i < k_NumberOfValues; i++)
            {
                string c = m_Guesses[m_GameLogics.CurrentGuess][i].BackColor.Name;
                if (m_Guesses[m_GameLogics.CurrentGuess][i].BackColor.Name == i_GuessColor.Name)
                {
                    haveOneColor = false;
                    break;
                }
            }
            
                return haveOneColor;
        }

        private bool isTheRowFullyFilled()
        {
            bool o_AreAllButtonCollored = true;
            foreach (Button buttonToCheckIfCollored in m_Guesses[m_GameLogics.CurrentGuess])
            {
                if (buttonToCheckIfCollored.BackColor == SystemColors.Control)
                {
                    o_AreAllButtonCollored = false;
                    break;
                }
            }

            return o_AreAllButtonCollored;
        }

        public Color GetGuessColorFromUser(Color i_CurrentColor)
        {
            Color o_ColorToSet;
            FormChooseColor colorPicking = new FormChooseColor();
            if (colorPicking.ShowDialog() == DialogResult.OK)
            {
                o_ColorToSet = colorPicking.PickedColor;
            }
            else
            {
                o_ColorToSet = i_CurrentColor;
            }

            return o_ColorToSet;
        }

        private void ArrowButton_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            StringBuilder colorGuess = new StringBuilder();
            
            foreach(Button buttonToManipulate in m_Guesses[m_GameLogics.CurrentGuess])
            {
                buttonToManipulate.Enabled = false;
                string charOfColor = m_ColorsToChar[buttonToManipulate.BackColor.Name];
                colorGuess.Append(charOfColor);
            }

            m_GuessArrow[m_GameLogics.CurrentGuess].Enabled = false;
            m_GameLogics.AddGuess(colorGuess.ToString());
            ShowResultOfGeuss();
            if (m_GameLogics.isVictory(m_GameLogics.LastGuess().Result))
            {
                ShowComputerPin();
            }
            else if (m_GameLogics.isFail())
            {
                ShowComputerPin();
            }
            else
            {
                m_GameLogics.CurrentGuess++;
                foreach (Button buttonToEnable in m_Guesses[m_GameLogics.CurrentGuess])
                {
                    buttonToEnable.Enabled = true;
                }
            }
        }

        private void ShowResultOfGeuss()
        {
            char bull = 'V', cow = 'X';
            int index = 0;
            foreach (char charInResultString in m_GameLogics.LastGuess().Result)
            {
                if (charInResultString == bull)
                {
                    m_Answers[m_GameLogics.CurrentGuess][index].BackColor = Color.Black;
                }
                else if (charInResultString == cow)
                {
                    m_Answers[m_GameLogics.CurrentGuess][index].BackColor = Color.Yellow;
                }

                index++;
            }   
        }

        private void ShowComputerPin()
        {
            string computerSequence = m_GameLogics.SecretCode;
            string colorOfButton;

            colorOfButton = getKeyFromValue(m_ColorsToChar, computerSequence[0].ToString());
            this.buttonComputerGuess1.BackColor = Color.FromName(colorOfButton);
            colorOfButton = getKeyFromValue(m_ColorsToChar, computerSequence[1].ToString());
            this.buttonComputerGuess2.BackColor = Color.FromName(colorOfButton);
            colorOfButton = getKeyFromValue(m_ColorsToChar, computerSequence[2].ToString());
            this.buttonComputerGuess3.BackColor = Color.FromName(colorOfButton);
            colorOfButton = getKeyFromValue(m_ColorsToChar, computerSequence[3].ToString());
            this.buttonComputerGuess4.BackColor = Color.FromName(colorOfButton);       
        }

        private string getKeyFromValue(Dictionary<string, string> i_dic, string i_Val)
        {
            string betaKey = string.Empty;
            foreach (KeyValuePair<string, string> pair in i_dic)
            {
                if (pair.Value == i_Val)
                {
                    betaKey = pair.Key; // Found
                    break;
                }
            }

            return betaKey;
        }
    } 
}