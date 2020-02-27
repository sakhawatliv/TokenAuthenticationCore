using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTinApi.Model;
using JWTinApi.Repository;
using JWTinApi.Repository.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usr = await _repository.GetUsers();
            return Ok(usr);

        }
        [HttpPost]
        public async Task<IActionResult> User([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var appUser = new ApplicationUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.Phone,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var isExist = await _userManager.FindByEmailAsync(user.Email);
            if (isExist != null)
            {
                return BadRequest("User Exist already");
            }
            var addInIdentity = await _userManager.CreateAsync(appUser, user.Password);
            user.Password = "";
            //user.CreateDate = DateTime.UtcNow;
            var addUser = await _repository.PostUser(user);
            if (addUser == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}