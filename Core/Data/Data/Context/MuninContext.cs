namespace SAC.Munin.Data.Context
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using EntityTypeConfiguration;
    using System.Data.Entity;
    using Seed.NLayer.Data.EntityFramework;
    using Domain.AdministrationContext;
    using Domain.GuardContext;
    using Domain.LocationContext;
    using Domain.PersonContext;
    using Domain.PhoneContext;
    using Domain.HabitantContext;
    using Domain.AttributeValueContext;
    using Domain.ProfileContext;    
    using Domain.CompanyServicesContext;
    using Domain.StaffContext;    
    using Domain.VisitorContext;
    using Domain.GuestbookContext;
    using Domain.VehicleContext;

    public class MuninContext : EfContextBase
    {
        #region Administration
        public virtual DbSet<Administration> Administration { get; set; }        
        public virtual DbSet<AdministrationPhone> AdministrationPhone { get; set; }
        public virtual DbSet<AdministrationStaff> AdministrationStaff { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        #endregion

        #region Attribute
        public virtual DbSet<AttributeValue> AttributeValue { get; set; }
        #endregion

        #region Visitor
        public virtual DbSet<Authorization> Authorization { get; set; }            
        public virtual DbSet<AuthorizedVisitor> AuthorizedVisitor { get; set; }
        public virtual DbSet<CasualVisitor> CasualVisitor { get; set; }
        public virtual DbSet<VisitorAttribute> VisitorAttribute { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }
        #endregion

        #region Services
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyPhone> CompanyPhone { get; set; }
        public virtual DbSet<CompanyStaff> CompanyStaff { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        #endregion

        #region Person
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAttributeValue> PersonAttributeValue { get; set; }
        public virtual DbSet<PersonPhone> PersonPhone { get; set; }
        #endregion

        #region Guard
        public virtual DbSet<Guard> Guard { get; set; }
        #endregion

        #region GuestBook
        public virtual DbSet<Guestbook> GuestBook { get; set; }
        #endregion

        #region Habitant
        public virtual DbSet<HabitantType> HabitantType { get; set; }
        public virtual DbSet<Habitant> Habitant { get; set; }
        #endregion

        #region Location        
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Community> Community { get; set; }        
        public virtual DbSet<LivingPlace> LivingPlace { get; set; }
        public virtual DbSet<LivingPlaceType> LivingPlaceType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<SharedSpot> SharedSpot { get; set; }        
        #endregion

        #region Phone
        public virtual DbSet<Telco> Telco { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        #endregion

        #region Roles
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<RolesComposition> RolesComposition { get; set; }
        #endregion

        #region Staff
        public virtual DbSet<Staff> Staff { get; set; }
        #endregion

        #region Vehicles
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.HasDefaultSchema("Mnn");

            modelBuilder.Configurations.Add(new GuardConfiguration());
            modelBuilder.Configurations.Add(new AdministratorConfiguration());
            modelBuilder.Configurations.Add(new HabitantConfiguration());
            modelBuilder.Configurations.Add(new StaffConfiguration());
            modelBuilder.Configurations.Add(new VisitorConfiguration());
            modelBuilder.Configurations.Add(new AuthorizedVisitorConfiguration());
            modelBuilder.Configurations.Add(new CasualVisitorConfiguration());            

            var indexName = this.GetIndexName<Person>(x => new { x.UidCode, x.UidSerie });
            modelBuilder.Entity<Person>()
                .Property(e => e.UidCode)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute(indexName) { Order = 1, IsUnique = true }));

            modelBuilder.Entity<Person>()
                .Property(e => e.UidSerie)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute(indexName) { Order = 2, IsUnique = true }));

            modelBuilder.Entity<Administrator>()
                .Property(e => e.UserId)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<Administrator>(x => x.UserId)) { Order = 1, IsUnique = true }));

            modelBuilder.Entity<Guard>()
                .Property(e => e.UserId)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<Guard>(x => x.UserId)) { Order = 1, IsUnique = true }));

            modelBuilder.Entity<Habitant>()
                .Property(e => e.UserId)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<Habitant>(x => x.UserId)) { Order = 1, IsUnique = true }));

            modelBuilder.Entity<Profile>()
                .Property(e => e.Code)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<Profile>(x => x.Code)) { Order = 1, IsUnique = true }));            

            modelBuilder.Entity<AdministrationStaff>()
                .Property(e => e.UserId)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<AdministrationStaff>(x => x.UserId)) { Order = 1, IsUnique = true }));

            modelBuilder.Entity<CompanyStaff>()
                .Property(e => e.UserId)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(
                        new IndexAttribute(this.GetIndexName<CompanyStaff>(x => x.UserId)) { Order = 1, IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}