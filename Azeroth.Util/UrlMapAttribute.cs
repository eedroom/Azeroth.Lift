using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public class UrlMapAttribute : System.Attribute {
        public UrlMapAttribute(string des, UrlMapCategory category) {
            this.Description = des;
            this.Category = category;
        }
        public string Description { get; set; }

        public UrlMapCategory Category { get; set; }
    }
}
