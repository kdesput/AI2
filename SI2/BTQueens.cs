using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class BTQueens
    {
        int assigns;
        int results;
        int returns;
        int[,] board;
        List<int[,]> solvedBoards; //solved boards 
        int N;
        public BTQueens(int N)
        {
            board = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    board[i, j] = 0;
            this.N = N;
            assigns = 0;
            results = 0;
            returns = 0;
            solvedBoards = new List<int[,]>();
        }

        public int GetResults()
        {
            return results;
        }

        public List<int[,]> GetSolvedBoards()
        {
            return solvedBoards;
        }

        public int GetReturns()
        {
            return returns;
        }

        public int GetAssigns()
        {
            return assigns;
        }
        public bool IsSafe(int x, int y)
        {
            assigns++;
            bool ret = true;
            for(int i = 0; i < N; i++) //vertically & horizontally
            {
                if (board[x, i] == 1) ret = false;
                if (board[i, y] == 1) ret = false;
            }
            for(int i = x, j = y; i >= 0 && j>=0; i--,j--) //up & left
            {
                if (board[i,j] == 1) ret = false;
            }
            for(int i = x, j = y; j>=0 && i<N;i++,j--) //down & left
            {
                if (board[i, j] == 1) ret = false;
            }
            for (int i = x, j = y; j < N && i >= 0; i--, j++) //up & right
            {
                if (board[i, j] == 1) ret = false;
            }
            for (int i = x, j = y; j < N && i < N; i++, j++) //down & right
            {
                if (board[i, j] == 1) ret = false;
            }
            return ret;
        }

        public bool InsertQueen(int column) {

            bool ret = false;
            if (column >= N)
            {
                 //solution found :)
                results++;
                solvedBoards.Add((int[,])board.Clone());
                return true;
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    if (IsSafe(i, column))
                    {
                        board[i,column] = 1;
                        if (InsertQueen(column + 1))
                        {
                            ret = true;
                        }
                        board[i,column] = 0;
                    }
                }
                returns++;
                return ret;
            }
        }
    }
}
