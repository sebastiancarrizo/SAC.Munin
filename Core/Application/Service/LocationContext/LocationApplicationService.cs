namespace SAC.Munin.Service.LocationContext
{
    using Seed.NLayer.Data;
    using Domain.LocationContext;
    using BaseDto;
    internal class LocationApplicationService : ILocationApplicationService
    {
        public IDataContext MuninCtx { get; set; }

        public LocationDto AddLocation(LocationDto locationInfo)
        {
            var svc = new LocationService(MuninCtx);
            return LocationToDto(svc.AddLocation(locationInfo));
        }

        private static LocationDto LocationToDto(Location location)
        {
            return ConstructLocation(location);
        }

        private static LocationDto ConstructLocation(Location location)
        {
            return location == null
                ? null
                : new LocationDto
                {
                    Code = location.Code,
                    Description = location.Description,
                    Id = location.Id,
                    LocationTypeCode = location.LocationTypeCode,
                    Name = location.Name,
                    ParentLocationId = location.ParentLocationId,
                    ParentLocation = ConstructLocation(location.ParentLocation)
                };
        }
    }
}
