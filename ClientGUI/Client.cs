/// <summary> 
/// Author:    Tate Reynolds/Thatcher Geary
/// Partner:   each other
/// Date:      4/16/2022 
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Thatcher Geary - This work may not be copied for use in Academic Coursework. 
/// 
/// We, Thatcher Geary and Tate Reynolds, certify that I wrote this code from scratch and did not copy it in part or whole from  
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// Client.cs runs the Gui and makes fills the information for dependecy injection
/// </summary>

using FileLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

/// <summary>
/// namespace for ClientGUI and Client cs. 
/// </summary>
namespace ClientGUI
{
    /// <summary>
    /// Class for the Client to run and use loggers
    /// </summary>
    internal static class Client
    {

        /// <summary>
        /// ConfigureServieces makes the puts all the information needed for dependency injection
        /// </summary>
        /// <param name="services">
        /// services that we are going to add to 
        /// </param>
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddDebug();
                configure.SetMinimumLevel(LogLevel.Debug);
                configure.AddProvider(new CustomFileLogProvider());
                configure.AddEventLog();
                configure.SetMinimumLevel(LogLevel.Debug);
            });

            services.AddScoped<ClientGUI>();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var gui = serviceProvider.GetRequiredService<ClientGUI>();
            Application.Run(gui);
        }
    }
}