using System;

namespace DSA_Proj.dark
{

// #709 
// Implement function ToLowerCase() that has a string parameter str, and returns the same string in lowercase.

    public class ToLowerCase
    {
        public static string ToLowerCaseMeth(string str)
        {
            if(str == null || str.Length == 0) return str;
            char [] arr = new char[str.Length];
            int val = 0;
            for(int i = 0; i < str.Length; i++)
            {
                val = (int)str[i];
                if(val >= 65 && val <= 90)
                    val += 32;
                arr[i] = (char)val;
            }
            return new string(arr);
        }

        public static void Main(string [] args)
        {
          Console.WriteLine("@>@");
          string res = ToLowerCaseMeth(null);
          Console.WriteLine("Res : " + res);
          Console.ReadLine();
        }
    }
}