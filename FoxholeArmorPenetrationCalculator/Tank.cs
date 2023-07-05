namespace FoxholeArmorPenetrationCalculator
{
    internal class Tank
    {
        public string name;
        public double basePenetrationChance;
        public double minimumArmorQuality;
        public void DeclareTank(string name, double basePenetrationChance, double minimumArmorQuality)
        {
            this.name = name;
            this.basePenetrationChance = basePenetrationChance;
            this.minimumArmorQuality = 100 - minimumArmorQuality;
        }
    }
}