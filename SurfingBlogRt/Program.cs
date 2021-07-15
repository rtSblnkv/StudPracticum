using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SurfingBlogRt.DAL;


namespace SurfingBlogRt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new DataContext();
            DBInitializer.Initialize(context);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
