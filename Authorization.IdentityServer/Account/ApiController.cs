using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorization.IdentityServer.Account
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected UserManager<IdentityUser> _userManager;

        public ApiController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        // GET: api/<ApiController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {

            //var user = await _userManager.GetUserAsync(User);

            //var userIsActivated = user.EmailConfirmed;

            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
