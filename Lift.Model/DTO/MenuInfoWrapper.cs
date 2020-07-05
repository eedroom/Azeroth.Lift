using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Model.DTO
{
    public class MenuInfoWrapper
    {
        public MenuInfo Current { get; set; }

        public List<Treedata<MenuInfo>> LstMenuInfo { get; set; }

        public MenuInfo Nav { get; set; }


        public static List<DTO.MenuInfo> GetAll()
        {
            var lst = new List<DTO.MenuInfo>();
            return lst;

        }
    }

    public class MenuInfo:Model.MenuInfo
    {
        /// <summary>
        /// 对应页面是否选中
        /// </summary>
        public bool Active { get; set; }
    }
}
