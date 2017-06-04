using System;

namespace CFTraining.Models
{
    public class Image
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }

        public string OriginalFileName { get; set; }

        public Guid? AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
