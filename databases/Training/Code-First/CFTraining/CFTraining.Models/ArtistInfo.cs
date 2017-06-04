using System.ComponentModel.DataAnnotations.Schema;

namespace CFTraining.Models
{
    [ComplexType]
    public class ArtistInfo
    {
        [Column("Biography")]
        public string Biography { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Age")]
        public int Age { get; set; }
    }
}
