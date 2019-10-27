using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFanta.Models;
using ProjectFanta.Services;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly IGroupManager groupManager;

        public GroupController(IGroupManager groupManager)
        {
            this.groupManager = groupManager;
        }

        [HttpPut]
        [Route("/api/group/{key}/{phoneNumber}")]
        public IActionResult Put(string key, string phoneNumber)
        {
            this.groupManager.AddSubscriberByKey(key, new User() { PhoneNumber = phoneNumber });
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        [Route("/api/group")]
        public IActionResult Post([FromBody] CreateGroupModel model)
        {
            var groupKey = this.groupManager.NewGroup(model.PhoneNumber);
            this.Response.StatusCode = StatusCodes.Status201Created;
            return new JsonResult(groupKey);
        }
    }
}