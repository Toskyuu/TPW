using Logika;

namespace Tests
{
    public class LogicApiTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _LogicApiTest()
        {
            AbstractLogicApi api = AbstractLogicApi.API();
            api.StartUpdating(1000, 200, 30);
            Assert.AreEqual(30, api.GetBalls().Count);
        }


    }
}
