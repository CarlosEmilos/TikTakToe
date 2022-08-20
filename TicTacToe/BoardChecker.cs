namespace TicTacToe;

using System;
using TicTacToe.Interfaces;


/// <summary>
/// A basic board checker that will determine if for a given row, diagonal or column, if all of
/// the elements is equal to eachother and not equal to null. It will also determine if the board
/// is in a tied position.
/// </summary>
public class BoardChecker : IBoardChecker {

    /// <summary>
    /// Method that is used to check if all elements in a row is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the row is equal else false.
    /// </returns>
    private bool IsRowWin(Board board) {
        int cross = 0;
        int naught = 0;

        for (int i = 0; i < board.Size ; i++){
            //cross and naught reset when there's a new row
            cross = 0; 
            naught = 0;
            for (int j = 0; j < board.Size; j++){
                if (board.Get(i,j) == PlayerIdentifier.Naught){
                    //add to naught 
                    naught += 1;
                } else if (board.Get(i,j) == PlayerIdentifier.Cross) {
                    cross += 1;
                }
            }
            //if naught or cross have n rows, they win!
            if (naught == board.Size || cross == board.Size){return true;}
        }
        //else return false
        return false;
    }



    /// <summary>
    /// Method that is used to check if all elements in a column is equal to eachother and is not
    /// equal to null.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the column is equal else false.
    /// </returns>
    private bool IsColWin(Board board) {
        //same as row win but switched i and j
        int cross = 0;
        int naught = 0;

        for (int i = 0; i < board.Size ; i++){
            cross = 0; 
            naught = 0;
            //cross and naught reset when there's a new row
            //change the (i,j) because it's columns
            for (int j = 0; j < board.Size; j++){
                if (board.Get(j,i) == PlayerIdentifier.Naught){
                    //add to naught reset cross
                    naught += 1;
                    //return true because there's a winner, same below
                } else if (board.Get(j,i) == PlayerIdentifier.Cross) {
                    cross += 1;
                }
            }
            if (naught == board.Size || cross == board.Size){return true;}
        }
        //else return false
        return false;
    }

    /// <summary>
    /// Method that is used to check if all elements in a diagonal is equal to eachother and is not
    /// equal to null. This diagonal will always be the two longest in a square.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns>
    /// True if there is a win where all identifiers in the diagonal is equal else false.
    /// </returns>
    private bool IsDiagWin(Board board) {
        //Is explained more report
        int diagCount = 0;
        //"normal" diagonal
        for (int i = 0; i < board.Size - 1; i++) {
            for (int j = 0; j < board.Size - 1; j++) {
                //if i == j then it's a diagonal
                if (i == j) {
                    if (board.Get(i,j) == board.Get(i+1, j+1) && board.Get(i,j) != null){
                        diagCount += 1;
                    }
                }
            }
        }

        if (diagCount == board.Size - 1){
            return true;
        } 

        //reset
        diagCount = 0;

        //the other diagonal
        for (int i = board.Size; i > board.Size - 1; i--) {
            for (int j = 0; j < board.Size - 1; j ++){
                //explained in the report
                if (i+j == board.Size - 1) {
                    if (board.Get(i,j) == board.Get(i+1, j+1) && board.Get(i,j) != null) {
                        diagCount += 1;
                    }
                }
            }
        }

        if (diagCount == board.Size - 1) {
            return true;
        }
    return false;
    }

    /// <summary>
    /// Method that will determine what the state of the board is. If there is a winner, a tied or
    /// the game is still inconclusive.
    /// </summary>
    /// <param name="board">A given board.</param>
    /// <returns> The state of the board.</returns>
    public BoardState CheckBoardState(Board board) {
        //cusing our methods check if there's a winner
        if (IsDiagWin(board) || IsColWin(board) || IsRowWin(board)){
            return BoardState.Winner;
        //board full but no winner
        } else if (board.IsFull()) { 
            return BoardState.Tied;
        //inconclusive
        } else { return BoardState.Inconclusive;}
    }
}