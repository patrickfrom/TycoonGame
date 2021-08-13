using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TycoonGame.Scripts;
using TycoonGame.Scripts.Objects;

namespace TycoonGame.Forms
{
    partial class GameForm : Form
    {
        public Tycoon gameTycoon;
        public int currentIndex;

        private DataManager dataManager = new DataManager();
        private ShopForm shopForm;

        bool mouseDown;
        Point offset;

        public GameForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            shopForm = new ShopForm();
            this.KeyPreview = true;
            
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            GameFormTitle.Text = gameTycoon.GetName();
            moneyLabel.Text = gameTycoon.GetCoins().ToString();
            shopForm.gameTycoon = gameTycoon;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MenuForm"].Close();
            dataManager.Save(currentIndex, gameTycoon);
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

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            int working = 0;
            while (true)
            {
                working++;
                Thread.Sleep(2500);
                backgroundWorker1.ReportProgress(working);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                foreach (Worker worker in gameTycoon.GetWorkers())
                {
                    gameTycoon.AddCoins(worker.GetEarn());
                    moneyLabel.Text = gameTycoon.GetCoins().ToString();
                }
            } catch
            {
                Debug.WriteLine("No Workers");
            }
        }


        private void GetKeyUp(object sender, KeyEventArgs e)
        {
            gameTycoon.AddCoins(1);
            moneyLabel.Text = gameTycoon.GetCoins().ToString();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            if(shopForm.Visible)
            {
                shopForm.Hide();
            } else 
            {
                shopForm.Show();
            }
        }
    }
}