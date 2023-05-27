using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Field : INotifyPropertyChanged
    {
        private int height;
        private int width;
        private readonly List<Ball> balls = new();

        public Field(int height, int width, int numberOfBalls)
        {
            this.height = height;
            this.width = width;
            Random r = new Random();
            int radius = 15;
            CreateBalls(numberOfBalls, radius);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Height
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

        public int Width
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

        public Ball CreateBall(int radius)
        {
            Random r = new Random();
            bool valid = true;
            
            double x = r.Next(20, this.Width - 20);
            double y = r.Next(20, this.Height - 20);

            double xSpeed = 0;
            double ySpeed = 0;

            while (xSpeed == 0)
            {
                xSpeed = r.Next(-3, 4);
            }
            while(ySpeed == 0)
            {
                ySpeed = r.Next(-3, 4);
            }

            int weight = r.Next(1,3);
            Ball createdBall = new Ball(x, y, radius, weight);

            createdBall.SetSpeed(xSpeed, ySpeed);
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
        public List<Ball> Balls
        {
            get { return balls; }
        }
    }
}
