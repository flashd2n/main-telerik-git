using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CFTraining.Models
{
    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.Members = 1;
            this.albums = new HashSet<Album>();
            this.MoreInfo = new ArtistInfo();
        }
        
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ArtistInfo MoreInfo { get; set; }

        public GenderType Gender { get; set; }

        public int Members { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
