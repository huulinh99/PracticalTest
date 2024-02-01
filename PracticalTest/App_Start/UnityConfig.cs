using Microsoft.Extensions.Options;
using PracticalTest.Interfaces;
using PracticalTest.Repositories;
using PracticalTest.Services;
using PracticalTest.Utils;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace PracticalTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType(typeof(IRepository<>), typeof(BaseRepository<>));
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<PaginationOptions>(new InjectionFactory(c => new PaginationOptions
            {
                DefaultPageNumber = 1,
                DefaultPageSize = 10
            }));
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();
            container.RegisterType<ISubjectService, SubjectService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}