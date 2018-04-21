using System;
using System.Collections.Generic;

public class MovingAverage {

 Queue<int> numbers;
     double sum;
     int size;
    /** Initialize your data structure here. */
    public MovingAverage(int cap) {
        numbers = new Queue<int>();
        sum = 0.0;
        size = cap;
    }
    
    public double Next(int val) {        
       if(numbers.Count == size)
          sum -= numbers.Dequeue();

        numbers.Enqueue(val);
        sum += val;
        return (double)(sum / numbers.Count);
    }

    public static void Main(string [] args){
      int size = 3;
      MovingAverage obj = new MovingAverage(size);   
      MovingAverage m = new MovingAverage(3);
      Console.WriteLine(m.Next(1));// = 1

      Console.WriteLine(m.Next(10));// = (1 + 10) / 2
      Console.WriteLine(m.Next(3));// = (1 + 10 + 3) / 3
      Console.WriteLine(m.Next(5));// = (10 + 3 + 5) / 3
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */