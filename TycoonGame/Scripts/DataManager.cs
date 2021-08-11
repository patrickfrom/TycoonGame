using System.IO;
using Newtonsoft.Json;
using TycoonGame.Forms;
using System.Security.Cryptography;

namespace TycoonGame.Scripts
{
    class DataManager
    {
        public void SaveOrLoad(int index, Tycoon tycoon) {
            try
            {
                using(StreamReader reader = new StreamReader(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
                {
                    DisplayForm displayForm = new DisplayForm();
                    displayForm.Show();
                    displayForm.TitleLabel.Text = reader.ReadLine();
                }
            } catch
            {
                using (StreamWriter file = File.CreateText(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
                {
                    file.WriteLine(JsonConvert.SerializeObject(tycoon));
                }
            }
        }

        public Tycoon Load(int index)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
            {
                Tycoon newTycoon = JsonConvert.DeserializeObject<Tycoon>(reader.ReadLine());
                return newTycoon;
            }
        }
    }
}
