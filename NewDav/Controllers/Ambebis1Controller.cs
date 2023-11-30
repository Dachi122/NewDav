using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDav;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace Ambebi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AmbebisNaxvaController : ControllerBase
    {
        //private readonly dbaContext _context;
        private readonly IAmbebi _iambebi;
        static readonly HttpClient client_JSONPlaceHolder = new HttpClient() {BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };

        public AmbebisNaxvaController(IAmbebi iambebi)
        {
            //_context = context;
            _iambebi = iambebi;
        }


        /// <summary>
        /// ამბების სია
        /// </summary>
        /// <returns></returns>

        // GET: api/Ambebis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebi()
        {


            return _iambebi.GetAmbebi();

        }
        
        
        
        [HttpGet]
        [Route ("ambebi-paged")]
        public async Task<ActionResult<DTOPages<Ambebi>>> GetAmbebiPaged([FromQuery] int page, [FromQuery] int per_page)
        {

            var data0 = _iambebi.GetAmbebi();
            List <Ambebi> data = data0.OrderBy(a => a.AmbebiId).ToList();


            var res = PagedTools.ConvertToPaged<Ambebi>(page, per_page, data);

            return res;
                        

        }


        /// <summary>
        /// ამბების სია მარტო თარიღი
        /// </summary>
        /// <returns></returns>

        // GET: api/Ambebis
        [HttpGet]
        [Route("filter3")]
        public async Task<ActionResult<IEnumerable<DTOAmbebiDateOnly>>> GetAmbebiDateOnly()
        {


            return _iambebi.GetAmbebiDateOnly();

        }


        /// <summary>
        /// თარიღის მიხედვით
        /// </summary>
        /// <returns></returns>
        // GET: api/Ambebis
        [HttpGet]
        [Route("filter/{DateTimeFrom}/{DateTimeTo}")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebi([FromRoute]  DTODateTimeInterval requ)
        {


            return _iambebi.GetAmbebi(requ);

        }




        [HttpGet]
        [Route("filterTitle/{Search}")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebiFilterTitle([FromRoute] DTOSearch requ)
        {


            return _iambebi.GetAmbebiFilterTitle(requ);

        }

        [HttpGet]
        [Route("filterContent/{Search}")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebiFilterContent([FromRoute] DTOSearch requ)
        {


            return _iambebi.GetAmbebiFilterContent(requ);

        }


        [HttpGet]
        [Route("filterBoth/{Search}")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebiFilterBoth([FromRoute] DTOSearch requ)
        {


            return _iambebi.GetAmbebiFilterBoth(requ);

        }



        [HttpPost]
        [Route("filterSplit")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebiFilterFour([FromForm] DTOSearch requ)
        {


            return _iambebi.GetAmbebiFilterFour(requ);

        }



        [HttpPost]
        [Route("Split")]
        public async Task<ActionResult<IEnumerable<string>>> Split([FromForm]string words)
        {

            var res = _iambebi.Splitter(words);

            

            return res;
        }








        [HttpPost]
        [Route("filter2")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebi2([FromBody] DTODateTimeInterval requ)
        {


            return _iambebi.GetAmbebi(requ);

        }


        [HttpPost]
        [Route("filter4")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebi3([FromQuery] DTODateTo requTo, [FromQuery] DTODateFrom requFrom)
        {


            return _iambebi.GetAmbebi(requTo , requFrom);

        }





        /// <summary>
        /// ერთი ამბის ნახვა
        /// </summary>
        /// <param name="id">ზრაპრის ნომერი</param>
        /// <returns></returns>

        // GET: api/Ambebis/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Ambebi>> GetAmbebi(int id)
        {

            return _iambebi.GetAmbebi(id);
        }







        


    }
}
