using System.IO;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using TycoonGame.Scripts.Objects;

namespace TycoonGame.Scripts
{
    class DataManager
    {
        public void CreateSave(int index, Tycoon tycoon) {
            try
            {
                using(StreamReader reader = new StreamReader(GetSaveLocation() + @"\save" + index + ".haus"))
                {
                    Debug.WriteLine("Data already exists");
                }
            } catch {
                Directory.CreateDirectory(GetSaveLocation());
                Save(index, tycoon);
            } 
        }

        public void Save(int index, Tycoon tycoon)
        {
            using (StreamWriter file = File.CreateText(GetSaveLocation() + @"\save" + index + ".haus"))
            {
                file.WriteLine(JsonConvert.SerializeObject(tycoon));
            }
        }

        public Tycoon Load(int index)
        {
            using (StreamReader reader = new StreamReader(GetSaveLocation() + @"\save" + index + ".haus"))
            {
                Tycoon newTycoon = JsonConvert.DeserializeObject<Tycoon>(reader.ReadLine());
                return newTycoon;
            }
        }

        public string GetSaveLocation()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] fullPatch = new string[] { docPath, @"CoderTycoon\" };
            string combinedPath = Path.Combine(fullPatch);
            string specialLocation = combinedPath;

            return specialLocation;
        }

    }
}
