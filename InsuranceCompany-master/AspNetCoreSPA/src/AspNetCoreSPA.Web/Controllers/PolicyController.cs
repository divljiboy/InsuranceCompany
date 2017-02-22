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
            List<Client> lista = stuff["listofClient"].ToObject<List<Client>>();

            SubjectOfInsurance subj = new SubjectOfInsurance();

            if (clientcar.Jmbg != null)
            {
                car.Client = clientcar;
                subj.Car = car;
            }
           
            if (clienthouse.Jmbg != null)
            {
                house.Client = clienthouse;
                subj.Home = house;
                
            }
            
            subj.Dst = destination;
            polisa.Ii = subj;
            polisa.PlItem = pritem;


            polisa.ClientNavigation = glavniklijent;

            _policyBLL.Add(polisa);

            if (lista.Count != 0)
            {
                foreach (Client cl in lista)
                {
                    cl.Policy = polisa;
                }
            }
            if (clienthouse.Jmbg != null && clientcar.Jmbg != null)
            {
               return Json(polisa.Ii.Car.Carid + " " + polisa.Ii.Home.HomeId);
            }
            if (clienthouse.Jmbg != null && clientcar.Jmbg == null) {
                return Json(" " + polisa.Ii.Home.HomeId);
            }
            if (clienthouse.Jmbg == null && clientcar.Jmbg != null)
            {
                return Json(polisa.Ii.Car.Carid + " ");
            }
            else {
                return Json(" ");
            }
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
