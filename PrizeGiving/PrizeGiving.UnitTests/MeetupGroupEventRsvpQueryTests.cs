using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PrizeGiving.UnitTests
{
    [TestFixture]
    public class MeetupGroupEventRsvpQueryTests
    {
        [Test]
        public void EmptyGroupEventIDThrowsAnException()
        {
            var sut = new MeetupGroupEventRsvpQuery();
            Assert.Throws<MissingFieldException>(() => sut.GetRsvpYesAttendees(string.Empty));
        }
    }
}
