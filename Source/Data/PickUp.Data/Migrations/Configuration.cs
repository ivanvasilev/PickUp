namespace PickUp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using PickUp.Common;
    using PickUp.Data.Models;
    using System.IO;
    using static System.Net.Mime.MediaTypeNames;
    using System;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var administratorRole = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(administratorRole);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

                // Create driver and passenger roles
                var driverRole = new IdentityRole { Name = GlobalConstants.DriverRoleName };
                roleManager.Create(driverRole);
                var passengerRole = new IdentityRole { Name = GlobalConstants.PassengerRoleName };
                roleManager.Create(passengerRole);

                // Create default profile picture
                System.Drawing.Image img = System.Drawing.Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "App_Data/Pictures/default-profile-picture.png");
                byte[] bytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    bytes = ms.ToArray();
                }

                var defaultPic = new PickUp.Data.Models.Image()
                {
                    FileName = "default-profile-picture",
                    Content = bytes,
                    Extension = "png"
                };

                context.Images.Add(defaultPic);
                context.SaveChanges();
            }
        }
    }
}
