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
    }
}