using System;
using System.Collections.Generic;

namespace BabySitterKata.TimePolicy
{
    public interface ITimeClockPolicy
    {
        IList<string> ValidateTimeClockEnties(IList<string> messages, DateTime clockInTime, DateTime clockOutTime);
    }
}
