using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TycoonGame.Scripts;
using System.IO;

namespace TycoonGame.Forms
{
    public partial class SlotForm : Form
    {

        DataManager dataManager;
        GameForm gameForm;
        Random random = new Random();

        public SlotForm()
        {
            dataManager = new DataManager();
            InitializeComponent();

            ChangeLabels(1, NameLabel1, CashLabel1, LevelLabel1, Slot1Button);
            ChangeLabels(2, NameLabel2, CashLabel2, LevelLabel2, Slot2Button);
            ChangeLabels(3, NameLabel3, CashLabel3, LevelLabel3, Slot3Button);
        }

        private void Slot1Button_Click(object sender, EventArgs e)
        {
            SelectSlot(1);
            
        }

        private void Slot2Button_Click(object sender, EventArgs e)
        {
            SelectSlot(2);
        }

        private void Slot3Button_Click(object sender, EventArgs e)
        {
            SelectSlot(3);
        }

        private void SelectSlot(int index)
        {
            if(!String.IsNullOrWhiteSpace(NameInput.Text) || !String.IsNullOrEmpty(NameInput.Text))
            {
                CreatePlayer(index, NameInput.Text);
            } else
            {
                CreatePlayer(index, "Coder " + random.Next(100000));
            }
            GameForm gameForm = new GameForm();
            gameForm.gameTycoon = dataManager.Load(index);
            gameForm.Show();
        }

        private void ChangeLabels(int index, Label name, Label cash, Label level, Button button)
        {
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
                {
                    Tycoon tycoon = JsonConvert.DeserializeObject<Tycoon>(reader.ReadLine());
                    button.Text = "Load Game";

                    name.Text = "Name: " + tycoon.GetName();
                    cash.Text = "Cash: " + tycoon.GetCoins().ToString();
                    level.Text = "Level: " + tycoon.level.GetLevel().ToString();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                Debug.WriteLine("Data Loaded!");
            }
        }

        private void CreatePlayer(int index, string name)
        {
            Tycoon newTycoon = new Tycoon(name, new Level(1, 150));
            dataManager.Save(index, newTycoon);
        }
    }
}
