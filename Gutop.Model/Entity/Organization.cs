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
    [Table("Organization")]
    public partial class Organization
    {
        /// <summary>
        ///
        /// </summary>
        [Key]
        public Int32 Id {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(100)]
        public String Name {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Nullable<Int32> Pid {set;get;}
        /// <summary>
        ///
        /// </summary>
        public DateTime CreateTime {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Int32 Creator {set;get;}
        /// <summary>
        ///0-公司;1-部门
        /// </summary>
        public Int32 Category {set;get;}
    }
}
