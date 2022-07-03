using Calculator;
using Telerik.JustMock;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private SimpleCalculator? calculator;
        private Logger? logger;

        [TestInitialize]
        public void Initialise()
        {
            logger = Mock.Create<Logger>(Behavior.CallOriginal);
            calculator = new SimpleCalculator(logger);
        }

        // Use AreEqual(expectedValue(actualValue))
        // Mock.Arrange() - make sure we get expected diagnostic results
        [TestMethod]
        public void Add()
        {
            Assert.AreEqual(2, calculator.Add(1, 1));
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(0, calculator.Subtract(1, 1));
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(2, calculator.Multiply(1, 2));
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }

        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(2, calculator.Divide(4, 2));
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        // Divide by zero, will give our custom exception
        public void DivideException()
        {
            calculator.Divide(2, 0);
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }

        [TestMethod]
        public void GetPrimeNumber()
        {
            // Make sure we return a value
            Assert.IsNotNull(calculator.GetPrimeNumber(4));
            Mock.Arrange(() => logger.Log(Arg.AnyString));
        }
    }
}