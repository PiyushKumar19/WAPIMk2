using Microsoft.AspNetCore.Connections;

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
            // Use method is used to add the middleware delegate to the pipeline. It has two parameters, first one is for showing the message or the code and second one is next that is a method that is for making the execution to go to the next middleware.
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-1 1. \n");
                await next();
                await context.Response.WriteAsync("Hello from Use-1 2. \n");
            });
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use-2 1. \n");
            //    await next();
            //    await context.Response.WriteAsync("Hello from Use-2 2. \n");
            //});

            app.UseMiddleware<CustomMiddleware1>();

            //Run method is an middleware that completes the execution of web app, hence any method will not run after once it runs as other middlewares will not run.
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from run.");
            //});
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from run. \n");
            //});

            // Map method is used to map a particular url request to a particular method. Here if the url is ending with Piyush just after the localhost port name, then it will run.
            // SomeMethod is a method, any method can be used here.
            app.Map("/Piyush", SomeMethod);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            // UseEndpoints middleware is used to add different endpoints to the route table.
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello From new web api app.");
                //});
                //// MultiplexedConnectionBuilder Endpoints can be added by simply changing the url in MaoGet().
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello From new web api app test.");
                //});

                endpoints.MapControllers();
            });
        }

        private void SomeMethod(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Piyush Map method middleware. \n");
                await next();
            });
        }
    }
}