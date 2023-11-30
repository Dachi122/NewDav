using Ambebi;
using Microsoft.AspNetCore.Mvc;
using NewDav;
using Newtonsoft.Json;

namespace PageTools
{
    public class ExternalSV : IExternal
    {

        static readonly HttpClient client_JSONPlaceHolder = new HttpClient() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };

        public async Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalData()
        {
            try
            {
                using HttpResponseMessage response = await client_JSONPlaceHolder.GetAsync($"posts");
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
                throw (e);
            }

            
        }



        public async Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalDataId(int id)
        {
            try
            {
                using HttpResponseMessage response = await client_JSONPlaceHolder.GetAsync($"posts/{id}");
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
                throw(e);
            }

            

        }




    }
}
