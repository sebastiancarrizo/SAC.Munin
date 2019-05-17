namespace SAC.Munin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Mnn.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        StreetNumber = c.String(nullable: false),
                        Floor = c.String(),
                        Apartment = c.String(),
                        Neighborhood = c.String(),
                        ZipCode = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "Mnn.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 100),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        LocationTypeCode = c.String(),
                        ParentLocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Location", t => t.ParentLocationId)
                .Index(t => t.ParentLocationId);
            
            CreateTable(
                "Mnn.Administration",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        AddressId = c.Int(),
                        ActivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivateNote = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "Mnn.Administrator",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                        UserId = c.Guid(nullable: false),
                        AdministrationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Administration", t => t.AdministrationId)
                .ForeignKey("Mnn.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserId, unique: true, name: "__IX_Administrator_UserId")
                .Index(t => t.AdministrationId);
            
            CreateTable(
                "Mnn.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        GenderCode = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 200),
                        UidSerie = c.String(nullable: false, maxLength: 100),
                        UidCode = c.String(nullable: false, maxLength: 50),
                        AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .Index(t => new { t.UidCode, t.UidSerie }, unique: true, name: "__IX_Person_UidCode_UidSerie")
                .Index(t => t.AddressId);
            
            CreateTable(
                "Mnn.AttributeValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributeCode = c.String(),
                        Value = c.String(),
                        PersonId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "Mnn.Guard",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                        UserId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Company", t => t.CompanyId)
                .ForeignKey("Mnn.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserId, unique: true, name: "__IX_Guard_UserId")
                .Index(t => t.CompanyId);
            
            CreateTable(
                "Mnn.Company",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        AddressId = c.Int(),
                        ActivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivateNote = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .ForeignKey("Mnn.ServiceType", t => t.ServiceTypeId)
                .Index(t => t.AddressId)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "Mnn.Phone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(nullable: false),
                        AreaCode = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        Mobile = c.Boolean(),
                        Name = c.String(),
                        TelcoId = c.Int(),
                        CompanyId = c.Guid(),
                        PersonId = c.Guid(),
                        AdministrationId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Company", t => t.CompanyId)
                .ForeignKey("Mnn.Person", t => t.PersonId)
                .ForeignKey("Mnn.Administration", t => t.AdministrationId)
                .ForeignKey("Mnn.Telco", t => t.TelcoId)
                .Index(t => t.TelcoId)
                .Index(t => t.CompanyId)
                .Index(t => t.PersonId)
                .Index(t => t.AdministrationId);
            
            CreateTable(
                "Mnn.Telco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Mnn.ServiceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Mnn.Habitant",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                        UserId = c.Guid(nullable: false),
                        HouseId = c.Int(nullable: false),
                        HabitantTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.HabitantType", t => t.HabitantTypeId)
                .ForeignKey("Mnn.House", t => t.HouseId)
                .ForeignKey("Mnn.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserId, unique: true, name: "__IX_Habitant_UserId")
                .Index(t => t.HouseId)
                .Index(t => t.HabitantTypeId);
            
            CreateTable(
                "Mnn.HabitantType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Mnn.House",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        CommunityId = c.Int(nullable: false),
                        HouseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .ForeignKey("Mnn.Community", t => t.CommunityId)
                .ForeignKey("Mnn.HouseType", t => t.HouseTypeId)
                .Index(t => t.AddressId)
                .Index(t => t.CommunityId)
                .Index(t => t.HouseTypeId);
            
            CreateTable(
                "Mnn.Community",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        AddressId = c.Int(nullable: false),
                        AdministrationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Address", t => t.AddressId)
                .ForeignKey("Mnn.Administration", t => t.AdministrationId)
                .Index(t => t.AddressId)
                .Index(t => t.AdministrationId);
            
            CreateTable(
                "Mnn.HouseType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Mnn.Visitor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        HouseId = c.Int(nullable: false),
                        UserId = c.Guid(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.House", t => t.HouseId)
                .ForeignKey("Mnn.Person", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.HouseId);
            
            CreateTable(
                "Mnn.AuthorizedVisitor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Delayed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Visitor", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Mnn.CasualVisitor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Delayed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeativatedDate = c.DateTimeOffset(precision: 7),
                        DeativateNote = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Visitor", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Mnn.Staff",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Person", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "Mnn.AdministrationStaff",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeactivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivateNote = c.String(),
                        StaffId = c.Guid(nullable: false),
                        AdministrationId = c.Guid(nullable: false),
                        StaffRoleCode = c.String(),
                        UserId = c.Guid(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Administration", t => t.AdministrationId)
                .ForeignKey("Mnn.Staff", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.AdministrationId)
                .Index(t => t.UserId, unique: true, name: "__IX_AdministrationStaff_UserId");
            
            CreateTable(
                "Mnn.CompanyStaff",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeactivatedDate = c.DateTimeOffset(precision: 7),
                        DeactivateNote = c.String(),
                        StaffId = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        StaffRoleCode = c.String(),
                        UserId = c.Guid(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Company", t => t.CompanyId)
                .ForeignKey("Mnn.Staff", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId, unique: true, name: "__IX_CompanyStaff_UserId");
            
            CreateTable(
                "Mnn.Authorization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Mnn.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Hierarchy = c.Int(nullable: false),
                        Scope = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "__IX_Profile_Code");
            
            CreateTable(
                "Mnn.RolesComposition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        RoleCode = c.String(),
                        CriticalRole = c.Boolean(nullable: false),
                        Hierarchy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Mnn.Profile", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Mnn.RolesComposition", "ProfileId", "Mnn.Profile");
            DropForeignKey("Mnn.Phone", "TelcoId", "Mnn.Telco");
            DropForeignKey("Mnn.Phone", "AdministrationId", "Mnn.Administration");
            DropForeignKey("Mnn.Administrator", "Id", "Mnn.Person");
            DropForeignKey("Mnn.Staff", "Id", "Mnn.Person");
            DropForeignKey("Mnn.CompanyStaff", "StaffId", "Mnn.Staff");
            DropForeignKey("Mnn.CompanyStaff", "CompanyId", "Mnn.Company");
            DropForeignKey("Mnn.AdministrationStaff", "StaffId", "Mnn.Staff");
            DropForeignKey("Mnn.AdministrationStaff", "AdministrationId", "Mnn.Administration");
            DropForeignKey("Mnn.Phone", "PersonId", "Mnn.Person");
            DropForeignKey("Mnn.Habitant", "Id", "Mnn.Person");
            DropForeignKey("Mnn.Visitor", "Id", "Mnn.Person");
            DropForeignKey("Mnn.Visitor", "HouseId", "Mnn.House");
            DropForeignKey("Mnn.CasualVisitor", "Id", "Mnn.Visitor");
            DropForeignKey("Mnn.AuthorizedVisitor", "Id", "Mnn.Visitor");
            DropForeignKey("Mnn.House", "HouseTypeId", "Mnn.HouseType");
            DropForeignKey("Mnn.Habitant", "HouseId", "Mnn.House");
            DropForeignKey("Mnn.House", "CommunityId", "Mnn.Community");
            DropForeignKey("Mnn.Community", "AdministrationId", "Mnn.Administration");
            DropForeignKey("Mnn.Community", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.House", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.Habitant", "HabitantTypeId", "Mnn.HabitantType");
            DropForeignKey("Mnn.Guard", "Id", "Mnn.Person");
            DropForeignKey("Mnn.Guard", "CompanyId", "Mnn.Company");
            DropForeignKey("Mnn.Company", "ServiceTypeId", "Mnn.ServiceType");
            DropForeignKey("Mnn.Phone", "CompanyId", "Mnn.Company");
            DropForeignKey("Mnn.Company", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.AttributeValue", "PersonId", "Mnn.Person");
            DropForeignKey("Mnn.Person", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.Administrator", "AdministrationId", "Mnn.Administration");
            DropForeignKey("Mnn.Administration", "AddressId", "Mnn.Address");
            DropForeignKey("Mnn.Address", "LocationId", "Mnn.Location");
            DropForeignKey("Mnn.Location", "ParentLocationId", "Mnn.Location");
            DropIndex("Mnn.RolesComposition", new[] { "ProfileId" });
            DropIndex("Mnn.Profile", "__IX_Profile_Code");
            DropIndex("Mnn.CompanyStaff", "__IX_CompanyStaff_UserId");
            DropIndex("Mnn.CompanyStaff", new[] { "CompanyId" });
            DropIndex("Mnn.CompanyStaff", new[] { "StaffId" });
            DropIndex("Mnn.AdministrationStaff", "__IX_AdministrationStaff_UserId");
            DropIndex("Mnn.AdministrationStaff", new[] { "AdministrationId" });
            DropIndex("Mnn.AdministrationStaff", new[] { "StaffId" });
            DropIndex("Mnn.Staff", new[] { "Id" });
            DropIndex("Mnn.CasualVisitor", new[] { "Id" });
            DropIndex("Mnn.AuthorizedVisitor", new[] { "Id" });
            DropIndex("Mnn.Visitor", new[] { "HouseId" });
            DropIndex("Mnn.Visitor", new[] { "Id" });
            DropIndex("Mnn.Community", new[] { "AdministrationId" });
            DropIndex("Mnn.Community", new[] { "AddressId" });
            DropIndex("Mnn.House", new[] { "HouseTypeId" });
            DropIndex("Mnn.House", new[] { "CommunityId" });
            DropIndex("Mnn.House", new[] { "AddressId" });
            DropIndex("Mnn.Habitant", new[] { "HabitantTypeId" });
            DropIndex("Mnn.Habitant", new[] { "HouseId" });
            DropIndex("Mnn.Habitant", "__IX_Habitant_UserId");
            DropIndex("Mnn.Habitant", new[] { "Id" });
            DropIndex("Mnn.Phone", new[] { "AdministrationId" });
            DropIndex("Mnn.Phone", new[] { "PersonId" });
            DropIndex("Mnn.Phone", new[] { "CompanyId" });
            DropIndex("Mnn.Phone", new[] { "TelcoId" });
            DropIndex("Mnn.Company", new[] { "ServiceTypeId" });
            DropIndex("Mnn.Company", new[] { "AddressId" });
            DropIndex("Mnn.Guard", new[] { "CompanyId" });
            DropIndex("Mnn.Guard", "__IX_Guard_UserId");
            DropIndex("Mnn.Guard", new[] { "Id" });
            DropIndex("Mnn.AttributeValue", new[] { "PersonId" });
            DropIndex("Mnn.Person", new[] { "AddressId" });
            DropIndex("Mnn.Person", "__IX_Person_UidCode_UidSerie");
            DropIndex("Mnn.Administrator", new[] { "AdministrationId" });
            DropIndex("Mnn.Administrator", "__IX_Administrator_UserId");
            DropIndex("Mnn.Administrator", new[] { "Id" });
            DropIndex("Mnn.Administration", new[] { "AddressId" });
            DropIndex("Mnn.Location", new[] { "ParentLocationId" });
            DropIndex("Mnn.Address", new[] { "LocationId" });
            DropTable("Mnn.RolesComposition");
            DropTable("Mnn.Profile");
            DropTable("Mnn.Authorization");
            DropTable("Mnn.CompanyStaff");
            DropTable("Mnn.AdministrationStaff");
            DropTable("Mnn.Staff");
            DropTable("Mnn.CasualVisitor");
            DropTable("Mnn.AuthorizedVisitor");
            DropTable("Mnn.Visitor");
            DropTable("Mnn.HouseType");
            DropTable("Mnn.Community");
            DropTable("Mnn.House");
            DropTable("Mnn.HabitantType");
            DropTable("Mnn.Habitant");
            DropTable("Mnn.ServiceType");
            DropTable("Mnn.Telco");
            DropTable("Mnn.Phone");
            DropTable("Mnn.Company");
            DropTable("Mnn.Guard");
            DropTable("Mnn.AttributeValue");
            DropTable("Mnn.Person");
            DropTable("Mnn.Administrator");
            DropTable("Mnn.Administration");
            DropTable("Mnn.Location");
            DropTable("Mnn.Address");
        }
    }
}
