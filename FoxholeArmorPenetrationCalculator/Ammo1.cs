namespace FoxholeArmorPenetrationCalculator
{
    internal class Ammo
    {
        public string name;
        public double ammoPenetrationModifier;
        public bool benefitsFromRangeAndAngle;
        public void DeclareAmmo(string name, double ammoPenetrationModifier, bool benefitsFromRangeAndAngle)
        {
            this.name = name;
            this.ammoPenetrationModifier = ammoPenetrationModifier;
            this.benefitsFromRangeAndAngle = benefitsFromRangeAndAngle;
        }
    }
}