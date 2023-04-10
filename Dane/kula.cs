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
            double pY = Math.Sqrt(2 - (pX * pX));
            if (pY > 1 )
            { 
                pY = - pY + 1; 
            }

            predkoscX = pX;
            predkoscY = pY;
        }



        static public void main()
        {
            Random rnd = new Random();
            double pX = 0;
            double pY;
            
            for (int i = 0; i < 100; i++)
            {
                do
                {
                    pX = rnd.NextDouble();
                } while (pX == 0);
                pY = Math.Sqrt(2 - (pX + pX));
                if (pY > 1)
                {
                    pY = - pY +1;
                }
                Console.WriteLine("PX" + pX);
                Console.WriteLine("PY" + pY);

            }
            
        }
    }
}
