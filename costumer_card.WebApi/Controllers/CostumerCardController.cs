using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RDIDigitalTest.Application.Interfaces;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.DTOs;
using RDIDigitalTest.Domain.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace costumer_card.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CostumerCardController : ControllerBase
    {
        private readonly ILogger<CostumerCardController> logger;
        private readonly ICostumerCardApplicationService costumerCardApplicationService;

        public CostumerCardController(ILogger<CostumerCardController> logger, ICostumerCardApplicationService costumerCardApplicationService)
        {
            this.logger = logger;
            this.costumerCardApplicationService = costumerCardApplicationService;
        }

        /// <summary>
        /// POST method to save costumer's card data
        /// </summary>
        /// <param name="costumerCard"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostCostumerCard")]
        public IActionResult PostCostumerCard([FromBody] CostumerCardTO costumerCard)
        {
            try 
            {
                if (costumerCard == null)
                    return NotFound();

                return Execute(() => costumerCardApplicationService.Add(costumerCard));
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
