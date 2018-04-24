using System;
using System.Collections.Generic;

namespace DSA_Proj
{
  class Self_Dividing_Numbers
  {

    public static IList<int> SelfDividingNumbers(int left, int right)
    {
      var res = new List<int>();
      for (int i = left; i <= right; i++)
      {
        int n = i;
        int rem = 0;
        int d = 0;
        while (n != 0 && rem == 0)
        {
          d = n % 10;
          n = n / 10;
          if (d == 0)
          {
            rem++;
            break;
          }
          rem += (i % d);
        }
        if (rem != 0) continue;
        res.Add(i);
      }
      return res;
    }
    public static void zMain(string[] args)
    {
      int left = 1;
      int right = 22;
      var res = Self_Dividing_Numbers.SelfDividingNumbers(left, right);
      foreach(int i in res)
        Console.WriteLine(i);
      Console.ReadLine();
    }
  }
}
