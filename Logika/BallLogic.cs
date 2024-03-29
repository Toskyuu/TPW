﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class BallLogic : INotifyPropertyChanged
    {
        private Ball ball;
        public BallLogic(Ball ball)
        {
            this.ball = ball;
            this.ball.PropertyChanged += Update;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ball.X)) 
            {
                OnPropertyChanged(nameof(ball.X));
            }
            else if(e.PropertyName == nameof(ball.Y))
            {
                OnPropertyChanged(nameof(ball.Y));
            }
            else if(e.PropertyName == nameof(ball.Radius))
            {
                OnPropertyChanged(nameof(ball.Radius));
            }
        }

        public double X
        {
            get { return ball.X; }
            set
            {
                if (ball.X != value)
                {
                    ball.X = value;
                    OnPropertyChanged(nameof(ball.X));
                }
            }
        }

        public double Y
        {
            get { return ball.Y; }
            set
            {
                if (ball.Y != value)
                {
                    ball.Y = value;
                    OnPropertyChanged(nameof(ball.Y));
                }
            }
        }

        public double Radius
        {
            get { return ball.Radius; }
        }

        public double Weight
        {
            get { return ball.Weight;  }
        }


    }
}
