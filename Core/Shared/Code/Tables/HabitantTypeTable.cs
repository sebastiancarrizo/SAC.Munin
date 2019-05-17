using SAC.Seed.CodeTable;

namespace SAC.Munin.Code.Tables
{
    public class HabitantTypeTable : CodeTable
    {
        public readonly CodeItem Owner = new CodeItem { Code = "Owner", Name = "Dueño" };

        public readonly CodeItem Tenant = new CodeItem { Code = "Tenant", Name = "Inquilino" };

        public readonly CodeItem Family = new CodeItem { Code = "Family", Name = "Familiar" };
    }
}
