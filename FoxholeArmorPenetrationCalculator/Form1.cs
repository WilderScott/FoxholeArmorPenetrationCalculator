namespace FoxholeArmorPenetrationCalculator
{
    public partial class Form1 : Form
    {
        double basePenetrationChance;
        double ammoPenetrationModifier;
        double flankModifier = 1;

        Tank[] tanks = new Tank[2];

        public Form1()
        {
            InitializeComponent();
            MakeTanks();
        }

        private void MakeTanks()
        {
            for(int i = 0; i < tanks.Length; i++)
            {
                tanks[i] = new Tank();
            }
            tanks[0].DeclareTank("Silverhand", 27);
            tanks[1].DeclareTank("Outlaw", 33);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            basePenetrationChance = tanks[listBox1.SelectedIndex].basePenetrationChance;
            UpdateChance();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
            {
                ammoPenetrationModifier = 1;
            }
            else if (listBox2.SelectedIndex == 1)
            {
                ammoPenetrationModifier = 1.5;
            }
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