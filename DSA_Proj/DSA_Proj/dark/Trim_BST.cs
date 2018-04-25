using System;

namespace DSA_Proj.dark
{

//  669. Trim a Binary Search Tree
//Given a binary search tree and the lowest and highest boundaries as L and R, trim the tree so that all its elements lies in [L, R] (R >= L). You might need to change the root of the tree, so the result should return the new root of the trimmed binary search tree.
//Example 1:
//Input: 
//    1
//   / \
//  0   2

//  L = 1
//  R = 2

//Output: 
//    1
//      \
//       2
//Example 2:
//Input: 
//    3
//   / \
//  0   4
//   \
//    2
//   /
//  1

//  L = 1
//  R = 3

//Output: 
//      3
//     / 
//   2   
//  /
// 1
  
  class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }
  class Trim_BST
  {
    public static TreeNode TrimBST(TreeNode root, int L, int R)
    {
      if (root == null) return root;

      if (root.val < L)
        return TrimBST(root.right, L, R);

      if (root.val > R)
        return TrimBST(root.left, L, R);

      root.left = TrimBST(root.left, L, R);
      root.right = TrimBST(root.right, L, R);
      return root;
    }

    public static void Main(string[] args) {

      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(0);
      root.right = new TreeNode(2);
      //root.left.right = new TreeNode(2);
      //root.left.right.left = new TreeNode(1);
      int L = 1, R = 2;
      //int L = 4, R = 5;

      TreeNode res = Trim_BST.TrimBST(root, L, R);
    }
  }
}
