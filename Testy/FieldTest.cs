using Dane;

namespace Tests
{
    public class FieldTest
    {
        Field field = new Field(500, 400, 20);
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetterTest()
        {
            Assert.AreEqual(500, field.Height);
            Assert.AreEqual(400, field.Width);
            Assert.AreEqual(20, field.Balls.Count);
        }

        [Test]
        public void SetterTest()
        {
            field.Width = 1000;
            field.Height = 2000;

            Assert.AreEqual(1000, field.Width);
            Assert.AreEqual(2000, field.Height);

        }
    }
}
