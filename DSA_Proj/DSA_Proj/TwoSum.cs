using System;
using System.Collections.Generic;

public class Two_Sum {

// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
// Example:
// Given nums = [2, 7, 11, 15], target = 9,
// Because nums[0] + nums[1] = 2 + 7 = 9,
// return [0, 1].
    
    public int[] TwoSum(int[] nums, int target) {
        int [] res = new int[2];
        if(nums == null || nums.Length < 2) return res;
        
        Dictionary<int, int> nos = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            int si = -1;
            if(nos.TryGetValue(target - nums[i], out si)) {
                res[0] = si;
                res[1] = i;
                return res;
            }
            else
                try{
                    nos.Add(nums[i], i);
                }catch(ArgumentException e){
                    // silencing the exception
                }
        }
        return res;
    }
}