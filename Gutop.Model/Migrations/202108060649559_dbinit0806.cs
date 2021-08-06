namespace Gutop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit0806 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 192),
                        Content = c.String(nullable: false),
                        LogLevel = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventName = c.String(maxLength: 192),
                        Exception = c.String(),
                        BizId = c.String(maxLength: 36),
                        CreateTime = c.DateTime(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Pid = c.Guid(),
                        CreateTime = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 19),
                        Birthday = c.DateTime(nullable: false),
                        Nation = c.String(nullable: false, maxLength: 20),
                        Education = c.String(nullable: false, maxLength: 255),
                        Country = c.String(nullable: false, maxLength: 50),
                        Province = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        County = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 50),
                        IdCard = c.String(nullable: false, maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UrlMap",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        Pid = c.Guid(),
                        Controller = c.String(nullable: false, maxLength: 192),
                        Ico = c.String(maxLength: 192),
                        Action = c.String(nullable: false, maxLength: 192),
                        Remark = c.String(maxLength: 255),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginName = c.String(nullable: false, maxLength: 100),
                        NikeName = c.String(maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        RowState = c.Int(nullable: false),
                        Mobile = c.String(maxLength: 20),
                        Email = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.UrlMap");
            DropTable("dbo.Staff");
            DropTable("dbo.Organization");
            DropTable("dbo.Log");
        }
    }
}
