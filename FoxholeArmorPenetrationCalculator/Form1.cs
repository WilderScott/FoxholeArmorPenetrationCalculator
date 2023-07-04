namespace FoxholeArmorPenetrationCalculator
{
    public partial class Form1 : Form
    {
        double basePenetrationChance;
        double ammoPenetrationModifier;
        double flankModifier = 1;

        Tank[] tanks = new Tank[2];
        Ammo[] ammos = new Ammo[2];

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

            tanks[0].DeclareTank("Silverhand", 27);
            tanks[1].DeclareTank("Outlaw", 33);

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

            ammos[0].DeclareAmmo("40mm", 1);
            ammos[1].DeclareAmmo("68mm", 1.5);

            for (int i = 0; i < ammos.Length; i++)
            {
                listBox2.Items.Add(ammos[i].name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            basePenetrationChance = tanks[listBox1.SelectedIndex].basePenetrationChance;
            UpdateChance();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ammoPenetrationModifier = ammos[listBox2.SelectedIndex].ammoPenetrationModifier;
            UpdateChance();
        }

        private void UpdateChance()
        {
            double finalPenetrationChance = basePenetrationChance * ammoPenetrationModifier * flankModifier;

            if(finalPenetrationChance > 100)
            {
                finalPenetrationChance = 100;
            }
            if(!(finalPenetrationChance == 0))
            {
                textBox1.Text = finalPenetrationChance.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                flankModifier = 2.5;
            }
            else
            {
                flankModifier = 1;
            }
            UpdateChance();
        }
    }
}