namespace Ambebi
{
    public interface IAmbebi
    {
        List<Ambebi> GetAmbebi();
        Ambebi GetAmbebi(int id);
        Ambebi CreateAmbebi(DTOAmbebi ambebi0);
        Ambebi UpdateAmbebi(int id, Ambebi ambebi);
        bool DeleteAmbebi(int id);



    }
}
