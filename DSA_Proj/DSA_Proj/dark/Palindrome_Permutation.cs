using System;



// 266. Palindrome Permutation
// Given a string, determine if a permutation of the string could form a palindrome.
// For example,
// "code" -> False, "aab" -> True, "carerac" -> True.


public class Solution {
    public bool CanPermutePalindrome(string s) {
        if(s == null || s.Length == 0) return false;
        
        var dict = new Dictionary<char, int>();
        
        foreach(char c in s)
          if(dict.ContainsKey(c))
            dict[c]++;
          else
            dict.Add(c, 1);
        
        bool odd = false;
        foreach(KeyValuePair<char, int> kv in dict)
         if(!odd &&  kv.Value % 2 != 0) odd = true;
         else if(kv.Value % 2 != 0) return false;
       return true;
    }
}