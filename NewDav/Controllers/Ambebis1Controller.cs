using Microsoft.AspNetCore.Mvc;
using NewDav;

namespace Ambebi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AmbebisNaxvaController : ControllerBase
    {
        //private readonly dbaContext _context;
        private readonly IAmbebi _iambebi;

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





        [HttpPost]
        [Route("filter2")]
        public async Task<ActionResult<IEnumerable<Ambebi>>> GetAmbebi2([FromBody] DTODateTimeInterval requ)
        {


            return _iambebi.GetAmbebi(requ);

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
