using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Muggle.TeklaPlugins.MainWindow.Services;
using Muggle.TeklaPlugins.MainWindow.ViewModels;

namespace Muggle.TeklaPlugins.MainWindow {
    public partial class App : Application {

        public App() {
            Services = ConfigureServices();
        }

        public static new App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices() {
            var services = new ServiceCollection();

            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<NavigationService>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<Views.MainWindow>();

            services.AddTransient<NormalToolsViewModel>();
            services.AddTransient<Views.NormalTools>();

            services.AddTransient<SelectBooleansViewModel>();
            services.AddTransient<Views.SelectBooleans>();

            services.AddTransient<ThreeDimensionalRotationViewModel>();
            services.AddTransient<Views.ThreeDimensionalRotation>();

            services.AddTransient<PluginsViewModel>();
            services.AddTransient<Views.Plugins>();

            return services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e) {
            var mainWindow = Services.GetRequiredService<Views.MainWindow>();
            mainWindow.Show();
        }
    }
}
