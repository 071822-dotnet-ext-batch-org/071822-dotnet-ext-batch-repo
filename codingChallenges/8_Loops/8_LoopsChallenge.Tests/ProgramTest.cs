using System;
using System.IO;
using Xunit;
using _8_LoopsChallenge;
using System.Collections.Generic;

namespace _8_LoopsChallenge.Tests
{
    public class ProgramTest
    {
        //public static readonly StringWriter output = new StringWriter();

        private readonly List<int> oddsAndEvens = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,1234,10,9,8,7,6,5,4,3,2,1// 10 odd, 11 even, 
        };

        private readonly List<object> oddsAndEvensDiffTypes = new List<object>()
        {
            -128,127,0,255,'h','e','y',-2147483648,"hey",21474836470,4294967295,
            "hey",-9223372036854775808,9223372036854775807,"hey",18446744073709551615,"hey"
        };//5 even

        [Fact]
        public void UseForShouldReturnHowManyEvenInts()
        {
            Assert.Equal(Program.UseFor(oddsAndEvens), 10);

            //keeping the below to remember how to test console values and set them..
            // Console.SetOut(output);
            // Program.UseFor();
            // int i = 1;
            // while (i < 50)
            // {
            //     Assert.Contains($"{i} ", output.ToString());
            //     i += 2;
            // }
            // //clear console output
            // output.GetStringBuilder().Remove(0, output.GetStringBuilder().Length);
        }


        [Fact]
        public void UseForEachShouldReturnHowManyEvenObjects()
        {
            Assert.Equal(Program.UseForEach(oddsAndEvensDiffTypes), 5);
        }

        // [Fact]
        // public void UseDoWhileShouldReturnHowManyFactors()
        // {
        //     // Arrange
        //     object[] array1 = new object[] { 10864.308642,27160.771605,-128,127,0,18107.18107,255,'h',13580.3858025,'e','y',-2147483648,"hey",21474836470,4294967295,
        //     "hey",-9223372036854775808,9053.590535,9223372036854775807,"hey",18446744073709551615,"hey"
        //     };
        //     double myDouble = 54321.54321;

        //     // Act
        //     // Assert
        //     Assert.Equal(Program.UseDoWhile(array1, myDouble), 5);
        // }

        [Fact]
        public void UseWhilehouldReturnHowManyMultiplesOf4()
        {
            Assert.Equal(2, Program.UseWhile(oddsAndEvens));
        }


        [Fact]
        public void UseForThreeFourReturnsHowManyMultiplesOf3And4()
        {
            int[] threefour = new int[]
            {
                1,12,2,3,4,5,6,7,8,9,10,1234,1236,10,9,8,7,6,5,4,3,2,1// 10 odd, 11 even, 
            };
            Assert.Equal(2, Program.UseForThreeFour(threefour));
        }

        [Fact]
        public void LoopdyLoopReturnsHowManyMultiplesOf3And4()
        {
            List<string>[] strings = new List<string>[5];
            strings[0] = new List<string> { "Tony", "look", "at" };
            strings[1] = new List<string> { "me.", "We're", "going to" };
            strings[2] = new List<string> { "be", "okay...", "I'm" };
            strings[3] = new List<string> { "sorry.", "You", "can" };
            strings[4] = new List<string> { "rest", "now.", "\n" };
            Assert.Equal("Tony look at me. We're going to be okay... I'm sorry. You can rest now. \n ", Program.LoopdyLoop(strings));
        }



    }// EoC
}// EoN
