namespace SAC.Munin.Domain.CompanyServicesContext
{
    using PhoneContext;
    using System;
    public class CompanyPhone : Phone
    {
        public Guid CompanyId { get; set; }    
    }
}
