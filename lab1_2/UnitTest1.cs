namespace lab1_2test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestY()
        {
            double x = 0;
            double expectedY = 10;

            double actualY = Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - 5 * x + 9 + Math.Cos(x);

            Assert.AreEqual(expectedY, actualY);
        }
    }
}