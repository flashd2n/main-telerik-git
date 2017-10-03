using AutoMapper.QueryableExtensions;
using GoshoSoft.ForumSystem.Web.App_Start;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GoshoSoft.ForumSystem.Web.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> MapTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}