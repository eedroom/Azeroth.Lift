using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public class TreeNode<T> {

        public TreeNode(T value) {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T value { get; set; }

        public TreeNode<T> parent { get; set; }

        public List<TreeNode<T>> children { set; get; }

        public TreeNode<T> GetRoot() {
            return this.parent == null ? this : this.parent.GetRoot();
        }

        public List<TreeNode<T>> GetAllChildren() {
            List<TreeNode<T>> lst = new List<TreeNode<T>>();
            Queue<TreeNode<T>> que = new Queue<TreeNode<T>>();
            que.Enqueue(this);
            while (que.Count > 0) {
                var tmp = que.Dequeue();
                lst.Add(tmp);
                tmp.children?.ForEach(x => que.Enqueue(x));
            }
            return lst;
        }
    }
}
