using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshoSoft.ForumSystem.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}