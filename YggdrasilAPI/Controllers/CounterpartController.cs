using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CounterpartController : Controller
    {
        private readonly ICounterpartData _cpControl;
        public CounterpartController(ICounterpartData inCpControl)
        {
            _cpControl = inCpControl;
        }
        [HttpGet, Route("Counterparts")]
        public ActionResult<List<Counterpart>> Get()
        {
            ActionResult<List<Counterpart>> foundReturn;
            // Retrieve data
            List<Counterpart> foundCounterparts = _cpControl.Get();

            // Evaluate
            if(foundCounterparts != null)
            {
                if(foundCounterparts.Count > 0)
                {
                    foundReturn = Ok(foundCounterparts);            // Statuscode 200, Ok
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
            // send response back to the client
            return foundReturn;
        }
    }
}
