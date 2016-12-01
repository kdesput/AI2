using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    public class Sudoku : ICloneable
    {
        public int[,] board;
        public int N;
        public int Npow;
        Random random;

        public Sudoku(int N)
        {
            Npow = (int)Math.Pow(N, 2);
            board = new int[Npow, Npow];
            random = new Random();
            this.N = N;
        }

        public Sudoku(int N, int[,] board)
        {
            Npow = (int)Math.Pow(N, 2);
            this.board = board;
            random = new Random();
            this.N = N;
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
                }
            }
        }

        public void SetCell(int x, int y, int value)
        {
            System.Diagnostics.Debug.WriteLine("SEEET");
            System.Diagnostics.Debug.WriteLine(ToString());
            board[x, y] = value;
            System.Diagnostics.Debug.WriteLine(ToString());
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

        public int[] GetEmpty(int heuristic = 0)
        {
            if(heuristic == 0) //selects first free cell
            {
                int[] empty = new int[2];
                for (int i = 0; i < Npow; i++)
                {
                    for (int j = 0; j < Npow; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            empty[0] = i;
                            empty[1] = j;
                            return empty;
                        }
                    }
                }
            }
            else if(heuristic == 1) //most dependent cell
            {
                List<SudokuCell> list = NumberOfEmptyNeighbours();
                if (list.Count == 0) return null;
                else
                {
                    list.Sort();
                    SudokuCell sudokuCell = list.First();
                    int[] empty = new int[2];
                    empty[0] = sudokuCell.x;
                    empty[1] = sudokuCell.y;
                    return empty;
                }
            }

            else if(heuristic == 2) //most independent cell
            {
                List<SudokuCell> list = NumberOfEmptyNeighbours();
                if (list.Count == 0) return null;
                else
                {
                    list.Sort();
                    list.Reverse();
                    SudokuCell sudokuCell = list.First();
                    int[] empty = new int[2];
                    empty[0] = sudokuCell.x;
                    empty[1] = sudokuCell.y;
                    return empty;
                }
            }
            return null;
        }

        public List<SudokuCell> NumberOfEmptyNeighbours()
        {
            List<SudokuCell> list = new List<SudokuCell>();
            for (int i = 0; i < Npow; i++)
            {
                for (int j = 0; j < Npow; j++)
                {
                    if (board[i, j] == 0)
                    {
                        //cell is empty
                        int neighbours = 0;
                        for (int x = 0; x < Npow; x++)
                        {
                            if (board[x, i] == 0) neighbours++;
                            if (board[i, x] == 0) neighbours++;
                        }
                        //checking small squares
                        int a = i - (i % N);
                        int b = j - (j % N);

                        for (int o = 0; o < N; o++)
                        {
                            for (int p = 0; p < N; p++)
                            {
                                if (board[a + o, b + p] == 0) neighbours++;
                            }
                        }
                        list.Add(new SudokuCell(i, j, neighbours));
                    }
                }
            }
            return list;
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

        public int GetN()
        {
            return N;
        }

        public int GetNpow()
        {
            return Npow;
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
