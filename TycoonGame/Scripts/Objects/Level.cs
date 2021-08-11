namespace TycoonGame.Scripts
{
    class Level
    {
        public int level;
        public int experience;
        public int maxExperience;

        public Level(int level, int maxExperience)
        {
            this.level = level;
            this.maxExperience = maxExperience;
            experience = 0;
        }

        public void LevelUp()
        {
            if(experience >= maxExperience)
            {
                level += 1;
                experience -= maxExperience;
                maxExperience *= 2;
            }
        }
        public void GainXP(int xp)
        {
            experience += xp;
            LevelUp();
        }

        public int GetLevel() => level;
        public int GetExperience() => experience;
        public int GetMaxExperience() => maxExperience;
    }
}