﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Field : INotifyPropertyChanged
    {
        private double height;
        private double width;
        private readonly List<Ball> balls = new();

        public Field(double height, double width, int numberOfBalls)
        {
            this.height = height;
            this.width = width;
            CreateBalls(numberOfBalls, 50);
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

        public Ball CreateBall(int radius)
        {
            Random r = new Random();
            int x = r.Next(radius, (int)this.Width - radius);
            int y = r.Next(radius, (int)this.Height - radius);
            int xSpeed = 0;
            int ySpeed = 0;

            while (xSpeed == 0)
            {
                xSpeed = r.Next(-3, 4);
            }
            while(ySpeed == 0)
            {
                ySpeed = r.Next(-3, 4);
            }

            int weight = 1;
            Ball createdBall = new Ball(x, y, radius, weight);

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
        public List<Ball> Balls
        {
            get { return balls; }
        }
    }
}
