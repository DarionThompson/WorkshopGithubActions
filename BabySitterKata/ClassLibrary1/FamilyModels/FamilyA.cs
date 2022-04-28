using System;

namespace BabySitterKata.FamilyModels
{
    public class FamilyA
        : Family
    {
        private readonly DateTime _startOfFirstPayPeriod = DateTime.Parse("5PM");

        private readonly DateTime _endOfFirstPayPeriod = DateTime.Parse("11PM");

		private readonly int firstHourlyCharge = 15;

		private readonly int secondHourlyCharge = 20;

        public override int BabySitterRates(DateTime clockedInTime)
		{
			if (clockedInTime >= _startOfFirstPayPeriod && clockedInTime < _endOfFirstPayPeriod)
			{
                return firstHourlyCharge;
			}
			return secondHourlyCharge;
        }
    }
}
