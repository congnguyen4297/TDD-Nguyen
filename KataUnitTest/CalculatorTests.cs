using System;
using Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataUnitTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestInputString()
        {
            //Given
            var inputNumber = "";
            var expectedResult = 0;
            //When
            var result = Calculator.Calculate(inputNumber);
            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSingleNumberString()
        {
            //Given
            var inputNumber = "5";
            int expectedResult = 5;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSumOfTwoCommaDelim()
        {
            //Given
            var inputNumber = "5,4";
            int expectedResult = 9;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSumOfTwoNewLineDelim()
        {
            //Given
            var inputNumber = "5\n6";
            int expectedResult = 11;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSumOfThree()
        {
            //Given
            var inputNumber = "5\n6,5";
            int expectedResult = 16;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input should not be negative")]
        public void TestNegativeNumbers()
        {
            //Given
            var inputNumber = "-5\n6,5";

            //When
            var result = Calculator.Calculate(inputNumber);
        }

        [TestMethod]
        public void TestIgnoreBiggerThan1000()
        {
            //Given
            var inputNumber = "5\n6,1234";
            int expectedResult = 11;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestOneDelimAtBeginning()
        {
            //Given
            var inputNumber = "#5\n6,1234";
            int expectedResult = 11;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestManyDelimsAtBeginning()
        {
            //Given
            var inputNumber = "####5\n7,1234";
            int expectedResult = 12;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSquareBracketDelim()
        {
            //Given
            var inputNumber = "5[\n,]7[,]12";
            int expectedResult = 24;
            //When
            var result = Calculator.Calculate(inputNumber);

            //Then
            Assert.AreEqual(expectedResult, result);
        }
    }
}
