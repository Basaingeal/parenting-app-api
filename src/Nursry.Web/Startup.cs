using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Infrastructure.Data;
using Nursry.Infrastructure.Data.Repositories;
using Nursry.Web.Authorization.Requirements;
using Nursry.Web.GraphQL;
using Nursry.Web.GraphQL.Types;

namespace Nursry.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}";

            string conString = Configuration.GetConnectionString("NursryDatabase");
            services.AddDbContext<NursryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NursryDatabase")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:activity", policy => policy.Requirements.Add(new HasScopeRequirement("read:activity", domain)));
                options.AddPolicy("write:activity", policy => policy.Requirements.Add(new HasScopeRequirement("write:activity", domain)));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            ConfigureRepos(services);

            ConfigureGraphQL(services);
        }

        private static void ConfigureGraphQL(IServiceCollection services)
        {
            //services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<NursryQuery>();
            services.AddSingleton<NursryMutation>();
            services.AddSingleton<LogInterface>();
            services.AddSingleton<BottleFeedingLogType>();
            services.AddSingleton<BreastFeedingLogType>();
            services.AddSingleton<DiaperLogType>();
            services.AddSingleton<ChildType>();

            services.AddSingleton<BottleContentEnum>();
            services.AddSingleton<DiaperTypeEnumType>();
            services.AddSingleton<FeedingTypeEnum>();
            services.AddSingleton<BreastEnum>();
            services.AddSingleton<GenderEnum>();

            services.AddSingleton<GuidGraphType>();
            services.AddSingleton<TimeSpanSecondsGraphType>();
            //services.AddSingleton<EnumerationGraphType<Gender>>();
            services.AddSingleton<EnumerationGraphType>();

            services.AddSingleton<ChildInputType>();

            var sp = services.BuildServiceProvider();

            services.AddSingleton<ISchema>(new NursrySchema(new FuncDependencyResolver(sp.GetService)));
            //services.AddSingleton<ISchema>(s => new NursrySchema(new FuncDependencyResolver(type => (IGraphType)s.GetRequiredService(type))));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            });
        }

        private static void ConfigureRepos(IServiceCollection services)
        {
            services.AddTransient<IChildRepository, ChildRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, NursryContext nursryContext)
        {
            nursryContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();

            // add http for Schema at default url /graphql
            //app.UseGraphQL<ISchema>("/graphql");

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
        }
    }
}
