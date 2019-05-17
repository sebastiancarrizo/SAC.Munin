namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using SAC.Munin.Domain.StaffContext;
    using System.Data.Entity.ModelConfiguration;
    public class StaffConfiguration : EntityTypeConfiguration<Staff>
    {
        public StaffConfiguration()
        {
            this.HasRequired(p => p.Person).WithOptional(b => b.Staff);
        }
    }
}