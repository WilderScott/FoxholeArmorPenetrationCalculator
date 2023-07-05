namespace FoxholeArmorPenetrationCalculator
{
    internal class ArmorQuality
    {
        public string name;
        public double armorQualityModifier;
        public void DeclareArmorQuality(string name, double armorQualityModifier)
        {
            this.name = name;
            this.armorQualityModifier = armorQualityModifier;
        }
    }
}