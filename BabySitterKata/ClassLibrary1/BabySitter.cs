using System;
using System.Collections.Generic;
using System.Linq;
using BabySitterKata.FamilyModels;
using BabySitterKata.Helpers;
using BabySitterKata.Services;
using BabySitterKata.TimePolicy;

namespace BabySitterKata
{
	public class BabySitter
	{
		private readonly IValidationServices _validationServices;

		private readonly ITimeClockPolicy _timeClockPolicy;

		public BabySitter()
		{
			_timeClockPolicy = new TimeClockPolicy();
			_validationServices = new ValidationServices();
		}

		public IList<string> CalculateNightlyCharge(string clockInTime, string clockOutTime, Family familyChoice)
		{
			var result = _validationServices.ValidateUserInputs(clockInTime, clockOutTime, familyChoice);

            if (!result.Any())
            {
                var startTime = CheckIfTimeEntryContainsAm(clockInTime);

                var endTime = CheckIfTimeEntryContainsAm(clockOutTime);

                result = _timeClockPolicy.ValidateTimeClockEnties(result, startTime, endTime);

                if (!result.Any())
                {
                    result.Add(CalculateRates(startTime, endTime, familyChoice).ToString());
                }

            }
			return result;
		}

        private DateTime CheckIfTimeEntryContainsAm(string time)
        {
            var convertedTime = DateTime.Parse(time);

            if (time.Contains(MessageHelper.amSuffix))
            {
                return convertedTime.AddDays(1);
            }

            return convertedTime;
        }

        private int CalculateRates(DateTime clockInTime, DateTime clockOutTime, Family familyChoice)
        {
            var family = familyChoice.GetType();

            var nightlyPay = 0;

            if (family == typeof(FamilyA))
            {
                var familyA = familyChoice as FamilyA;
                nightlyPay = familyA.CalculateBabySitterPay(clockInTime, clockOutTime);
            }

            if (family == typeof(FamilyB))
            {
                var familyB = familyChoice as FamilyB;
                nightlyPay = familyB.CalculateBabySitterPay(clockInTime, clockOutTime);
            }

            if (family == typeof(FamilyC))
            {
                var familyC = familyChoice as FamilyC;
                nightlyPay =  familyChoice.CalculateBabySitterPay(clockInTime, clockOutTime);
            }

            return nightlyPay;
        }
    }
}
