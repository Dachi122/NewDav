using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambebi
{
    public class dbaContext : DbContext
    {
        public DbSet<Ambebi> Ambebis { get; set; }


        public dbaContext(DbContextOptions<dbaContext> options)
            : base(options)
        {
        }

    }



    public class Ambebi
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AmbebiId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Content { get; set; }
        [Column(TypeName = "DateTime" )]
        public DateTime? CreatedDateTime { get; set; }


    }


}
