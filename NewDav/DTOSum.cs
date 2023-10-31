namespace NewDav
{

    public abstract class IntCouple
    {
        public float a { get; set; }
        public float b { get; set; }


    }

    public abstract class IntAnswer
    {
        public float c { get; set; }
    }



    public class DTOSumRequest : IntCouple
    {      
    }


    public class DTOSumResponse : IntAnswer
    {            
    }


}
