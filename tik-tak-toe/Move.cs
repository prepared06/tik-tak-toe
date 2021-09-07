using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tik_tak_toe
{
    class Move
    {
        protected int index;
        protected int score;

        public int Index { get { return index; } set { index = value; } }
        public int Score { get { return score; }set { score = value; } }

        public Move()
        {
            index = 0;
            score = 0;
        }
        public Move(int i, int s)
        {
            index = i;
            score = s;
        }
    }
}
