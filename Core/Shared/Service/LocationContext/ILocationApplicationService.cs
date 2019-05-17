namespace SAC.Munin.Service.LocationContext
{
    using System.ServiceModel;
    using Seed.NLayer.ExceptionHandling;
    using BaseDto;
    [ServiceContract]
    internal interface ILocationApplicationService
    {
        [OperationContract]
        [FaultContract(typeof(BusinessRulesFaultDetail))]
        LocationDto AddLocation(LocationDto locationInfo);
    }
}
