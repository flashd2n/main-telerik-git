using GoshoSoft.ForumSystem.Models;
using GoshoSoft.ForumSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace GoshoSoft.ForumSystem.Web.Models.Home
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.AuthorEmail, cfg => cfg.MapFrom(y => y.Author.Email))
                .ForMember(x => x.PostedOn, cfg => cfg.MapFrom(y => y.CreatedOn));
        }
    }
}