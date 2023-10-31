using Microsoft.AspNetCore.Mvc;
using NewDav;

namespace Ambebi
{
    public interface IAmbebi
    {
        List<Ambebi> GetAmbebi();
        List<Ambebi> GetAmbebi(DTODateTimeInterval requInterval);
        Ambebi GetAmbebi(int id);
        Ambebi CreateAmbebi(DTOAmbebi ambebi0);
        Ambebi UpdateAmbebi(int id, DTOAmbebiUpdate ambebi);
        bool DeleteAmbebi(int id);
        
    }
}
