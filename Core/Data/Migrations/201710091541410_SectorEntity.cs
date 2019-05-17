namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SectorEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Mnn.House", "CommunityId", "Mnn.Community");
            DropForeignKey("Mnn.SharedSpot", "CommunityId", "Mnn.Community");
            DropIndex("Mnn.House", new[] { "CommunityId" });
            DropIndex("Mnn.SharedSpot", new[] { "CommunityId" });
            CreateTable(
                "Mnn.Sector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Number = c.Int(nullable: false),
                        CommunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Community", t => t.CommunityId)
                .Index(t => t.CommunityId);
            
            AddColumn("Mnn.House", "SectorId", c => c.Int(nullable: false));
            AddColumn("Mnn.SharedSpot", "SectorId", c => c.Int(nullable: false));
            CreateIndex("Mnn.House", "SectorId");
            CreateIndex("Mnn.SharedSpot", "SectorId");
            AddForeignKey("Mnn.House", "SectorId", "Mnn.Sector", "Id");
            AddForeignKey("Mnn.SharedSpot", "SectorId", "Mnn.Sector", "Id");
            DropColumn("Mnn.House", "CommunityId");
            DropColumn("Mnn.SharedSpot", "CommunityId");
        }
        
        public override void Down()
        {
            AddColumn("Mnn.SharedSpot", "CommunityId", c => c.Int(nullable: false));
            AddColumn("Mnn.House", "CommunityId", c => c.Int(nullable: false));
            DropForeignKey("Mnn.SharedSpot", "SectorId", "Mnn.Sector");
            DropForeignKey("Mnn.House", "SectorId", "Mnn.Sector");
            DropForeignKey("Mnn.Sector", "CommunityId", "Mnn.Community");
            DropIndex("Mnn.SharedSpot", new[] { "SectorId" });
            DropIndex("Mnn.Sector", new[] { "CommunityId" });
            DropIndex("Mnn.House", new[] { "SectorId" });
            DropColumn("Mnn.SharedSpot", "SectorId");
            DropColumn("Mnn.House", "SectorId");
            DropTable("Mnn.Sector");
            CreateIndex("Mnn.SharedSpot", "CommunityId");
            CreateIndex("Mnn.House", "CommunityId");
            AddForeignKey("Mnn.SharedSpot", "CommunityId", "Mnn.Community", "Id");
            AddForeignKey("Mnn.House", "CommunityId", "Mnn.Community", "Id");
        }
    }
}
