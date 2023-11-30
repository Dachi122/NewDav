using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ambebi;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.Drawing.Printing;
using SQLitePCL;
using PageTools;

namespace NewDav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly IExternal _iexternal;
        static readonly HttpClient client_JSONPlaceHolder = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
        public ExternalController(IExternal iexternal)
        {

            _iexternal = iexternal;
        }


        [HttpGet]
        [Route("GetExternalData/{id}")]

        public async Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalDataId(int id)
        {
            return await _iexternal.GetExternalDataId();

        }


        [HttpGet]
        [Route("GetExternalDataFull")]

        public async Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalData()
        {
           return await _iexternal.GetExternalData();
        }






        [HttpGet]
        [Route("GetExternalData/{id}/comments")]

        public async Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalDataComment(int id)
        {
            try
            {
                using HttpResponseMessage response = await client_JSONPlaceHolder.GetAsync($"posts/{id}/comments");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
                List<DTOExternalPosts> externalPosts = JsonConvert.DeserializeObject<List<DTOExternalPosts>>(responseBody);
                return externalPosts;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return BadRequest();

        }





        [HttpGet]
        [Route("GetExternalDataPaged")]


        public async Task<ActionResult<DTOPages<DTOExternalPosts>>> GetExternalDataPaged([FromQuery] int page, [FromQuery] int per_page)
        {
            try
            {
                using HttpResponseMessage response = await client_JSONPlaceHolder.GetAsync($"posts");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
                List<DTOExternalPosts> externalPosts0 = JsonConvert.DeserializeObject<List<DTOExternalPosts>>(responseBody);
                List<DTOExternalPosts> externalPosts = externalPosts0.OrderBy(a => a.Id ).ToList();

                //List<DTOExternalPosts> Data = new List<DTOExternalPosts>();
                //Data = PagedTools.GetPages(page, per_page, externalPosts);

                var res = PagedTools.ConvertToPaged(page, per_page, externalPosts);


                //DTOPages<DTOExternalPosts> res = new DTOPages<DTOExternalPosts>();
                //res.page = page;
                //res.per_page = per_page;
                //res.total = externalPosts.Count;
                //res.total_pages = (int)Math.Ceiling((double)res.total / per_page);
                //res.Data = Data;

                return res;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return BadRequest();

        }



    }
}