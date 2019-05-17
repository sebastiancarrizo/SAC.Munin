namespace SAC.Munin.Domain.PersonContext
{
    using System;
    using AttributeValueContext;
    public class PersonAttributeValue : AttributeValue
    {
        public Guid PersonId { get; set; }
    }
}
