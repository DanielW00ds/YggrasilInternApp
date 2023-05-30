using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly IStateData _sControl;
        public StateController(IStateData inSControl)
        {
            _sControl = inSControl;
        }
        [HttpGet, Route("States")]
        public ActionResult<List<State>> Get()
        {
            ActionResult<List<State>> foundReturn;
            // Retrieve data
            List<State> foundStates = _sControl.Get();

            //Evaluate
            if(foundStates != null)
            {
                if(foundStates.Count > 0)
                {
                    foundReturn = Ok(foundStates);                  // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);        // Ok, but not content
                }
            }
            else
            {
                foundReturn = null;
            }
            // send response to the client
            return foundReturn;
        }

    }
}
