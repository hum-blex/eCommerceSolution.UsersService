﻿using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // Check for invalid registerRequest
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        // Call the UsersService to handle registration
        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest(authenticationResponse);
        }
        return Ok(authenticationResponse);

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null) return BadRequest("Invalid login data");

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }
}
