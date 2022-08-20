namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;
using TicTacToe.IO;


public class CursorTest {
    private Cursor cursor;

    [SetUp]
    public void Setup() {
        var keyToMoveMap = new KeyToMoveMap('i', 'k', 'j', 'l', 'q', ' ');
        cursor = new Cursor(3, keyToMoveMap);
        cursor.MoveDown();
        cursor.MoveRight();
    }

    [Test]
    public void CursorCenterTest() {
        Assert.True(cursor.position.X == 1 && cursor.position.Y == 1);
    }

    [Test]
    public void MoveUpTest() {
        //1 test: that it actually moves
        cursor.MoveUp();
        //2 test: that it dosn't move outside the screen
        cursor.MoveUp();
        Assert.True(cursor.position.Y == 0);
    }

    [Test]
    public void MoveDownTest() {
        //1 test: that it actually moves
        cursor.MoveDown();
        //2 test: that it dosn't move outside the screen
        cursor.MoveDown();
        Assert.True(cursor.position.Y == 2);
    }
    
    [Test]
    public void MoveLeftTest() {
        //1 test: that it actually moves
        cursor.MoveLeft();
        //2 test: that it dosn't move outside the screen
        cursor.MoveLeft();
        Assert.True(cursor.position.X == 0);
    }

    [Test]
    public void MoveRightTest() {
        //1 test: that it actually moves
        cursor.MoveRight();
        //2 test: that it dosn't move outside the screen
        cursor.MoveRight();
        Assert.True(cursor.position.X == 2);
    }   
}
