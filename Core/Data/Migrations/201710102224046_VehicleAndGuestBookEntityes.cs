namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleAndGuestBookEntityes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Mnn.HouseType", newName: "DestinationType");
            DropForeignKey("Mnn.House", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.House", "HouseTypeId", "Mnn.HouseType");
            DropForeignKey("Mnn.House", "SectorId", "Mnn.Sector");
            DropForeignKey("Mnn.Visitor", "HouseId", "Mnn.House");
            DropForeignKey("Mnn.Habitant", "HouseId", "Mnn.House");
            DropIndex("Mnn.House", new[] { "AddressId" });
            DropIndex("Mnn.House", new[] { "SectorId" });
            DropIndex("Mnn.House", new[] { "HouseTypeId" });
            DropIndex("Mnn.Visitor", new[] { "HouseId" });
            RenameColumn(table: "Mnn.Habitant", name: "HouseId", newName: "DestinationId");
            RenameIndex(table: "Mnn.Habitant", name: "IX_HouseId", newName: "IX_DestinationId");
            CreateTable(
                "Mnn.Guestbook",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EntryDate = c.DateTimeOffset(nullable: false, precision: 7),
                        VisitorId = c.Guid(nullable: false),
                        GuardId = c.Guid(nullable: false),
                        DestinationId = c.Int(nullable: false),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Visitor", t => t.VisitorId)
                .ForeignKey("Mnn.Vehicle", t => t.VehicleId)
                .ForeignKey("Mnn.Destination", t => t.DestinationId)
                .ForeignKey("Mnn.Guard", t => t.GuardId)
                .Index(t => t.VisitorId)
                .Index(t => t.GuardId)
                .Index(t => t.DestinationId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "Mnn.Destination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        AddressId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                        DestinationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .ForeignKey("Mnn.DestinationType", t => t.DestinationTypeId)
                .ForeignKey("Mnn.Sector", t => t.SectorId)
                .Index(t => t.AddressId)
                .Index(t => t.SectorId)
                .Index(t => t.DestinationTypeId);
            
            CreateTable(
                "Mnn.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePlate = c.String(nullable: false),
                        Mark = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        Year = c.DateTime(nullable: false),
                        VisitorId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Visitor", t => t.VisitorId)
                .Index(t => t.VisitorId);
            
            AddColumn("Mnn.Visitor", "DestinationId", c => c.Int(nullable: false));
            CreateIndex("Mnn.Visitor", "DestinationId");
            AddForeignKey("Mnn.Visitor", "DestinationId", "Mnn.Destination", "Id");
            DropColumn("Mnn.Visitor", "HouseId");
            DropTable("Mnn.House");
        }
        
        public override void Down()
        {
            CreateTable(
                "Mnn.House",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        AddressId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                        HouseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Mnn.Visitor", "HouseId", c => c.Int(nullable: false));
            DropForeignKey("Mnn.Guestbook", "GuardId", "Mnn.Guard");
            DropForeignKey("Mnn.Guestbook", "DestinationId", "Mnn.Destination");
            DropForeignKey("Mnn.Vehicle", "VisitorId", "Mnn.Visitor");
            DropForeignKey("Mnn.Guestbook", "VehicleId", "Mnn.Vehicle");
            DropForeignKey("Mnn.Guestbook", "VisitorId", "Mnn.Visitor");
            DropForeignKey("Mnn.Visitor", "DestinationId", "Mnn.Destination");
            DropForeignKey("Mnn.Destination", "SectorId", "Mnn.Sector");
            DropForeignKey("Mnn.Destination", "DestinationTypeId", "Mnn.DestinationType");
            DropForeignKey("Mnn.Destination", "AddressId", "Mnn.Address");
            DropIndex("Mnn.Vehicle", new[] { "VisitorId" });
            DropIndex("Mnn.Visitor", new[] { "DestinationId" });
            DropIndex("Mnn.Destination", new[] { "DestinationTypeId" });
            DropIndex("Mnn.Destination", new[] { "SectorId" });
            DropIndex("Mnn.Destination", new[] { "AddressId" });
            DropIndex("Mnn.Guestbook", new[] { "VehicleId" });
            DropIndex("Mnn.Guestbook", new[] { "DestinationId" });
            DropIndex("Mnn.Guestbook", new[] { "GuardId" });
            DropIndex("Mnn.Guestbook", new[] { "VisitorId" });
            DropColumn("Mnn.Visitor", "DestinationId");
            DropTable("Mnn.Vehicle");
            DropTable("Mnn.Destination");
            DropTable("Mnn.Guestbook");
            RenameIndex(table: "Mnn.Habitant", name: "IX_DestinationId", newName: "IX_HouseId");
            RenameColumn(table: "Mnn.Habitant", name: "DestinationId", newName: "HouseId");
            CreateIndex("Mnn.Visitor", "HouseId");
            CreateIndex("Mnn.House", "HouseTypeId");
            CreateIndex("Mnn.House", "SectorId");
            CreateIndex("Mnn.House", "AddressId");
            AddForeignKey("Mnn.Visitor", "HouseId", "Mnn.House", "Id");
            AddForeignKey("Mnn.House", "SectorId", "Mnn.Sector", "Id");
            AddForeignKey("Mnn.House", "HouseTypeId", "Mnn.HouseType", "Id");
            AddForeignKey("Mnn.House", "AddressId", "Mnn.Address", "Id");
            RenameTable(name: "Mnn.DestinationType", newName: "HouseType");
        }
    }
}
