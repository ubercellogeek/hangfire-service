using System;
using Hangfire;
using Microsoft.Owin.Hosting;
using System.Configuration;

namespace HangfireService
{
    public class Service
    {
        private BackgroundJobServer _server;

        /// <summary>
        /// Initializes and starts the hangfire server.
        /// </summary>
        public void Start()
        {
            // Set the configuration for hangfire's SQL database to use.
            GlobalConfiguration.Configuration.UseSqlServerStorage("hangfire");

            // Setup the OWIN host endpoint url(s) for the Hangfire UI.
            StartOptions options = new StartOptions();
            options.Urls.Add($"http://127.0.0.1:{ConfigurationManager.AppSettings["ListenPort"]}");
            options.Urls.Add($"http://{Environment.MachineName}:{ConfigurationManager.AppSettings["ListenPort"]}");
            WebApp.Start<Startup>(options);

            // Start the Hangfire job server.
            _server = new BackgroundJobServer();
        }

        /// <summary>
        /// Stops and disposes of the hangfire server instance.
        /// </summary>
        public void Stop()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }
    }
}
