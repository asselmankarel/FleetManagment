using Fleetmanagement.IdentityProvider.Services;
using IdentityModel;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleetmanagement.IdentityProvider.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly ILocalUserService _localUserService;
        private readonly IIdentityServerInteractionService _interaction;

        public UserRegistrationController(ILocalUserService localUserService, IIdentityServerInteractionService interaction)
        {
            _localUserService = localUserService ?? throw new ArgumentNullException(nameof(localUserService));
            _interaction = interaction ?? throw new ArgumentNullException(nameof(interaction));
        }

        [HttpGet]
        public IActionResult RegisterUser(string returnUrl)
        {
            var viewModel = new RegisterUserViewModel { ReturnUrl = returnUrl };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userToCreate = new Entities.User
            {
                Password = model.Password,
                Email = model.Email,
                Subject = Guid.NewGuid().ToString(),
                IsActive = true
            };

            userToCreate.Claims.Add(new Entities.UserClaim
            {
                Type = JwtClaimTypes.Name,
                Value = $"{model.GivenName} {model.FamilyName}"
            });

            userToCreate.Claims.Add(new Entities.UserClaim
            {
                Type = JwtClaimTypes.GivenName,
                Value = model.GivenName
            });

            userToCreate.Claims.Add(new Entities.UserClaim
            {
                Type = JwtClaimTypes.FamilyName,
                Value = model.FamilyName
            });

            _localUserService.AddUser(userToCreate, model.Password);
            await _localUserService.SaveChangesAsync();

            //await HttpContext.SignInAsync()

            return Redirect("~/");
        }
    }
}
