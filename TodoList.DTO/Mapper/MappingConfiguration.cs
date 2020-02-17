using AutoMapper;
using TodoList.DTO.Mapper.Profiles;

namespace TodoList.DTO.Mapper
{
    /// <summary>
    /// Automapper configuration helper
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TodoProfile>();
            });

            return config;
        }
    }
}
