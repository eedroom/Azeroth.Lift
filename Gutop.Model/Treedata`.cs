using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class Treedata<T>
    {

        public Treedata(T value)
        {
            this.value = value;
            this.children = new List<Treedata<T>>();
        }

        public T value { get; set; }

        public Treedata<T> parent { get; set; }

        public List<Treedata<T>> children { set; get; }

        public Treedata<T> GetRoot()
        {
            return this.parent == null ? this : this.parent.GetRoot();
        }

        public List<Treedata<T>> GetAllChildren()
        {
            List<Treedata<T>> lst = new List<Treedata<T>>();
            Queue<Treedata<T>> que = new Queue<Treedata<T>>();
            que.Enqueue(this);
            while (que.Count > 0)
            {
                var tmp = que.Dequeue();
                lst.Add(tmp);
                tmp.children?.ForEach(x => que.Enqueue(x));
            }
            return lst;
        }
    }
}
