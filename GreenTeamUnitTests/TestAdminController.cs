using GreenTeam.Controllers;
using GreenTeam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeamUnitTests
{

    [TestClass]
    public class TestAdminController
    {

        public List<ApplicationRole> CreateTestRoles()
        {
            ApplicationRole roleUser = new ApplicationRole()
            {
               RoleName = "User"
            };

            ApplicationRole adminUser = new ApplicationRole()
            {
                RoleName = "Admin"
            };

            List<ApplicationRole> applicationRoles = new List<ApplicationRole>();
            applicationRoles.Add(roleUser);
            applicationRoles.Add(adminUser);

            return applicationRoles;
        }

        public List<AppUser> CreateTestUsers()
        {
            AppUser user1 = new AppUser();
            user1.UserName = "hendrik@greenteam.com";
            user1.Email = "hendrik@greenteam.com";
            user1.FullName = "Hendrik Verboom";

            AppUser user2 = new AppUser();
            user2.UserName = "mien@greenteam.com";
            user2.Email = "mien@greenteam.com";
            user2.FullName = "Mien Post";

            List<AppUser> users = new List<AppUser>();
            users.Add(user1);
            users.Add(user2);

            return users;
        }

        [TestMethod]
        public void Test_GetListOfUsers()
        {
            //Arrange
            List<AppUser> appUsers = CreateTestUsers();
            var mockUserManager = new Mock<UserManager<AppUser>>();
            mockUserManager.Setup(au => au.Users.ToList()).Returns(appUsers);
            var controller = new AdminController(null, mockUserManager.Object);

            //Act
            var actionResult = controller.ListUsers();

            ViewResult actionViewResult = (ViewResult)actionResult; //Unpackaging
            List<AppUser> actualModel = actionViewResult.Model as List<AppUser>; //Unpackaging

            //Assert           
            Assert.AreSame(appUsers, actualModel, "Models are not the same.");
        }

    }
}
