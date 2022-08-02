using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using _9_ClassesChallenge;

namespace _9_ClassesChallenge.Tests
{
    public class HumanTest
    {
        internal Human testHuman = new Human();
        internal Human2 human2 = new Human2();
        private Human h = new Human("Marielle", "Nolasco");
        private Human2 h1 = new Human2("Marielle", "Nolasco", "Brown", 21);
        private Human2 h2 = new Human2("Marielle", "Nolasco", "Brown");
        private Human2 h3 = new Human2("Marielle", "Nolasco", 21);

        [Fact]
        public void HumanShouldSetDefaultNames()
        {
            Assert.Equal("My name is Pat Smyth.", testHuman.AboutMe());
        }

        [Fact]
        public void HumanShouldSetNames()
        {
            Assert.Equal("My name is Marielle Nolasco.", h.AboutMe());
        }

        [Fact]
        public void Human2ShouldSetDefaultNames()
        {
            Assert.Equal("My name is Pat Smyth.", human2.AboutMe());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(500)]
        public void Human2ShouldNotAllowInvalidWeight(int weight)
        {
            // Arrange
            h1.Weight = 20;

            // Act
            h1.Weight = weight;

            // Assert
            Assert.Equal(0, h1.Weight);
        }

        [Fact]
        public void Human2ShouldSetValidWeight()
        {
            human2.Weight = 100;
            Assert.Equal(100, human2.Weight);
        }

        [Fact]
        public void Human2ShouldSetCorrectValues()
        {
            Assert.Equal("My name is Marielle Nolasco. My age is 21. My eye color is Brown.", h1.AboutMe2());
        }

        [Fact]
        public void Human2ShouldSetCorrectEyeColor()
        {
            Assert.Equal("My name is Marielle Nolasco. My eye color is Brown.", h2.AboutMe2());
        }

        [Fact]
        public void Human2ShouldSetCorrectAge()
        {
            Assert.Equal("My name is Marielle Nolasco. My age is 21.", h3.AboutMe2());
        }


    }
}
