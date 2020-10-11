
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Gutop.Model
{
  public partial class DbContext : System.Data.Entity.DbContext,Model.Autofac.IScoped,Model.Autofac.ISingleton
  {
        public DbContext() : base("name=master")
        {
        }    
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.LogInfo> LogInfo { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.MenuInfo> MenuInfo { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.UserInfo> UserInfo { get; set; }
    }
}