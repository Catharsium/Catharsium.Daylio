using Catharsium.Daylio.Core.Models;
using Catharsium.Daylio.Ui.Console.ActionHandlers;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Daylio.Ui.Console._Configuration
{
    public static class DaylioConsoleUiRegistration
    {
        public static IServiceCollection AddDaylioConsoleUi(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<DaylioConsoleUiConfiguration>();
            services.AddSingleton<DaylioConsoleUiConfiguration, DaylioConsoleUiConfiguration>(provider => configuration);

            services.AddIoUtilities(config);
            services.AddConsoleIoUtilities(config);
            services.AddDaylioCoreLogic(config);

            services.AddScoped<IJsonFileRepository<DaylioEntry>>(s =>
            {
                return new JsonFileRepository<DaylioEntry>(
                    s.GetService<IFileFactory>(),
                    s.GetService<IJsonFileReader>(),
                    s.GetService<IJsonFileWriter>(),
                    configuration.SerializationFolder);
            });

            services.AddSingleton<IActionHandler, ImportActionHandler>();
            services.AddSingleton<IActionHandler, RepositoryStatusActionHandler>();

            return services;
        }
    }
}