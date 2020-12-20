using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model.VO.Account {
    public class Login {
        /// <summary>
        /// 登陆用户名
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "必须指定用户名")]
        [System.ComponentModel.DataAnnotations.MaxLength(6)]
        public string LoginName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "必须指定密码")]
        [System.ComponentModel.DataAnnotations.MaxLength(6)]
        public string PassWord { get; set; }

        /// <summary>
        /// 下次自动登陆
        /// </summary>
        public Nullable<bool> IsPersistent { get; set; }
    }
}
