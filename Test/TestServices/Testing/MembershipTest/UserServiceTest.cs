namespace SAC.Munin.Test.TestServices.Testing.MembershipTest
{    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SAC.Seed.Dependency;
    using SAC.Membership.Service.BaseDto;    
    using SAC.Membership.Service.UserAccess;
    using SAC.Munin.Code;
    using System.Collections.Generic;
    using SAC.Membership.Service.UserManagement;
    using SAC.Membership.Helper;
    using SAC.Munin.Infrastructure;

    [TestClass]
    public class UserServiceTest
    {
        string _userName = UserName.MuninManagement;
        string Password = UserHelper.GetCryptoPass(UserName.MuninManagement, "12345678", 0);

        [TestMethod]
        public void LoginUser()
        {
            var userService = NewContainer().Resolve<IUserAccessApplicationService>();
            var result = userService.LoginUser(CodeConst.Application.Munin.Code, GenerateAuthAttribute("1234", "pass"));
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddUser()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var member = userService.GetMember(CodeConst.UidType.Other.Code, "20-27266953-8");
            var newUser = new UserDto
            {
                FirstName = "234",
                LastName = "as",
                Email = "c@c.com",
                UserName = "1234",                
                AppCode = CodeConst.Application.Munin.Code,
                MemberId = member.Id,
                UidCode = CodeConst.UidType.Other.Code,
                UidSerie = "202726695922",                
                AuthAttribute =
                 new List<AuthAttributeDto>
                                {
                                   new AuthAttributeDto
                                     {
                                       AttributeCode = CodeConst.AuthAttribute.UserName.Code,
                                       AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                                       Value = UserName.MuninCrew
                                     },
                                   new AuthAttributeDto
                                     {
                                       AttributeCode = CodeConst.AuthAttribute.CryptoPass.Code,
                                       AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                                       Value = UserHelper.GetCryptoPass(UserName.MuninManagement, "pass", 0)
                                     }
                                }, 
                
                Attributes =
                 new List<AttributeValueDto>
                                   {
                                      new AttributeValueDto
                                        {
                                          AttributeCode = CodeConst.Attribute.Scope.Code,
                                          Value = CodeConst.Attribute.Scope.Values.SAC.Code
                                        },
                                      new AttributeValueDto
                                        {
                                          AttributeCode = CodeConst.Attribute.StaffRole.Code,
                                          Value = CodeConst.Attribute.StaffRole.Values.SACAministrator.Code
                                        }
                                   }
            };

            newUser.SetUserName(newUser.UserName);
            newUser.SetPassword("pass");

            var result = userService.AddUser(newUser);            
            Assert.IsNotNull(result);            
        }

        [TestMethod]
        public void QueryUid()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var uid = userService.QueryUidType();

            Assert.IsNotNull(uid);
        }             

        [TestMethod]
        public void QueryRol()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var rol = userService.ExistsRole(CodeConst.Role.SmartLoyaltyCustomerManager.Code, CodeConst.Application.Munin.Code);
            var roles = userService.QueryRole(CodeConst.Application.Munin.Code, true);

            Assert.IsTrue(rol && (roles != null));
        }

        [TestMethod]
        public void ModUser()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var user = userService.GetUser("1234");
          
            user.LastName = "modified";
            var result = userService.ModifyUser(user);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddApplication()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();            
            userService.AddApplication("tst2", "Test App", "Aplicacion de prueba");

            Assert.IsTrue(userService.ExistsApplication("tst2"));            
        }

        [TestMethod]
        public void GetUser()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var user = userService.GetUser("1234");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ActivateUser()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var user = userService.GetUser("1234");
            userService.ActivateUser(user);            
        }

        [TestMethod]
        public void DeactivateUser()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var user = userService.GetUser("1234");
            userService.DeactivateUser(user);
        }

        [TestMethod]
        public void AddRole()
        {
            var userService = NewContainer().Resolve<IUserManagementApplicationService>();
            var role = new RoleDto
            {
                AppCode = CodeConst.Application.Munin.Code,
                Code = "codetes",
                Description = "test",
                Name = "dad"
            };

           var result = userService.AddRole(role);
           Assert.IsNotNull(result);
        }

        private AuthAttributeDto[] GenerateAuthAttribute(string userName, string password = null)
        {
            var result = new List<AuthAttributeDto>
                     {
                       new AuthAttributeDto
                         {
                           AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                           Value = userName,
                           AttributeCode = CodeConst.AuthAttribute.UserName.Code
                         }
                     };
            if (password != null)
            {
                result.Add(
                  new AuthAttributeDto
                  {
                      AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                      Value = password,
                      AttributeCode = CodeConst.AuthAttribute.Password.Code
                  });
            }

            return result.ToArray();
        }

        private static IDiContainer NewContainer()
        {
            return DiContainerFactory.DiContainer().BeginScope();
        }
    }
}
