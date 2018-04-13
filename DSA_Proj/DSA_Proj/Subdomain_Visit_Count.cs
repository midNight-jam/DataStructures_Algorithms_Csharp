using System;
using System.Collections.Generic;

public class Solution {
    public static IList<string> SubdomainVisits(string[] cpdomains) {
        if(cpdomains == null || cpdomains.Length == 0) return new List<String>();
        var dictionary = new Dictionary<string, int>();
        foreach(string s in cpdomains){
        	string [] p = s.Split(' ');
        	int count = Int32.Parse(p[0]);
        	string[] sub = p[1].Split('.');
        	string dom = "";
        	for(int i = sub.Length - 1 ; i >- 1; i--){
        		dom = sub[i] + dom;
        		if(dictionary.ContainsKey(dom)){
        			dictionary[dom]+= count;
        		}else{
        			dictionary.Add(dom, count);
        		}
        		dom = "." + dom;
        	}
        }
        var res = new List<string>();
        foreach(var kvp in dictionary)
        	res.Add(kvp.Value+" " + kvp.Key);
        
        return res;
    }

    public static void Main(string [] args){
    	var dm = new string[]{
    		"900 google.mail.com",
    		 "50 yahoo.com", 
    		 "1 intel.mail.com", 
    		 "5 wiki.org"
    		};
    	var res = SubdomainVisits(dm);
        Console.WriteLine(string.Join(",", res.ToArray()));
    }
}