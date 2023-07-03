namespace FoxholeArmorPenetrationCalculator
{
    public partial class Form1 : Form
    {
        double basePenetrationChance;
        double ammoPenetrationModifier;
        double flankModifier = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                basePenetrationChance = 27;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                basePenetrationChance = 33;
            }
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