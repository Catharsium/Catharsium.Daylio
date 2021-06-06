using Catharsium.Daylio.Core.Interfaces;
using Catharsium.Daylio.Core.Logic.Interfaces;
using Catharsium.Daylio.Core.Models;
using Catharsium.Util.Enums;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Daylio.Core.Logic.Import
{
    public class DaylioCsvParser : IDaylioCsvParser
    {
        private readonly ICsvReader csvReader;


        public DaylioCsvParser(ICsvReader csvReader)
        {
            this.csvReader = csvReader;
        }


        public List<DaylioEntry> ParseList(List<string> records)
        {
            var splitRecords = this.csvReader.Parse(records);
            var result = new List<DaylioEntry>();
            result.AddRange(splitRecords.Select(r => this.ParseRecord(r)));
            return result;
        }


        public DaylioEntry ParseRecord(List<string> record)
        {
            return record.Count != 8
                ? null
                : new DaylioEntry
                {
                    Date = this.ParseDate(record[0], record[3]),
                    Mood = record[4].ParseEnum<Mood>(),
                    Activities = record[5].Split('|').Select(a => a.Trim()).ToArray(),
                    NoteTitle = record[6],
                    Note = record[7]
                };
        }


        private DateTime ParseDate(string date, string time)
        {
            var dateTime = $"{date} {time}";
            return DateTime.Parse(dateTime);
        }
    }
}