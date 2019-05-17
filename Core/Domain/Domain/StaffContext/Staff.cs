namespace SAC.Munin.Domain.StaffContext
{
    using AdministrationContext;
    using PersonContext;
    using SAC.Munin.Domain.CompanyServicesContext;
    using SAC.Seed.NLayer.Domain;
    using System.Collections.Generic;

    public class Staff : EntityGuid
    {        
        public virtual Person Person { get; set; }
     
        public virtual ICollection<AdministrationStaff> AdministrationStaff { get; set; }

        public virtual ICollection<CompanyStaff> CompanyStaff { get; set; }        
    }
}
