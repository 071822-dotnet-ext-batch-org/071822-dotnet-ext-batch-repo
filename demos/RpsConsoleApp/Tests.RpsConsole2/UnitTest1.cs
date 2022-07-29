
using RpsConsole2;

namespace Tests.RpsConsole2;

public class UnitTest1
{
    [Fact]
    public void NewGameMethodCreateGameWithDefaultP2()
    {
        //Arrange - set up the environment for the test. this includes variables, class objects, mock classes, etc
        // internal Player GetP2()
        // {
        //     return this._CurrentGame.P2;
        // }
        GamePlay gp = new GamePlay();// create the class
        gp.NewGame();// invoke the method to start a game... which creates a galme instance, which, by defulat, has a P2 that is the computer

        // act - do the action that invokes the method under test (MoT) and get the result
        Player p = gp.GetP2();
        string fname = "The";
        string lname = "Computer";

        //assert - compare teh expected result with the actual result of the 'act' action
        Assert.StrictEqual(fname, p.Fname);
        Assert.StrictEqual(lname, p.Lname);

    }

    [Fact]
    public void GameClassHasDefaultP2()
    {
        //arrange
        Game g = new Game();

        //act
        //no action necessary

        //assert
        Assert.Contains("omput", g.P2.Lname);
    }

    [Theory]
    [InlineData(false, new string[] { "Mark", "Moore" })]
    [InlineData(false, new string[] { "Mark" })]
    [InlineData(false, new string[] { })]
    public void DifferentNameCombinationsGetTreatedCorrectly(bool res, string[] strArr)
    {
        //arrange
        GamePlay g = new GamePlay();
        g.NewGame();

        //act - call P1Name(string[] playerNames)
        bool b = g.P1Name(strArr);
        Player p = g.GetP1();

        //assert
        if (strArr.Length == 2)
        {
            Assert.Equal("Mark", p.Fname);
            Assert.Equal("Moore", p.Lname);
        }
        else if (strArr.Length == 1)
        {
            Assert.Equal("Mark", p.Fname);
            Assert.Equal("default", p.Lname);
        }
        else if (strArr.Length == 0)
        {
            Assert.Equal("default", p.Fname);
            Assert.Equal("name", p.Lname);
        }
        else Assert.False(true);
    }



}//EoC