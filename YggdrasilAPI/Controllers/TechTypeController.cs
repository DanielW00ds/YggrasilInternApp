using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TechTypeController : Controller
    {
        private readonly ITechTypeData _ttControl;
        public TechTypeController(ITechTypeData inTtControl)
        {
            _ttControl = inTtControl;
        }
        [HttpGet, Route("TechnologyTypes")]
        public ActionResult<List<TechnologyType>> Get()
        {
            ActionResult<List<TechnologyType>> foundReturn;
            // Retrieve data
            List<TechnologyType> foundTechTypes = _ttControl.Get();

            // Evaluate
            if(foundTechTypes != null)
            {
                if(foundTechTypes.Count > 0)
                {
                    foundReturn = Ok(foundTechTypes);               // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);        // Ok, but no content
                }
            }
            else
            {
                foundReturn = null;
            }
            // Send response back to client
            return foundReturn;
        }
    }
}
