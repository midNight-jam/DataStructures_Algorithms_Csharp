using System;

/*
557. Reverse Words in a String III
Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Note: In the string, each word is separated by single space and there will not be any extra space in the string.
*/
public class Reverse_String_II{
    public string ReverseWords(string s) {
        if(s == null || s.Length == 0) return s;
        char [] arr = s.ToCharArray();
        int lp = 0, rp = 0;
        while(rp < s.Length){
            while(rp < s.Length && arr[rp] != ' ') rp++;
            if(rp < s.Length){
                int bw = lp;
                int ew = rp - 1;
                while(bw < ew){
                    char t = arr[bw];
                    arr[bw] = arr[ew];
                    arr[ew] = t;
                    bw++;
                    ew--;
                }
                
                lp = ++rp;
            }
        }
        if(rp == s.Length){
            int bw = lp;
                int ew = rp - 1;
                while(bw < ew){
                    char t = arr[bw];
                    arr[bw] = arr[ew];
                    arr[ew] = t;
                    bw++;
                    ew--;
                }
        }
        return new string(arr);
    }
}