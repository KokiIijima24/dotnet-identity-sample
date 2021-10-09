using System.Collections.Generic;
using System.Linq;
using dotnet_identity_sample.DTOs;
using dotnet_identity_sample.Models;
using dotnet_identity_sample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_identity_sample.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController
  {
    private readonly 
    ApplicationDbContext _dbContext;
    private readonly ILogger<UserController> _logger;

    public UserController(
        ILogger<UserController> logger
      , ApplicationDbContext dbContext)
    {
      _logger = logger;
      _dbContext = dbContext;
    }

    [HttpGet("list")]
    public IEnumerable<UserDto> GetUsers()
    {
      return _dbContext.Users.Select(_ => 
      new UserDto(){
        Id = _.Id,
        Iamge = null
      });
    }
  }
}