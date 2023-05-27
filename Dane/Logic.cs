
using System.Diagnostics;
using System.Text.Json;

namespace Dane
{
    internal class Logger
    {
        private Stopwatch stopWatch = new Stopwatch();
        private int index = 0;

        public Logger(List<Ball> balls)
        {
            Task t = new Task(async () =>
            {
                stopWatch.Start();
                while (true)
                {
                    if (stopWatch.ElapsedMilliseconds >= 5)
                    {
                        stopWatch.Restart();
                        using (StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + "\\orbLog.txt", true))
                        {
                            string msg = ($". Log from {DateTime.Now:R}");
                            foreach (Ball ball in balls)
                            {
                                streamWriter.WriteLine(index + msg + JsonSerializer.Serialize(ball));
                                index += 1;
                            }
                            
                        }
                    }
                }
            });
            t.Start();
        }

        public void Stop()
        {
            stopWatch.Reset();
            stopWatch.Stop();
            index = 0;
        }
    }
}