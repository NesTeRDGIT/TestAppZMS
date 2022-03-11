using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

using TestAppZMS.Entity;
using TestAppZMS.Class;
using System.Threading;
namespace TestAppZMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("RU-ru");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("RU-ru");
        }

        private void ConfigureServices(IServiceCollection services)
        {
          

            services.AddSingleton<MainWindow>();
            services.AddTransient<MSSQLContext>();
            services.AddTransient<IXSDChecker>(pr=>new XSDChecker("PR.XSD"));
            services.AddTransient<IConStrChecker>(pr => new MssqlConStrChecker());
           
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }


}
