using Catharsium.Daylio.Core.Interfaces.Logic;
using Catharsium.Daylio.Core.Models;
using Catharsium.Daylio.Ui.Console._Configuration;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Daylio.Ui.Console.ActionHandlers
{
    public class ImportActionHandler : IActionHandler
    {
        private readonly IDaylioCsvReader daylioCsvReader;
        private readonly IJsonFileRepository<DaylioEntry> jsonFileRepository;
        private readonly IConsole console;
        private readonly DaylioConsoleUiConfiguration configuration;

        public string FriendlyName => "Import";


        public ImportActionHandler(IDaylioCsvReader daylioCsvReader, IJsonFileRepository<DaylioEntry> jsonFileRepository, IConsole console, DaylioConsoleUiConfiguration configuration)
        {
            this.daylioCsvReader = daylioCsvReader;
            this.jsonFileRepository = jsonFileRepository;
            this.console = console;
            this.configuration = configuration;
        }

        public async Task Run()
        {
            var entries = this.daylioCsvReader.Read();
            this.console.WriteLine($"Imported {entries.Count()} entries from export file.");
            await this.jsonFileRepository.Store(entries, "daylio");
        }
    }
}