using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Gutop.Model.Entity
{
    /// <summary>
    /// 
    /// <summary>
    [Table("UrlMap")]
    public partial class UrlMap
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        public Guid Id {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(50)]
        public String Description {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Nullable<Guid> Pid {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(192)]
        public String Controller {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(192)]
        public String Ico {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(192)]
        public String Action {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(255)]
        public String Remark {set;get;}
    }
}
