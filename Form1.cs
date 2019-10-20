using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsInterface01
{
    public partial class Form1 : Form
    {
       
        Shape sh = new Shape();
        int timer = 0;
        int Sleep = 1000;
        public int NumWiederholungen;
        
        //public static Double Counter; 

        public Form1()
        {
            sh.Counter = 0;
            
            //NumWiederholungen = (int)this.Anz_comboBox3.SelectedValue;            
            InitializeComponent();
            sh.panel1_Screen = panel1_Screen;
            sh.panel1_Screen.BackColor = Color.Black;

            comboBox1.Text = "Line";
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            sh.Counter = 0;
            timer1.Start();

            try
            {
                NumWiederholungen = Convert.ToInt32(this.Anz_comboBox3.SelectedItem.ToString());
            }
            catch(System.NullReferenceException)
            {
                timer1.Stop();
                MessageBox.Show("Bitte geben Sie die Wiederholungs Nummer an !");
                
            }

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;

            int raster = 10;
            Pen pinsel = new Pen(Color.White, 3);
            
            System.Windows.Forms.Timer thisTimer = sender as System.Windows.Forms.Timer;


            if (sh.dir.maxsmall == true)
            {
                sh.newX -= raster;
                sh.newY -= raster;
            }
            else
            {
                sh.newX += raster;
                sh.newY += raster;
            }

            

            if (comboBox1.SelectedItem.ToString() == "Rectangle")
            {
                sh.drawRect(new Point(sh.newX, sh.newY));
                //drawRect(new Point(newX, newY));
                System.Threading.Thread.Sleep(Sleep / trackBar1.Value);
                sh.Zeichenfläche.Clear(Color.Black);
            }

            if(comboBox1.SelectedItem.ToString()== "Circle")
            {
                sh.Circle(new Point(sh.newX, sh.newY));

                System.Threading.Thread.Sleep(Sleep / trackBar1.Value);
                sh.Zeichenfläche.Clear(Color.Black);
            }

            if(comboBox1.SelectedItem.ToString() == "Line")
            {
                sh.Line(new Point(sh.newX, sh.newY));

                System.Threading.Thread.Sleep(Sleep / trackBar1.Value);
                sh.Zeichenfläche.Clear(Color.Black);
            }

            

            textBox1.Text = sh.Counter.ToString();



            if (timer % (panel1_Screen.Width / 10) == 0)
            {
                sh.Counter += 1;

                if (sh.Counter >= NumWiederholungen)
                {
                    timer1.Stop();
                }
            }
        }
    }
}
