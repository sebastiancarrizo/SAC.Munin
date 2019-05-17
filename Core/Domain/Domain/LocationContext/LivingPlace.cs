namespace SAC.Munin.Domain.LocationContext
{
    using HabitantContext;
    using VisitorContext;
    using SAC.Seed.NLayer.Domain;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using GuestbookContext;

    public class LivingPlace : EntityAutoInc
    {
        [Required(ErrorMessage = "El [Codigo] es requerido.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
        public int LivingPlaceTypeId { get; set; }
        public virtual LivingPlaceType LivingPlaceType { get; set; }
        public virtual ICollection<Habitant> Habitants { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<Guestbook> Visits { get; set; }
    }
}