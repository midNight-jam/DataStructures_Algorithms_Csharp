using System;
using System.Collections.Generic;

namespace DSA_Proj.dark
{
  class Island_Perimeter
  {
    public int IslandPerimeter(int[,] grid)
    {
      if (grid == null || grid.GetLength(0) == 0 || grid.GetLength(1) == 0) return 0;
      int count = 0;
      int top, bottom, left, right;
      for (int i = 0; i < grid.GetLength(0); i++)
        for (int j = 0; j < grid.GetLength(1); j++)
        {
          if (grid[i, j] == 1)
          {
            top = get(grid, i - 1, j);
            if (top == 0) count++;
            bottom = get(grid, i + 1, j);
            if (bottom == 0) count++;
            left = get(grid, i, j - 1);
            if (left == 0) count++;
            right = get(grid, i, j + 1);
            if (right == 0) count++;
          }
        }
      return count;
    }
    private int get(int[,] grid, int i, int j)
    {
      if (i > -1 && i < grid.GetLength(0) && j > -1 && j < grid.GetLength(1))
        return grid[i, j];
      return 0;
    }
  }
}
