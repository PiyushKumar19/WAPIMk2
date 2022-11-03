﻿using Microsoft.AspNetCore.Connections;

namespace WAPIByConsole
{
    public class Startup
    {
        // To add services to the project.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();

        }

        // Configure method is a very important method as it is responsible for adding middleware to the execution pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        //private void SomeMethod(IApplicationBuilder app)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Hello from Piyush Map method middleware. \n");
        //        await next();
        //    });
        //}
    }
}