namespace SAC.Munin.Domain.HabitantContext
{
    using PersonContext;
    using System;
    using Seed.NLayer.Domain;
    using LocationContext;

    public class Habitant : EntityGuid
    {
        public virtual Person Person { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeativatedDate { get; set; }
        public string DeativateNote { get; set; }
        public Guid UserId { get; set; }
        public int LivingPlaceId { get; set; }
        public virtual LivingPlace LivingPlace { get; set;}
        public int HabitantTypeId { get; set; }
        public virtual HabitantType HabitantType { get; set; }
    }
}
