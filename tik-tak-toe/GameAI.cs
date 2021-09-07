using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tik_tak_toe
{
    class GameAI
    {       
        string huPlayer = "x";
        string aiPlayer = "o";

        protected string nextMove = "x";

        public int moveInGame (List<string> board)
        {
            Move m = minimax(board, "o");
            return m.Index;
        }

        protected Move minimax(List<string> newBoard, string player)
        {
            List<Move> moves = new List<Move>();
            List<int> availSpots = emptyIndexies(newBoard);

            // checks for the terminal states such as win, lose, and tie and returning a value accordingly

            if (winning(newBoard, huPlayer))
            {
                return new Move(-20,-10);
            }
            else if (winning(newBoard, aiPlayer))
            {
                return new Move(-20, 10);
            }
            else if (availSpots.Count == 0)
            {
                return new Move(-20, 0);
            }

            for (var i = 0; i < availSpots.Count; i++)
            {
                //create an object for each and store the index of that spot that was stored as a number in the object's index key
                Move move = new Move();
                move.Index = Convert.ToInt32(newBoard[availSpots[i]]);

                // set the empty spot to the current player
                newBoard[availSpots[i]] = player;

                //if collect the score resulted from calling minimax on the opponent of the current player
                if (player == aiPlayer)
                {
                    var result = minimax(newBoard, huPlayer);
                    move.Score = result.Score;
                }
                else
                {
                    var result = minimax(newBoard, aiPlayer);
                    move.Score = result.Score;
                }

                //reset the spot to empty
                newBoard[availSpots[i]] = move.Index.ToString();
                
                // push the object to the array
                moves.Add(move);
            }
            // if it is the computer's turn loop over the moves and choose the move with the highest score
            int bestMove = 0;
            if (player == aiPlayer)
            {
                int bestScore = -10000;
                for (var i = 0; i < moves.Count; i++)
                {
                    if (moves[i].Score > bestScore)
                    {
                        bestScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            }
            else
            {

                // else loop over the moves and choose the move with the lowest score
                var bestScore = 10000;
                for (var i = 0; i < moves.Count; i++)
                {
                    if (moves[i].Score < bestScore)
                    {
                        bestScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            }

            // return the chosen move (object) from the array to the higher depth
            return moves[bestMove];

        }

        protected bool winning(List<string> board, string player)
        {
            if (
                   (board[0] == player && board[1] == player && board[2] == player) ||
                   (board[3] == player && board[4] == player && board[5] == player) ||
                   (board[6] == player && board[7] == player && board[8] == player) ||
                   (board[0] == player && board[3] == player && board[6] == player) ||
                   (board[1] == player && board[4] == player && board[7] == player) ||
                   (board[2] == player && board[5] == player && board[8] == player) ||
                   (board[0] == player && board[4] == player && board[8] == player) ||
                   (board[2] == player && board[4] == player && board[6] == player)
                   )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected List<int> emptyIndexies(List<string> board)
        {
            List<string> newBoard = new List<string>(board);
            List<int> newBoardWithEmptyCells = new List<int>();

            newBoard.RemoveAll(c => { return c == "x"; });
            newBoard.RemoveAll(c => { return c == "o"; });
            for (int i = 0; i < newBoard.Count; i++)
            {
                newBoardWithEmptyCells.Add(Convert.ToInt32(newBoard[i]));
            }

            return newBoardWithEmptyCells; 
        }


    }
}
