using Microsoft.AspNetCore.Mvc;
using ModelLiberary;
using YggdrasilAPI.BusinessLogic;

namespace YggdrasilAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AssetTypeController : Controller
    {
        private readonly IAssetTypeData _atControl;
        public AssetTypeController(IAssetTypeData inAtControl)
        {
            _atControl = inAtControl;
        }
        [HttpGet, Route("AssetTypes")]
        public ActionResult<List<AssetType>> Get()
        {
            ActionResult<List<AssetType>> foundReturn;
            // Retrieve data
            List<AssetType>? foundAssetTypes = _atControl.Get();

            // Evaluate
            if(foundAssetTypes != null)
            {
                if(foundAssetTypes.Count > 0)
                {
                    foundReturn = Ok(foundAssetTypes);              // Statuscode 200, Ok
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);        // Ok, but not content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);            // Internal Server Error
            }
            return foundReturn;
        }
    }
}
