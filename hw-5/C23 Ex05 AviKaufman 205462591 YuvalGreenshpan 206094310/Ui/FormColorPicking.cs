using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class FormChooseColor : Form
    {
        private Color m_PickedColor;

        public FormChooseColor()
        {
            InitializeComponent();
        }

        public Color PickedColor
        {
            get { return m_PickedColor; }
        }

        private void buttonPurple_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Purple;
            this.Visible = false;
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Red;
            this.Visible = false;
        }

        private void buttonLime_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Lime;
            this.Visible = false;
        }

        private void buttonCyan_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Cyan;
            this.Visible = false;
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Blue;
            this.Visible = false;
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Yellow;
            this.Visible = false;
        }

        private void buttonBrown_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.Brown;
            this.Visible = false;
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            m_PickedColor = Color.White;
            this.Visible = false;
        }
    }
}