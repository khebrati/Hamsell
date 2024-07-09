using Hamsell.Data;
using Hamsell.Data.Repositories.User;
using Hamsell.Models;
using Hamsell.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hamsell.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DbContext _context;
    private readonly UserRepository _userRepository;

    public UserController(ILogger<HomeController> logger, UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var account = new Account
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber
                };

                _userRepository.AddAccount(account);

                int accountId = _userRepository.GetLastInsertedAccountId();

                var user = new User
                {
                    AccountId = accountId,
                    UserStatusId = 1 //Enabled
                };

                _userRepository.AddUser(user);
                
                HttpContext.Session.SetString("UserEmail", model.EmailAddress);
                HttpContext.Session.SetInt32("UserId", user.AccountId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while processing your request.");
                _logger.LogError(ex,"Error occurred while processing request");
                ViewBag.ErrorMessage = $"An error occurred while processing your request. Error says: {ex.Message}";
            }
        }
        
        return View(model);
    }
}