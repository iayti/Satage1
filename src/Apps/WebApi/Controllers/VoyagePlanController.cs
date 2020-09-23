namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Common.Models;
    using Application.Dto;
    using Application.VoyagePlan.Commands.Create;
    using Application.VoyagePlan.Commands.Delete;
    using Application.VoyagePlan.Commands.Enroll;
    using Application.VoyagePlan.Commands.Publish;
    using Application.VoyagePlan.Commands.Update;
    using Application.VoyagePlan.Queries.GetCities;
    using Application.VoyagePlan.Queries.GetCityById;
    using Application.VoyagePlan.Queries.GetVoyagePlanByCityFrom;
    using Microsoft.AspNetCore.Mvc;

    public class VoyagePlanController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<VoyagePlanDto>>>> GetAllVoyagePlan()
        {
            return Ok(await Mediator.Send(new GetAllVoyagePlansQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> GetVoyagePlanById(int id)
        {
            return Ok(await Mediator.Send(new GetVoyagePlanByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> Create(CreateVoyagePlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> Update(UpdateVoyagePlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteVoyagePlanCommand { Id = id }));
        }

        [HttpPost("publish")]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> Publish(PublishVoyagePlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("searchfrom/{param}")]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> GetVoyagePlanByCityFrom(string param)
        {
            return Ok(await Mediator.Send(new GetVoyagePlanByCityFromQuery { param = param }));
        }

        [HttpGet("searchto/{param}")]
        public async Task<ActionResult<ServiceResult<VoyagePlanDto>>> GetVoyagePlanByCityTo(string param)
        {
            return Ok(await Mediator.Send(new GetVoyagePlanByCityToQuery { param = param }));
        }

        [HttpPost("enroll")]
        public async Task<ActionResult<ServiceResult<EnrolleeDto>>> Enroll(EnrollVoyagePlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
