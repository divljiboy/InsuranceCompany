using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSPA.BLL;
using AspNetCoreSPA.Model.POCOs;
using Newtonsoft.Json.Linq;

namespace AspNetCoreSPA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Policy")]
    public class PolicyController : Controller
    {
        private readonly IPolicyBLL _policyBLL;

        public PolicyController(IPolicyBLL policyBLL)
        {
            _policyBLL = policyBLL;
        }

        // GET: api/Policy
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_policyBLL.GetAll());
        }

        // GET: api/Policy/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json("value" + id);
        }

        // POST: api/Policy
        [HttpPost]
        public IActionResult Post([FromBody] JObject stuff)
        {

            Policy polisa = stuff["finalPolicy"].ToObject<Policy>();
            Client glavniklijent = stuff["ClientNavigation"].ToObject<Client>();
            Car car = stuff["finalCar"].ToObject<Car>();
            Client clientcar = stuff["clientCar"].ToObject<Client>();
            Client clienthouse = stuff["clientHouse"].ToObject<Client>();
            Home house = stuff["finalHouse"].ToObject<Home>();
            Destination destination = stuff["finalDestination"].ToObject<Destination>();
            PricelistItem pritem = stuff["finalPrice"].ToObject<PricelistItem>();
            polisa.ClientNavigation = glavniklijent;

            car.Client = clientcar;
            
            SubjectOfInsurance subj = new SubjectOfInsurance();
            subj.Car = car;
            subj.Home = house;
            subj.Dst = destination;
            subj.TpId = 1;
            polisa.Ii = subj;
            polisa.PlItem = pritem;



            _policyBLL.Add(polisa);




            return Json(polisa.Ii.Car.Carid+" "+polisa.Ii.Home.HomeId);
        }

        // PUT: api/Policy/5
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
