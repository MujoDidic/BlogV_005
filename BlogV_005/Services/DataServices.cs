using BlogV_005.Data;
using BlogV_005.Enums;
using BlogV_005.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogV_005.Services
{
    public class DataServices
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataServices(ApplicationDbContext dbContext,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task ManageDataAsync()
        {
            //Create DB from migrations
            await _dbContext.Database.MigrateAsync();

            //1. seeding few roles into the system
            await SeedRolesAsync();

            //2. seed few users into the system
            await SeedUsersAsync();
        }

        //1. seeding few roles into the system
        private async Task SeedRolesAsync()
        {
            //If there are already roles in system do nothing
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise create few roles
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //Use Role manager
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }


        //2. seed few users into the system

        private async Task SeedUsersAsync()
        {
            //If there are already users in system do nothing
            if (_dbContext.Users.Any())
            {
                return;
            }

            /***************************
             *  Role of Administrator  *
             ***************************/

            //1.Creates new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "mujocsharpdev@gmail.com",
                UserName = "mujocsharpdev@gmail.com",
                FirstName = "Mujo",
                LastName = "Didic",
                DisplayName = "ADMIN",
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };

            //2.Create new user defined by admin role
            await _userManager.CreateAsync(adminUser, "Asd&123!");


            //3.add new user ot admin role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            /***********************
             *  Role of Moderator  *
             **********************/

            //1.Creates new instance of BlogUser
            var modUser = new BlogUser()
            {
                Email = "mujo149@gmail.com",
                UserName = "mujo149@gmail.com",
                FirstName = "Mujaga",
                LastName = "Mali",
                DisplayName = "MOD",
                PhoneNumber = "9876543210",
                EmailConfirmed = true
            };

            //2.Create new user defined by moderator role
            await _userManager.CreateAsync(modUser, "Asd&123!");


            //3.add new user ot moderator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }

    }
}
