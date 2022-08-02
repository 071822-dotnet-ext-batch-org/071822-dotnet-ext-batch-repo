using Xunit;
using System.Collections.Generic;
using _5_OperatorsChallenge;

namespace _5_OperatorsChallenge.Tests
{
    public class ProgramTest
    {
        public static readonly IEnumerable<object[]> _singleNumbers = new List<object[]>
        {
            new object[] {1},
            new object[] {2},
            new object[] {3},
            new object[] {4}
        };
        public static readonly IEnumerable<object[]> _pairNumbers = new List<object[]>
        {
            new object[] {1,2},
            new object[] {2,3},
            new object[] {3,4},
            new object[] {4,5}
        };

        [Theory]
        [MemberData(nameof(_singleNumbers))]
        public void IncrementShouldIncrement(int input)
        {
            Assert.Equal(Program.Increment(input), ++input);
        }

        [Theory]
        [MemberData(nameof(_singleNumbers))]
        public void DecrementShouldDecrement(int input)
        {
            Assert.Equal(Program.Decrement(input), --input);
        }

        [Theory]
        [MemberData(nameof(_singleNumbers))]
        public void NegateShouldNegate(int input)
        {
            Assert.Equal(-input, Program.Negate(input));
        }

        [Fact]
        public void NotShouldNegate()
        {
            Assert.True(Program.Not(false));
            Assert.False(Program.Not(true));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void SumShouldReturnSum(int num1, int num2)
        {
            Assert.Equal(num1 + num2, Program.Sum(num1, num2));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void DiffShouldReturnDiff(int num1, int num2)
        {
            Assert.Equal(num1 - num2, Program.Diff(num1, num2));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void ProductShouldReturnProduct(int num1, int num2)
        {
            Assert.Equal(num1 * num2, Program.Product(num1, num2));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void QuotientShouldReturnQuotient(int num1, int num2)
        {
            Assert.Equal(num1 / num2, Program.Quotient(num1, num2));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void RemainderShouldReturnRemainder(int num1, int num2)
        {
            Assert.Equal(num1 % num2, Program.Remainder(num1, num2));
        }

        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void AndShouldReturnFalse(int num1, int num2)
        {
            Assert.False(Program.And(num1, num2));
        }
        [Theory]
        [MemberData(nameof(_pairNumbers))]
        public void OrShouldReturnFalse(int num1, int num2)
        {
            Assert.False(Program.Or(num1, num2));
        }

    }
}
