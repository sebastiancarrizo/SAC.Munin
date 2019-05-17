namespace SAC.Munin.Test.TestServices.Infraestructure
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BootTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            ContainerConfig.Initialize();
        }
    }
}
