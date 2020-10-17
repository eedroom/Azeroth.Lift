using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model.VO
{
    public class LoginUserInfo
    {
        /// <summary>
        /// 登陆用户名
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings =false,ErrorMessage ="必须指定用户名")]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string LoginName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = false, ErrorMessage = "必须指定密码")]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string PassWord { get; set; }
    }
}
