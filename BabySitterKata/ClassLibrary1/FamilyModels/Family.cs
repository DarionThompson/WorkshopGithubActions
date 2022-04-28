using System;

namespace BabySitterKata.FamilyModels
{
    public abstract class Family
    {
        public abstract int BabySitterRates(DateTime clockedInTime);

        public int CalculateBabySitterPay(DateTime startTime, DateTime endTime)
        {
            int total = 0;

            while (!startTime.Equals(endTime) || startTime > endTime)
            {
                total += BabySitterRates(startTime);

                startTime = startTime.AddHours(1);
            }

            return total;
        }
    }
}
 