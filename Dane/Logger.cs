using System.Diagnostics;
using System.Text.Json;

namespace Dane
{
    internal class Logger
    {
        private int index = 0;
        Stopwatch stopWatch = new Stopwatch();


        public Logger(List<Ball> balls)
        {
            stopWatch.Start();
            Task t = new Task(async () =>
            {
                while (true)
                {
                    if (stopWatch.IsRunning)
                    {
                        using (StreamWriter streamWriter =
                               new StreamWriter(Directory.GetCurrentDirectory() + "\\ballLogs.txt", true))
                        {
                            TimeSpan ts = stopWatch.Elapsed;
                            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds);
                            string msg = ($". Log from {DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss")}\n" +
                                          $"App running time: " + elapsedTime + "\n");
                            foreach (Ball ball in balls)
                            {
                                streamWriter.WriteLine(index + msg + JsonSerializer.Serialize(ball));
                                index += 1;
                            }
                        }
                    }

                    await Task.Delay(5);
                }
            });
            t.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
            index = 0;
        }
    }
}