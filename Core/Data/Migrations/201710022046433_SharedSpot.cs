namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SharedSpot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Mnn.SharedSpot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(),
                        CommunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .ForeignKey("Mnn.Community", t => t.CommunityId)
                .Index(t => t.AddressId)
                .Index(t => t.CommunityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Mnn.SharedSpot", "CommunityId", "Mnn.Community");
            DropForeignKey("Mnn.SharedSpot", "AddressId", "Mnn.Address");
            DropIndex("Mnn.SharedSpot", new[] { "CommunityId" });
            DropIndex("Mnn.SharedSpot", new[] { "AddressId" });
            DropTable("Mnn.SharedSpot");
        }
    }
}
