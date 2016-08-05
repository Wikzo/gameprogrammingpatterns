using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_SpatialPartition
{
    class Grid
    {
        private const int NUM_CELLS = 10;
        private const int CELL_SIZE = 20;

        private Unit[,] _cells = new Unit[NUM_CELLS,NUM_CELLS]; // 2D array

        public Grid()
        {
            // clear the grid
            for (int x = 0; x < NUM_CELLS; x++)
            {
                for (int y = 0; y < NUM_CELLS; y++)
                {
                    _cells[x, y] = null;
                }
            }
        }

        public void Add(Unit unit)
        {
            // determine which grid cell it's in
            // Dividing by cell size conversts world coordinates to cell space
            // Casting using int truncates the fractional part, so we get the cell index
            int cellX = (int) (unit.X/CELL_SIZE);
            int cellY = (int) (unit.Y/CELL_SIZE);

            // add to the front of the list for the cell it's in
            unit.Prev = null;
            unit.Next = _cells[cellX, cellY];
            _cells[cellX, cellY] = unit;

            if (unit.Next != null)
                unit.Next.Prev = unit;
        }

        // O(n^2) checks!
        public void HandleMeleeNonOptimized(Unit[] units, int numUnits)
        {
            for (int a = 0; a < numUnits - 1; a++)
            {
                for (int b = a+1; b < numUnits; b++)
                {
                    // basic collision detection
                    if (units[a].X == units[b].X && units[a].Y == units[b].Y)
                        HandleAttack(units[a], units[b]);
                }
            }
        }

        public void HandleMelee()
        {
            for (int x = 0; x < NUM_CELLS; x++)
            {
                for (int y = 0; y < NUM_CELLS; y++)
                {
                    HandleCell(_cells[x, y]);
                }
            }
        }

        // instead of doing O(n^2) checks, we only do 
        private void HandleCell(Unit unit)
        {
            Unit other = unit.Next;

            while (other != null)
            {
                if (unit.X == other.X && unit.Y == other.Y)
                    HandleAttack(unit, other);
            }
        }

        private void HandleAttack(Unit unit, Unit other)
        {
            Console.WriteLine("{0} attacks {1}!", unit, other);
        }

        public void Move(Unit unit, double x, double y)
        {
            // see which cell it was in
            int oldCellX = (int) (unit.X/CELL_SIZE);
            int oldCellY = (int) (unit.Y/CELL_SIZE);

            // see which cell we are moving to
            int newCellX = (int)(x / CELL_SIZE);
            int newCellY = (int)(y / CELL_SIZE);

            unit.X = x;
            unit.Y = y;

            // if it didn't change cells, we're done
            if (oldCellX == newCellX && oldCellY == newCellY)
                return;

            // unlink it from the list of its old ell
            if (unit.Prev != null)
                unit.Prev.Next = unit.Next;

            if (unit.Next != null)
                unit.Next.Prev = unit.Prev;

            // if it's the head of a list, remove it
            if (_cells[oldCellX, oldCellX] == unit)
                _cells[oldCellX, oldCellY] = unit.Next;

            // add it back to the grid at its new cell
            Add(unit);
        }
    }
}
