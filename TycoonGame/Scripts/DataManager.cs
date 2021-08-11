using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System;
using System.Diagnostics;
using TycoonGame.Forms;

namespace TycoonGame.Scripts
{
    class DataManager
    {
        public void CreateSave(int index, Tycoon tycoon) {
            try
            {
                using(StreamReader reader = new StreamReader(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
                {
                    Debug.WriteLine("Data already exists");
                }
            } catch{
                using (StreamWriter file = File.CreateText(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
                {
                    file.WriteLine(JsonConvert.SerializeObject(tycoon));
                }
            } 
        }

        public void Save(int index, Tycoon tycoon)
        {
            using (StreamWriter file = File.CreateText(@"C:\Users\patr9570\Documents\TycoonSaves\save" + index + ".haus"))
            {
                file.WriteLine(JsonConvert.SerializeObject(tycoon));
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
