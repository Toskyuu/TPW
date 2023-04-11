using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class abstractDataApi
    {
        public abstract void CreateField(int height, int width, int numberOfBalls);
        public abstract List<ball> getBalls();
        public abstract void StopUpdating();
        public abstract bool isUpdating();
        public abstract field field { get; }   

        public static abstractDataApi API()
        { 
            return new DataApi();
        }

        internal class DataApi : abstractDataApi {
            private field Field;
            private bool updating;
            private readonly object locked = new object();

            public bool Updating
            {
                get { return updating; }    
                set { updating = value; }
            }

            public override field field
            {
                get { return Field; }
            }

            public override void CreateField(int height, int width, int numberOfBalls)
            {
                this.Field = new field(height, width, numberOfBalls);
                this.Updating = true;
                List<ball> balls = getBalls();

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

            public override bool isUpdating()
            {
                return this.Updating;
            }

            public override List<ball> getBalls()
            {
                return this.field.Balls;
            }
        }
    }
}
