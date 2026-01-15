using CorporationNetworkWPF.Services;
using CorporationNetworkWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CorporateNetworkWPF
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            // Регистрируем сервисы
            services.AddSingleton<IApiService, ApiService>();
            // Регистрируем ViewModels
            services.AddSingleton<MainViewModel>();
            // Регистрируем окно (это важно!)
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Получаем окно из контейнера зависимостей (оно само возьмёт MainViewModel)
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            // 2. УСТАНАВЛИВАЕМ ЕГО КАК ГЛАВНОЕ ОКНО ПРИЛОЖЕНИЯ
            this.MainWindow = mainWindow;

            // 3. Показываем его
            mainWindow.Show();
        }
    }
}