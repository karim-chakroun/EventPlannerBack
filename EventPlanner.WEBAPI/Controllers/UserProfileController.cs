using EventPlanner.Data;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventPlanner.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _UserManager;
        private readonly AppPlanningContext _context;
        public UserProfileController(UserManager<ApplicationUser> userManager, AppPlanningContext context)
        {
            _UserManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        //Get : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _UserManager.FindByIdAsync(userId);
            var userRole = _UserManager.GetRolesAsync(user).Result.First();
            return new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName,
                user.Adresse,
                user.AboutMe,
                user.birthday,
                user.PhoneNumber,
                user.Image,
                Feedbacks = user.Feedbacks.Select(f => new Feedback
                {
                    IdFeedback = f.IdFeedback,
                    DatePost = f.DatePost,
                    IdPoster = f.IdPoster,
                    Description = f.Description,
                    IdReceiver = f.IdReceiver,
                    




                }).ToList(),
                userRole

            };
        }

        [HttpGet("{id}")]
        // GET: /api/UserProfile/{id}
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userRole = await _UserManager.GetRolesAsync(user);

            var userProfile = new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName,
                user.AboutMe,
                user.birthday,
                user.Adresse,
                user.PhoneNumber,
                user.Image,
                Feedbacks = user.Feedbacks.Select(f => new Feedback
                {
                    IdFeedback = f.IdFeedback,
                    DatePost = f.DatePost,
                    IdPoster = f.IdPoster,
                    Description = f.Description,
                    IdReceiver = f.IdReceiver,
                    Fullname= f.Fullname,
                    Image= f.Image,





                }).ToList(),
                userRole
            };

            return Ok(userProfile);
        }

        [HttpGet]
        [Route("GetUsersByUsername")]
        // GET: /api/Users?username={username}
        public async Task<IActionResult> GetUsersByUsername(string username)
        {
            var users = await _UserManager.Users
                .Where(u => u.FullName.Contains(username))
                .ToListAsync();

            var userProfiles = users.Select(user => new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName,
                user.PhoneNumber,
                user.Image,
            });

            return Ok(userProfiles);
        }


        [HttpGet]
        [Authorize(Roles = "Agent")]
        [Route("ForAgent")]
        public string GetForAgent()
        {
            return "web method for Agent";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetForCustomer()
        {
            return "web method for customer";
        }


        //[Authorize]
        ////Get : /api/UserProfile
        //[HttpPut("{id}")]
        //public async void Put(string userId, ApplicationUserModel user)
        //{

        //    var myUser = _context.ApplicationUsers.FindAsync(userId);

        //    _context.Entry(myUser).State = EntityState.Modified;


        //    await _context.SaveChangesAsync();






        //}


        [HttpPut]
        [Authorize]
        // Put: /api/UserProfile
        public async Task<IActionResult> EditUserProfile(ApplicationUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Update the user's profile properties
            

            user.Image = model.Image;

            // Update the user using the UserManager
            var result = await _UserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                // If the update failed, return the errors to the client
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("EditUser")]
        // Put: /api/UserProfile
        public async Task<IActionResult> EditUser(ApplicationUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _UserManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            // Update the user's profile properties


            user.FullName = model.FullName;
            user.Email=model.Email;
            user.UserName = model.UserName;
            user.AboutMe=model.AboutMe;
            user.birthday = model.birthday;
            user.PhoneNumber = model.PhoneNumber;
            user.Adresse = model.Adresse;


            // Update the user using the UserManager
            var result = await _UserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                // If the update failed, return the errors to the client
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }
        }

    }
}
