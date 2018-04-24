using System;
using System.Collections.Generic;

namespace DSA_Proj.dark
{

//  412. Fizz Buzz
//Write a program that outputs the string representation of numbers from 1 to n.
//But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”.//Example:
//n = 15,
//Return:
//[
//    "1",
//    "2",
//    "Fizz",
//    "4",
//    "Buzz",
//    "Fizz",
//    "7",
//    "8",
//    "Fizz",
//    "Buzz",
//    "11",
//    "Fizz",
//    "13",
//    "14",
//    "FizzBuzz"
//]


  class FizzBuzz
  {
    public IList<string> FizzBuzz(int n)
    {
      var res = new string[n];

      for (int i = 1; i <= n; i++)
      {
        if ((i % 3 != 0) && (i % 5 != 0)) res[i - 1] = "" + i;
        else
        {
          if (i % 3 == 0) res[i - 1] += "Fizz";
          if (i % 5 == 0) res[i - 1] += "Buzz";
        }
      }
      return res;
    }
  }
}
