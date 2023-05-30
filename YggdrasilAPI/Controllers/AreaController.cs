using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaData _areaControl;

        public AreaController(IAreaData inAreaControl)
        {
            _areaControl = inAreaControl;
        }

        [HttpGet, Route("Areas")]
        public ActionResult<List<Area>> Get()
        {
            ActionResult<List<Area>> foundReturn;
            // Retrieve data
            List<Area>? foundAreas = _areaControl.Get();

            // Evaluate
            if(foundAreas != null)
            {
                if(foundAreas.Count > 0)
                {
                    foundReturn = Ok(foundAreas);                   // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);        // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);            // Internal Server Error
            }
            // Send response back to client
            return foundReturn;
        }
    }
}
