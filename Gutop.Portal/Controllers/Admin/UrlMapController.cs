using Gutop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gutop.UI.Controllers.Admin
{
    public class UrlMapController : AuthenticationedController
    {
        // GET: Account
        [Gutop.Model.UrlMap("同步UrlMap", Model.Enum.UrlMapCategory.页面)]
        public ActionResult Index(string act)
        {
            if ("sync" == act)
                this.SyncUrlMap();
            var lst= this.Bll.GetEntities<Model.Entity.UrlMap>();
            lst = lst.OrderBy(x => x.Controller).ToList();
            this.ViewData["lstUrlMap"] = lst;
            return View();
        }

        private void SyncUrlMap() {
            var lstAll = this.Bll.GetEntities<Model.Entity.UrlMap>();
            var controllermeta =typeof(Controller);
            var lstMethod= System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => controllermeta.IsAssignableFrom(x))
                .SelectMany(x => x.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                .Select(x => Tuple.Create(x, x.GetCustomAttributes(typeof(Model.UrlMapAttribute), false)))
                .Where(x => x.Item2.Length == 1)
                .Select(x=>Tuple.Create(x.Item1,(UrlMapAttribute)x.Item2[0]))
                .ToList();
           var lstUrlMapWithCode=  lstMethod.Select(x => new Model.Entity.UrlMap() {
                Action = x.Item1.Name,
                Category = x.Item2.Category,
                Controller = x.Item1.DeclaringType.Name.Replace("Controller", string.Empty),
                Description = x.Item2.Description,
                Id = Guid.NewGuid(),
                Pid = Guid.Empty
            }).ToList();
            var cpHandler= new Gutop.Utils.MyEqualityComparer<Model.Entity.UrlMap>((a, b) => a.Controller == b.Controller && a.Action == b.Action);
            var  lstAdd= lstUrlMapWithCode.Except(lstAll, cpHandler).ToList();

            this.Bll.Add<Model.Entity.UrlMap>(lstAdd);

        }
    }
}