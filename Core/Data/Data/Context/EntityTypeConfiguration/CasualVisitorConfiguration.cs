namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using Domain.VisitorContext;
    using System.Data.Entity.ModelConfiguration;
    public class CasualVisitorConfiguration : EntityTypeConfiguration<CasualVisitor>
    {
        public CasualVisitorConfiguration()
        {
            this.HasRequired(p => p.Visitor).WithOptional(b => b.CasualVisitor);
        }
    }
}