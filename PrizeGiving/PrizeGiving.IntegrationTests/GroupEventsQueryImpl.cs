using System;
using System.Linq;
using NUnit.Framework;

namespace PrizeGiving.Models
{
    [TestFixture]
    public class GroupEventsQueryImplTest
    {
        [Test]
        public void ReturnMeetupEventsForGroup()
        {
            var sut = new MeetupGroupEventsQuery();
            var result = sut.GetEventsForGroup("DeveloperUG");
            Assert.GreaterOrEqual(result.Count(), 1);
        }

        [Test]
        public void ThrowExceptionIfNoGroupSet()
        {
            var sut = new MeetupGroupEventsQuery();
            Assert.Throws<MissingFieldException>(() => sut.GetEventsForGroup(string.Empty));
        }


    }
}