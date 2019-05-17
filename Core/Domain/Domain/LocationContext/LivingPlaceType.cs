﻿namespace SAC.Munin.Domain.LocationContext
{
    using SAC.Seed.NLayer.Domain;
    using System.ComponentModel.DataAnnotations;
    public class LivingPlaceType : EntityAutoInc
    {
        [Required(ErrorMessage = "El [Codigo] es requerido.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
