using GoshoSoft.ForumSystem.Models.Abstracts;

namespace GoshoSoft.ForumSystem.Models
{
    public class Post : DataModel
    {
        public Post() : base()
        {
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }
    }
}
