using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CC2020_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CC2020_API.Controllers
{
    [Route("api/[controller]")]
    public class PayslipsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger _logger;


        public PayslipsController(ApplicationDbContext context, ILogger<PayslipsController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Payslip> Get()
        {
            return unitOfWork.Payslips.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
