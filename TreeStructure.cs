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
            Root = new TreeNode<T>(data, 0, 0);
        }
        public uint AddNode(Func<TreeNode<T>, bool> predicate, T data)
        {
            var parent = this.First(predicate);
            uint id = this.Max(x => x.ID);
            parent.Children.Add(new(data, id + 1, parent.Depth + 1));
            return id + 1;
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
        public List<TreeNode<T>> Children { get; set; }
        public int Depth { get; set; }
        public TreeNode(T data, uint iD, int depth)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
            ID = iD;
            Depth = depth;
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
    public struct TreeDepthEnumerator<T, T1> : IEnumerator<T> where T : TreeNode<T1>
    {
        public int DepthLevel = 0;
        public TreeNode<T1> enumer = null;
        public List<TreeNode<T1>> nodes = new();

        public TreeDepthEnumerator(TreeNode<T1> root)
        {
            nodes.Add(root);
        }

        public T Current => (T)enumer;

        object IEnumerator.Current => enumer;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (nodes.Count == 0) return false;
            enumer = nodes[0];
            nodes.RemoveAt(0);
            foreach (var item in enumer.Children.Reverse<TreeNode<T1>>())
            {
                nodes.Insert(0, item);
            }
            return true;
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
