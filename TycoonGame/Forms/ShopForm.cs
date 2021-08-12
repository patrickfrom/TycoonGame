using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using TycoonGame.Scripts.Objects;
using System.Diagnostics;

namespace TycoonGame.Forms
{
    partial class ShopForm : Form
    {
        public Tycoon gameTycoon;

        List<Worker> shopWorkers = new List<Worker>();

        bool mouseDown;
        Point offset;

        public ShopForm()
        {
            InitializeComponent();
        }

        int i;
        private void ShopForm_Load(object sender, EventArgs e)
        {
            shopWorkers.Add(new Worker("Jeffry", 250, 1));
            shopWorkers.Add(new Worker("John", 1000, 3));
            shopWorkers.Add(new Worker("Rasmus", 3250, 6));
            shopWorkers.Add(new Worker("Noah", 100000, 15));

            foreach(Worker worker in shopWorkers)
            {
                Debug.WriteLine(i);
                Button newButton = new Button();

                newButton.BackColor = ColorTranslator.FromHtml("#27ae60");
                newButton.ForeColor = Color.White;

                newButton.FlatStyle = FlatStyle.Flat;

                newButton.Text = $"{worker.GetName()} \n Cost: {worker.GetCost()} \n Earn: {worker.GetEarn()}";
                newButton.Click += Buy_Click;

                shopList.Controls.Add(newButton);

                i++;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void Buy_Click(object sender, EventArgs e)
        {
            string[] workerString = sender.ToString().Split(" ");
            foreach(string ss in workerString)
            {
                foreach (Worker worker in shopWorkers)
                {
                    if(worker.GetName() == ss)
                    {
                        Debug.WriteLine(worker.GetName());
                    }
                }
            }
        }
    }

}