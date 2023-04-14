using Logika;
using Model;


namespace Tests
{
    public class ModelBallTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _ModelBallTest()
        {
            Dane.Ball ball = new Dane.Ball(100, 200, 30);
            Logika.BallLogic ballLogic = new Logika.BallLogic(ball);

            Assert.AreEqual(ball.X, ballLogic.X);
            Assert.AreEqual(ball.Y, ballLogic.Y);
            Assert.AreEqual(ball.Radius, ballLogic.Radius);


        }


    }
}
