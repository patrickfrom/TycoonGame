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
    partial class GameForm : Form
    {
        public Tycoon gameTycoon;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            label1.Text = gameTycoon.GetName();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
