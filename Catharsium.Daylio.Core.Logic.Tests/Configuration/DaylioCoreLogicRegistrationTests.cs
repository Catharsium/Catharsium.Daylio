using Catharsium.Daylio.Core.Interfaces.Logic;
using Catharsium.Daylio.Core.Logic.Import;
using Catharsium.Daylio.Core.Logic.Interfaces;
using Catharsium.Daylio.Ui.Console._Configuration;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Daylio.Ui.Console.Tests.Configuration
{
    [TestClass]
    public class DaylioCoreLogicRegistrationTests
    {
        [TestMethod]
        public void AddDaylioCoreLogic_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddDaylioCoreLogic(configuration);

            serviceCollection.ReceivedRegistration<IDaylioCsvParser, DaylioCsvParser>();
            serviceCollection.ReceivedRegistration<IDaylioCsvReader, DaylioCsvReader>();
        }


        [TestMethod]
        public void AddDaylioCoreLogic_RegistersPackages()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddDaylioCoreLogic(configuration);
        }
    }
}