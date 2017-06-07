using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Repositories;
using Repositories.RepositoryContexts;

namespace f1bets.Controllers
{
    [Route("api/user")]
    public class ApiUserController : Controller
    {
        private UserRepository repo = new UserRepository(new UserRepositorySQLContext());
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return repo.GetUserNames();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                string username = repo.GetUser(id).Username;
                return username;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
