namespace SAC.Munin.Domain.VisitorContext
{
    using SAC.Seed.NLayer.Domain;
    using System;

    public class VisitorAttribute : EntityAutoInc
    {           
        public bool Delayed { get; set; }
        public bool Authorized { get; set; }
        public Guid VisitorId { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
