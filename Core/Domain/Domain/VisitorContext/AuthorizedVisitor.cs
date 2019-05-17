namespace SAC.Munin.Domain.VisitorContext
{    
    using SAC.Seed.NLayer.Domain;
    using System;

    public class AuthorizedVisitor : EntityGuid
    {               
        public virtual Visitor Visitor { get; set; }             
        public bool Delayed { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DeativatedDate { get; set; }
        public string DeativateNote { get; set; }
    }
}