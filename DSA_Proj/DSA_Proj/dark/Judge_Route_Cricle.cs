
// 657. Judge Route Circle
// DescriptionHintsSubmissionsDiscussSolution
// Initially, there is a Robot at position (0, 0). Given a sequence of its moves, judge if this robot makes a circle, which means it moves back to the original place.
// The move sequence is represented by a string. And each move is represent by a character. The valid robot moves are R (Right), L (Left), U (Up) and D (down). The output should be true or false representing whether the robot makes a circle.
// Example 1:
// Input: "UD"
// Output: true
// Example 2:
// Input: "LL"
// Output: false

public class Judge_Route_Circle {
    public bool JudgeCircle(string moves) {
      if(moves == null || moves.Length == 0) return false;
      int x = 0;
      int y = 0;
      foreach(char c in moves)
        switch(c){
          case 'U': y++;
            break;
          case 'D': y--;
            break;
          case 'R': x++;
            break;
          case  'L': x--;
            break;
        }
      
      return (x  == 0 && y == 0);
    }
}