namespace SAC.Munin.Domain.AdministrationContext
{
    using Domain.PhoneContext;
    using System;
    public class AdministrationPhone : Phone
    {
        public Guid AdministrationId { get; set; }    
    }
}