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
        public abstract List<Ball> GetBalls();
        public abstract void StopUpdating();
        public abstract bool IsUpdating();
        public abstract Field Field { get; }   

        public static AbstractDataApi API()
        { 
            return new DataApi();
        }

        internal class DataApi : AbstractDataApi {
            private Field field;
            private bool updating;
            private readonly object positionLock = new();

            public bool Updating
            {
                get { return updating; }    
                set { updating = value; }
            }

            public override Field Field
            {
                get { return field; }
            }

            public override void CreateField(int height, int width, int numberOfBalls)
            {
                this.field = new Field(height, width, numberOfBalls);
                this.Updating = true;
                List<Ball> balls = GetBalls();

                foreach (Ball ball in balls)
                {
                    Task task = new Task(async () =>
                    {
                        while (updating)
                        {
                            lock (positionLock)
                            {
                                ball.changePosition(ball.X + ball.XSpeed, ball.Y + ball.YSpeed);
                            }
                            await Task.Delay(5);    
                        }
                    });
                    task.Start();
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

            public override List<Ball> GetBalls()
            {
                return this.field.Balls;
            }
        }
    }
}
