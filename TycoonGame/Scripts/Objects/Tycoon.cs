namespace TycoonGame.Scripts
{
    class Tycoon
    {
        public string name;
        public int coins;

        public Level level;

        public Tycoon(string name, Level level)
        {
            this.name = name;
            this.level = level;
            coins = 25;
        }

        public string GetName() => name;
        public int GetCoins() => coins;
        public void AddCoins(int amount)
        {
            coins += amount;
        }
    }
}
