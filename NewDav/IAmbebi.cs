using Microsoft.AspNetCore.Mvc;
using NewDav;

namespace Ambebi
{
    public interface IAmbebi
    {
        List<Ambebi> GetAmbebi();
        List<Ambebi> GetAmbebi(DTODateTimeInterval requInterval);
        List<Ambebi> GetAmbebi(DTODateTo requTo, DTODateFrom requFrom);
        List<Ambebi> GetAmbebiFilterTitle(DTOSearch requ);
        List<Ambebi> GetAmbebiFilterContent(DTOSearch requ);
        List<Ambebi> GetAmbebiFilterBoth(DTOSearch requ);
        List<Ambebi> GetAmbebiFilterFour(DTOSearch requ);
        List<DTOAmbebiDateOnly> GetAmbebiDateOnly();
        Ambebi GetAmbebi(int id);
        Ambebi CreateAmbebi(DTOAmbebi ambebi0);
        Ambebi CreateAmbebi30(DTOAmbebi ambebi0);
        Ambebi UpdateAmbebi(int id, DTOAmbebiUpdate ambebi);
        bool DeleteAmbebi(int id);
        string[] Splitter(string search);
    }
}
