namespace NewDav
{
    public class DTOExternalPosts
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }

    public class DTOPageInfo
    {

        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<DTOExternalPosts> Data { get; set; }
    }


    public class DTOPages<T>
    {

        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<T> Data { get; set; }
    }



}
