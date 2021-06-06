using Catharsium.Daylio.Core.Interfaces;
using Catharsium.Daylio.Core.Logic.Import;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Daylio.Core.Logic.Tests.Import
{
    [TestClass]
    public class DaylioCsvParserTests : TestFixture<DaylioCsvParser>
    {
        #region ParseList

        [TestMethod]
        public void ParseList_()
        {

        }

        #endregion

        #region ParseRecord

        [TestMethod]
        public void ParseRecord_ValidRecord_ReturnsEntry()
        {
            var date = new DateTime(2020, 12, 31, 15, 30, 00);
            var activities = new[] { "First activity", "Second activity", "Third activity" };
            var record = new List<string>
            {
                date.ToString("yyyy-MM-dd"),
                date.ToString("MMMM dd"),
                date.DayOfWeek.ToString(),
                date.ToString("HH:mm"),
                "good",
                 string.Join(" | ", activities),
                "My note title",
                "My note"
            };

            var actual = this.Target.ParseRecord(record);
            Assert.IsNotNull(actual);
            Assert.AreEqual(date, actual.Date);
            Assert.AreEqual(Mood.Good, actual.Mood);
            Assert.AreEqual(record[5], string.Join(" | ", actual.Activities));
            Assert.AreEqual(record[6], actual.NoteTitle);
            Assert.AreEqual(record[7], actual.Note);
        }


        [TestMethod]
        public void ParseRecord_RecordTooShort_ReturnsNull()
        {
            var record = new string[7].ToList();
            var actual = this.Target.ParseRecord(record);
            Assert.IsNull(actual);
        }


        [TestMethod]
        public void ParseRecord_RecordTooLong_ReturnsNull()
        {
            var record = new string[9].ToList();
            var actual = this.Target.ParseRecord(record);
            Assert.IsNull(actual);
        }

        #endregion
    }
}