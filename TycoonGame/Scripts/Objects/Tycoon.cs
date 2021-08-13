using System.Collections.Generic;
namespace TycoonGame.Scripts.Objects
{
    class Tycoon
    {
        public string name;
        public int coins;

        public List<Worker> workers = new List<Worker>();

        public Tycoon(string name)
        {
            this.name = name;
            coins = 25;
        }

        public string GetName() => name;
        public List<Worker> GetWorkers() => workers;
        public int GetCoins() => coins;
        public void AddCoins(int amount)
        {
            coins += amount;
        }
        public void DecreaseCoins(int amount)
        {
            coins -= amount;
        }

    }
}
