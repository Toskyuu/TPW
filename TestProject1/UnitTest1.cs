using Programisko;
namespace TestProject1
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void DodawanieTest()
        {
            Program p1 = new Program(5, 4);
            p1.dodaj();
            Assert.AreEqual(9, p1.zwrocWynik());
        }
        [TestMethod]
        public void OdejmowanieTest()
        {
            Program p1 = new Program(5, 4);
            p1.odejmij();
            Assert.AreEqual(1, p1.zwrocWynik());
        }
        [TestMethod]
        public void MnozenieTest()
        {
            Program p1 = new Program(5, 4);
            p1.pomnoz();
            Assert.AreEqual(20, p1.zwrocWynik());
        }
        [TestMethod]
        public void DzielenieTest()
        {
            Program p1 = new Program(5, 4);
            p1.podziel();
            Assert.AreEqual(1, p1.zwrocWynik());
        }
    }
}