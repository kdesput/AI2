using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class BTSudoku
    {
        int assigns, returns, heuristic;
        Sudoku sudoku;
        public BTSudoku(Sudoku sudoku, int heuristic)
        {
            System.Diagnostics.Debug.WriteLine("test");
            assigns = 0;
            returns = 0;
            this.sudoku = sudoku;
            this.heuristic = heuristic;
        }

        public bool Solve()
        {
            System.Diagnostics.Debug.WriteLine(sudoku.ToString());
            int[] empty = sudoku.GetEmpty(heuristic);
            bool ret = false;
            if (empty == null)
            {
                ret = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(empty[0] + " " + empty[1]);
                System.Diagnostics.Debug.WriteLine("Wszedlem");
                int x = empty[0];
                int y = empty[1];
                for (int i = 1; i <= sudoku.GetNpow(); i++)
                {
                    if (IsSafe(x, y, i))
                    {
                        sudoku.SetCell(x, y, i);
                        System.Diagnostics.Debug.WriteLine("PO: " + sudoku.ToString());
                        if (Solve())
                        {
                            ret = true;
                        }
                        else sudoku.SetCell(x, y, 0);
                    }
                }
            }
            if(ret == false) returns++;
            System.Diagnostics.Debug.WriteLine("Wychodze z " + ret);
            return ret;
        }

        public int GetReturns()
        {
            return returns;
        }

        public int GetAssigns()
        {
            return assigns;
        }

        public Sudoku GetSudoku()
        {
            return sudoku;
        }

        public bool IsSafe(int x, int y, int value)
        {
            System.Diagnostics.Debug.WriteLine(x + " safe " + y +" " + value);
            assigns++;
            //checking rows and columns
            for (int i = 0; i < sudoku.GetNpow(); i++)
            {
                if (sudoku.GetBoard()[x, i] == value) return false;
                if (sudoku.GetBoard()[i, y] == value) return false;
            }
            //checking small squares
            System.Diagnostics.Debug.WriteLine("small");
            int a = x - (x % sudoku.GetN());
            int b = y - (y % sudoku.GetN());

            for (int i = 0; i < sudoku.GetN(); i++)
            {
                for (int j = 0; j < sudoku.GetN(); j++)
                {
                    if (sudoku.GetBoard()[a + i, b + j] == value) return false;
                }
            }
            return true;
        }
    }
}
