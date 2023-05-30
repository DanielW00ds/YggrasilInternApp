using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly IAssetData _aControl;
        public AssetController(IAssetData inAssetControl)
        {
            _aControl = inAssetControl;
        }

        [HttpGet, Route("Assets")]
        public ActionResult<List<Asset>> Get()
        {
            ActionResult<List<Asset>> foundReturn;
            // Retrieve data
            List<Asset>? foundAssets = _aControl.get();

            // Evaluate
            if(foundAssets != null)
            {
                if(foundAssets.Count > 0)
                {
                    foundReturn = Ok(foundAssets);                  // Statuscode 200, Ok
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
            // send response back to client
            return foundReturn;
        }

        [HttpPost, Route("Assets")]
        public ActionResult<bool> Post(Asset asset)
        {
            ActionResult<bool> foundReturn;
            if(asset != null)
            {
                bool wasOk = _aControl.Post(asset);
                if (wasOk)
                {
                    foundReturn = Ok();                             // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);        // Internal Server Error
                }
            }
            else
            {
                foundReturn= new StatusCodeResult(400);             // Bad Request
            }
            return foundReturn;
        }

        [HttpPut, Route("Assets/{id}")]
        public ActionResult Put(Asset asset)
        {
            ActionResult foundReturn;
            if (asset != null)
            {
                bool wasOk = _aControl.Put(asset);
                if (wasOk)
                {
                    foundReturn = Ok();                             // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);        // Internal Server Error
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(400);             // Bad Request
            }
            return foundReturn;
        }
        [HttpDelete, Route("Assets/{id}")]
        public ActionResult Delete(int id)
        {
            ActionResult foundReturn;
            if(id > 0)
            {
                bool wasOk = _aControl.Delete(id);
                if (wasOk)
                {
                    foundReturn = Ok();                             // Statuscide 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(500);        // Internal Server Error
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);            // Bad Request
            }
            return foundReturn;
        }
    }
}
