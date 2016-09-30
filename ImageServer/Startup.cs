using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ImageServer.Models;

[assembly: OwinStartupAttribute(typeof(ImageServer.Startup))]
namespace ImageServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
        }

        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());

            // Check for Provider users.  If not exists we created it.
            if(!roleManager.RoleExists("Provider"))
            {
                var role = new IdentityRole();
                role.Name = "Provider";
                roleManager.Create(role);
           
            }
            
            if(!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);
            }

            if(!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);
            }

            if(!roleManager.RoleExists("Consumer"))
            {
                var role = new IdentityRole();
                role.Name = "Consumer";
                roleManager.Create(role);
            }
            
        }
    }
}
