namespace SAC.Munin.Domain.VisitorContext
{
    using PersonContext;
    using LocationContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    using System.Collections.Generic;
    using VehicleContext;
    using GuestbookContext;

    public class Visitor : EntityGuid
    {
        public virtual Person Person { get; set; }
        public int LivingPlaceId { get; set; }
        public virtual LivingPlace LinkedTo { get; set; }
        public Guid? UserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeativatedDate { get; set; }
        public string DeativateNote { get; set; }        
        public virtual AuthorizedVisitor AuthorizedVisitor { get; set; }
        public virtual CasualVisitor CasualVisitor { get; set; }
        public virtual ICollection<VisitorAttribute> VisitorAttribute { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Guestbook> Movements { get; set; }
    }
}
