using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class kula
    {
        private double x;
        private double y;
        private double waga;
        private double promien;
        private double predkoscX;
        private double predkoscY;

        public kula(double x, double y, double waga, double promien)
        {
            this.x = x;
            this.y = y;
            this.waga = waga;
            this.promien = promien;
            Random rnd = new Random();
            double pX;
            do
            {
                pX = rnd.NextDouble();
            } while (pX == 0);
            double pY = Math.Sqrt(2 - (pX + pX));
            if (pY > 1 )
            { 
                pY = - pY + 1; 
            }

            predkoscX = pX;
            predkoscY = pY;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Waga
        {
            get { return waga; }
            set { waga = value; }
        }

        public double Promien
        {
            get { return promien; }
            set { promien = value; }
        }

        public double PredkoscX
        {
            get { return predkoscX; }
            set { predkoscX = value; }
        }

        public double PredkoscY
        {
            get { return predkoscY; }
            set { predkoscY = value; }  
        }

        public void ruch()
        {
            X += predkoscX;
            Y += predkoscY;
        }

        
    }
}
