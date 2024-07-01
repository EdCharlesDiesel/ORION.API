using System;

namespace ORION.Core.BinarySearchTree
{
  /// <summary>
  /// Write a function that takes in a Binary Tree(BTS) and a target integer value and returns
  /// the closest value to that target value contained in the BTS.
  ///
  /// You can assume that there will only be one closet value.
  ///
  /// Each BTS node has an integer valie, a left child node, and right child node.A node is
  /// said to be a valid BTS node id and only id it satisfies the BTS property: its value is
  /// strictly greater than the values of every node to its value; its value is less than or
  /// equal to the values of every node to its right
  /// tha
  /// </summary>
    public static class FindClosestValueInBstClass
    {
        // Average: O(log(n)) time | O(log(n)) space
        // Worst: O(n) time | O(n) space
        public static int FindClosestValueInBst(Bst tree, int target)
        {
            return FindClosestValueInBst(tree, target, Int32.MaxValue);
        }

        private static int FindClosestValueInBst(Bst tree, int target, double closest)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }
            if (target < tree.value && tree.left != null)
            {
                return FindClosestValueInBst(tree.left, target, closest);
            }
            else if (target > tree.value && tree.right != null)
            {
                return FindClosestValueInBst(tree.right, target, closest);
            }
            else
            {
                return (int)closest;
            }
        }
        public class Bst
        {
            public int value;
            public Bst left;
            public Bst right;
            public Bst(int value)
            {
                this.value = value;
            }
        }
    }
}