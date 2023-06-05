using System.Diagnostics;
using System.Text.Json;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Dane
{
    internal class Logger
    {
        private Timer timer;
        private List<Ball> balls;


        public Logger(List<Ball> balls)
        {
            this.balls = balls;
            SetTimer();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            using (StreamWriter streamWriter =
                   new StreamWriter(Directory.GetCurrentDirectory() + "\\ballLogs.txt", true))
            {
                string msg = ("Log from " + e.SignalTime + "\n");
                foreach (Ball ball in balls)
                {
                    streamWriter.WriteLine(msg + JsonSerializer.Serialize(ball)); }
            }
        }

        private void SetTimer()
        {
            timer = new Timer(100);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public void Stop()
        {
            timer.Stop();
        }
    }
}