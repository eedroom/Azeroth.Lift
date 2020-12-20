using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutop.Model
{
    public class MenuCollections
    {
        public Treedata<UrlMapWrapper> MathedItem { get; set; }

        public List<Treedata<UrlMapWrapper>> Value { get; set; }



        public static List<UrlMapWrapper> GetAll()
        {
            var lst = new List<UrlMapWrapper>();
            return lst;
            UrlMapWrapper m0, m1, m2;
            m0 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = null, Description = "经典旧世", Url = string.Empty };
            lst.Add(m0);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "达纳苏斯", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "幽影谷", Url = "/Danasusi/Youyingu" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "暗夜精灵", Url = "/Danasusi/Anye" };
            lst.Add(m2);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "黑海岸", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "黑暗深渊", Url = "/HeiHaian/HeiAnshenyuan" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "审判之剑", Url = "/HeiHaian/Shenpanzhijian" };
            lst.Add(m2);

            m0 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = null, Description = "燃烧的远征", Url = string.Empty };
            lst.Add(m0);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "伊利丹", Url = "/Home/Yilidan" };
            lst.Add(m1);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "卡拉赞", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "午夜", Url = "/Klz/Wuye" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "埃兰", Url = "/Klz/Ailan" };
            lst.Add(m2);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "外域", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "影月谷", Url = "/Waiyu/Yingyuegu" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "沙塔斯", Url = "/Waiyu/Shatasi" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "黑暗神殿", Url = "/Waiyu/HeianShendian" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "黑暗秘密编年史", Url = "/Home/Index" };
            lst.Add(m2);

            m0 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = null, Description = "组件", Url = string.Empty };
            lst.Add(m0);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "Bootstrap", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "表单", Url = "/Bootstrap/Biaodan" };
            lst.Add(m2);
            m1 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m0.Id, Description = "Easyui", Url = string.Empty };
            lst.Add(m1);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "树", Url = "/Easyui/Tree" };
            lst.Add(m2);
            m2 = new UrlMapWrapper() { Id = Guid.NewGuid(), Pid = m1.Id, Description = "官方demo", Url = "/Easyui/DemoList" };
            lst.Add(m2);
            return lst;

        }
    }

    
}
