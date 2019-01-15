using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nursry.Core.Interfaces;
using Nursry.Core.Entities;
using Nursry.Core.Specifications;
using Nursry.Core.SharedKernel;

namespace Nursry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IChildRepository childRepo;
        private readonly ILogRepository logRepo;

        public ValuesController(IChildRepository childRepository, ILogRepository logRepository)
        {
            this.childRepo = childRepository;
            this.logRepo = logRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(Guid id)
        {
            return "Hello world!";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
