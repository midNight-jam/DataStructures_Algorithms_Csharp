using System;
using System.Collections.Generic;

namespace DSA_Proj.dark
{
  class Flip_Game
  {
    public IList<string> GeneratePossibleNextMoves(string s)
    {
      var res = new List<string>();
      if (s == null || s.Length == 0) return res;
      char[] arr = s.ToCharArray();
      for (int i = 1; i < arr.Length; i++)
      {
        if (arr[i - 1] == '+' && arr[i] == '+')
        {
          arr[i - 1] = arr[i] = '-';
          res.Add(new String(arr));
          arr[i - 1] = arr[i] = '+';
        }
      }
      return res;
    }
  }
}
