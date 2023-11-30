using Microsoft.AspNetCore.Mvc;
using NewDav;

namespace PageTools
{
   
        public interface IExternal
    {
        Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalData();
        Task<ActionResult<IEnumerable<DTOExternalPosts>>> GetExternalDataId(int id);

    }
    
}
