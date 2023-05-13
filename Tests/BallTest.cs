﻿using Dane;

namespace Tests
{
    public class BallTest
    {
        Ball ball = new Ball(30, 40, 20, 5);
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetterTest()
        {
            Assert.AreEqual(30, ball.X);
            Assert.AreEqual(40, ball.Y);
            Assert.AreEqual(20, ball.Radius);
            Assert.AreEqual(5, ball.Weight);
        }

        [Test]
        public void SetterTest()
        {
            ball.SetSpeed(2, 3);
            ball.X = 50;
            ball.Y = 60;
            ball.Radius = 30;

            Assert.AreEqual(2, ball.XSpeed);
            Assert.AreEqual(3, ball.YSpeed);
            Assert.AreEqual(50, ball.X);
            Assert.AreEqual(60, ball.Y);
            Assert.AreEqual(30, ball.Radius);
        }
    }
}