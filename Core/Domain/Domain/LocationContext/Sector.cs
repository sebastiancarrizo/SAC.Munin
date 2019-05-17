namespace SAC.Munin.Domain.LocationContext
{
    using Seed.NLayer.Domain;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Sector : EntityAutoInc
    {
        [Required(ErrorMessage = "El [Codigo] es requerido.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int CommunityId { get; set; }
        public virtual Community Community { get; set; }
        public virtual ICollection<LivingPlace> LivingPlaces { get; set; }
        public virtual ICollection<SharedSpot> SharedSpots { get; set; }
    }
}