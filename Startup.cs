using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using WebApplication2.Models;

[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
namespace WebApplication2
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
                
        }

        private void CreateDefaultRolesAndUsers()
        {
            var roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager= new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            IdentityRole role = new IdentityRole();
            if (!roleManger.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManger.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.UserName = "Moamen";
                user.Email = "moamen@gmail.com";
                var Check = userManager.Create(user, "Moamen@12345");

                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }
        }
    }
}
