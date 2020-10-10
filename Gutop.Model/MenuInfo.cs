using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Gutop.Model
{
    /// <summary>
    /// 
    /// <summary>
    [Table("MenuInfo")]
    public partial class MenuInfo
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
        public String Name {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Nullable<Guid> Pid {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(192)]
        public String Url {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(192)]
        public String Ico {set;get;}
    }
}
