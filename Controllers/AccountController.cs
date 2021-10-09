using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_identity_sample.DTOs;
using dotnet_identity_sample.Models;
using dotnet_identity_sample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_identity_sample.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;

    private readonly SignInManager<AppUser> _signInManager;
    public AccountController(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    TokenService tokenService)
    {
      _tokenService = tokenService;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.FindByEmailAsync(loginDto.Email);

      if (user == null) return Unauthorized();

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (result.Succeeded)
      {
        return CreateUserObject(user);
      }

      return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
      {
        return BadRequest("Email taken");
      }

      if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName))
      {
        return BadRequest("User name taken");
      }

      var user = new AppUser
      {
        Email = registerDto.Email,
        //DisplayName = registerDto.DisplayName,
        UserName = registerDto.UserName
      };

      var result = await _userManager.CreateAsync(user, registerDto.Password);

      if (result.Succeeded)
      {
        return CreateUserObject(user);
      }

      return BadRequest("failed regist");
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      return CreateUserObject(user);
    }

    private UserDto CreateUserObject(AppUser user)
    {
      // TODO:フロントとの兼ね合いなので後でなんとかしておく
      user.Email = user.UserName;
      return new UserDto
      {
        Id = user.Id,
        Iamge = null,
        Token = _tokenService.CreateToken(user),
        UserName = user.UserName
      };
    }
  }
}