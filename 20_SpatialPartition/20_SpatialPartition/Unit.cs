using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_SpatialPartition
{
    class Unit
    {
        public double X { get; set; }
        public double Y { get; set; }
        private Grid _grid;

        // simple doubly-linked list
        // linked lists should be done using a library!
        public Unit Prev { get; set; }
        public Unit Next { get; set; }

        public Unit(Grid grid, double x, double y)
        {
            _grid = grid;
            X = x;
            Y = y;

            Prev = null;
            Next = null;
        }

        public void Move(double x, double y)
        {
            _grid.Move(this, x, y);
        }


    }
}
