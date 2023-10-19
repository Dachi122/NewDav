﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Ambebi
{


    public class DTOAmbebi
    {

        public string Title { get; set; }

        public string Content { get; set; }

    }

    public class DTOAmbebiUpdate
    {

        public int AmbebiId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


    }
        

}
