using System.Collections.Generic;
using BabySitterKata.FamilyModels;

namespace BabySitterKata.Services
{
	public interface IValidationServices
	{
		IList<string> ValidateUserInputs(string clockInTime, string clockOutTime, Family familyChoice);
	}
}
