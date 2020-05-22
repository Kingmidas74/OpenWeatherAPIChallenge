using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIService.Extensions;

namespace WebAPIService.Versions.ANY.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class StatusController : ControllerBase {
        public StatusController () {
        }

        /// <summary>
        /// Открытый статус
        /// </summary>
        /// <returns></returns>
        [HttpGet (nameof (GetFreeStatus))]
        public IActionResult GetFreeStatus () {
            //MessageService.Enqueue (nameof (GetFreeStatus), MessageBusEvents.UserNotificationEvent.GetDescription ());
            return Ok (new {
                result=1
            });
        }
    }
}