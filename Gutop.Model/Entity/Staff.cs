using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Gutop.Model.Enum;
namespace Gutop.Model.Entity
{
    /// <summary>
    /// 员工表
    /// <summary>
    [Table("Staff")]
    public partial class Staff
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
        [StringLength(19)]
        public String Name {set;get;}
        /// <summary>
        ///
        /// </summary>
        public DateTime Birthday {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(20)]
        public String Nation {set;get;}
        /// <summary>
        ///
        /// </summary>
        [Required]
        [StringLength(255)]
        public String Education {set;get;}
        /// <summary>
        ///国家
        /// </summary>
        [Required]
        [StringLength(50)]
        public String Country {set;get;}
        /// <summary>
        ///省
        /// </summary>
        [Required]
        [StringLength(50)]
        public String Province {set;get;}
        /// <summary>
        ///市
        /// </summary>
        [Required]
        [StringLength(50)]
        public String City {set;get;}
        /// <summary>
        ///县
        /// </summary>
        [Required]
        [StringLength(50)]
        public String County {set;get;}
        /// <summary>
        ///乡镇门牌号地址
        /// </summary>
        [Required]
        [StringLength(50)]
        public String Adress {set;get;}
        /// <summary>
        ///身份证
        /// </summary>
        [Required]
        [StringLength(18)]
        public String IdCard {set;get;}
    }
}
