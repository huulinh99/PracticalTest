using Microsoft.Extensions.DependencyInjection;
using PracticalTest.Interfaces;
using PracticalTest.Repositories;
using PracticalTest.Services;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace PracticalTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Đăng ký các dịch vụ ở đây
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}