using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateField(int height, int width, int numberOfBalls);
        public abstract List<ball> GetBalls();
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract field Field { get; }   

        public static AbstractDataApi API()
        { 
            return new DataApi();
        }

        internal class DataApi : AbstractDataApi {
            private field field;
            private bool updating;
            private readonly object locked = new();

            public bool Updating
            {
                get { return updating; }    
                set { updating = value; }
            }

            public override field Field
            {
                get { return Field; }
            }

            public override void CreateField(int height, int width, int numberOfBalls)
            {
                this.field = new field(height, width, numberOfBalls);
                this.Updating = true;
                List<ball> balls = GetBalls();

                foreach (ball ball in balls)
                {
                    Thread thread = new Thread(() =>
                    {
                        while (updating)
                        {
                            lock (locked)
                            {
                                ball.changePosition(ball.X + ball.XSpeed, ball.Y + ball.YSpeed);
                            }
                            Thread.Sleep(10);
                        }
                    });
                    thread.Start();
                }
            }

            public override void StopUpdating()
            {
                this.Updating = false;
            }

            public override bool IsUpdating()
            {
                return this.Updating;
            }

            public override List<ball> GetBalls()
            {
                return this.field.Balls;
            }
        }
    }
}
