namespace SAC.Munin.Domain.AttributeValueContext
{
    using Seed.NLayer.Domain;
    public class AttributeValue : EntityAutoInc
    {
        public string AttributeCode { get; set; }
        public string Value { get; set; }
    }
}
