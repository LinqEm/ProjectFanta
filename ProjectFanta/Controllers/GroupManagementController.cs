using Microsoft.AspNetCore.Mvc;
using ProjectFanta.Services;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Controllers
{
    public class GroupManagementController : ControllerBase
    {
        [HttpPost]
        public ActionResult NewGroup(string adminNumber)
        {

            
            return Ok();
        }
    }
}