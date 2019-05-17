namespace SAC.Munin.Domain.VisitorContext
{
    using SAC.Seed.NLayer.Domain;

    public class Authorization : EntityAutoInc
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
