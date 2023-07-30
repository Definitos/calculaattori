using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculaattori

{
    public partial class Form1 : Form
    {    // Tässä säädetään muuttujat arvojen ja toimintojen säilyttämiseksi
        double value = 0;
        string operation = "";
        bool operation_pressed = false;


        public Form1()
        {
            InitializeComponent();
        }
        // Tapahtumakäsittelijä numeronäppäimille
        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operation_pressed)) //tässä tyhjennetään tuloskenttä, mikäli kentässä on 0 tai toimintonappia on painettu
                result.Clear();
            Button b = (Button)sender; // Haetaan painike, jota painettiin ja lisätään sen teksti tuloskenttään
            result.Text = result.Text + b.Text;
        }
        // tapahtumakäsittelijä CE näppäimelle
        private void button16_Click(object sender, EventArgs e)
        {
            result.Text = "0";//asettaa tuloskentän luvuksi 0

        }

        private void operator_click(object sender, EventArgs e) // Tapahtumankäsittelijä toimintopainikkeille (+, -, *, /.)
        {
            Button b = (Button)sender;
            operation = b.Text; // Hae painike, jota painettiin, ja tallenna sen teksti nykyisenä toimintojna
            value = double.Parse(result.Text);  
            operation_pressed = true;

        }

        private void button19_Click(object sender, EventArgs e) // Tapahtumankäsittelijä "=" -painikkeelle 
        {/* Suorita laskutoimitus painetun komennon perusteella
          */
            switch (operation)
            {
                case "+":
                    result.Text = (value + double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;



            }
            operation_pressed = false; //nollataan annettu komento
        }

        private void button17_Click(object sender, EventArgs e)// Tapahtumankäsittelijä "Clear" -painikkeelle
        {/*
          * Tyhjennä tuloskenttä, nollaa arvo ja aseta tuloskentän tekstiksi "0"
          */
            result.Clear();
            value = 0;
            result.Text = "0";




        }
        // asetetaan muuttujat muistinäppäimille.
        private double memoryValue = 0;
        private bool memoryStored = false;

        private void button18_Click(object sender, EventArgs e)
        {
            // Tallennetaan laskimen näytöllä oleva luku muistiin
            double currentValue;
            if (double.TryParse(result.Text, out currentValue))
            {
                memoryValue = currentValue;
                memoryStored = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Noudetaan tallennettu luku muistista.
            if (memoryStored)
            {
                result.Text = memoryValue.ToString();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // nollataan muistissa oleva luku ja tyhjennetään edellinen tallennus.
            memoryValue = 0;
            memoryStored = false;
        }
    }
}

