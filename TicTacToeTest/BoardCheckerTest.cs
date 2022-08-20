namespace TicTacToeTest;

using NUnit.Framework;
using TicTacToe;

public class BoardCheckerTest {

    public Board board;
    public BoardChecker boardChecker;

    [SetUp]
    public void Setup() {
        board = new Board(3);
        boardChecker = new BoardChecker();
    }

    [Test]
    public void DiagonalWinTest() {
        //create winning board
        board.TryInsert(0,0, PlayerIdentifier.Cross);
        board.TryInsert(1,1, PlayerIdentifier.Cross);
        board.TryInsert(2,2, PlayerIdentifier.Cross);
        //check if it has won
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
        board.TryInsert(2,0, PlayerIdentifier.Cross);
        board.TryInsert(1,1, PlayerIdentifier.Cross);
        board.TryInsert(0,2, PlayerIdentifier.Cross);
        //check if it has won
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));        
    }

    [Test]
    public void RowWinTest() {
        board.TryInsert(2,0, PlayerIdentifier.Cross);
        board.TryInsert(2,1, PlayerIdentifier.Cross);
        board.TryInsert(2,2, PlayerIdentifier.Cross);
        //check if it has won
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }
    
    [Test]
    public void ColumnWinTest() {

        //create winning board
        board.TryInsert(0,1, PlayerIdentifier.Cross);
        board.TryInsert(1,1, PlayerIdentifier.Cross);
        board.TryInsert(2,1, PlayerIdentifier.Cross);
        //check if it has won
        Assert.AreEqual(BoardState.Winner, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void InconclusiveTest() {
        //basically an empty board
        board.TryInsert(0,0, PlayerIdentifier.Cross);
        Assert.AreEqual(BoardState.Inconclusive, boardChecker.CheckBoardState(board));
    }

    [Test]
    public void TiedTest() {
        board.TryInsert(0,0,PlayerIdentifier.Cross);
        board.TryInsert(0,1,PlayerIdentifier.Naught);
        board.TryInsert(0,2,PlayerIdentifier.Cross);
        board.TryInsert(1,0,PlayerIdentifier.Cross);
        board.TryInsert(1,1,PlayerIdentifier.Naught);
        board.TryInsert(1,2,PlayerIdentifier.Cross);
        board.TryInsert(2,0,PlayerIdentifier.Naught);
        board.TryInsert(2,1,PlayerIdentifier.Cross);
        board.TryInsert(2,2,PlayerIdentifier.Naught);
        //check if it has won
        Assert.AreEqual(boardChecker.CheckBoardState(board), BoardState.Tied);
    }
}
