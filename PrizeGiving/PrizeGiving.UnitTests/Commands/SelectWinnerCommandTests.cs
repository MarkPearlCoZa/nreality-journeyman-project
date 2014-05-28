using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using PrizeGiving.Domain.Commands;
using PrizeGiving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeGiving.UnitTests.Commands
{
    [TestFixture]
    class SelectWinnerCommandTests
    {
        //We need to discuss whether or not we are going to write tests for the randomizer. I think that will be a framework type test...

        [Test]
        public void AWinnerIsSelectedAndNotNull()
        {
            var fixture = new Fixture();

            var groupEventRsvpQuery = new Mock<GroupEventRsvpQuery>();
            var rsvpMembers = fixture.CreateMany<MeetupMember>();

            groupEventRsvpQuery
                .Setup(query => query.GetRsvpYesAttendees(It.IsAny<string>()))
                .Returns(rsvpMembers);

            var selectWinnerCommand = new SelectWinnerCommand(groupEventRsvpQuery.Object, new CSharpRandomizer());
            var winner = selectWinnerCommand.SelectWinnerForEvent(It.IsAny<string>());

            Assert.IsNotNull(winner);
        }

        [Test]
        public void TheCorrectWinnerIsReturnedBasedOnTheRandomNumber()
        {
            int randomNumber = 5;
            var fixture = new Fixture();

            var groupEventRsvpQuery = new Mock<GroupEventRsvpQuery>();
            var randomizer = new Mock<PrizeGiving.Domain.SelectWinner.Randomizer>();
            var rsvpMembers = fixture.CreateMany<MeetupMember>(10);

            groupEventRsvpQuery
                .Setup(query => query.GetRsvpYesAttendees(It.IsAny<string>()))
                .Returns(rsvpMembers);

            randomizer.Setup(r => r.GetRandomNumber(It.IsAny<int>()))
                .Returns(randomNumber);

            var selectWinnerCommand = new SelectWinnerCommand(groupEventRsvpQuery.Object, randomizer.Object);
            var winner = selectWinnerCommand.SelectWinnerForEvent(It.IsAny<string>());

            Assert.AreEqual(rsvpMembers.ToList()[randomNumber], winner);
        }

    }
}
