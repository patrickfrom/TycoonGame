namespace TycoonGame.Scripts.Objects
{
    class Worker
    {
        readonly public string name;
        readonly public int cost;

        readonly public int earn;

        public Worker(string name, int cost, int earn)
        {
            this.name = name;
            this.cost = cost;
            this.earn = earn;
        }

        public string GetName() => name;
        public int GetCost() => cost;
        public int GetEarn() => earn;
    }
}
