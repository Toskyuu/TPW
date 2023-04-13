using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using Model;

namespace ViewModel
{
    public class GenerateBalls : INotifyPropertyChanged
    {
        private ObservableCollection<Ball> balls = new();
        private AbstractModelApi api;
        private int numberOfBalls;


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public GenerateBalls()
        {
            startMove = new StartMove(this);
            this.api = AbstractModelApi.API();
        }

        public ObservableCollection<Ball> Balls
        {
            get { return balls; }
            set
            {
                if (balls != value)
                {
                    balls = value;
                    OnPropertyChanged(nameof(balls));
                }
            }
        }
        public int NumberOfBalls
        {
            get { return numberOfBalls; }
            set
            {
                if (numberOfBalls != value)
                {
                    numberOfBalls = value;
                    OnPropertyChanged(nameof(numberOfBalls));
                }
            }
        }

        public void StartUpdating()
        {
            this.api.StartUpdating(numberOfBalls);
            this.Balls = api.GetBalls();
        }

        public void StopUpdating()
        {
            this.api.StopUpdating();
        }

        public bool IsUpdating()
        {
            return this.api.IsUpdating();
        }

        public StartMove startMove { get; set; }

        
    }

}
