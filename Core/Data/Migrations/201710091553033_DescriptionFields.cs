namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("Mnn.House", "Code", c => c.String(nullable: false));
            AddColumn("Mnn.House", "Name", c => c.String(nullable: false));
            AddColumn("Mnn.House", "Description", c => c.String());
            AddColumn("Mnn.Community", "Code", c => c.String(nullable: false));
            AddColumn("Mnn.SharedSpot", "Description", c => c.String());
            AlterColumn("Mnn.Sector", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Mnn.Sector", "Code", c => c.String());
            DropColumn("Mnn.SharedSpot", "Description");
            DropColumn("Mnn.Community", "Code");
            DropColumn("Mnn.House", "Description");
            DropColumn("Mnn.House", "Name");
            DropColumn("Mnn.House", "Code");
        }
    }
}