using System;

/*
344. Reverse String
Write a function that takes a string as input and returns the string reversed.
Example:
Given s = "hello", return "olleh
*/

public class Reverse_String{
    public string ReverseString(string s) {
        if(s == null || s.Length == 0) return s;
        char [] arr = s.ToCharArray();
        for(int i = 0, j = s.Length - 1; i < j; i++, j--){
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        return new string(arr);
    }
}