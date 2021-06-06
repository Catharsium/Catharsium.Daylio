using Catharsium.Daylio.Core.Models;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Daylio.Ui.Console.ActionHandlers
{
    public class RepositoryStatusActionHandler : IActionHandler
    {
        private readonly IJsonFileRepository<DaylioEntry> jsonFileRepository;
        private readonly IConsole console;

        public string FriendlyName => "Repository Status";


        public RepositoryStatusActionHandler(IJsonFileRepository<DaylioEntry> jsonFileRepository, IConsole console)
        {
            this.jsonFileRepository = jsonFileRepository;
            this.console = console;
        }


        public async Task Run()
        {
            var entries = await this.jsonFileRepository.LoadAll();
            this.console.WriteLine($"{entries.Count()} entries");
        }
    }
}