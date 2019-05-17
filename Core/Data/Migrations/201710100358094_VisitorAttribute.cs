namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorAttribute : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Mnn.VisitorAttribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Delayed = c.Boolean(nullable: false),
                        Authorized = c.Boolean(nullable: false),
                        VisitorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Visitor", t => t.VisitorId)
                .Index(t => t.VisitorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Mnn.VisitorAttribute", "VisitorId", "Mnn.Visitor");
            DropIndex("Mnn.VisitorAttribute", new[] { "VisitorId" });
            DropTable("Mnn.VisitorAttribute");
        }
    }
}
