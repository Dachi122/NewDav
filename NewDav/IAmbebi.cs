namespace Ambebi
{
    public interface IAmbebi
    {
        List<Ambebi> GetAmbebi();
        List<Ambebi> GetAmbebi(DateTime currentDay);
        Ambebi GetAmbebi(int id);
        Ambebi CreateAmbebi(DTOAmbebi ambebi0);
        Ambebi UpdateAmbebi(int id, DTOAmbebiUpdate ambebi);
        bool DeleteAmbebi(int id);



    }
}
