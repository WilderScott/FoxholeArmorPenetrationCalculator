namespace FoxholeArmorPenetrationCalculator
{
    public partial class Form1 : Form
    {
        // UNCONFIRMED:
        // Does worst visual armor quality represent 0% armor, or maximum armor stripped? Right now, assuming it represents 0%
        // https://foxhole.wiki.gg/wiki/Vehicle_Penetration_Chance information on angle and range modifiers perfectly correct? Right now, assuming yes

        double basePenetrationChance;
        double ammoPenetrationModifier;
        double flankModifier = 0;
        double visualArmorDamage = 0;
        double minimumArmorQuality;
        double rangeModifier = 0;
        bool benefitsFromRangeAndAngle;

        Tank[] tanks = new Tank[17];
        Ammo[] ammos = new Ammo[10];

        public Form1()
        {
            InitializeComponent();
            MakeTanks();
            MakeAmmo();
        }

        private void MakeTanks()
        {
            for(int i = 0; i < tanks.Length; i++)
            {
                tanks[i] = new Tank();
            }

            tanks[0].DeclareTank("Ares", 25, 50);
            tanks[1].DeclareTank("Ballista / Scorpion", 40, 25);
            tanks[2].DeclareTank("Bardiche / Ranseur", 23, 33);
            tanks[3].DeclareTank("Cullen Predator", 22, 50);
            tanks[4].DeclareTank("Devitt / Ironhide / Caine", 30, 33);
            tanks[5].DeclareTank("Falchion / Spatha / Talos", 33, 33);
            tanks[6].DeclareTank("Flood", 25, 50);
            tanks[7].DeclareTank("Flood Juggernaut", 23, 50);
            tanks[8].DeclareTank("Hasta", 22, 50);
            tanks[9].DeclareTank("Hatchet / Kranesca / Vulcan", 33, 33);
            tanks[10].DeclareTank("King Gallant / Gallant", 50, 10);
            tanks[11].DeclareTank("Lance", 25, 50);
            tanks[12].DeclareTank("Noble Widow / Firebrand", 17, 50);
            tanks[13].DeclareTank("Pelekys", 35, 33);
            tanks[14].DeclareTank("Outlaw / Highwayman / Thornfall", 33, 33);
            tanks[15].DeclareTank("Silverhand / Chieftan", 27, 33);
            tanks[16].DeclareTank("Silverhand Lordscar", 30, 33);

            for (int i = 0; i < tanks.Length; i++)
            {
                listBox1.Items.Add(tanks[i].name);
            }
        }

        private void MakeAmmo()
        {
            for (int i = 0; i < ammos.Length; i++)
            {
                ammos[i] = new Ammo();
            }

            ammos[0].DeclareAmmo("20mm", 1, true);
            ammos[1].DeclareAmmo("30mm", 1, true);
            ammos[2].DeclareAmmo("40mm", 1, true);
            ammos[3].DeclareAmmo("68mm", 1.5, true);
            ammos[4].DeclareAmmo("75mm", 1.5, true);
            ammos[5].DeclareAmmo("94.5mm", 2, true);
            ammos[6].DeclareAmmo("RPG", 1, true);
            ammos[7].DeclareAmmo("Ignifist", 1.5, true);
            ammos[8].DeclareAmmo("Direct ATRPG", 1.5, true);
            ammos[9].DeclareAmmo("Indirect ATRPG", 2.5, false);

            for (int i = 0; i < ammos.Length; i++)
            {
                listBox2.Items.Add(ammos[i].name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            basePenetrationChance = tanks[listBox1.SelectedIndex].basePenetrationChance;
            minimumArmorQuality = tanks[listBox1.SelectedIndex].minimumArmorQuality;
            UpdateChance();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ammoPenetrationModifier = ammos[listBox2.SelectedIndex].ammoPenetrationModifier;
            benefitsFromRangeAndAngle = ammos[listBox2.SelectedIndex].benefitsFromRangeAndAngle;
            UpdateChance();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            visualArmorDamage = trackBar1.Value;
            UpdateChance();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                flankModifier = 40;
            }
            else
            {
                flankModifier = 0;
            }
            UpdateChance();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                rangeModifier = 25;
            }
            else
            {
                rangeModifier = 0;
            }
            UpdateChance();
        }

        private void UpdateChance()
        {
            double finalPenetrationChance = Math.Min(Math.Min(Math.Max(basePenetrationChance, visualArmorDamage), minimumArmorQuality) * ammoPenetrationModifier + (Convert.ToInt32(benefitsFromRangeAndAngle) * (flankModifier + rangeModifier)), 100);
           
            if (!(finalPenetrationChance == 0))
            {
                textBox1.Text = "Penetration Chance: " + finalPenetrationChance.ToString();
            }
        }
    }
}
