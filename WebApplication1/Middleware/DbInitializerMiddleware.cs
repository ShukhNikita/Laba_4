using Product.Context;

namespace WebApplication1.Middleware
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public Task Invoke(HttpContext context, IServiceProvider serviceProvider, ProductContext dbContext)
        {

            DbInitializer.Initialize(dbContext, 50, 50);

            return _next.Invoke(context);
        }
    }
}
