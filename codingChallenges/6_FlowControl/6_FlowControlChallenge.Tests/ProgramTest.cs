using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using _6_FlowControl;

namespace _6_FlowControlChallenge.Tests
{
    public class ProgramTest
    {
        public static readonly StringWriter output = new StringWriter();
        public static readonly IEnumerable<object[]> _tempList = new List<object[]>
        {
            new object[] {-30},
            new object[] {18},
            new object[] {60},
            new object[] {120}
        };

        [Theory]
        [MemberData(nameof(_tempList))]
        public void GetValidTempReturnsValidTemp(int temp)
        {
            var input = new StringReader(temp.ToString());
            Console.SetIn(input);
            Assert.Equal(temp, Program.GetValidTemperature());
            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Fact]
        public void RegisterShouldRegister()
        {
            Console.SetOut(output);

            var input = new StringReader("mars");
            Console.SetIn(input);

            Program.Register();

            Assert.Contains("saved", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Fact]
        public void GetTemperatureTernaryShouldSayTooCold()
        {
            Console.SetOut(output);

            Program.GetTemperatureTernary(20);
            Assert.Contains("too cold!", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Fact]
        public void GetTemperatureTernaryShouldSayOK()
        {
            Console.SetOut(output);

            Program.GetTemperatureTernary(50);
            Assert.Contains("ok temperature", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Fact]
        public void GetTemperatureTernaryShouldSayTooHot()
        {
            Console.SetOut(output);

            Program.GetTemperatureTernary(100);
            Assert.Contains("too hot", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(-21)]
        [InlineData(-22)]
        [InlineData(-30)]
        [InlineData(-40)]
        public void GiveActivityAdviceShouldSayHellaCold(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("hella cold", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }
        [Theory]
        [InlineData(-19)]
        [InlineData(-18)]
        [InlineData(-5)]
        [InlineData(-1)]
        public void GiveActivityAdviceShouldSayPrettyCold(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("pretty cold", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }
        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(6)]
        [InlineData(19)]
        public void GiveActivityAdviceShouldSayCold(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("cold", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }
        [Theory]
        [InlineData(21)]
        [InlineData(30)]
        [InlineData(35)]
        [InlineData(25)]
        public void GiveActivityAdviceShouldSayThawedOut(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("thawed out", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(45)]
        [InlineData(50)]
        [InlineData(55)]
        [InlineData(40)]
        public void GiveActivityAdviceShouldSayFeelsLikeAutumn(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("feels like Autumn", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(65)]
        [InlineData(70)]
        [InlineData(75)]
        [InlineData(60)]
        public void GiveActivityAdviceShouldSayPerfectOutdoorTemp(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("perfect outdoor workout temperature", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(80)]
        [InlineData(82)]
        [InlineData(85)]
        [InlineData(88)]
        public void GiveActivityAdviceShouldSayNice(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("niiice", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(95)]
        [InlineData(90)]
        [InlineData(93)]
        [InlineData(99)]
        public void GiveActivityAdviceShouldSayHellaHot(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("hella hot", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(120)]
        [InlineData(125)]
        [InlineData(130)]
        public void GiveActivityAdviceShouldSayHottest(int temp)
        {
            Console.SetOut(output);

            Program.GiveActivityAdvice(temp);
            Assert.Contains("hottest", output.ToString());

            //clear console output
            output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }
    }
}
