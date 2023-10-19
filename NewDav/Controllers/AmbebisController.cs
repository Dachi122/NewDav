using Microsoft.AspNetCore.Mvc;

namespace Ambebi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AmbebisController : ControllerBase
    {
        //private readonly dbaContext _context;
        private readonly IAmbebi _iambebi;

        public AmbebisController(IAmbebi iambebi)
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


        /// <summary>
        /// ამბის შეცვლა
        /// </summary>
        /// <param name="id">ზრაპრის ნომერი</param>
        /// <param name="ambebi">თვითონ ტექსტი</param>
        /// <returns></returns>

        // PUT: api/Ambebis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbebi(int id, Ambebi ambebi)
        {

            return Ok(_iambebi.UpdateAmbebi(id, ambebi));
        }




        /// <summary>
        /// დამატება
        /// </summary>
        /// <param name="ambebi0"></param>
        /// <returns></returns>
        // POST: api/Ambebis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ambebi>> PostAmbebi(DTOAmbebi ambebi0)
        {

            return _iambebi.CreateAmbebi(ambebi0);
        }




        /// <summary>
        /// წაშლა
        /// </summary>
        /// <param name="id">ტესტ</param>
        /// <returns></returns>
        // DELETE: api/Ambebis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbebi(int id)
        {

            return Ok(_iambebi.DeleteAmbebi(id));
        }


    }
}
