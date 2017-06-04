using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book
    {
        private ICollection<Genre> genres;

        public Book()
        {
            this.genres = new HashSet<Genre>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual ICollection<Genre> Genres
        {
            get { return this.genres; }
            set { this.genres = value; }
        }

        [Required]
        public virtual Author Author { get; set; }

        [Required]
        public virtual Library Library { get; set; }
    }
}
