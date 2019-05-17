namespace SAC.Munin.Domain.PersonContext
{
    using AdministrationContext;
    using GuardContext;
    using LocationContext;
    using HabitantContext;
    using Seed.Validator.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Seed.NLayer.Domain;
    using SAC.Munin.Domain.StaffContext;
    using SAC.Munin.Domain.VisitorContext;

    public class Person : EntityGuid
    {
        [Required(ErrorMessage = "El [Nombre] es requerido.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El [Apellido] es requerido.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El [Género] es requerido.")]
        public string GenderCode { get; set; }

        [Required(ErrorMessage = "La [Fecha de Nacimiento] es requerida.")]
        public DateTime BirthDate { get; set; }

        [StringLength(200, ErrorMessage = "El [Email] no puede ser mas extenso de 200 caracteres.")]
        [EmailValid(ErrorMessage = "El valor de [Email] no es un formato de Email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El [Identificador Personal] es requerido.")]
        [StringLength(100, ErrorMessage = "El [Identificador Personal] no puede ser mas extenso de 100 caracteres.")]
        public string UidSerie { get; set; }

        [Required(ErrorMessage = "El [Código de Identificador Personal] es requerido.")]
        [StringLength(50, ErrorMessage = "El [Código de Identificador Personal] no puede ser mas extenso de 50 caracteres.")]
        public string UidCode { get; set; }
        public virtual ICollection<PersonPhone> Phones { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Guard Guard { get; set; }
        public virtual Administrator Administrator { get; set; }
        public virtual Habitant Habitant { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<PersonAttributeValue> Attributes { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0}, {1}", this.LastName, this.FirstName);
            }
        }
    }
}
