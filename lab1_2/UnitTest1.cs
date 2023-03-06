namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double x = 0;
            double result = lab1_2.Program.Example(x);
            Assert.AreEqual(10, result);
        }
    }
}
