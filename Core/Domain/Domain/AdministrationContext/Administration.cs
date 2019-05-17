namespace SAC.Munin.Domain.AdministrationContext
{
    using LocationContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Administration : EntityGuid
    {       
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<AdministrationPhone> Phones { get; set; }

        public DateTimeOffset? ActivatedDate { get; set; }

        public DateTimeOffset? DeactivatedDate { get; set; }

        public string DeactivateNote { get; set; }

        public DateTimeOffset CreatedDate { get; set; }       

        public virtual ICollection<Community> Communities { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
    }
}
