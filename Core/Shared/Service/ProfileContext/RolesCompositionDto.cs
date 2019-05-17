namespace SAC.Munin.Service.ProfileContext
{
    using Seed.NLayer.Application;
    public class RolesCompositionDto : EntityDto<int>
    {
        public ProfileDto Profile { get; set; }
        public string RoleCode { get; set; }
        public bool CriticalRole { get; set; }
        public int Hierarchy { get; set; }
    }
}
