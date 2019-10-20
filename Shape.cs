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
    class Shape
    {
        public int newX;
        public int newY;
        public PictureBox panel1_Screen;
        public int Counter;



        public Graphics Zeichenfläche;
        public Richtung dir = new Richtung();


        public struct Richtung
        {
            public bool maxsmall;
            public bool maxLarge;
        }

        public void drawRect(Point po)
        {

            Zeichenfläche = panel1_Screen.CreateGraphics();
            int rectWidth = panel1_Screen.Width - (po.X * 2);
            int rectHeight = panel1_Screen.Height - (po.Y * 2);

            Pen pinsel = new Pen(Color.White, 5);
            Rectangle rect = new Rectangle(po.X, po.Y, rectWidth, rectHeight);
            Zeichenfläche.DrawRectangle(pinsel, rect);

            if (rect.Width <= panel1_Screen.Width / 5)
            {
                
                dir.maxsmall = true;
                dir.maxLarge = false;
                
                
            }
            if (rect.Width >= panel1_Screen.Width)
            {
                dir.maxLarge = true;
                dir.maxsmall = false;
            }

            return ;
        }

        public void  Circle(Point po)
        {
            Zeichenfläche = panel1_Screen.CreateGraphics();
            int rectWidth = panel1_Screen.Width - (po.X * 2);
            int rectHeight = panel1_Screen.Height - (po.Y * 2);

            Pen pinsel = new Pen(Color.White, 5);
            Rectangle rect = new Rectangle(po.X, po.Y, rectWidth, rectHeight);

            Zeichenfläche.DrawEllipse(pinsel, rect);
            

            if (rect.Width <= panel1_Screen.Width / 5)
            {

                dir.maxsmall = true;
                dir.maxLarge = false;


            }
            if (rect.Width >= panel1_Screen.Width)
            {
                dir.maxLarge = true;
                dir.maxsmall = false;
            }

            return;
        }

        public void Line(Point po)
        {
            Zeichenfläche = panel1_Screen.CreateGraphics();
            
            Pen pinsel = new Pen(Color.White, 5);
            
            Point StPt = new Point(0, po.Y + panel1_Screen.Height/2);
            Point EndPt = new Point(panel1_Screen.Width, po.Y + panel1_Screen.Height / 2);

            Point StPt1 = new Point(0, -po.Y + panel1_Screen.Height / 2);
            Point EndPt1 = new Point(panel1_Screen.Width, - po.Y + panel1_Screen.Height / 2);

            Zeichenfläche.DrawLine(pinsel, StPt, EndPt);
            Zeichenfläche.DrawLine(pinsel, StPt1, EndPt1);

            if (po.Y + panel1_Screen.Height / 2 >= panel1_Screen.Height)
            {

                dir.maxsmall = true;
                dir.maxLarge = false;


            }
            if (po.Y + panel1_Screen.Height / 2 <= panel1_Screen.Height/2)
            {
                dir.maxLarge = true;
                dir.maxsmall = false;
            }

            return;


        }

    }
}
