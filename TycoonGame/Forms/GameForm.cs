using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TycoonGame.Scripts;

namespace TycoonGame.Forms
{
    public partial class GameForm : Form
    {
        DataManager dataManager = new DataManager();
        Tycoon tycoon;

        public GameForm()
        {
            tycoon = dataManager.Load(2);
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            label1.Text = tycoon.GetName();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
