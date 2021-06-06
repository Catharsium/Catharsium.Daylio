using Catharsium.Daylio.Ui.Console._Configuration;
using Catharsium.Daylio.Ui.Console.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Daylio.Ui.Console.Tests.Configuration
{
    [TestClass]
    public class DaylioConsoleUiRegistrationTests
    {
        [TestMethod]
        public void AddDaylioConsoleUi_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddDaylioConsoleUi(configuration);
            serviceCollection.ReceivedRegistration<IActionHandler, ImportActionHandler>();
            serviceCollection.ReceivedRegistration<IActionHandler, RepositoryStatusActionHandler>();
        }


        [TestMethod]
        public void AddDaylioConsoleUi_RegistersPackages()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var configuration = Substitute.For<IConfiguration>();

            serviceCollection.AddDaylioConsoleUi(configuration);
            serviceCollection.ReceivedRegistration<IConsole>();
        }
    }
}