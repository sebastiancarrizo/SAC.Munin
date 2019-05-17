namespace SAC.Munin.Domain.GuardContext
{
    using PersonContext;
    using System;
    using Seed.NLayer.Domain;
    using CompanyServicesContext;
    using System.Collections.Generic;
    using GuestbookContext;

    public class Guard : EntityGuid
    {
        public virtual Person Person { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeativatedDate { get; set; }
        public string DeativateNote { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Guestbook> Records { get; set; }
    }
}
