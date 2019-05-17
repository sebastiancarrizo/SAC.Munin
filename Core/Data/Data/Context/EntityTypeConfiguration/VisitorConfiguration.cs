namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using Domain.VisitorContext;
    using System.Data.Entity.ModelConfiguration;

    public class VisitorConfiguration : EntityTypeConfiguration<Visitor>
    {
        public VisitorConfiguration()
        {
            this.HasRequired(p => p.Person).WithOptional(b => b.Visitor);
        }
    }
}