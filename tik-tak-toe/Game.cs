using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tik_tak_toe
{
    class Game
    {
        // this is the board flattened and filled with some values to easier asses the Artificial Inteligence.
        protected List<string> origBoard = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
        GameAI AI;
        protected int index;

        protected string nextMove = "x";

        public delegate void winMessage(string p);
        protected event winMessage Notify;

        public delegate void AImove(int indexOfBoard);
        protected event AImove AImoves;

        public Game(winMessage d, AImove am)
        {
            Notify = d;
            AImoves = am;
            AI = new GameAI();
        }



        public string NextMove { get { return nextMove; } }

        public void moveAI(int cell)
        {
            origBoard[cell] = "x";
            bool isWin = winning(origBoard, "x");

            if (isWin)
            {
                Notify("x");
                return;
            }

            index = AI.moveInGame(origBoard);


            if(isToe(origBoard))
            {
                Notify("toe");
                return;
            }
            

            origBoard[index] = "o";
            AImoves(index);

            isWin = winning(origBoard, "o");
            if (isWin)
            {
                Notify("o");
                return;
            }

        }
        public void move(int cell)
        {
            origBoard[cell] = this.NextMove;
            bool isWin = winning(origBoard, nextMove);

            if (isWin)
            {
                Notify(nextMove);
                return;
            }
            if (isToe(origBoard))
            {
                Notify("toe");
                return;
            }

            if (nextMove == "x")
            {
                nextMove = "o";
            }
            else
            {
                nextMove = "x";
            }
        }
        public void restart()
        {
            nextMove = "x";
            origBoard = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
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
        protected bool isToe(List<string> board)
        {
            List<string> newBoard = new List<string>(board);

            newBoard.RemoveAll(c => { return c == "x"; });
            newBoard.RemoveAll(c => { return c == "o"; });

            if (newBoard.Count == 0)
                return true;
            return false;
        }

    }
}
