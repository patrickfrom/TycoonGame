using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TycoonGame.Forms
{
    public partial class DisplayForm : Form
    {
        bool mouseDown;
        Point offset;
        public DisplayForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Application.OpenForms["GameForm"].Enabled = false;
            Application.OpenForms["ShopForm"].Enabled = false;
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms["GameForm"].Enabled = true;
            Application.OpenForms["ShopForm"].Enabled = true;
            this.Close();
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
