using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_rob4
{
    public partial class Form1 : Form
    {
        Form2 ff;
        delegate void myType(int nim);
        event myType myEvent;

        delegate void Type();
        event Type myEvent2;

        public Form1(Form2 form1)
        {
            ff = form1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt32(textBox1.Text);
                c++;
                textBox1.Text = Convert.ToString(c, 10);

                int w = button1.Width;
                int ww = w + 1;
                button1.Width = ww;

                int h = button1.Height;
                int hh = h + 1;
                button1.Height = hh;

                myEvent(c);
            }
            catch (Exception)
            {
                MessageBox.Show("Щось пішло не так");
                return;
            }

        }
        public void myFunction5()
        {
            Random random1 = new Random();
            int r = random1.Next(0, 255);
            int g = random1.Next(0, 0xFF);
            int b = random1.Next(0, 0b11111111);
            ff.progressBar1.BackColor = Color.FromArgb(r, g, b);
        }
        private void myFunction3(int d)
        {
            Random random = new Random();
            int r = random.Next(0, 255);
            int g = random.Next(0, 0xFF);
            int b = random.Next(0, 0b11111111);
            button1.BackColor = Color.FromArgb(r, g, b);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            myType myDelegate1 = form2.myFunction1;
            myType myDelegate2 = form2.myFunction2;

            myType myDelegate3 = this.myFunction3;
            // те саме, але більш лаконічно:
            myEvent += myDelegate1; //myEvent += form2.myFunction1;
            myEvent += myDelegate2; //myEvent += form2.myFunction2;
            myEvent += myDelegate3; //myEvent += this.myFunction3;
            myEvent2 += myFunction5;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    


    
    }
}
