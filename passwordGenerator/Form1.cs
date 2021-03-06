using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string password = "";

            Random rd = new Random();

            int randNum;
            int randLet;
            int upOrLow;
            int spenum;
            int num;

            char[] letter = new char[] { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            char[] specialCar = new char[] { '~','!','@','#','$','%','^','*','-','_','=','+','[','{',']','}','/',';',':',',','.','?'};
            char[] number = new char[] {'0','1','2','3','4','5','6','7','8','9'};

            bool numeric = cbNumeric.Checked;
            bool specialCarracters = cbSpecialCharacters.Checked;

            while(password.Length != trackBar1.Value)
            {
                randNum = rd.Next(4);
                if(randNum == 1)
                {
                    randLet = rd.Next(26);
                    upOrLow = rd.Next(2);

                    if(upOrLow == 0)
                    {
                        password += Char.ToUpper(letter[randLet]);
                    }
                    else
                    {
                        password += letter[randLet];
                    }
                }
                if(randNum == 2 && numeric)
                {
                    num = rd.Next(10);
                    password += number[num];
                }
                if(randNum == 3 && specialCarracters)
                {
                    spenum = rd.Next(22);
                    password += specialCar[spenum];
                }
            }
            textBox1.Text = password;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar1.Value.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && Convert.ToInt32(textBox2.Text) < 101 && Convert.ToInt32(textBox2.Text) > 0)
            {
                trackBar1.Value = Convert.ToInt32(textBox2.Text);
            }
        }
    }
}
