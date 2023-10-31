using Ambebi;
using NewDav.Controllers;

namespace NewDav
{
    public interface ICalc
    {
        DTOSumResponse Sum(DTOSumRequest requ);
        DTOMultiResponse Multi(DTOMultiRequest requ);
    }

    public class Calc : ICalc
    {

       
        public DTOMultiResponse Multi(DTOMultiRequest requ)
        {
            DTOMultiResponse res = new DTOMultiResponse();
            res.c = requ.a * requ.b;

            return res;
        }

        public DTOSumResponse Sum(DTOSumRequest requ)
        {
            DTOSumResponse res = new DTOSumResponse();
            res.c = requ.a + requ.b;

            return res;
        }
    }




}
