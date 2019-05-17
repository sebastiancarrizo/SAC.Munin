namespace SAC.Munin.Code
{
    using SAC.Membership.Code.Tables;
    using Tables;
    using ApplicationTable = SAC.Munin.Code.Tables.ApplicationTable;
    using RoleTable = SAC.Munin.Code.Tables.RoleTable;
    public static class CodeConst
    {
        private static TelcoTable instanceTelcoTable;

        private static LocationTypeTable instanceLocationTypeTable;

        private static HouseTypeTable instanceHouseTypeTable;

        private static ServiceTypeTable instanceServiceTypeTable;

        private static HabitantTypeTable instanceHabitantTypeTable;

        private static AuthorizationTable instanceAuthorizationTable;

        private static AuthMethodTable instanceAuthMethodTable;

        private static AuthAttributeTable instanceAuthAttributeTable;

        private static ApplicationTable instanceApplicationTable;

        private static AttributeTable instanceAttributeTable;

        private static RoleTable instanceRoleTable;

        private static UidTypeTable instanceUidTypeTable;

        public static UidTypeTable UidType
        {
            get
            {
                return instanceUidTypeTable ?? (instanceUidTypeTable = new UidTypeTable());
            }
        }

        public static AuthMethodTable AuthMethod
        {
            get
            {
                return instanceAuthMethodTable ?? (instanceAuthMethodTable = new AuthMethodTable());
            }
        }

        public static AuthAttributeTable AuthAttribute
        {
            get
            {
                return instanceAuthAttributeTable ?? (instanceAuthAttributeTable = new AuthAttributeTable());
            }
        }
        public static ApplicationTable Application
        {
            get
            {
                return instanceApplicationTable ?? (instanceApplicationTable = new ApplicationTable());
            }
        }

        public static AttributeTable Attribute
        {
            get
            {
                return instanceAttributeTable ?? (instanceAttributeTable = new AttributeTable());
            }
        }

        public static RoleTable Role
        {
            get
            {
                return instanceRoleTable ?? (instanceRoleTable = new RoleTable());
            }
        }

        public static TelcoTable Telco
        {
            get
            {
                return instanceTelcoTable ?? (instanceTelcoTable = new TelcoTable());
            }
        }

        public static LocationTypeTable LocationType
        {
            get
            {
                return instanceLocationTypeTable ?? (instanceLocationTypeTable = new LocationTypeTable());
            }
        }

        public static HouseTypeTable HouseTypeTable
        {
            get
            {
                return instanceHouseTypeTable ?? (instanceHouseTypeTable = new HouseTypeTable());
            }
        }

        public static ServiceTypeTable ServiceTypeTable
        {
            get
            {
                return instanceServiceTypeTable ?? (instanceServiceTypeTable = new ServiceTypeTable());
            }
        }

        public static HabitantTypeTable HabitantTypeTable
        {
            get
            {
                return instanceHabitantTypeTable ?? (instanceHabitantTypeTable = new HabitantTypeTable());
            }
        }
        public static AuthorizationTable AuthorizationTable
        {
            get
            {
                return instanceAuthorizationTable ?? (instanceAuthorizationTable = new AuthorizationTable());
            }
        }
    }
}