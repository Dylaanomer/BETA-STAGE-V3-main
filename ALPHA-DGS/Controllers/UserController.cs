using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALPHA_DGS.Data;

namespace ALPHA_DGS.Controllers
{
    public class UserController : Controller
    {

        private readonly AlphaDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public UserController(AlphaDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        public IActionResult Index ()

        {
            var userList = _db.ApplicationUser.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach(var user in userList)
            {
                var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
                if (role == null)
                {
                    user.Role = "None";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
                }

            }

            return View(userList);


        }
    }
}
