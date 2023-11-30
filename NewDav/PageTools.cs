using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace NewDav
{

   

    public class PagedTools
    {
        public static List <DTOExternalPosts> GetPages(int pageIndex, int RecordsPerPage, List<DTOExternalPosts> AllList)
        {
        
            List <DTOExternalPosts> res = new List <DTOExternalPosts> ();

            res = AllList.Skip((pageIndex - 1) * RecordsPerPage).Take(RecordsPerPage).ToList() ;

            return res ;
        }

        public static List<T> GetPages<T>(int pageIndex, int RecordsPerPage, List<T> AllList) 
        {

            List<T> res = new List<T>();

            res = AllList.Skip((pageIndex - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();

            return res;
        }


        public static DTOPages<T> ConvertToPaged<T>(int page, int per_page, List<T> AllList)
        {

            DTOPages<T> res = new DTOPages<T>();
            res.page = page;
            res.per_page = per_page;
            res.total = AllList.Count;
            res.total_pages = (int)Math.Ceiling((double)res.total / per_page);
            res.Data = AllList.Skip((page - 1) * per_page).Take(per_page).ToList();

            return res;
        }




        



    }
}
