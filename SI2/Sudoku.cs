using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class Sudoku
    {
        public static int[,] board;
        public static int N;
        public static int Npow;
        Random random;

        public Sudoku(int N)
        {
            Npow = (int)Math.Pow(N, 2);
            board = new int[Npow, Npow];
            random = new Random();
            Sudoku.N = N;
        }

        public void DeleteCells(int M)
        {
            for(int i = 0; i < M; i++)
            {
                bool deleted = false;
                while(!deleted)
                {
                    int x = random.Next(Npow);
                    int y = random.Next(Npow);
                    if (board[x, y] > 0)
                    {
                        board[x, y] = 0;
                        deleted = true;
                    }
                    /*while(!deleted && y >0)
                    {
                        y--;
                        if (board[x, y] > 0)
                        {
                            board[x, y] = 0;
                            deleted = true;
                        }
                    }*/
                }
            }
        }


        public void LoadSudoku() //loads sudoku from a file
        {
            try
            {
                var lines = System.IO.File.ReadAllLines(@"C:\Users\dowla\Desktop\sudoku" + N + ".txt");
                board = new int[Npow, Npow];
                int lineNumber = 0;
                foreach (var line in lines)
                {
                    var temp = line.Split(' ');
                    for (int i = 0; i < temp.Length; i++)
                    {
                        board[lineNumber, i] = Convert.ToInt32(temp[i]);
                    }
                    lineNumber++;
                }
            }
            catch (Exception ex) //error
            {
                Console.Write("Error " + ex);
            }
        }

        public override string ToString() //converts sudoku array to a text
        {
            string ret = "";
            for (int i = 0; i < Npow; i++)
            {
                for (int j = 0; j < Npow; j++)
                {
                    if (board[i, j] == 0) ret += "_\t";
                    else ret = ret + board[i, j] + "\t";
                }
                ret += "\n";
            }
                
            return ret;
        }
    }
}
