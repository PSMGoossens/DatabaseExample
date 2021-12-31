using DatabaseExample.Database;
using DatabaseExample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = ConfigureServiceProvider();
            var viewModel = serviceCollection.GetService<StudentViewModel>();
            var window = new MainWindow() { DataContext= viewModel };
            window.Show();
        }

        //public override
        private static IServiceProvider ConfigureServiceProvider()
        {
            // __TODO__ [PSMG] Change FormatLogger to AddConsoleFormatter 
            return new ServiceCollection()
                .AddLogging(opt =>
                {
                    // TODO migrate to AddConsoleFormatter
                    opt.AddConsole(c => c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ");
                })
                .AddDbContext<StudentContext>()
                .AddSingleton<StudentViewModel>()
                .BuildServiceProvider();
        }
    }
}
