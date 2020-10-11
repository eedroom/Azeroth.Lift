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
    [Table("LogInfo")]
    public partial class LogInfo
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
        public String Source {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(65535)]
        public String Message {set;get;}
    }
}
