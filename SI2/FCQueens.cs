using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class FCQueens
    {
        int assigns;
        int results;
        int returns;
        int[,] board;
        List<int[,]> solvedBoards; //solved boards 
        int N;
        public FCQueens(int N)
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
        public bool IfCan(int x, int y)
        {
            
            if (y >= N) return true;
            bool ret = true;
            for (int i = 0; i < N; i++) //vertically & horizontally
            {
                if (board[x, i] == 1) ret = false;
                if (board[i, y] == 1) ret = false;
            }
            for (int i = x, j = y; i >= 0 && j >= 0; i--, j--) //up & left
            {
                if (board[i, j] == 1) ret = false;
            }
            for (int i = x, j = y; j >= 0 && i < N; i++, j--) //down & left
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

        public List<int> IfCanInsert(int column)
        {
            List<int> fields = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if (IfCan(i, column))
                {
                    fields.Add(i);
                }
            }
            return fields;
        }

        public bool InsertQueen(int column, List<int> fields) //assigning new queen to this column
        {

            bool ret = false;
            if (column >= N)
            {
                //solution found
                results++;
                solvedBoards.Add((int[,])board.Clone());
                Write();
                return true;
            }
            else //still no solution
            {
                for (int i = 0; i < fields.Count; i++)
                {
                    assigns++;
                    board[fields[i], column] = 1;
                    List<int> temp = IfCanInsert(column + 1);
                    if (temp.Count != 0)
                    {
                        if (InsertQueen(column + 1, temp))
                        {
                            ret = true;
                        }
                    }
                    board[fields[i], column] = 0;
                }
                returns++;
                return ret;
            }
        }

        public void Write()
        {
            string ret = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 1)
                        ret += "X\t";
                    else ret += "_\t";
                }
                ret += "\n";
            }
        }
    }
}
