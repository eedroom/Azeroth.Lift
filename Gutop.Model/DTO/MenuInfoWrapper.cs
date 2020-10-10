using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model.DTO
{
    public class MenuInfoWrapper
    {
        public Treedata<MenuInfo> MathedItem { get; set; }

        public List<Treedata<MenuInfo>> Value { get; set; }



        public static List<DTO.MenuInfo> GetAll()
        {
            var lst = new List<DTO.MenuInfo>();
            MenuInfo m0,m1,m2;
            m0 = new MenuInfo() {  Id=Guid.NewGuid(), Pid=null, Name="经典旧世", Url=string.Empty};
            lst.Add(m0);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "达纳苏斯", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "幽影谷", Url = "/Danasusi/Youyingu" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "暗夜精灵", Url = "/Danasusi/Anye" };
            lst.Add(m2);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "黑海岸", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "黑暗深渊", Url = "/HeiHaian/HeiAnshenyuan" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "审判之剑", Url = "/HeiHaian/Shenpanzhijian" };
            lst.Add(m2);

            m0 = new MenuInfo() { Id = Guid.NewGuid(), Pid = null, Name = "燃烧的远征", Url = string.Empty };
            lst.Add(m0);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "伊利丹", Url = "/Home/Yilidan" };
            lst.Add(m1);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "卡拉赞", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "午夜", Url = "/Klz/Wuye" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "埃兰", Url = "/Klz/Ailan" };
            lst.Add(m2);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "外域", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "影月谷", Url = "/Waiyu/Yingyuegu" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "沙塔斯", Url = "/Waiyu/Shatasi" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "黑暗神殿", Url = "/Waiyu/HeianShendian" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "黑暗秘密编年史", Url = "/Home/Index" };
            lst.Add(m2);

            m0 = new MenuInfo() { Id = Guid.NewGuid(), Pid = null, Name = "组件", Url = string.Empty };
            lst.Add(m0);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "Bootstrap", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "表单", Url = "/Bootstrap/Biaodan" };
            lst.Add(m2);
            m1 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m0.Id, Name = "Easyui", Url = string.Empty };
            lst.Add(m1);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "树", Url = "/Easyui/Tree" };
            lst.Add(m2);
            m2 = new MenuInfo() { Id = Guid.NewGuid(), Pid = m1.Id, Name = "官方demo", Url = "/Easyui/DemoList" };
            lst.Add(m2);
            return lst;

        }
    }

    public class MenuInfo:Model.MenuInfo
    {
        /// <summary>
        /// 对应页面是否选中
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        public bool Collapsing { get; set; }
    }
}
