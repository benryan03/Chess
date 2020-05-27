using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        Color color = new Color();

        public Form1()
        {
            InitializeComponent();
        }

        private void mouseEnterSquare(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            color = square.BackColor;
            square.BackColor = Color.White;
        }

        private void mouseLeaveSquare(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            square.BackColor = color;
        }
    }
}
