using AutoMapper;

namespace GoshoSoft.ForumSystem.Web.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
