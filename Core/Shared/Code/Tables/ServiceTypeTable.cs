namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;
    public class ServiceTypeTable : CodeTable
    {
        public readonly CodeItemAttribute<CodeTable> Public = new CodeItemAttribute<CodeTable> { Code = "Public", Name = "Servicio Público" };

        public readonly CodeItemAttribute<CodeTable> Domestic = new CodeItemAttribute<CodeTable> { Code = "Domestic", Name = "Servicio Doméstico" };

        public readonly CodeItemAttribute<CodeTable> Administration = new CodeItemAttribute<CodeTable> { Code = "Administration", Name = "Servicio de Administración" };    
    }
}
