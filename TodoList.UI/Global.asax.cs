using Autofac;
using Autofac.Integration.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using TodoList.BLL.Repositories;
using TodoList.BLL.Repositories.Interfaces;
using TodoList.BLL.UnitOfWork;
using TodoList.BLL.UnitOfWork.Interfaces;
using TodoList.DAL.Contexts;
using TodoList.DTO.Mapper;
using TodoList.UI.Extensions;

namespace TodoList.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            #region Autofac IOC Container
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TodoRepository>().As<ITodoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TodoContext>().As<DbContext>().InstancePerLifetimeScope();

            //Registers the AutoMapper profile
            //builder.Register(x=> AutoMapperConfiguration.InitializeAutoMapper().CreateMapper()).As<IMapper>();//.InstancePerLifetimeScope()
            //Register MapperConfiguration
            //builder.Register(ctx => AutoMapperConfiguration.InitializeAutoMapper());
            //builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperExtensions.Init(AutoMapperConfiguration.InitializeAutoMapper().CreateMapper());

            //GlobalFilters.Filters.Add(new ValidateModelStateAttribute());
        }
    }
}
