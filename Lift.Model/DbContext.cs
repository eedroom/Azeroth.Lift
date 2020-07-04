
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Lift.Model
{
  public partial class DbContext : System.Data.Entity.DbContext,Model.Autofac.ITransient
  {
        public DbContext() : base("name=master")
        {
        }    
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<MenuInfo> MenuInfo { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}