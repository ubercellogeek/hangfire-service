using Owin;
using Hangfire;


namespace HangfireService
{
    /// <summary>
    /// OWIN class used to bootstrap the Hangfire dashbaord.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireDashboard();
        }
    }
}
