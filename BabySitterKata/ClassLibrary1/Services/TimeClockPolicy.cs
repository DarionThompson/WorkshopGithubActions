using System;
using System.Collections.Generic;
using BabySitterKata.Helpers;

namespace BabySitterKata.TimePolicy
{
    public class TimeClockPolicy
        : ITimeClockPolicy
    {
        private readonly DateTime _clockInRestriction = DateTime.Parse("5PM");

        private readonly DateTime _clockOutRestriction = DateTime.Parse("4AM").AddDays(1);

        public IList<string> ValidateTimeClockEnties(IList<string> messages, DateTime clockInTime, DateTime clockOutTime)
        {
            if (AssertStartTimePolicy(clockInTime))
            {
                messages.Add(MessageHelper.earlyStartTimeMessage);
            }
            else if (AsserEndTimePolicy(clockOutTime))
            {
                messages.Add(MessageHelper.lateEndTimeMessage);
            }

            else if (AssertStartTimeAndEndTimeTimePolicy(clockInTime, clockOutTime))
            {
                messages.Add(MessageHelper.errorEndTimeMessage);
            }

            return messages;
        }

		private bool AssertStartTimePolicy(DateTime startTime)
		{
            return startTime < _clockInRestriction;
		}

		private bool AsserEndTimePolicy(DateTime endTime)
		{
			return endTime > _clockOutRestriction;
		}

		private bool AssertStartTimeAndEndTimeTimePolicy(DateTime startTime, DateTime endTime)
		{
			return endTime < startTime;
		}
    }
}
