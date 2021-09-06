using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RDIDigitalTest.Application.Interfaces;
using RDIDigitalTest.Application.TransferObjects.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace token_validation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> logger;
        private readonly ICostumerCardApplicationService costumerCardApplicationService;

        public TokenController(ILogger<TokenController> logger, ICostumerCardApplicationService costumerCardApplicationService)
        {
            this.logger = logger;
            this.costumerCardApplicationService = costumerCardApplicationService;
        }

        /// <summary>
        /// POST method to validate token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("TokenValidate")]
        public IActionResult TokenValidate([FromBody] TokenTO token)
        {
            try
            {
                if (token == null)
                    return NotFound();

                return Execute(() => costumerCardApplicationService.isValidToken(token));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
