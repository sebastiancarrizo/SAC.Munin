namespace SAC.Munin.Domain.LocationContext
{
    using Domain.AdministrationContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Community : EntityAutoInc
    {
        [Required(ErrorMessage = "El [Codigo] es requerido.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId {get; set;}
        public virtual Address Address { get; set; }
        public virtual ICollection<Sector> Sector { get; set; }
        public Guid AdministrationId { get; set; }
        public virtual Administration Administration { get; set; }
    }
}