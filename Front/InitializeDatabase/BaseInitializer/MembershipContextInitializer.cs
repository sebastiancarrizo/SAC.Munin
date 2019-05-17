namespace SAC.Munin.BaseInitializer
{
    using SAC.Membership.Data.Context;
    using SAC.Membership.Domain.ApplicationContext;
    using SAC.Membership.Domain.AuthMethodContext;
    using SAC.Membership.Domain.MemberContext;
    using SAC.Membership.Domain.RoleContext;
    using SAC.Membership.Domain.UserContext;
    using SAC.Membership.Helper;
    using SAC.Munin.Code;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    internal static class MembershipContextInitializer
    {
        public static void Seed(MembershipContext context)
        {
            var apService = new ApplicationService(context);
            var munin = apService.GetApplication(CodeConst.Application.Munin.Code);
            if (munin == null)
            {
                munin = new Application
                {
                    Code = CodeConst.Application.Munin.Code,
                    Name = CodeConst.Application.Munin.Name,
                    Description = CodeConst.Application.Munin.Description
                };

                context.Application.AddOrUpdate(r => r.Code, munin);
                context.SaveChanges();
            }                       

            foreach (var item in CodeConst.Role.Values())
            {
                if (item.Code.Contains(CodeConst.Application.Munin.Code + "."))
                {
                    var role = new Role { Code = item.Code, Description = item.Description, Name = item.Name, Application = munin };
                    context.Role.Add(role);
                }
            }

            context.SaveChanges();

            var memb = new Member
            {
                FirstName = "SRC",
                LastName = "SRC",
                Email = "admin@sac.com",
                UidCode = CodeConst.UidType.Other.Code,
                UidSerie = "20-27266953-8",
                AttributeValues =
                  new Collection<MemberAttributeValue>
                  {
                    new MemberAttributeValue
                        {
                        AttributeCode = CodeConst.Attribute.Gender.Code,
                        Value = CodeConst.Attribute.Gender.Values.Male.Code
                        }
                  }
            };

            var usr = new User
            {
                UserName = UserName.MuninManagement,
                AuthValues =
                 new List<AuthMethodValue>
                                {
                                   new AuthMethodValue
                                     {
                                       AttributeCode = CodeConst.AuthAttribute.UserName.Code,
                                       AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                                       Value = UserName.MuninManagement
                                     },
                                   new AuthMethodValue
                                     {
                                       AttributeCode = CodeConst.AuthAttribute.CryptoPass.Code,
                                       AuthMethodCode = CodeConst.AuthMethod.LoginPassword.Code,
                                       Value = UserHelper.GetCryptoPass(UserName.MuninManagement, "12345678", 0)
                                     }
                                },
                AttributeValues =
                 new Collection<UserAttributeValue>
                                   {
                                      new UserAttributeValue
                                        {
                                          AttributeCode = CodeConst.Attribute.Scope.Code,
                                          Value = CodeConst.Attribute.Scope.Values.SAC.Code
                                        },
                                      new UserAttributeValue
                                        {
                                          AttributeCode = CodeConst.Attribute.StaffRole.Code,
                                          Value = CodeConst.Attribute.StaffRole.Values.SACAministrator.Code
                                        }
                                   }
            };

            AddUser(usr, memb, context, munin);
        }

        private static void AddUser(User usr, Member memb, MembershipContext context, Application app)
        {
            var member = context.Member.FirstOrDefault(m => m.UidCode.Equals(memb.UidCode) && m.UidSerie.Equals(memb.UidSerie));
            if (member == null)
            {
                member = memb;
                member.CreatedDate = DateTimeOffset.UtcNow;
                member.GenerateNewIdentity();
                context.Member.Add(member);
                context.SaveChanges();
            }            

            if (context.User.Any(m => m.MemberId == member.Id && m.ApplicationId == app.Id))
            {
                return;
            }

            usr.ApplicationId = app.Id;
            usr.Application = app;
            usr.Member = memb;
            usr.MemberId = memb.Id;
            usr.CreatedDate = DateTimeOffset.UtcNow;
            usr.ApprovedDate = DateTimeOffset.UtcNow;
            usr.GenerateNewIdentity();
            context.User.Add(usr);
            context.SaveChanges();
        }
    }
}