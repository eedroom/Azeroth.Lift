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
    [Table("Log")]
    public partial class Log
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
        [StringLength(192)]
        public String CategoryName {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(65535)]
        public String Content {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Int32 LogLevel {set;get;}
        /// <summary>
        ///
        /// </summary>
        public Int32 EventId {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(192)]
        public String EventName {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(65535)]
        public String Exception {set;get;}
        /// <summary>
        ///
        /// </summary>
        [StringLength(36)]
        public String BizId {set;get;}
        /// <summary>
        ///
        /// </summary>
        public DateTime CreateTime {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(255)]
        public String Creator {set;get;}
    }
}
