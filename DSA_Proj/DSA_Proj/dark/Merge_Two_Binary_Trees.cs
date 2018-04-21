// 617. Merge Two Binary Trees
// DescriptionHintsSubmissionsDiscussSolution
// Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.

// You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of new tree.

// Example 1:
// Input: 
//   Tree 1                     Tree 2                  
//           1                         2                             
//          / \                       / \                            
//         3   2                     1   3                        
//        /                           \   \                      
//       5                             4   7                  
// Output: 
// Merged tree:
//        3
//       / \
//      4   5
//     / \   \ 
//    5   4   7
// Note: The merging process must start from the root nodes of both trees.


 //* Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }

  public class Merge_Two_Binary_Trees
  {
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
      if (t1 == null && t2 == null) return null;
      TreeNode node = new TreeNode(0);
      if (t1 != null) node.val += t1.val;
      if (t2 != null) node.val += t2.val;
      node.left = MergeTrees(t1 != null ? t1.left : null, t2 != null ? t2.left : null);
      node.right = MergeTrees(t1 != null ? t1.right : null, t2 != null ? t2.right : null);
      return node;
    }
  }