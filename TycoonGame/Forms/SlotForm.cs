using System;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using TycoonGame.Scripts;
using System.IO;
using System.Drawing;
using TycoonGame.Scripts.Objects;

namespace TycoonGame.Forms
{
    public partial class SlotForm : Form
    {

        DataManager dataManager;
        Random random = new Random();

        bool mouseDown;
        Point offset;

        public SlotForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
        private void SlotForm_Load(object sender, EventArgs e)
        {
            dataManager = new DataManager();

            ChangeLabels(1, NameLabel1, CashLabel1, Slot1Button);
            ChangeLabels(2, NameLabel2, CashLabel2, Slot2Button);
            ChangeLabels(3, NameLabel3, CashLabel3, Slot3Button);
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
            gameForm.currentIndex = index;
            gameForm.Show();
            Application.OpenForms["SlotForm"].Hide();
        }

        private void ChangeLabels(int index, Label name, Label cash, Button button)
        {
            try
            {
                using (StreamReader reader = new StreamReader(dataManager.GetSaveLocation() + @"\save" + index + ".haus"))
                {
                    Tycoon tycoon = JsonConvert.DeserializeObject<Tycoon>(reader.ReadLine());
                    button.Text = "Load Game";

                    name.Text = "Name: " + tycoon.GetName();
                    cash.Text = "Cash: " + tycoon.GetCoins().ToString();
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
            Tycoon newTycoon = new Tycoon(name);
            dataManager.CreateSave(index, newTycoon);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms["MenuForm"].Close();
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
