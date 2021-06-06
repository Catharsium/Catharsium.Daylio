using Catharsium.Daylio.Core.Interfaces.Logic;
using Catharsium.Daylio.Core.Logic.Import;
using Catharsium.Daylio.Core.Logic.Interfaces;
using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Daylio.Ui.Console._Configuration
{
    public static class DaylioCoreLogicRegistration
    {
        public static IServiceCollection AddDaylioCoreLogic(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<DaylioCoreLogicConfiguration>();
            services.AddSingleton<DaylioCoreLogicConfiguration, DaylioCoreLogicConfiguration>(provider => configuration);

            services.AddIoUtilities(config);

            services.AddSingleton<IDaylioCsvParser, DaylioCsvParser>();
            services.AddSingleton<IDaylioCsvReader, DaylioCsvReader>();

            return services;
        }
    }
}