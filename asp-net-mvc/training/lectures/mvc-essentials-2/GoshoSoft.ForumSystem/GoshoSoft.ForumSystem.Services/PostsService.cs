using GoshoSoft.ForumSystem.Data.Repository;
using GoshoSoft.ForumSystem.Data.SaveContext;
using GoshoSoft.ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoshoSoft.ForumSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepostory<Post> postsRepostory;
        private readonly ISaveContext saveContext;

        public PostsService(IEfRepostory<Post> postsRepo, ISaveContext saveContext)
        {
            this.postsRepostory = postsRepo;
            this.saveContext = saveContext;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepostory.All;
        }

        public void Update(Post post)
        {
            this.postsRepostory.Update(post);
            this.saveContext.Commit();
        }
    }
}
