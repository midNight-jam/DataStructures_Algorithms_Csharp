using System.Collections.Generic;

public class Jewels_And_Stones {
// You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
// The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters are case sensitive, so "a" is considered a different type of stone from "A".

// Example 1:

// Input: J = "aA", S = "aAAbbbb"
// Output: 3

// Example 2:
// Input: J = "z", S = "ZZ"
// Output: 0

// Note:
// S and J will consist of letters and have length at most 50.
// The characters in J are distinct.

    public int NumJewelsInStones(string j, string s) {
        if(j == null || s.Length == 0 || s == null) return 0;
        var set = new HashSet<char>();
        foreach(char c in j)
            set.Add(c);
        int count = 0;
        foreach(char c in s)
            if(set.Contains(c)) count++;
        return count;
    }

     public int NumJewelsInStones__2(string j, string s) {
         if(j == null || s.Length == 0 || s == null) return 0;
        int [] arr = new int [256];
        foreach(char c in j)
            arr[c]++;
        int count = 0;
        foreach(char c in s)
            if(arr[c]>0)count++;
        return count;
    }
}