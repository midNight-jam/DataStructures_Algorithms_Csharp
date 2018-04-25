using System;

namespace DSA_Proj.dark
{

//  766. Toeplitz Matrix
//A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.
//Now given an M x N matrix, return True if and only if the matrix is Toeplitz.

//Example 1:

//Input: matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]
//Output: True
//Explanation:
//1234
//5123
//9512

//In the above grid, the diagonals are "[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]", and in each diagonal all elements are the same, so the answer is True.
//Example 2:

//Input: matrix = [[1,2],[2,2]]
//Output: False
//Explanation:
//The diagonal "[1, 2]" has different elements.
//Note:

//matrix will be a 2D array of integers.
//matrix will have a number of rows and columns in range [1, 20].
//matrix[i][j] will be integers in range [0, 99].


  class Toeplitz_Matrix
  {
    public bool IsToeplitzMatrix(int[,] matrix)
    {
      if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return false;

      int row = matrix.GetLength(0);
      int col = matrix.GetLength(1);

      for (int i = row - 1; i > -1; i--)
      {
        for (int j = col - 1; j > -1; j--)
        {
          int element = matrix[i, j];
          int ri = i;
          int cj = j;
          while (ri < row && cj < col)
          {
            if (matrix[ri, cj] == element)
            {
              ri++;
              cj++;
            }
            else
              return false;
          }
        }
      }
      return true;
    }
  }
}