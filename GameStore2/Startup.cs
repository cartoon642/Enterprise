﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using GameStore2.Models;

[assembly: OwinStartupAttribute(typeof(GameStore2.Startup))]
namespace GameStore2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndDefaultUsers();
        }

        private void createRolesAndDefaultUsers()
        {
            // using keyword - this is the same as try/finally and dispose.
            // it is used for IDisposable classes, such as a DBContext to make sure
            // that all resources are cleaned up
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                // some tutorials will use the var keyword
                // var allows the data type to be inferred by the compiler and Visual Studio
                using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    // check whether an Admin role already exists - if it does, do nothing
                    if (!roleManager.RoleExists("Admin"))
                    {
                        // Admin role does NOT exist - we need to create it
                        IdentityRole role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                        role.Name = "Admin";
                        roleManager.Create(role);
                    }
                }

                // Now it is time to manage the users and assign roles to the user
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // First, check if the admin user exists!
                    if (userManager.FindByName("administrator@yourEmailHost.com") == null)
                    {
                        // admin user does not exist - we can create it
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = "AxelSatariano@yourEmailHost.com";
                        user.Email = "AxelSatariano@yourEmailHost.com";

                        string userPWD = "P@ssw0rd_1234";

                        IdentityResult chkUser = userManager.Create(user, userPWD);

                        //Add the admin user to the Admin role, if it was successfully created
                        if (chkUser.Succeeded)
                        {
                            IdentityResult chkRole = userManager.AddToRole(user.Id, "Admin");

                            if (!chkRole.Succeeded)
                            {
                                // admin user was not assigned to role, something went wrong!
                                // Log this information and handle it
                                Console.Error.WriteLine("An error has occured in Startup! admin user was not assigned to Admin role successfully.");
                                Console.WriteLine("An error has occured in Startup! admin user was not assigned to Admin role successfully.");
                            }
                        }
                        else
                        {   // admin user was not created, something went wrong!
                            // Log this information and handle it
                            Console.Error.WriteLine("An error has occured in Startup! admin user does not exist, but was not created successfully.");
                            Console.WriteLine("An error has occured in Startup! admin user does not exist, but was not created successfully.");
                        }
                    }
                }
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // First, check if the admin user exists!
                    if (userManager.FindByName("administrator@yourEmailHost.com") == null)
                    {
                        // admin user does not exist - we can create it
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = "TestUser1";
                        user.Email = "Testuser@hotmail.com";

                        string userPWD = "P@ssw0rd_1234";

                        IdentityResult chkUser = userManager.Create(user, userPWD);
                    }
                }
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // First, check if the admin user exists!
                    if (userManager.FindByName("administrator@yourEmailHost.com") == null)
                    {
                        // admin user does not exist - we can create it
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = "TestUser4";
                        user.Email = "Testuser4@hotmail.com";

                        string userPWD = "P@ssw0rd_1234";

                        IdentityResult chkUser = userManager.Create(user, userPWD);
                    }
                }
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // First, check if the admin user exists!
                    if (userManager.FindByName("administrator@yourEmailHost.com") == null)
                    {
                        // admin user does not exist - we can create it
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = "TestUser2";
                        user.Email = "Testuser2@hotmail.com";

                        string userPWD = "P@ssw0rd_1234";

                        IdentityResult chkUser = userManager.Create(user, userPWD);
                    }
                }
                using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
                {
                    // First, check if the admin user exists!
                    if (userManager.FindByName("administrator@yourEmailHost.com") == null)
                    {
                        // admin user does not exist - we can create it
                        ApplicationUser user = new ApplicationUser();
                        user.UserName = "TestUser3";
                        user.Email = "Testuser3@hotmail.com";

                        string userPWD = "P@ssw0rd_1234";

                        IdentityResult chkUser = userManager.Create(user, userPWD);
                    }
                }

            }
        }
    }
}