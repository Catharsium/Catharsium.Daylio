using Catharsium.Daylio.Core.Models;
using System.Collections.Generic;

namespace Catharsium.Daylio.Core.Logic.Interfaces
{
    public interface IDaylioCsvParser
    {
        List<DaylioEntry> ParseList(List<string> records);
        DaylioEntry ParseRecord(List<string> record);
    }
}