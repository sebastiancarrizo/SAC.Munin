namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;
    public class AuthorizationTable : CodeTable
    {
        public readonly CodeItem Authorized = new CodeItem { Code = "Authorized", Name = "Autorizado" };
        public readonly CodeItem NotAuthorized = new CodeItem { Code = "NotAuthorized", Name = "No Autorizado" };
        public readonly CodeItem Delayed = new CodeItem { Code = "Delayed", Name = "Demorado" };
    }
}
