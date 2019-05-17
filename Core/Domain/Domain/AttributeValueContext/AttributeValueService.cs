namespace SAC.Munin.Domain.AttributeValueContext
{
    using Seed.NLayer.Data;
    internal class AttributeValueService
    {
        private readonly IDataContext context;
        public AttributeValueService(IDataContext context)
        {
            this.context = context;
        }
    }
}