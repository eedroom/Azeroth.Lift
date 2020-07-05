using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Model.DTO
{
    public class Treedata<T>
    {

        public Treedata(T value)
        {
            this.value = value;
            this.children = new List<Treedata<T>>();
        }

        public T value{ get; set; }

        public Treedata<T> parent{ get; set; }

        public List<Treedata<T>> children { set; get; }
    }
}
