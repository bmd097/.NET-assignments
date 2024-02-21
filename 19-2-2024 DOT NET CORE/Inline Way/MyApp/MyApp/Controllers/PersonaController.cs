using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Utils;

namespace MyApp.Controllers {
    [Route("Persona")]
    [ApiController]
    public class PersonaController : ControllerBase {

        public FishCatcherUtil fishCatcherUtil;
        public PersonaController(FishCatcherUtil fishCatcherUtil) { // Dependency Injection
            this.fishCatcherUtil = fishCatcherUtil;
        }

        [Route("me")]
        [HttpGet]
        public Person Get() {
            fishCatcherUtil.CatchAFish();
            return new Person {
                Name = "Mohan",
                Age = 10,
                createdAt = DateTime.Now,
                Id = 7
            };
        }

        [Route("addMe")]
        [HttpPost]
        public object AddMe([FromBody]Person person) {
            return new {
                success = true
            };
        }

       
    }
}
