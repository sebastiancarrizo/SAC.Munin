namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;

    public class HouseTypeTable : CodeTable
    {
        public readonly CodeItem Apartment = new CodeItem { Code = "Apartment", Name = "Departamento" };

        public readonly CodeItem House = new CodeItem { Code = "House", Name = "Casa" };        
    }
}
