using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2_Lessons
{
    public class TreeStructure<T> : IEnumerable<TreeNode<T>>
    {
        bool IterationMethod;
        public TreeNode<T> Root { get; set; }
        public TreeStructure(T data)
        {
            Root = new TreeNode<T>(data, null, 0);
        }
        public void AddNode(TreeNode<T> parent, T data)
        {
            uint id = this.Max(x => x.ID);
            TreeNode<T> node = new TreeNode<T>(data, parent, id + 1);
            parent.Children.Add(node);
        }
        public uint AddNode(Func<TreeNode<T>, bool> predicate, T data)
        {
            var parent = this.First(predicate);
            uint id = this.Max(x => x.ID);
            parent.Children.Add(new(data, parent, id + 1));
            return id + 1;
        }
        public void RemoveNode(TreeNode<T> node)
        {
            if (node.Parent != null)
            {
                node.Parent.Children.Remove(node);
            }
        }

        //True for Depth, False for Breadth
        public void SetIterationMethod(bool method)
        {
            IterationMethod = method;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<TreeNode<T>>).GetEnumerator();
        }

        IEnumerator<TreeNode<T>> IEnumerable<TreeNode<T>>.GetEnumerator()
        {
            if (IterationMethod)
                return new TreeDepthEnumerator<TreeNode<T>, T>(Root);
            else
                return new TreeBreadthEnumerator<TreeNode<T>, T>(Root);
        }
    }
    public class TreeNode<T>
    {
        public uint ID { get; private set; }
        public T Data { get; set; }
        public TreeNode<T> Parent { get; private set; }
        public List<TreeNode<T>> Children { get; set; }
        public TreeNode(T data, TreeNode<T> parent, uint iD)
        {
            Parent = parent;
            Data = data;
            Children = new List<TreeNode<T>>();
            ID = iD;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    public struct TreeDepthEnumerator<T, T1> : IEnumerator<T> where T : TreeNode<T1>
    {
        public int DepthLevel = 0;
        public TreeNode<T1> enumer;
        bool firstIteration;

        public TreeDepthEnumerator(TreeNode<T1> root)
        {
            enumer = root;
            firstIteration = true;
        }

        public T Current => (T)enumer;

        object IEnumerator.Current => enumer;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (firstIteration)
            { // If it is first iteration, that means, that we are on the root node, so we return true.
                firstIteration = false;
                return true;
            }
            if (enumer.Children.Count > 0)
            {//If has any children, we go to the first child.
                enumer = enumer.Children[0];
                DepthLevel++;
                return true;
            }
            else
            {//If has no children, we go to the next sibling.
                return Recursive();
            }
        }
        private bool Recursive()
        {
            //If has no parent, we return false, we are back on the root.
            if (enumer.Parent == null) return false;
            //Remembering the index of the current node in the parent's children list.
            int index = enumer.Parent.Children.IndexOf(enumer);
            //If the current node is the last child, we go to the parent and call the recursive function again.
            if (enumer.Parent.Children.Count <= index + 1)
            {
                DepthLevel--;
                enumer = enumer.Parent;
                return Recursive();
            }
            //If the current node is not the last child, we go to the next sibling.
            else
            {
                enumer = enumer.Parent.Children[index + 1];
                return true;
            }
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public struct TreeBreadthEnumerator<T, T1> : IEnumerator<T> where T : TreeNode<T1>
    {
        public Queue<TreeNode<T1>> enumer;
        private TreeNode<T1> node;
        public TreeBreadthEnumerator(TreeNode<T1> root)
        {
            enumer = new Queue<TreeNode<T1>>();
            enumer.Enqueue(root);
            node = root;
        }
        public T Current => (T)node;
        object IEnumerator.Current => node;
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            //Adding the children of the current node to the queue.
            if (enumer.Count == 0) return false;
            TreeNode<T1> node = enumer.Dequeue();
            this.node = node;
            foreach (var item in node.Children)
            {
                enumer.Enqueue(item);
            }
            return true;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
