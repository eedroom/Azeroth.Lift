
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Gutop.Model.Entity
{
  public partial class DbContext : System.Data.Entity.DbContext,Azeroth.Util.Autofac.IScoped,Azeroth.Util.Autofac.ISingleton
  {
        public DbContext() : base("name=master")
        {
        }    
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.Entity.Log> Log { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.Entity.Organization> Organization { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.Entity.Staff> Staff { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.Entity.UrlMap> UrlMap { get; set; }
    /// <summary>
    /// 
    /// <summary>
    public virtual DbSet<Gutop.Model.Entity.User> User { get; set; }
    }
}