using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI2
{
    class SudokuCell : IEquatable<SudokuCell> , IComparable<SudokuCell>
    {
        public int x, y, emptyNeighbours;
        public SudokuCell(int x, int y, int emptyNeighbours)
        {
            this.x = x;
            this.y = y;
            this.emptyNeighbours = emptyNeighbours;
        }

        public int CompareTo(SudokuCell other)
        {
            if (other == null) return 1;
            return emptyNeighbours.CompareTo(other.emptyNeighbours);
        }

        public bool Equals(SudokuCell other)
        {
            if (other == null) return false;
            return (this.emptyNeighbours.Equals(other.emptyNeighbours));
        }
    }
}
