using System;
using System.Collections.Generic;

namespace DSA_Proj.dark
{
  class Reshape_Matrix
  {
    public static int[,] MatrixReshape(int[,] nums, int r, int c)
    {
      if (nums == null || nums.GetLength(0) == 0 || nums.GetLength(1) == 0 ||
         nums.GetLength(0) * nums.GetLength(1) != r * c) return nums;
      int[,] reshapeMat = new int[r, c];
      int nr, nc;
      nr = nc = 0;
      for (int i = 0; i < nums.GetLength(0); i++)
      {
        for (int j = 0; j < nums.GetLength(1); j++)
        {
          reshapeMat[nr, nc] = nums[i, j];
          nc++;
          if (nc == c)
          {
            nr++;
            nc = 0;
          }
        }
      }
      return reshapeMat;
    }

    public static void zMain(string[] args) {
      int[,] mat = new int[,] { { 1, 2 }, { 3, 4 } };
      int r = 1, c = 4;
      int[,] newMat = Reshape_Matrix.MatrixReshape(mat, r, c);
    }
  }
}
