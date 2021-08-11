using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TycoonGame.Forms
{
    public partial class MenuForm : Form
    {
        bool mouseDown;
        Point offset;

        public SlotForm slotForm;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            slotForm = new SlotForm();
            slotForm.Show();
            Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
