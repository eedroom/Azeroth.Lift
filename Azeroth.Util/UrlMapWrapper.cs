using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public class UrlMapWrapper {
        /// <summary>
        /// 对应页面是否选中
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        public bool Collapsing { get; set; }

        public string Url { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Key]
        public Guid Id { set; get; }
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(50)]
        public String Description { set; get; }
        /// <summary>
        ///
        /// </summary>
        public Nullable<Guid> Pid { set; get; }
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(192)]
        public String Controller { set; get; }
        /// <summary>
        ///
        /// </summary>
        [StringLength(192)]
        public String Ico { set; get; }
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(192)]
        public String Action { set; get; }
        /// <summary>
        ///
        /// </summary>
        [StringLength(255)]
        public String Remark { set; get; }
        /// <summary>
        ///枚举|UrlMapCategory|1页面，2api
        /// </summary>
        public UrlMapCategory Category { set; get; }
    }
}
