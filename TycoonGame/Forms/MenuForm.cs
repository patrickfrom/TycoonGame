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
        // Use input to write in code, type "fake" code which you have to write after to earn cash by publshing application.
        // you can also have "workers" who create applications for you and you earn money from that
        // When finishing an application, you earn money

        // Clone Slot Form
        
        // Open Tycoon List of Saved Tycoons
          // Choose Slot
            // If slot open 
              // Create
            // Else
              // Open saved slot
   
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SlotForm slotForm = new SlotForm(); ;
            slotForm.Show();
        }
    }
}
