using System;
using System.Threading.Tasks;
using BusinessServices.Modules.ParentModule;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIService.Versions.V01.Controllers
{

    [Route ("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("0.1")]
    public class DataController : ControllerBase {
        private readonly IMediator mediator;
        public DataController (IMediator mediator) {            
            this.mediator = mediator;
        }


        /// <summary>
        /// Get data by lon and lan
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDataByLonAndLat([FromQuery]double lat, [FromQuery]double lon) {
            return Ok(await mediator.Send(new GetDataByLonLatQuery() {
                Lattitude = lat,
                Longitude = lon
            }));
        }

    }
}