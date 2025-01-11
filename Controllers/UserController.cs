using FleamarketApp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller 
{
    private readonly IFirebaseTokenService _firebaseTokenService;
    private readonly IUserRepository _userRepository;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserService _userService;

    public UserController(
        IUserRepository userRepository, 
        SignInManager<User> signInManager, 
        IUserService userService,
        IFirebaseTokenService firebaseTokenService)
    {
        _userRepository = userRepository;
        _signInManager = signInManager;
        _userService = userService;
        _firebaseTokenService = firebaseTokenService;
    }


    #region  Login Routes
    [Route("login")]
    public IActionResult Login()
    {
        UserLoginDTO userDTO = new UserLoginDTO();
        return View(userDTO);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserLoginDTO userDTO)
    {
        // check model validity
        if(!ModelState.IsValid)
            return View(userDTO);

        // verify userdto against db
        User? user = await _userRepository.GetUserByUsernameAsync(userDTO.Username);
        if(user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(userDTO);
        }
            
        // verify password
        if(!_userRepository.VerifyPassword(user, userDTO.UnhashedPassword))
        {
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(userDTO);
        }

        //Generate firebase token and update user
        var token = await _firebaseTokenService.GenerateTokenAsync(user.Id);
        user.FirebaseToken = token;
        await _userRepository.UpdateUserAsync(user);

        // if user exists and password is correct then login
        await _signInManager.SignInAsync(user, true);

        return RedirectToAction("Index", "Home");  
    }

    #endregion

    #region Registration Routes

    [Route("register")]
    public IActionResult Register()
    {
        CreateUserDTO createUserDTO = new CreateUserDTO();
        return View(createUserDTO);
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
    {
        if(!ModelState.IsValid)
        {
            return View(createUserDTO);
        }

        // basic verification to check if account username is taken
        if(await _userRepository.CheckIfAccountExistsAsync(createUserDTO.Username))
            return View("User already exists");

        // create new user model
        User newUser = new User();
        
        // populate model data
        newUser.FirstName = createUserDTO.FirstName;
        newUser.LastName = createUserDTO.LastName;
        newUser.UserName = createUserDTO.Username;
        newUser.PasswordHash = _userRepository.HashPassword(newUser, createUserDTO.UnhashedPassword);
        newUser.Email = createUserDTO.Email;
        newUser.Address = string.Empty;
        newUser.ProfilePictureURL = createUserDTO.DefaultProfilePictureURL;
        newUser.FirebaseToken = string.Empty;

        // add to db
        await _userRepository.AddAsync(newUser);

        return RedirectToAction("Login");
    }

    #endregion

    #region Profile Routes

    [Route("profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        User? user = await _userRepository.GetUserByUsernameAsync(User.Identity.Name);
        if(user == null)
            return View("Error: User model could not be loaded");

        return View(user);
    }


    [HttpPost]
    [Authorize]
    public async  Task<IActionResult> UpdateProfilePicture(string profilePictureURL)
    {
        // get model
        User? user = await _userRepository.GetUserByUsernameAsync(User.Identity.Name);
        if(user == null)
            return View("Error: User model could not be loaded");

        // change url
        await _userService.UpdateProfilePictureAsync(user, profilePictureURL);

        return RedirectToAction("Profile");
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateAddress(string newAddress)
    {
        // get model
        User? user = await _userRepository.GetUserByUsernameAsync(User.Identity.Name);
        if(user == null)
            return View("Error: User model could not be loaded");

        await _userService.UpdateUserAddressAsync(user, newAddress);

        return RedirectToAction("Profile");
    }
    #endregion


    [Route("signout")]
    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}