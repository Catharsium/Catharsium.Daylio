using Catharsium.Daylio.Core.Interfaces.Logic;
using Catharsium.Daylio.Core.Logic.Interfaces;
using Catharsium.Daylio.Core.Models;
using Catharsium.Daylio.Ui.Console._Configuration;
using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;

namespace Catharsium.Daylio.Core.Logic.Import
{
    public class DaylioCsvReader : IDaylioCsvReader
    {
        private readonly IFileFactory fileFactory;
        private readonly IDaylioCsvParser csvParser;
        private readonly DaylioCoreLogicConfiguration configuration;


        public DaylioCsvReader(IFileFactory fileFactory, IDaylioCsvParser csvParser, DaylioCoreLogicConfiguration configuration)
        {
            this.fileFactory = fileFactory;
            this.csvParser = csvParser;
            this.configuration = configuration;
        }


        public List<DaylioEntry> Read()
        {
            var file = this.fileFactory.CreateFile(this.configuration.DaylioExportFileLocation);

            var records = new List<string>();

            using (var reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                {
                    records.Add(reader.ReadLine());
                }
            }

            return this.csvParser.ParseList(records);
        }
    }
}