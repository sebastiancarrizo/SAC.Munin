namespace SAC.Munin.Code.Tables
{
    using Seed.CodeTable;
    public class ApplicationTable : CodeTable
    {
        public readonly CodeItem Munin = new CodeItem { Code = Code.Munin, Name = "Munin", Description = "Sistema de seguridad y acceso" };
        public struct Code
        {
            public const string Munin = "SAC.Munin";
        }
    }
}
