namespace SAC.Munin.Domain.GuestbookContext
{
    using GuardContext;
    using LocationContext;
    using VehicleContext;
    using VisitorContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    public class Guestbook : EntityGuid
    {
        public DateTimeOffset EntryDate { get; set; }
        public Guid VisitorId { get; set; }
        public virtual Visitor Visistor { get; set; }
        public Guid GuardId { get; set; }
        public virtual Guard Guard { get; set; }
        public int LivingPlaceId { get; set; }
        public virtual LivingPlace Destination { get; set; }
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
