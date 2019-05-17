namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.AdministrationContext;
    public class AdministratorConfiguration : EntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
            this.HasRequired(p => p.Person).WithOptional(b => b.Administrator);
        }
    }
}
