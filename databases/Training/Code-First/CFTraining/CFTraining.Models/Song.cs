using System;

namespace CFTraining.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Duration in Seconds
        /// </summary>
        public int Duration { get; set; }
        
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
