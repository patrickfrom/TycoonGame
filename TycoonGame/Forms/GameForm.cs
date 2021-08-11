using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TycoonGame.Scripts;

namespace TycoonGame.Forms
{
    partial class GameForm : Form
    {
        private DataManager dataManager = new DataManager();
        public Tycoon gameTycoon;

        public int currentIndex;

        bool mouseDown;
        Point offset;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            GameFormTitle.Text = gameTycoon.GetName();
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
            gameTycoon.AddCoins(1);
            Debug.WriteLine(gameTycoon.GetCoins());
        }
    }
}
