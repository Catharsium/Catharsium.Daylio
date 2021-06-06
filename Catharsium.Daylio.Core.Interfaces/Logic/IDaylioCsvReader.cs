using Catharsium.Daylio.Core.Models;
using System.Collections.Generic;

namespace Catharsium.Daylio.Core.Interfaces.Logic
{
    public interface IDaylioCsvReader
    {
        List<DaylioEntry> Read();
    }
}