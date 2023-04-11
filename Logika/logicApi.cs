using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public abstract List<ballLogic> GetBalls();
        public abstract void StartUpdating(int height, int width, int numberOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();

        public static AbstractLogicApi API(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        internal class LogicApi : AbstractLogicApi
        {
            private List<ballLogic> balls = new();
            private AbstractDataApi dataApi;

            public LogicApi(AbstractDataApi abstractDataApi = null)
            {
                if (abstractDataApi == null)
                {
                    this.dataApi = AbstractDataApi.API();
                }
                else
                {
                    this.dataApi = abstractDataApi;
                }
            }
            public override List<ballLogic> GetBalls()
            {
                return this.balls;
            }

            public override void StartUpdating(int height, int width, int numberOfBalls)
            {
                this.dataApi.CreateField(height, width, numberOfBalls);
                foreach (ball ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new ballLogic(ball));
                    ball.PropertyChanged += CheckCollision;
                }
            }
            public override void StopUpdating()
            {
                this.dataApi.StopUpdating();
                this.balls.Clear();
            }

            public override bool IsUpdating()
            {
                return dataApi.IsUpdating();
            }

            public void CheckCollision(object sender, PropertyChangedEventArgs e)
            {
                ball ball = (ball)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    FieldCollision(ball);
                }
            }

            private void FieldCollision(ball ball)
            {
                if (ball.X <= 0)
                {
                    ball.setSpeed(1, ball.YSpeed);
                }
                if (ball.Y <= 0)
                {
                    ball.setSpeed(ball.XSpeed, 1);
                }
                if (ball.X >= this.dataApi.Field.Width - ball.Radius)
                {
                    ball.setSpeed(-1, ball.YSpeed);
                }
                if (ball.Y >= this.dataApi.Field.Height - ball.Radius)
                {
                    ball.setSpeed(ball.XSpeed, -1);
                }
            }
        }
    }
}
