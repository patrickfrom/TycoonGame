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
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            shopWorkers.Add(new Worker("Jeffrey", 250, 1));
            shopWorkers.Add(new Worker("John", 1000, 4));
            shopWorkers.Add(new Worker("Rasmus", 3250, 6));
            shopWorkers.Add(new Worker("Noah", 100000, 15));

            foreach(Worker worker in shopWorkers)
            {
                BuyControl buyControl = new BuyControl();

                buyControl.nameLabel.Text = worker.GetName();
                buyControl.priceLabel.Text = "Price: $" + worker.GetCost();
                buyControl.earnLabel.Text = "Earn: $" + worker.GetEarn();

                buyControl.buyButton.Click += Buy_Click;

                shopList.Controls.Add(buyControl);
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
            Control test = (Control)sender;
            foreach (Control item in test.Parent.Controls)
            {
                foreach (Worker worker in shopWorkers)
                {
                    if(item.Text == worker.GetName()) 
                    {
                        if(gameTycoon.GetCoins() >= worker.GetCost())
                        {
                            gameTycoon.DecreaseCoins(worker.GetCost());
                            gameTycoon.workers.Add(worker);
                        } else
                        {
                            DisplayForm displayForm = new DisplayForm();
                            displayForm.Show();
                            displayForm.TitleLabel.Text = "Not enough money!";
                            displayForm.BackColor = ColorTranslator.FromHtml("#2c3e50");
                        }
                    }
                }
            }
        }
    }

}