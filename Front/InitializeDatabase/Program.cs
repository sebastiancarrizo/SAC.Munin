namespace SAC.Munin
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using Membership.Data.Context;
    using Membership.Data.Migrations;
    using Data.Context;
    using Data.Migrations;
    using System;
    using SAC.Munin.BaseInitializer;

    public class Program
    {
        public static void Main()
        {
            if (!Debugger.IsAttached)
            {
                var cmd = new SqlCommand
                {
                    Connection =
                                new SqlConnection(
                                ConfigurationManager.ConnectionStrings[@"SAC.Munin.Data.Context.MuninContext"].ToString()),
                    CommandText =
                                @"USE master; "
                                + "ALTER DATABASE [SAC.Munin.DB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; "
                                + "DROP DATABASE [SAC.Munin.DB]; ",
                    CommandType = CommandType.Text
                };
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // NADA. SI FALLA ES PORQUE NO EXISTE Y PUEDE SEGUIR.
                }              

                try
                {
                    var membershipMigration = new MembershipMigration();
                    var membershipContext = new MembershipContext();

                    membershipMigration.Configure();
                    membershipMigration.InitializeDatabase(membershipContext);

                    MembershipContextInitializer.Seed(membershipContext);                                       

                    Console.WriteLine("Membership Database migrated OK!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);
                    Console.ReadKey();
                }

                try
                {
                    var muninMigration = new MuninMigration();
                    var muninContext = new MuninContext();

                    muninMigration.Configure();
                    muninMigration.InitializeDatabase(muninContext);

                    MuninContextCoreInitializer.Seed(muninContext);

                    Console.WriteLine("Munin Database migrated OK!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);
                    Console.ReadKey();
                }

                Console.WriteLine(@"El proceso de inicializacion se ejecuto de manera exitosa!!");
            }
            else
            {
                Console.WriteLine(@"ERROR!!: Este proceso solo se puede ejecutar en MODO DEBUG!!");
            }

            Console.ReadLine();
        }        
    }
}