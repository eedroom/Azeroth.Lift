using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System {
    public class EqualityComparerWrapper<T> : IEqualityComparer<T> {
        Func<T, T, bool> handler;
        public EqualityComparerWrapper(Func<T,T,bool> handler) {
            this.handler = handler;
        }


        public bool Equals(T x, T y) {
            return this.handler(x, y);
        }

        public int GetHashCode(T obj) {
            return 0;
        }
    }
}
