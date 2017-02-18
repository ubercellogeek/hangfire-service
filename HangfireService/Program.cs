using Topshelf;
using System.Configuration;

namespace HangfireService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize and run the TopShelf service runner/configuration.
            HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(name => new Service());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.SetDescription(ConfigurationManager.AppSettings["ServiceDescription"]);
                x.SetDisplayName(ConfigurationManager.AppSettings["ServiceDisplayName"]);
                x.SetServiceName(ConfigurationManager.AppSettings["ServiceName"]);
                x.RunAsNetworkService();
                // Alternatively, you can run the service as a specific user. 
                // x.RunAs("user","password");                     
            });
        }
    }
}
