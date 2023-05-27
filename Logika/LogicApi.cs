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
        public abstract List<BallLogic> GetBalls();
        public abstract void StartUpdating(int height, int width, int numberOfBalls);
        public abstract void StopUpdating();
        public abstract bool IsUpdating();

        public static AbstractLogicApi API(AbstractDataApi abstractDataApi = null)
        {
            return new LogicApi(abstractDataApi);
        }

        internal class LogicApi : AbstractLogicApi
        {
            private List<BallLogic> balls = new();
            private AbstractDataApi dataApi;
            private readonly object speedLock = new object();


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
            public override List<BallLogic> GetBalls()
            {
                return this.balls;
            }

            public override void StartUpdating(int height, int width, int numberOfBalls)
            {
                this.dataApi.CreateField(height, width, numberOfBalls);
                foreach (Ball ball in this.dataApi.GetBalls())
                {
                    this.balls.Add(new BallLogic(ball));
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
                Ball ball = (Ball)sender;
                if (e.PropertyName == nameof(ball.X) || e.PropertyName == nameof(ball.Y))
                {
                    FieldCollision(ball);
                    BallCollision(ball);
                }
            }

            private void FieldCollision(Ball ball)
            {
                if (ball.X <= 0)
                {
                    ball.SetSpeed(Math.Abs(ball.XSpeed), ball.YSpeed);
                    ball.X = 1;
                }
                if (ball.Y  <= 0)
                {
                    ball.SetSpeed(ball.XSpeed,Math.Abs(ball.YSpeed));
                    ball.Y = 1;
                }
                if ((ball.X + ball.Radius) >= this.dataApi.Field.Width )
                {
                    ball.SetSpeed(-Math.Abs(ball.XSpeed), ball.YSpeed);
                    ball.X = dataApi.Field.Width - ball.Radius - 1;
                }
                if ((ball.Y + ball.Radius) >= this.dataApi.Field.Height )
                {
                    ball.SetSpeed(ball.XSpeed, -Math.Abs(ball.YSpeed));
                    ball.Y = dataApi.Field.Height - ball.Radius - 1;
                }
            }

            private void BallCollision(Ball ball)
            {
                foreach (Ball ball2 in dataApi.GetBalls()){
                    if (ball2 == ball)
                    {
                        continue;
                    }

                    double ballCenterX = ball.X + ball.Radius / 2 ;
                    double ball2CenterX = ball2.X + ball2.Radius / 2;
                    double ballCenterY = ball.Y + ball.Radius / 2 ;
                    double ball2CenterY = ball2.Y + ball2.Radius / 2 ;

                    if (Math.Pow(Math.Pow((ballCenterX + ball.XSpeed) - (ball2CenterX + ball2.XSpeed), 2) + Math.Pow(((ballCenterY + ball.YSpeed) - (ball2CenterY + ball2.YSpeed)), 2),0.5) < ((ball.Radius / 2) + (ball2.Radius / 2)))
                    {
                        double newXSpeedForBall2 =
                            ((ball2.XSpeed * (ball2.Weight - ball.Weight) + (ball.Weight * ball.XSpeed * 2)) /
                             (ball2.Weight + ball.Weight));
                        double newXSpeedForBall =
                            ((ball.XSpeed * (ball.Weight - ball2.Weight) + (ball2.Weight * ball2.XSpeed * 2)) /
                             (ball.Weight + ball2.Weight));
                        double newYSpeedForBall2 = 
                            ((ball2.YSpeed * (ball2.Weight - ball.Weight) + (ball.Weight * ball.YSpeed * 2)) /
                             (ball2.Weight + ball.Weight));
                        double newYSpeedForBall = 
                            ((ball.YSpeed * (ball.Weight - ball2.Weight) + (ball2.Weight * ball2.YSpeed * 2)) /
                             (ball.Weight + ball2.Weight));
                        
                        lock (speedLock)
                        {
                            ball.SetSpeed(newXSpeedForBall, newYSpeedForBall);
                            ball2.SetSpeed(newXSpeedForBall2, newYSpeedForBall2);
                        }
                    }
                }
            }
        }
    }
}
