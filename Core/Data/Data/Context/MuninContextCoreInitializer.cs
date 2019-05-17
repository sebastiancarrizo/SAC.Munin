namespace SAC.Munin.Data.Context
{
    using System.Data.Entity.Migrations;
    using Code;
    using Domain.PhoneContext;
    using Domain.LocationContext;
    using Domain.CompanyServicesContext;
    using Domain.HabitantContext;
    using Domain.VisitorContext;

    public class MuninContextCoreInitializer
    {
        public static void Seed(MuninContext context)
        {
            foreach (var telco in CodeConst.Telco.Values())
            {
                context.Telco.AddOrUpdate(t => t.Code, new Telco { Code = telco.Code, Description = telco.Description, Name = telco.Name });
            }

            foreach (var typeHouse in CodeConst.HouseTypeTable.Values())
            {
                context.LivingPlaceType.AddOrUpdate(t => t.Code, new LivingPlaceType { Code = typeHouse.Code, Description = typeHouse.Description, Name = typeHouse.Name });
            }

            foreach (var serviceType in CodeConst.ServiceTypeTable.Values())
            {
                context.ServiceType.AddOrUpdate(t => t.Code, new ServiceType { Code = serviceType.Code, Description = serviceType.Description, Name = serviceType.Name });
            }

            foreach (var habitanType in CodeConst.HabitantTypeTable.Values())
            {
                context.HabitantType.AddOrUpdate(t => t.Code, new HabitantType { Code = habitanType.Code, Description = habitanType.Description, Name = habitanType.Name });
            }

            foreach (var auth in CodeConst.AuthorizationTable.Values())
            {
                context.Authorization.AddOrUpdate(t => t.Code, new Authorization { Code = auth.Code, Description = auth.Description, Name = auth.Name });
            }

            context.SaveChanges();
        }
    }
}
