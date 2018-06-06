using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeePayslip.Startup))]
namespace EmployeePayslip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
