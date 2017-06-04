using System;
using System.Collections.Generic;

namespace CFTraining.Models
{
    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;
        private ICollection<Image> images;

        public Album()
        {
            this.Id = Guid.NewGuid();
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
            this.images = new HashSet<Image>();
        }

        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public decimal? Price { get; set; }

        public DateTime? ReleasedOn { get; set; }
        
        public AlbumStatus Status { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}
