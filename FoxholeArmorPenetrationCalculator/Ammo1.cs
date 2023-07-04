namespace FoxholeArmorPenetrationCalculator
{
    internal class Ammo
    {
        public string name;
        public double ammoPenetrationModifier;
        public void DeclareAmmo(string name, double ammoPenetrationModifier)
        {
            this.name = name;
            this.ammoPenetrationModifier = ammoPenetrationModifier;
        }
    }
}