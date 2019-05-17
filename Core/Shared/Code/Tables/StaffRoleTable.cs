namespace SAC.Munin.Code.Tables
{
    using SAC.Seed.CodeTable;
    public class StaffRoleTable : CodeTable
    {        
        public readonly CodeItem SACAministrator = new CodeItem { Code = "SACAministrator", Name = "Aministrador de SAC" };
        public readonly CodeItem Administrator = new CodeItem { Code = "Administrator", Name = "Administrador de Comunidad" };
        public readonly CodeItem AdministrationStaff = new CodeItem { Code = "AdministrationStaff", Name = "Empleado de Administracion de Comunidad" };
        public readonly CodeItem HabitanAdministrator = new CodeItem { Code = "HabitanAdministrator", Name = "Habitante Administrador" };
    }
}
