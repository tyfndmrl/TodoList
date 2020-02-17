using AutoMapper;
using System.Linq;

namespace TodoList.UI.Extensions
{
    public static class AutoMapperExtensions
    {
        private static IMapper _instance;
        public static void Init(IMapper mapper) => _instance = mapper;

        public static TDestinationType Map<TDestinationType>(this object source) => _instance.Map<TDestinationType>(source);
        public static TDestinationType Map<TDestinationType>(this object source, TDestinationType destination) => _instance.Map(source, destination);
        public static IQueryable<TDestinationType> ProjectTo<TDestinationType>(this IQueryable source) => _instance.ProjectTo<TDestinationType>(source);
    }
}