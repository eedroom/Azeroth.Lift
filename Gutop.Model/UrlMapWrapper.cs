using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model {
    public class UrlMapWrapper : Model.Entity.UrlMap {
        /// <summary>
        /// 对应页面是否选中
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        public bool Collapsing { get; set; }

        public string Url { get; set; }
    }
}
