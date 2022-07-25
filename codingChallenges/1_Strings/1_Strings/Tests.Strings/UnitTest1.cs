using Xunit;

namespace StringManipulationChallenge.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void StringToUpperReturnsAllUpperCase()
        {
            //Arrange
            string s1 = "This is a test";

            //Act
            string result = Program.StringToUpper(s1);
            string expected = "THIS IS A TEST";

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringToLowerReturnsAllLowerCase()
        {
            //Arrange
            string s1 = "THIS IS A TEST";

            //Act
            string result = Program.StringToLower(s1);

            //Assert
            Assert.Equal("this is a test", result);
        }

        [Fact]
        public void StringTrimmerReturnsTrimmedString()
        {
            //Arrange
            string s1 = "  This is a test .  ";
            //Act
            string result = Program.StringTrim(s1);

            //Assert
            Assert.Equal("This is a test .", result);
        }

        [Fact]
        public void StringSubstringReturnsCorrectSubstring()
        {
            //Arrange
            string s1 = "This is a test";

            //Act
            string result = Program.StringSubstring(s1, 5, 8);

            //Assert
            Assert.Equal("is a tes", result);
        }

        [Fact]
        public void SearchCharReturnsIndexOfChar()
        {
            //Arrange
            string s1 = "This is a test";

            //Act
            int result = Program.SearchChar(s1, 't');

            //Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void ConcatNamesReturnsCompleteName()
        {
            //Arrange
            string s1 = "This is a test";
            string s2 = "of the emergency broadcast system";

            //Act
            string result = Program.ConcatNames(s1, s2);

            //Assert
            Assert.Equal("This is a test of the emergency broadcast system", result);
        }
    }
}
