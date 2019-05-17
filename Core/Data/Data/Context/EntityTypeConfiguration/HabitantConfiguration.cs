namespace SAC.Munin.Data.Context.EntityTypeConfiguration
{
    using System.Data.Entity.ModelConfiguration;
    using Domain.HabitantContext;
    public class HabitantConfiguration : EntityTypeConfiguration<Habitant>
    {
        public HabitantConfiguration()
        {
            this.HasRequired(p => p.Person).WithOptional(b => b.Habitant);
        }
    }
}