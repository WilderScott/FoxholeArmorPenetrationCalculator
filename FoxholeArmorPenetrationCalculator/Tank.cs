namespace FoxholeArmorPenetrationCalculator
{
    internal class Tank
    {
        public string name;
        public double basePenetrationChance;
        public void DeclareTank(string name, int basePenetrationChance)
        {
            this.name = name;
            this.basePenetrationChance = basePenetrationChance;
        }
    }
}