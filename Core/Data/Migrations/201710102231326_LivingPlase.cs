namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LivingPlase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Mnn.Destination", newName: "LivingPlace");
            DropForeignKey("Mnn.Visitor", "DestinationId", "Mnn.Destination");
            DropForeignKey("Mnn.Habitant", "DestinationId", "Mnn.Destination");
            DropIndex("Mnn.Habitant", new[] { "DestinationId" });
            DropIndex("Mnn.Visitor", new[] { "DestinationId" });
            AddColumn("Mnn.Habitant", "LivingPlace_Id", c => c.Int());
            AddColumn("Mnn.Visitor", "LinkedTo_Id", c => c.Int());
            CreateIndex("Mnn.Habitant", "LivingPlace_Id");
            CreateIndex("Mnn.Visitor", "LinkedTo_Id");
            AddForeignKey("Mnn.Visitor", "LinkedTo_Id", "Mnn.LivingPlace", "Id");
            AddForeignKey("Mnn.Habitant", "LivingPlace_Id", "Mnn.LivingPlace", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Mnn.Habitant", "LivingPlace_Id", "Mnn.LivingPlace");
            DropForeignKey("Mnn.Visitor", "LinkedTo_Id", "Mnn.LivingPlace");
            DropIndex("Mnn.Visitor", new[] { "LinkedTo_Id" });
            DropIndex("Mnn.Habitant", new[] { "LivingPlace_Id" });
            DropColumn("Mnn.Visitor", "LinkedTo_Id");
            DropColumn("Mnn.Habitant", "LivingPlace_Id");
            CreateIndex("Mnn.Visitor", "DestinationId");
            CreateIndex("Mnn.Habitant", "DestinationId");
            AddForeignKey("Mnn.Habitant", "DestinationId", "Mnn.Destination", "Id");
            AddForeignKey("Mnn.Visitor", "DestinationId", "Mnn.Destination", "Id");
            RenameTable(name: "Mnn.LivingPlace", newName: "Destination");
        }
    }
}
