using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Model;

namespace FineArtsWebApp
{
    public class AuthController : BaseController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserAccountService _userAccountService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IUserService _userService;
        private readonly IModelBaseService _modelBaseService;

        public AuthController(
            ILogger<AuthController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IUserAccountService userAccountService,
            IStringLocalizer<SharedResource> localizer,
            IUserService userService,
            IModelBaseService modelBaseService
           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userAccountService = userAccountService;
            _localizer = localizer;
            _userService = userService;
            _logger = logger;
            _modelBaseService = modelBaseService;
        }

        public ActionResult Signup()
        {
            var objModel = new UserViewModel();
            objModel.PageName = "Registration Page";
                   return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(UserViewModel model)
        {
            var userIdentity = new IdentityUser
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                NormalizedUserName = model.Email.ToUpper(),
                UserName = Common.StringHelper.GetUserNameFromEmail(model.Email)
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            

            await _userManager.AddToRoleAsync(userIdentity, "User"); 
          
            
            if (result.Succeeded)
            {
                // Visitor User (DeshiEntityContext of Applicaton)
                User objUserEntity = new User(userIdentity.Id, userIdentity.Email, userIdentity.UserName,
                                            StaticAppSettings.Country, StaticAppSettings.CompanyName);

                
                bool res = await _userService.AddUser(objUserEntity);
                

                return RedirectToAction("Login");
            }

            return BadRequest(result.Errors);        
        }

        public ActionResult Login()
        {
            var objModel = new AccountViewModel();
            objModel.PageName = "Login";
            return View(objModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            var userIdentity = await _userManager.FindByEmailAsync(model.Email);

            if (userIdentity == null)
            {
                return BadRequest("Invalid credentials");
            }


            var resultSignIn = await _signInManager.PasswordSignInAsync(
                userIdentity, model.Password, true, lockoutOnFailure: false);


            if (resultSignIn.Succeeded)
            {
                //UserID i the Application to use.
                int userID = await _userService.GetSingleUser(userIdentity.Id);


                //User Session (UserID)
                UserModel userModel = new UserModel(userID);
                SetSessionUser(userModel);

                
                //Model Base
                _modelBaseService.SetUpModelBase(StaticAppSettings.CompanyName, StaticAppSettings.Country, userID);
                
                ModelBase modelBaseCreate = _modelBaseService.CreateEntity();
                ModelBase modelBaseUpdate = _modelBaseService.UpdateEntity();

                SetModelBaseSession(modelBaseCreate, modelBaseUpdate);
                //Model Base End

                return RedirectToAction("Index", "Home");
            }

            return BadRequest("Invalid credentials");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Clear the user's authentication cookie
            await _signInManager.SignOutAsync();
           
            ClearSessionUser();

            ClearModelBaseSession();

            return RedirectToAction("Index", "Home");
        }


        [Authorize(Roles = "Admin,User,Company")]
        public ActionResult ResetPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                var objModel = new AccountViewModel() { PageName = "Reset Password" };
                return View(objModel);
            }

            return RedirectToAction("Login", "Auth");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User,Company")]
        public async Task<ActionResult> ResetPassword(AccountViewModel accountViewModel)  
        {
            var isValid = ValidationService.IsValidEmail(accountViewModel.Email);
            _logger.LogInformation("Password reset attempt for email: {Email}, Valid Email: {IsValid}", accountViewModel.Email, isValid);
            
            if(!isValid)
            {
                _logger.LogWarning("Invalid email format for password reset: {Email}", accountViewModel.Email);
                return RedirectToAction("ResetPassword");
            }

            var user = await _userManager.FindByEmailAsync(accountViewModel.Email);

            if (user == null)
            {
                _logger.LogWarning("Password reset attempt failed for email: {Email}", accountViewModel.Email);
                return RedirectToAction("ResetPassword");
            }

            try
            {
                var result = await _userManager.ChangePasswordAsync(user, accountViewModel.CurrentPassword, accountViewModel.NewPassword);
                
                if (result.Succeeded)
                {
                    // Optional: Refresh sign-in to update cookies/claims
                    return RedirectToAction("Login");
                }

                return RedirectToAction("ResetPassword");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                _logger.LogError(ex, "Error sending password reset email to {Email}", accountViewModel.Email);
                return RedirectToAction("ResetPassword");
            }
        }

        //[HttpPost]
        //public async Task<JsonResult> EmailVerify()
        //{
        //    try
        //    {
        //        var codeValue = "";
        //        UserModel userModel = GetSessionUser();
        //        if (!userModel.IsVerifiedUser.Value && userModel != null)
        //        {
        //            codeValue = await _userAccountService.UpdateVerifyCode(userModel.UserID);
        //            var objEmailViewModel = _EmailService.GetVerifyEmailViewModel(codeValue);
        //            objEmailViewModel.MessageBodyHTMLText = await FindMyView(this, "_VerifyEmail", objEmailViewModel);
        //            objEmailViewModel.ReceiverEmail = userModel.Email;
        //            _EmailService.SendAccountVerifyEmail(objEmailViewModel);
        //            return Json(false);
        //        }
        //        return Json(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error sending account verification email to user ID: {UserID}", GetSessionUser()?.UserID);
        //        var msg = ex.Message;
        //        return Json(false);
        //    }
        //}
    }
}
