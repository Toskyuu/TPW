﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dane;
using Logika;
using Model;

namespace ViewModel
{
    public class StopMove : ICommand
    {
        GenerateBalls generateBalls;
        public StopMove(GenerateBalls generateBalls)
        {
            this.generateBalls = generateBalls;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (this.generateBalls.IsUpdating())
            {
                this.generateBalls.StopUpdating();
            }

        }
    }
}
