using System;
using System.Collections.Generic;

namespace StructScript
{
    public class BinaryTree<T>
    {
        //根节点
        private TreeNode<T> mRoot;
        //比较器
        private Comparer<T> mComparer;

        public BinaryTree()
        {
            mRoot = null;
            mComparer = Comparer<T>.Default;
        }

        public bool Contains(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            TreeNode<T> node = mRoot;
            while (node != null)
            {
                int comparer = mComparer.Compare(value, node.Data);
                if (comparer > 0)
                {
                    node = node.RightChild;
                }
                else if (comparer < 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(T value)
        {
            mRoot = Insert(mRoot, value);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                return new TreeNode<T>(value, 1);
            }
            int comparer = mComparer.Compare(value, node.Data);
            if (comparer > 0)
            {
                node.RightChild = Insert(node.RightChild, value);
            }
            else if (comparer < 0)
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }
            else
            {
                node.Data = value;
            }
            return node;
        }

        public int Count
        {
            get
            {
                return CountLeafNode(mRoot);
            }
        }

        private int CountLeafNode(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return CountLeafNode(root.LeftChild) + CountLeafNode(root.RightChild) + 1;
            }
        }

        public int Depth
        {
            get
            {
                return GetHeight(mRoot);
            }
        }

        private int GetHeight(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftHight = GetHeight(root.LeftChild);
            int rightHight = GetHeight(root.RightChild);
            return leftHight > rightHight ? leftHight + 1 : rightHight + 1;
        }

        public T Max
        {
            get
            {
                TreeNode<T> node = mRoot;
                while (node.RightChild != null)
                {
                    node = node.RightChild;
                }
                return node.Data;
            }
        }

        public T Min
        {
            get
            {
                if (mRoot != null)
                {
                    TreeNode<T> node = GetMinNode(mRoot);
                    return node.Data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void DelMin()
        {
            mRoot = DelMin(mRoot);
        }

        private TreeNode<T> DelMin(TreeNode<T> node)
        {
            if (node.LeftChild == null)
            {
                return node.RightChild;
            }
            node.LeftChild = DelMin(node.LeftChild);
            return node;
        }

        public void Remove(T value)
        {
            mRoot = Delete(mRoot, value);
        }

        private TreeNode<T> Delete(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            int comparer = mComparer.Compare(value, node.Data);
            if (comparer > 0)
            {
                node.RightChild = Delete(node.RightChild, value);
            }
            else if (comparer < 0)
            {
                node.LeftChild = Delete(node.LeftChild, value);
            }
            else
            {
                // 1.如果删除节点没有子节点，直接返回null
                // 2.如果只有一个子节点，返回其子节点代替删除节点即可
                if (node.LeftChild == null)
                {
                    return node.RightChild;
                }
                else if (node.RightChild == null)
                {
                    return node.LeftChild;
                }
                else
                {
                    // 3.当左右子节点都不为空时
                    // 找到其右子树中的最小节点，替换删除节点的位置
                    TreeNode<T> tempNode = node;
                    node = GetMinNode(tempNode.RightChild);
                    node.RightChild = DelMin(tempNode.RightChild);
                    node.LeftChild = tempNode.LeftChild;
                }
            }
            return node;
        }

        private TreeNode<T> GetMinNode(TreeNode<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }


        // 中序遍历：首先遍历其左子树，然后访问根结点，最后遍历其右子树。
        // 递归方法实现体内再次调用方法本身的本质是多个方法的简写，递归一定要有出口
        public void ShowTree()
        {
            ShowTree(mRoot);
        }

        private void ShowTree(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }
            ShowTree(node.LeftChild);
            //打印节点数据
            Console.WriteLine(node.Data);
            ShowTree(node.RightChild);
        }
    }

    public class TreeNode<T>
    {
        //数据
        public T Data { get; set; }

        //左孩子
        public TreeNode<T> LeftChild { get; set; }

        //右孩子
        public TreeNode<T> RightChild { get; set; }

        public TreeNode(T value, int count)
        {
            Data = value;
            LeftChild = null;
            RightChild = null;
        }
    }
}
