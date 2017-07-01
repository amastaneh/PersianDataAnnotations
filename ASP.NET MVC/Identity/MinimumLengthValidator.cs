using Microsoft.AspNet.Identity;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace PersianDataAnnotations.Identity
{
	public class PersianMinimumLengthValidator : MinimumLengthValidator
	{
		public PersianMinimumLengthValidator(int requiredLength) 
			: base(requiredLength) { }

		public override Task<IdentityResult> ValidateAsync(string item)
		{
			if (string.IsNullOrWhiteSpace(item) || item.Length < RequiredLength)
			{
				return
					Task.FromResult(
						IdentityResult.Failed(String.Format(CultureInfo.CurrentCulture, Resources.PasswordTooShort,
							RequiredLength)));
			}
			return Task.FromResult(IdentityResult.Success);
		}
	}
}
