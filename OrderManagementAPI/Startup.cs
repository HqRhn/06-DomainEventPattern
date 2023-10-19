using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagement.Repository.Persistence.DBContext;
using OrderManagement.Repository.Persistence.Repositories;
using OrderManagementAPI.Middleware;
using OrderManagement.Application.EventHandler;
using IConnectionFactory = OrderManagement.Repository.Persistence.DBContext.IConnectionFactory;
using OrderManagement.Domain.DomainEvents;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Common;

namespace OrderManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var applicationAssembly = typeof(OrderManagement.Application.AssemblyReference).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture-CQRS", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton<IConnectionFactory>(new ConnectionFactory(connectionString));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddTransient<IEmailService,EmailService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
