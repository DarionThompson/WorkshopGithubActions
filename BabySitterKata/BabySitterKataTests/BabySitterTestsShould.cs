using BabySitterKata;
using BabySitterKata.FamilyModels;
using System;
using System.Linq;
using Xunit;

namespace BabySitterKataTests
{
    public class BabySitterTestsShould
    {
        private string _clockInTime;

        private string _clockOutTime;

        private Family _familyChoiceA;

        private Family _familyChoiceB;

        private Family _familyChoiceC;

        private BabySitter _babySitter;

        public BabySitterTestsShould()
        {
            _clockInTime = "5PM";

            _clockOutTime = "6PM";

            _babySitter = new BabySitter();

            _familyChoiceA = new FamilyA();

            _familyChoiceB = new FamilyB();

            _familyChoiceC = new FamilyC();
        }

        [Fact]
        public void ReturnErrorValidationWhenTimeStartEarlierThand5PM()
        {
            //Arrange
            _clockInTime = "4PM";
            var earlyClockInTimeMessage = "You cannout work before 5PM";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(earlyClockInTimeMessage, earnings);
        }

        [Fact]
        public void ReturnErrorValidationWhenFamilyNotSelected()
        {
            //Arrange
            var selectAFamilyMessage = "You Must Select A Family";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, null).ToList();

            //Assert
            Assert.Contains(selectAFamilyMessage, earnings);
        }
    }
}