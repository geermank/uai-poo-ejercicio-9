using ObservatoryProject;
using ObservatoryProject.Stars;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ejercicio9
{
    public partial class Form1 : Form
    {
        private Observatory observatory; 

        public Form1()
        {
            InitializeComponent();
            observatory = new Observatory();
            observatory.OnDiscoveryCreated += ObservatoryOnDiscoveryCreated;
        }

        private void ObservatoryOnDiscoveryCreated(Discovery newDiscovery)
        {
            MessageBox.Show("Descubrimiento creado!");
            UpdateStars();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            observatory.StarColors.ForEach(color => comboBox1.Items.Add(color));
            observatory.StarTypes.ForEach(type => comboBox2.Items.Add(type));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = checkBox1.Checked;
            label4.Visible = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person discoverer = GetDiscoverer();
            if (discoverer == null)
            {
                MessageBox.Show("Completa los datos del descubridor");
                return;
            }
            if (IsBasicDataValid())
            {
                MessageBox.Show("Completa los datos basicos de la estrella");
                return;
            }
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Completa los datos de la temperatura");
                return;
            }
            if (textBox8.Text.Length == 0 || 
                comboBox1.SelectedItem == null || 
                comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Completa los datos faltantes de la estrella");
                return;
            }

            if (IsDiscoveryDataValid())
            {
                MessageBox.Show("Completa los datos del descubrimiento");
                return;
            }

            // base data
            string name = textBox7.Text;
            int mass = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);

            // star data
            Temperature temperature = null;
            int temperatureValue = int.Parse(textBox6.Text);
            if (radioButton1.Checked)
            {
                temperature = new CelciusTemperature(temperatureValue);
            } else if (radioButton2.Checked)
            {
                temperature = new FahrenheitTemperature(temperatureValue);
            }

            int diameter = int.Parse(textBox8.Text);
            StarColor starColor = (StarColor) comboBox1.SelectedItem;
            StarType starType = (StarType) comboBox2.SelectedItem;

            DateTime discoveredTime = dateTimePicker2.Value;
            double distanceFromEarthValue = double.Parse(textBox12.Text);
            BaseDistance distanceFromEarth = new LightYears(distanceFromEarthValue);

            observatory.RegisterNewStarDiscocvery(name, age, mass, temperature, diameter, starColor, starType, discoverer, discoveredTime, distanceFromEarth, GetSelectedConstellation());
        }

        private Person GetDiscoverer()
        {
            if (textBox1.Text.Length == 0 || 
                textBox2.Text.Length == 0 ||
                dateTimePicker1.Value > DateTime.Now || 
                (checkBox1.Checked && textBox3.Text.Length == 0))
            {
                return null;
            }

            Person person = null;

            string name = textBox1.Text;
            string surname = textBox2.Text;
            DateTime dob = dateTimePicker1.Value;

            if (checkBox1.Checked)
            {
                string file = textBox3.Text;
                person = new ObservatoryStaff(name, surname, dob, file);
            } else
            {
                person = new Person(name, surname, dob);
            }

            return person;
        }

        private Constellation GetSelectedConstellation()
        {
            return (Constellation) listBox2.SelectedItem;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string constellationName = textBox13.Text;
            if (constellationName.Length == 0)
            {
                MessageBox.Show("Completa el nombre de la constelación");
                return;
            }
            listBox2.Items.Add(new Constellation(constellationName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person discoverer = GetDiscoverer();
            if (discoverer == null)
            {
                MessageBox.Show("Completa los datos del descubridor");
                return;
            }
            if (IsBasicDataValid())
            {
                MessageBox.Show("Completa los datos basicos del planeta");
                return;
            }
            if (IsDiscoveryDataValid())
            {
                MessageBox.Show("Completa los datos del descubrimiento");
                return;
            }

            // base data
            string name = textBox7.Text;
            int mass = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);

            // planet data
            Temperature temperature = null;
            int temperatureValue = int.Parse(textBox9.Text);
            if (radioButton4.Checked)
            {
                temperature = new CelciusTemperature(temperatureValue);
            }
            else if (radioButton3.Checked)
            {
                temperature = new FahrenheitTemperature(temperatureValue);
            }

            List<Satelite> satelites = new List<Satelite>();
            foreach (Satelite satelite in listBox1.Items)
            {
                satelites.Add(satelite);
            }

            DateTime discoveredTime = dateTimePicker2.Value;
            double distanceFromEarthValue = double.Parse(textBox12.Text);
            BaseDistance distanceFromEarth = new LightYears(distanceFromEarthValue);

            observatory.RegisterPlanetDiscovery(name, age, mass, temperature, satelites, discoverer, discoveredTime, distanceFromEarth);
        }

        private bool IsBasicDataValid()
        {
            return textBox7.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0;
        }

        private bool IsDiscoveryDataValid()
        {
            return textBox12.Text.Length == 0 || dateTimePicker2.Value > DateTime.Now;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsBasicDataValid())
            {
                MessageBox.Show("Completa los datos basicos del satelite");
                return;
            }

            // base data
            string name = textBox7.Text;
            int mass = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);
            bool hasTidalLocking = checkBox2.Checked;

            Satelite satelite = new Satelite(name, age, mass, hasTidalLocking);
            listBox1.Items.Add(satelite);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person discoverer = GetDiscoverer();
            if (discoverer == null)
            {
                MessageBox.Show("Completa los datos del descubridor");
                return;
            }
            if (IsBasicDataValid())
            {
                MessageBox.Show("Completa los datos basicos del planeta");
                return;
            }
            if (IsDiscoveryDataValid())
            {
                MessageBox.Show("Completa los datos del descubrimiento");
                return;
            }

            // base data
            string name = textBox7.Text;
            int mass = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);

            // planet data
            Temperature temperature = null;
            int temperatureValue = int.Parse(textBox9.Text);
            if (radioButton4.Checked)
            {
                temperature = new CelciusTemperature(temperatureValue);
            }
            else if (radioButton3.Checked)
            {
                temperature = new FahrenheitTemperature(temperatureValue);
            }

            List<Satelite> satelites = new List<Satelite>();
            foreach (Satelite satelite in listBox1.Items)
            {
                satelites.Add(satelite);
            }

            Star star = (Star) listBox3.SelectedItem;
            BaseDistance distanceToStar = new LightYears(double.Parse(textBox10.Text));
            bool goldilocksZone = checkBox3.Checked;
            bool potentiallyHabitable = checkBox4.Checked; 

            DateTime discoveredTime = dateTimePicker2.Value;
            double distanceFromEarthValue = double.Parse(textBox12.Text);
            BaseDistance distanceFromEarth = new LightYears(distanceFromEarthValue);

            observatory.RegisterUnarySistemPlanetDiscovery(name, age, mass, temperature, satelites, star, distanceToStar, goldilocksZone, potentiallyHabitable, discoverer, discoveredTime, distanceFromEarth);
        }

        private void UpdateStars()
        {
            listBox3.Items.Clear();
            foreach(CelestialBody cb in observatory.Stars)
            {
                listBox3.Items.Add(cb);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Person discoverer = GetDiscoverer();
            if (discoverer == null)
            {
                MessageBox.Show("Completa los datos del descubridor");
                return;
            }
            if (IsBasicDataValid())
            {
                MessageBox.Show("Completa los datos basicos del planeta");
                return;
            }
            if (IsDiscoveryDataValid())
            {
                MessageBox.Show("Completa los datos del descubrimiento");
                return;
            }

            // base data
            string name = textBox7.Text;
            int mass = int.Parse(textBox4.Text);
            int age = int.Parse(textBox5.Text);

            // planet data
            Temperature temperature = null;
            int temperatureValue = int.Parse(textBox9.Text);
            if (radioButton4.Checked)
            {
                temperature = new CelciusTemperature(temperatureValue);
            }
            else if (radioButton3.Checked)
            {
                temperature = new FahrenheitTemperature(temperatureValue);
            }

            List<Satelite> satelites = new List<Satelite>();
            foreach (Satelite satelite in listBox1.Items)
            {
                satelites.Add(satelite);
            }

            Star star = (Star) listBox3.SelectedItems[0];
            BaseDistance distanceToStar = new LightYears(double.Parse(textBox10.Text));
            bool goldilocksZone = checkBox3.Checked;
            bool potentiallyHabitable = checkBox4.Checked;


            Star secondaryStar = (Star)listBox3.SelectedItems[1];
            BaseDistance distanceToSecondaryStar = new LightYears(double.Parse(textBox11.Text));

            DateTime discoveredTime = dateTimePicker2.Value;
            double distanceFromEarthValue = double.Parse(textBox12.Text);
            BaseDistance distanceFromEarth = new LightYears(distanceFromEarthValue);

            observatory.RegisterBinarySistemPlanetDiscovery(name, age, mass, temperature, satelites, star, distanceToStar, secondaryStar, distanceToSecondaryStar, goldilocksZone, potentiallyHabitable, discoverer, discoveredTime, distanceFromEarth);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var result = observatory.FilterPlanetsByName(textBox14.Text);
            listBox4.Items.Clear();
            result.ForEach(p => listBox4.Items.Add(p));
        }
    }
}
