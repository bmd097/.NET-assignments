using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.contexts;
using WebApi.Models;
using WebApi.Utils;

namespace WebApi.Controllers
{
    public class FlightController : ApiController {
        FlightContext context = new FlightContext();

        // GET api/values
        public IEnumerable<Flight> Get() {
            return context.flights.ToList();
        }

        // GET api/values/5
        public Dictionary<string,object> Get(int id) {
            var enumerator = this.Request.Headers.GetEnumerator();
            bool jsonContentNegotiation = false;
            while (enumerator.MoveNext()) 
                if(enumerator.Current.Key == "Accept") {
                    if(enumerator.Current.Value.Contains("application/json")) 
                        jsonContentNegotiation = true;
                    break;
                }
            var flight = context.flights.Find(id);
            if (flight != null) 
                return CommonUtils.ReturnSuccess(new Dictionary<object,object> {
                    { "flight",flight },
                    { "json",jsonContentNegotiation }
                });
            else return CommonUtils.FailedResponse("Not Found!", HttpStatusCode.NotFound);
        }

        // POST api/values
        public Dictionary<string,object> Post([FromBody] Flight flight) {
            if (ModelState.IsValid) {
                context.flights.Add(flight);
                context.SaveChanges();
                return CommonUtils.ReturnSuccess(flight.ToString());
            } else return CommonUtils.FailedResponse("Please, provide valid data!",HttpStatusCode.BadRequest);
        }

        // PUT api/values/5
        public Dictionary<string, object> Put(int id, [FromBody] Flight flight) {
            if (ModelState.IsValid) {
                var existingFlight = context.flights.Find(id);
                if (existingFlight != null) {
                    existingFlight.name = flight.name;
                    existingFlight.description = flight.description;
                    existingFlight.startTime = flight.startTime;
                    existingFlight.duration = flight.duration;
                    existingFlight.createdAt = flight.createdAt;
                    existingFlight.type = flight.type;
                    context.SaveChanges();
                    return CommonUtils.ReturnSuccess(existingFlight.ToString());
                } else return CommonUtils.FailedResponse("No Such Flight!",HttpStatusCode.NotFound);
            } else return CommonUtils.FailedResponse("Please, provide valid data!", HttpStatusCode.BadRequest);
        }

        // DELETE api/values/5
        public Dictionary<string,object> Delete(int id) {
            var flight = context.flights.Find(id);
            if (flight != null) {
                context.flights.Remove(flight);
                context.SaveChanges();
                return CommonUtils.ReturnSuccess("Successfully Deleted!");
            } else return CommonUtils.FailedResponse("No flight to delete!",HttpStatusCode.NotFound);
        }
    }

}