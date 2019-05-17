namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.GuardContext;
    public class GuardConfiguration : EntityTypeConfiguration<Guard>
    {
        public GuardConfiguration()
        {
            this.HasRequired(p => p.Person).WithOptional(b => b.Guard);
        }
    }
}
