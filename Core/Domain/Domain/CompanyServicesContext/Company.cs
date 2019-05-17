namespace SAC.Munin.Domain.CompanyServicesContext
{
    using LocationContext;
    using SAC.Seed.NLayer.Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company : EntityGuid
    {
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<CompanyPhone> Phones { get; set; }

        public DateTimeOffset? ActivatedDate { get; set; }

        public DateTimeOffset? DeactivatedDate { get; set; }

        public string DeactivateNote { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public int ServiceTypeId { get; set; }

        public virtual ServiceType ServiceType  { get; set; }
    }
}
