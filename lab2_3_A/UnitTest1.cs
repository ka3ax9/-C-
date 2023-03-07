namespace lab2_3_A
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void TestProductAndSum()
        {
            // Arrange
            int[] arr = { -3, 4, 7, -5, 6, 8, 2 };
            int expectedProduct = 2688;
            int expectedSum = 19;

            // Act
            int actualProduct = 1, actualSum = 0, lastPositiveIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    actualProduct *= arr[i];
                    lastPositiveIndex = i;
                }
                actualSum += arr[i];
            }

            // Assert
            if (lastPositiveIndex == -1)
            {
                Assert.AreEqual(expectedProduct, 1);
                Assert.AreEqual(expectedSum, actualSum);
            }
            else
            {
                Assert.AreEqual(expectedProduct, actualProduct);
                Assert.AreEqual(expectedSum, actualSum - arr.Length + lastPositiveIndex + 1);
            }
        }
    }
}