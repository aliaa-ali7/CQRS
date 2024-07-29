using CQRS_Library.CQRS.Commands;
using CQRS_Library.CQRS.Handelrs;
using CQRS_Library.CQRS.Queries;
using CQRS_Library.Data.Models;
using CQRS_Library.Repos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IitemRepository iitemRepository;
        private readonly IMediator mediator;

        public ItemsController(IitemRepository iitemRepository , IMediator mediator) 
        {
            this.iitemRepository = iitemRepository;
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetItems()
        {

            var result = await mediator.Send(new GetAllQueries());

            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> InsertItem(Items item)
        { 

            var result = await mediator.Send(new InsertCommand(item));

            return Ok(result);
        }
    }
}
