using Microsoft.AspNetCore.Mvc;
using TicketsApi.Services;

namespace TicketsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
      

        private readonly ILogger<TicketsController> _logger;
        private ITicketsQueryService ticketQueryService;
        public TicketsController(ILogger<TicketsController> logger, ITicketsQueryService ticketQueryService)
        {
            _logger = logger;

            this.ticketQueryService = ticketQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken token)
        {
            var results = await this.ticketQueryService.GetAllAsync();

            return Ok(results);
        }
    }
}