using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class field : INotifyPropertyChanged
    {
        private double height;
        private double width;
        private readonly List<ball> balls = new List<ball>();

        public field(double height, double width, int numberOfBalls)
        {
            this.height = height;
            this.width = width;
            CreateBalls(numberOfBalls, 20);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }

        public ball CreateBall(int radius)
        {
            Random r = new Random();
            int x = r.Next(20, (int)this.Height - 20);
            int y = r.Next(20, (int)this.Width - 20);

            int xSpeed = r.Next(-1, 2);
            int ySpeed = r.Next(-1, 2);

            ball createdBall = new ball(x, y, radius);

            createdBall.setSpeed(xSpeed, ySpeed);
            return createdBall;
        }
        public void CreateBalls(int numberOfBalls, int radius)
        {
            this.balls.Clear();
            for(int i = 0; i < numberOfBalls; i++)
            {
                this.balls.Add(CreateBall(radius));
            }
        }
        public List<ball> Balls
        {
            get { return balls; }
        }
    }
}
