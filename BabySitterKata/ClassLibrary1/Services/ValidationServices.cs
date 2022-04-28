using System.Collections.Generic;
using BabySitterKata.FamilyModels;
using BabySitterKata.Helpers;

namespace BabySitterKata.Services
{
	public class ValidationServices
	: IValidationServices
	{
		public IList<string> ValidateUserInputs(string clockInTime, string clockOutTime, Family familyChoice)
		{
			var result = new List<string>();

            if (familyChoice == null)
			{
                result.Add(MessageHelper.missingFamilyChoiceMessage);
			}

            if(string.IsNullOrEmpty(clockInTime))
            {
                result.Add(MessageHelper.missingStartTimeMessage);
            }

            if(string.IsNullOrEmpty(clockOutTime))
            {
                result.Add(MessageHelper.missingEndTimeMessage);
            }

			return result;
		}
	}
}
