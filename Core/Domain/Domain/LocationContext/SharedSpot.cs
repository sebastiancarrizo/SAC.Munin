namespace SAC.Munin.Domain.LocationContext
{
    using SAC.Seed.NLayer.Domain;
    using System.ComponentModel.DataAnnotations;

    public class SharedSpot : EntityAutoInc
    {
        [Required(ErrorMessage = "El [Codigo] es requerido.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}