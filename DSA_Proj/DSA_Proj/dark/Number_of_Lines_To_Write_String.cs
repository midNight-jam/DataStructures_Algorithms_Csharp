using System;

public class Number_of_Lines_To_Write_String
{
    public static int[] NumberOfLines(int[] widths, string S) {
        if(widths == null || widths.Length == 0 || S == null || S.Length == 0) return new int[0];
        int lines= 1;
        int width = 0;
        
        foreach(char c in S)
        	if(widths[c-'a'] + width >= 100){
        		lines++;
        		width = widths[c-'a'] + width == 100 ? 0 : widths[c-'a'];
        	}else
        		width += widths[c-'a'];
        	
        
        return new int[]{lines, width}; 
    }

    public static void zMain(string [] args){
    	//int [] widths = new int[]{4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10};
    	//string S = "bbbcccdddaaa";
    	int [] widths = new int[]{10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10};
    	string S = "abcdefghijklmnopqrstuvwxyz";

    	int[] res = NumberOfLines(widths, S);
    	foreach(int i in res)
    		Console.WriteLine(i);
    }
}