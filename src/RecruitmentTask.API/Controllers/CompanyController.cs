using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.API.ViewModels;
using RecruitmentTask.INFRATRUCTURE.Commands;
using RecruitmentTask.INFRATRUCTURE.Queries;
using System.Threading.Tasks;

namespace RecruitmentTask.API.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CompanyController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyViewModel model)
        {
            var command = this.mapper.Map<CreateCompanyViewModel, CreateCompanyCommand>(model);
            var result = await this.mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPost("search")]
        public async Task<ActionResult> SearchCompany([FromBody] SearchCompanyViewModel model)
        {
            var command = this.mapper.Map<SearchCompanyViewModel, SearchCompaniesQuery>(model);
            var result = await this.mediator.Send(command);
            return Ok(result);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> EditCompany(long id, [FromBody] EditCompanyViewModel model)
        {
            var command = new EditCompanyCommand(id, model.Name, model.EstablishmentYear, model.Employees);
            var result = await this.mediator.Send(command);
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(long id)
        {
            var command = new DeleteCompanyCommand(id);
            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}
