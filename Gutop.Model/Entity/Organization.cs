using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Gutop.Model.Enum;
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
        public Guid Id {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(100)]
        public String Name {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Nullable<Guid> Pid {set;get;}
        /// <summary>
        ///
        /// </summary>
        public DateTime CreateTime {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Int32 Creator {set;get;}
        /// <summary>
        ///枚举|OrganizationCategory|0公司;1部门
        /// </summary>
        public OrganizationCategory Category {set;get;}
    }
}
