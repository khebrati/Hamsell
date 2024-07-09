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

    public UserController(ILogger<HomeController> logger,UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }
    public IActionResult SignUp()
    {
        // _userRepository.GetUser(1);
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        
        // if (ModelState.IsValid)
        // {
        //     var existingAccount = await _context.Accounts
        //         .FirstOrDefaultAsync(a => a.EmailAddress == model.EmailAddress);
        //     if (existingAccount != null)
        //     {
        //         ModelState.AddModelError("EmailAddress", "Email already in use.");
        //         return View(model);
        //     }
        //
        //     var account = new Account
        //     {
        //         FirstName = model.FirstName,
        //         LastName = model.LastName,
        //         EmailAddress = model.EmailAddress,
        //         PhoneNumber = model.PhoneNumber,
        //         CreationDate = DateTime.UtcNow
        //     };
        //
        //     _context.Accounts.Add(account);
        //     await _context.SaveChangesAsync();
        //
        //     // Assuming automatic AccountId assignment upon saving
        //     var user = new User
        //     {
        //         AccountId = account.AccountId,
        //         // Additional properties like CityId and UserStatusId can be set here if needed
        //     };
        //
        //     _context.Users.Add(user);
        //     await _context.SaveChangesAsync();
        //
        //     // Implement any sign-in logic here
        //
        //     return RedirectToAction("Index", "Home"); // Redirect to a different action/view as appropriate
        // }
        //
        // // If we got this far, something failed, redisplay form
        // return View(model);
        return View(model);
    }
}