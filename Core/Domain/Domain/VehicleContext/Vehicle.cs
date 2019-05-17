namespace SAC.Munin.Domain.VehicleContext
{
    using GuestbookContext;
    using VisitorContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Vehicle : EntityAutoInc
    {
        [Required]
        public string LicensePlate { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public Guid? VisitorId { get; set; } 
        public virtual Visitor Visitor { get; set; }
        public virtual ICollection<Guestbook> Movements { get; set; }
    }
}
