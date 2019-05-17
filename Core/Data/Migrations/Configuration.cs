namespace SAC.Munin.Migrations
{
    using System.Data.Entity.Migrations;
    using Data.Context;
    internal sealed class Configuration : DbMigrationsConfiguration<MuninContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;            
        }

        protected override void Seed(MuninContext context)
        {
            base.Seed(context);
            MuninContextCoreInitializer.Seed(context);
        }
    }
}
