namespace WAPIByConsole
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from Custom Middleware 1. \n");
            await next(context);
            await context.Response.WriteAsync("Hello from Custom Middleware 1. \n");
        }
    }
}
