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

       [Fact]
        public void IfTheclockoutTimeIsLaterThan4AMAnErrorValidationMessageIsReturned()
        {
            //Arrange
            _clockOutTime = "5AM";
            var lateClockOutTimeMessage = "You cannout work past 4AM";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(lateClockOutTimeMessage, earnings);
        }

       [Fact]
        public void IfTheclockoutTimeIsBeforeThanClockInTimeAnErrorValidationMessageIsReturned()
        {
            //Arrange
            _clockInTime = "8PM";
            _clockOutTime = "6PM";
            var errorClockOutTimeMessage = "Your end time cannot be before your start time";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(errorClockOutTimeMessage, earnings);
        }

       [Fact]
        public void IfTheBabySitterDoesNotSelectAClockInTimeASelectClockInTimeErrorValidationmessageIsReturned()
        {
            //Arrange
            _clockInTime = string.Empty;

            var selectAClockInTimeMessage = "You must select a start time";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(selectAClockInTimeMessage, earnings);
        }

       [Fact]
        public void IfTheBabySitterDoesNotSelectAClockOutTimeASelectClockOutTimeErrorValidationmessageIsReturned()
        {
            //Arrange
            _clockOutTime = string.Empty;

            var selectAClockOutTimeMessage = "You must select an end time";

            //Act
            var earnings = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(selectAClockOutTimeMessage, earnings);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyAAndWorksBetween5PMAnd11PMAValueOf90IsReturned()
        {
            //Arrange
            var expectedPay = "90";
            _clockOutTime = "11PM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyAAndWorksBetween5PMAnd4AMAValueOf190IsReturned()
        {
            //Arrange
            var expectedPay = "190";
            _clockOutTime = "4AM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceA).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyBAndWorksBetween5PMAnd10PMAValueOf60IsReturned()
        {
            //Arrange
            var expectedPay = "60";
            _clockOutTime = "10PM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceB).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyBAndWorksBetween5PMAnd12PMAValueOf76IsReturned()
        {
            //Arrange
            var expectedPay = "76";
            _clockOutTime = "12AM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceB).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyBAndWorksBetween5PMAnd4AMAValueOf140IsReturned()
        {
            //Arrange
            var expectedPay = "140";
            _clockOutTime = "4AM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceB).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyCAndWorksBetween5PMAnd9PMAValueOf84IsReturned()
        {
            //Arrange
            var expectedPay = "84";
            _clockOutTime = "9PM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceC).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }

       [Fact]
        public void IfTheBabySitterSelectsFamilyCAndWorksBetween5PMAnd41MAValueOf189IsReturned()
        {
            //Arrange
            var expectedPay = "189";
            _clockOutTime = "4AM";

            //Act
            var actualPay = _babySitter.CalculateNightlyCharge(_clockInTime, _clockOutTime, _familyChoiceC).ToList();

            //Assert
            Assert.Contains(expectedPay, actualPay);
        }
    }
}