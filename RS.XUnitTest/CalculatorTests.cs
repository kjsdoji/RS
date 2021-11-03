using System;
using Xunit;

namespace RS.XUnitTest
{
    public class CalculatorTests
    {
        [Theory]
        [JsonFileData("data.json", "AddData")]
        public void CanAddTheoryJsonFileFromProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }
    }
}
