namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;
    public class RoleTable : CodeTable
    {
        public readonly CodeItem SmartLoyaltyCustomerManager = new CodeItem
        {
            Code = Code.StockAdmin,
            Name = "Administrator",
            Description = "Usuario Administrador. "
        };
        public struct Code
        {
            public const string StockAdmin = ApplicationTable.Code.Munin + ".Admin";
        }
    }
}