namespace SAC.Munin.Domain.LocationContext
{
    using System.Globalization;
    using System;
    using System.Linq;
    using Seed.NLayer.Data;
    using Seed.NLayer.Domain;
    using Seed.NLayer.ExceptionHandling;
    using Code;
    using Service.BaseDto;
    internal class LocationService
    {
        private readonly IDataContext context;

        public LocationService(IDataContext context)
        {
            this.context = context;
        }

        private IDataView<Location, int> ViewLocations
        {
            get
            {
                return this.context.GetView<Location, int>();
            }
        }

        public Location AddLocation(LocationDto locationInfo)
        {
            if ((locationInfo.Code != null) && this.ViewLocations.Exists(x => x.Code.Equals(locationInfo.Code, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw BusinessRulesCode.LocationExists.NewBusinessException();
            }

            TrimLocation(locationInfo);
            var location = locationInfo.AdaptToLocation();
            location.Code = locationInfo.Code ?? Guid.NewGuid().ToString();
            this.ViewLocations.Add(location);

            try
            {
                this.context.ApplyChanges();
            }
            catch
            {
                var locationCode = CodeConst.LocationType.Values().FirstOrDefault(l => l.Code.Equals(location.LocationTypeCode));
                var strLocationCodeName = (locationCode == null) ? "Ubicación" : locationCode.Name;
                throw new BusinessRulesException(string.Format("Falló la carga {0}", strLocationCodeName));
            }

            return location;
        }

        private static void TrimLocation(LocationDto locationInfo)
        {
            locationInfo.Code = string.IsNullOrWhiteSpace(locationInfo.Code) ? null : locationInfo.Code.Trim();
            locationInfo.Name = string.IsNullOrWhiteSpace(locationInfo.Name) ? null : FirstToCapital(locationInfo.Name.Trim());
            locationInfo.Description = string.IsNullOrWhiteSpace(locationInfo.Description) ? null : FirstToCapital(locationInfo.Description.Trim());
        }

        private static string FirstToCapital(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            var chars = data.ToCharArray();
            chars[0] = chars[0].ToString(CultureInfo.InvariantCulture).ToUpperInvariant().ToCharArray()[0];
            return new string(chars);
        }
    }
}
