using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDev.Service.TokenService;

namespace YDev.Web.Controllers.Admin
{
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Route("api/token")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(string username, string password)
        {
            bool checkDb = true;

            if (checkDb)//Check Database for username and password
            {
                var token = _tokenService.GetToken(username, password);

                return new OkObjectResult(new { token = token });
            }
            else
                return new BadRequestObjectResult(new { error = "Incorrect username or password" });
        }
    }
}