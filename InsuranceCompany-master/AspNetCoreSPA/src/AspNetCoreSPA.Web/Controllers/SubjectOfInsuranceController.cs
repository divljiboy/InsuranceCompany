using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSPA.BLL;
using AspNetCoreSPA.Model.POCOs;

namespace AspNetCoreSPA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/SubjectOfInsurance")]
    public class SubjectOfInsuranceController : Controller
    {
        private readonly ISubjectOfInsuranceBLL _subjectOfInsuranceBLL;

        public SubjectOfInsuranceController(ISubjectOfInsuranceBLL subjectOfInsuranceBLL)
        {
            _subjectOfInsuranceBLL = subjectOfInsuranceBLL;
        }

        // GET: api/SubjectOfInsurance
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_subjectOfInsuranceBLL.GetAll());
        }

        // GET: api/SubjectOfInsurance/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json("value" + id);
        }

        // POST: api/SubjectOfInsurance
        [HttpPost]
        public IActionResult Post([FromBody]SubjectOfInsurance value)
        {
            return Json(_subjectOfInsuranceBLL.Add(value));
        }

        // PUT: api/SubjectOfInsurance/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
