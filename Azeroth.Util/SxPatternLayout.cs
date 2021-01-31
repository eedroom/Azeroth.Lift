using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
   public class SxPatternLayout : log4net.Layout.PatternLayout {
        public SxPatternLayout() {
            this.AddConverter("sx", typeof(SxPatternLayoutConverter));
        }
    }
}
