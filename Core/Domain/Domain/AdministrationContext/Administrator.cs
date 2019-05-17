namespace SAC.Munin.Domain.AdministrationContext
{
    using PersonContext;
    using System;
    using Seed.NLayer.Domain;
    public class Administrator : EntityGuid
    {
        public virtual Person Person { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeativatedDate { get; set; }
        public string DeativateNote { get; set; }
        public Guid UserId { get; set; }
        public Guid AdministrationId { get; set; }
        public virtual Administration Administration { get; set; }
    }
}
