using System;
using System.Text;

using System.Collections.Generic;

namespace DSA_Proj.dark
{
  class GoatLatin
  {

    public static string ToGoatLating(string S) {
      if (S == null || S.Length == 0) return S;
      char[] arr = S.ToCharArray();
      int s = 0;
      String w, l;
      StringBuilder sbr = new StringBuilder();
      StringBuilder abr = new StringBuilder();

      for (int i = 1; i < arr.Length; i++)
      {
        if (arr[i] == ' ' || i == arr.Length - 1)
        {
          w = i == arr.Length - 1 ? new string(arr, s, i - s + 1) : new string(arr, s, i - s);
          if (!(w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u'
             || w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U'))
              w = "" + w.Substring(1, w.Length - 1) + w[0];

          abr.Append("a");
          sbr.Append(w + "ma" + abr.ToString() + " ");
          s = i + 1;
        }
      }
      return sbr.ToString().Substring(0, sbr.Length - 1);
    }


    public static void zMain(string[] args)
    {
      //string s = "I speak Goat Latin";
      string s = "The quick brown fox jumped over the lazy dog";
      string res = ToGoatLating(s);
      Console.WriteLine("S : " + s);
      Console.WriteLine("R : " + res);
      Console.ReadLine();
    }
  }

}
