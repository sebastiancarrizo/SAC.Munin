namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;
    public class ScopeTable : CodeTable
    {
        public readonly CodeItem SAC = new CodeItem { Code = "SAC", Name = "SAC" };
        public readonly CodeItem Administration = new CodeItem { Code = "Administration", Name = "Administracion de Comunidad" };
        public readonly CodeItem ServiceCompany = new CodeItem { Code = "ServiceCompany", Name = "Empresa de servicio publico" };
        public readonly CodeItem Guard = new CodeItem { Code = "Guard", Name = "Guardia" };
        public readonly CodeItem Habitant = new CodeItem { Code = "Habitant", Name = "Habitante" };
        public readonly CodeItem Familiar = new CodeItem { Code = "Familiar", Name = "Familiar" };
        public readonly CodeItem Visitor = new CodeItem { Code = "Visitor", Name = "Visitante" };
    }
}
