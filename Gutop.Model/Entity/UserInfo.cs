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
    [Table("UserInfo")]
    public partial class UserInfo
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
        public String LoginName {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(100)]
        public String NikeName {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(100)]
        public String Password {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Int32 RowState {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(20)]
        public String Mobile {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(200)]
        public String Email {set;get;}
    }
}
