using Ambebi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace NewDav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {

        private readonly ICalc _icalc;

        private readonly IConfiguration Configuration;

        

        public CalcController(ICalc icalc, IConfiguration configuration)
        {
            _icalc = icalc;
            Configuration = configuration;
           
        }




        /// <summary>
        /// ორი მთელი რიცხვის შეკრება
        /// </summary>
        /// <param name="requ"></param>
        /// <returns></returns>

        [HttpPost]
        [Route ("Sum")]
        public async Task<ActionResult<DTOSumResponse>> Sum([FromBody]  DTOSumRequest requ)
        {
            //int c = requ.a + requ.b;
            //DTOSumResponse result = new DTOSumResponse();
            //result.c = c;

            //return Ok(result);

            var res = _icalc.Sum (requ);

            return Ok(res);

        }
        

        /// <summary>
        /// ორი მთელი რიცხვის გამრავლება
        /// </summary>
        /// <param name="requ"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route ("Multi")]
        public async Task<ActionResult<DTOMultiResponse>> Multiply([FromBody]  DTOMultiRequest requ)
        {
            //int c = requ.a * requ.b;
            //DTOMultiResponse result = new DTOMultiResponse();
            //result.c = c;

            //return Ok(result);

            var res = _icalc.Multi (requ);

            return Ok(res);
                      
        }


        [HttpGet]
        [Route("get-settings")]
        public string GetSettingsData()
        {
            var res = Configuration["MySettings"];
            var resTitle = Configuration["Settings2:Title"];
            var resBody = Configuration["Settings2:Body"];
            var resAge = Configuration["Settings2:Age"];

            return res +" "+ resTitle +" "+ resBody +" "+ resAge;
        }


        [HttpGet]
        [Route("Settings2Options")]

        public string GetSettings2()
        {
            var settings2Options = new Settings2Options();
            Configuration.GetSection("Settings2").Bind(settings2Options);

            string res = settings2Options.Title + " " + settings2Options.Body +" "+ settings2Options.Age;
            
            return res;
        }



    }
}
