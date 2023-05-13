using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double xSpeed;
        private double ySpeed;
        private double weight;

        public Ball(double x, double y, int radius, int weight)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.weight = weight;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }

        public double Weight
        {
            get { return weight; }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }


        public double XSpeed
        {
            get { return xSpeed; }
            set
            {
                if (xSpeed != value)
                {
                    xSpeed = value;
                    OnPropertyChanged(nameof(XSpeed));
                }
            }
        }

        public double YSpeed
        {
            get { return ySpeed; }
            set
            {
                if (ySpeed != value)
                {
                    ySpeed = value;
                    OnPropertyChanged(nameof(YSpeed));
                }
            }
        }

        public void changePosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetSpeed(double x, double y)
        {
            if (x > 20 || y > 20)
            {
                x = 1;
                y = 1;
            }
            XSpeed = x;
            YSpeed = y;
        }
    }
}