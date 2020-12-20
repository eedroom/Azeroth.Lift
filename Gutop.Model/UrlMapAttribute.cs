using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model {
    public class UrlMapAttribute : System.Attribute {
        public UrlMapAttribute(string des, Model.Enum.UrlMapCategory category) {
            this.Description = des;
            this.Category = category;
        }
        public string Description { get; set; }

        public Model.Enum.UrlMapCategory Category { get; set; }
    }
}
