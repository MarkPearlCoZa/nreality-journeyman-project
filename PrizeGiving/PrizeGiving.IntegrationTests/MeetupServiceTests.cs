using Moq;
using NUnit.Framework;
using PrizeGiving.Services;
using System.Linq;

namespace PrizeGiving.Models
{
    [TestFixture]
    class MeetupServiceTests
    {
        IConfiguration _configuration;

        [SetUp]
        public void SetConfiguration()
        {
            var mockIConfiguration = new Mock<IConfiguration>();
            mockIConfiguration
                .Setup(mockConfig => mockConfig.ApiKey)
                .Returns("944427917291e3a2d146b1652263b54");
            _configuration = mockIConfiguration.Object;

        }

        [Test]
        public async void GetAllEventsForDeveloperUserGroupByNameInOneMonth_ReturnsListOfEvents()
        {
            IMeetupService meetupService = new MeetupService(_configuration);

            var events = await meetupService.GetEventsByGroupNameAndTime("DeveloperUG","0,1m");

            Assert.IsNotNullOrEmpty(events.First().Id);
        }

        [Test]
        public async void GetAllEventsForDeveloperUserGroupByName_ReturnsListOfEvents()
        {
            IMeetupService meetupService = new MeetupService(_configuration);
            var events = await meetupService.GetEventsByGroupName("DeveloperUG");
            Assert.GreaterOrEqual(events.Count(), 1);
        }


        [Test]
        public async void GetAllEventsForNonExistingGroupName_ReturnsEmptyList()
        {
            IMeetupService meetupService = new MeetupService(_configuration);

            var events = await meetupService.GetEventsByGroupNameAndTime("-1", "0,1m");

            Assert.AreEqual(0, events.Count);
        }

        [Test]
        public async void GetRsvpsForEventWithinOneMonth_ReturnsListOfRsvps()
        {
            IMeetupService meetupService = new MeetupService(_configuration);

            var events = await meetupService.GetEventsByGroupNameAndTime("DeveloperUG","0,1m");

            var rsvps = await meetupService.GetRsvpsByEventIdAndRsvpAnswer(events.First().Id,"yes");

#warning Assume that there has been an RSVP which is not always the case... Find a better way to test for RSVP's
            Assert.Greater(rsvps.Count, 0);
        }

        [Test]
        public async void GetYesRsvpsForFirstEventWithinOneMonth_ReturnsListOfRsvpsWithYes()
        {
            IMeetupService meetupService = new MeetupService(_configuration);

            var events = await meetupService.GetEventsByGroupNameAndTime("DeveloperUG", "0,1m");

            var rsvps = await meetupService.GetRsvpsByEventIdAndRsvpAnswer(events.First().Id, "yes");

#warning Assume that there has been an RSVP which is not always the case... Find a better way to test for RSVP's
            Assert.AreEqual(0, rsvps.Count(r => r.Response != "yes"));
        }

        [Test]
        public async void GetRsvpsForNonExistingEvent_ReturnsEmptyListOfRsvps()
        {
            IMeetupService meetupService = new MeetupService(_configuration);

            var rsvps = await meetupService.GetRsvpsByEventIdAndRsvpAnswer("-1","yes");

            Assert.AreEqual(rsvps.Count, 0);
        }

    }
}
