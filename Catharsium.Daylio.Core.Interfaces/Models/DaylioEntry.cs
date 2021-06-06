using Catharsium.Daylio.Core.Interfaces;
using System;

namespace Catharsium.Daylio.Core.Models
{
    public class DaylioEntry
    {
        public DateTime Date { get; set; }
        public Mood Mood { get; set; }
        public string[] Activities { get; set; }
        public string NoteTitle { get; set; }
        public string Note { get; set; }
    }
}