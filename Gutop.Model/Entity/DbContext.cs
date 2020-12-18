
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Gutop.Model.Entity
{
  public partial class DbContext : System.Data.Entity.DbContext,Gutop.Model.Autofac.IScoped
  {
        public DbContext() : base("name=master")
        {
        }    
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Empoloyee> Empoloyee { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Log> Log { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<MenuInfo> MenuInfo { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Organization> Organization { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}