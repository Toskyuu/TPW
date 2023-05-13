using System.Collections.ObjectModel;
using Logika;
using Model;

namespace Tests
{
    public class ModelApiTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _ModelApiTest()
        {
            AbstractLogicApi logicApi = AbstractLogicApi.API();
            AbstractModelApi modelApi = AbstractModelApi.API();
            modelApi.StartUpdating(30);
            ObservableCollection<Ball> balls = modelApi.GetBalls();
            Assert.AreEqual(30, modelApi.GetBalls().Count);
            Assert.NotNull(balls);
        }


    }
}
