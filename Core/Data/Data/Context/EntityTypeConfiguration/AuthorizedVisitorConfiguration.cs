namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using Domain.VisitorContext;
    using System.Data.Entity.ModelConfiguration;
    public class AuthorizedVisitorConfiguration : EntityTypeConfiguration<AuthorizedVisitor>
    {
        public AuthorizedVisitorConfiguration()
        {
            this.HasRequired(p => p.Visitor ).WithOptional(b => b.AuthorizedVisitor);
        }        
    }
}