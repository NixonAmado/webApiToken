using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Services;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        //sobrecarga
        public async Task<ActionResult> RegisterAsync(RegisterDto model)
        {
            var result =  await _userService.RegisterAsync(model);
            return Ok(result);
        }
        [HttpGet("token")]
        public async Task<IActionResult> GetTokenAsync(LoginDto model)
                {
            var result =  await _userService.GetTokenAsync(model);
            return Ok(result);
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRolAsync(AddRolDto model)
            {
                var result =  await _userService.AddRoleAsync(model);
                return Ok(result);
            }

}