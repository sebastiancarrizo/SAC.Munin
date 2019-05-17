namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LivingPlaseType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Mnn.DestinationType", newName: "LivingPlaceType");
            DropIndex("Mnn.Habitant", new[] { "LivingPlace_Id" });
            DropIndex("Mnn.Visitor", new[] { "LinkedTo_Id" });
            RenameColumn(table: "Mnn.Guestbook", name: "DestinationId", newName: "LivingPlaceId");
            RenameColumn(table: "Mnn.Habitant", name: "LivingPlace_Id", newName: "LivingPlaceId");
            RenameColumn(table: "Mnn.Visitor", name: "LinkedTo_Id", newName: "LivingPlaceId");
            RenameColumn(table: "Mnn.LivingPlace", name: "DestinationTypeId", newName: "LivingPlaceTypeId");
            RenameIndex(table: "Mnn.Guestbook", name: "IX_DestinationId", newName: "IX_LivingPlaceId");
            RenameIndex(table: "Mnn.LivingPlace", name: "IX_DestinationTypeId", newName: "IX_LivingPlaceTypeId");
            AlterColumn("Mnn.Habitant", "LivingPlaceId", c => c.Int(nullable: false));
            AlterColumn("Mnn.Visitor", "LivingPlaceId", c => c.Int(nullable: false));
            CreateIndex("Mnn.Habitant", "LivingPlaceId");
            CreateIndex("Mnn.Visitor", "LivingPlaceId");
            DropColumn("Mnn.Habitant", "DestinationId");
            DropColumn("Mnn.Visitor", "DestinationId");
        }
        
        public override void Down()
        {
            AddColumn("Mnn.Visitor", "DestinationId", c => c.Int(nullable: false));
            AddColumn("Mnn.Habitant", "DestinationId", c => c.Int(nullable: false));
            DropIndex("Mnn.Visitor", new[] { "LivingPlaceId" });
            DropIndex("Mnn.Habitant", new[] { "LivingPlaceId" });
            AlterColumn("Mnn.Visitor", "LivingPlaceId", c => c.Int());
            AlterColumn("Mnn.Habitant", "LivingPlaceId", c => c.Int());
            RenameIndex(table: "Mnn.LivingPlace", name: "IX_LivingPlaceTypeId", newName: "IX_DestinationTypeId");
            RenameIndex(table: "Mnn.Guestbook", name: "IX_LivingPlaceId", newName: "IX_DestinationId");
            RenameColumn(table: "Mnn.LivingPlace", name: "LivingPlaceTypeId", newName: "DestinationTypeId");
            RenameColumn(table: "Mnn.Visitor", name: "LivingPlaceId", newName: "LinkedTo_Id");
            RenameColumn(table: "Mnn.Habitant", name: "LivingPlaceId", newName: "LivingPlace_Id");
            RenameColumn(table: "Mnn.Guestbook", name: "LivingPlaceId", newName: "DestinationId");
            CreateIndex("Mnn.Visitor", "LinkedTo_Id");
            CreateIndex("Mnn.Habitant", "LivingPlace_Id");
            RenameTable(name: "Mnn.LivingPlaceType", newName: "DestinationType");
        }
    }
}
