namespace TycoonGame
{
    class Level
    {
        int level;
        int experience;
        int maxExperience;

        public Level(int level, int experience, int maxExperience)
        {
            this.level = level;
            this.experience = experience;
            this.maxExperience = maxExperience;
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