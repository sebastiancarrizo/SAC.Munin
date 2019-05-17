namespace SAC.Munin.Service.ProfileContext
{    
    using System.Collections.Generic;    
    using Seed.NLayer.Application;
    public class ProfileDto : EntityDto<int>
    {
        public ProfileDto()
        {
            this.Roles = new List<RolesCompositionDto>();
        }
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public int Hierarchy { get; set; }
        public string Scope { get; set; }
        public List<RolesCompositionDto> Roles { get; set; }
    }
}
