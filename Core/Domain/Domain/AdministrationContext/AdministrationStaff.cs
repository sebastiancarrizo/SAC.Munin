namespace SAC.Munin.Domain.AdministrationContext
{
    using StaffContext;
    using SAC.Seed.NLayer.Domain;
    using System;

    public class AdministrationStaff : EntityGuid
    {    
        public DateTimeOffset? DeactivatedDate { get; set; }
            
        public string DeactivateNote { get; set; }
             
        public Guid StaffId { get; set; }
             
        public virtual Staff Staff { get; set; }
             
        public Guid AdministrationId { get; set; }
             
        public virtual Administration Administration { get; set; }
             
        public string StaffRoleCode { get; set; }
             
        public Guid? UserId { get; set; }
             
        public DateTimeOffset CreatedDate { get; set; }    
    }
}
