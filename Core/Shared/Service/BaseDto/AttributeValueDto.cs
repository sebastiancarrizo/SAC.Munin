namespace SAC.Munin.Service.BaseDto
{
    using Seed.NLayer.Application;
    internal class AttributeValueDto : EntityDto<int>
    {
        public string AttributeCode { get; set; }
        public string Value { get; set; }
    }
}
