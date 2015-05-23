using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersianDataAnnotations.Identity
{
	public class PersianPasswordValidator : PasswordValidator
	{
		public override Task<IdentityResult> ValidateAsync(string item)
		{
			/// این سورس به نظر به روز می آید برای جیایگزینی استفاده شده است
			//return base.ValidateAsync(item);

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			var errors = new List<string>();
			if (string.IsNullOrWhiteSpace(item) || item.Length < RequiredLength)
			{
				errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.PasswordTooShort, RequiredLength));
			}
			if (RequireNonLetterOrDigit && item.All(IsLetterOrDigit))
			{
				errors.Add(Resources.PasswordRequireNonLetterOrDigit);
			}
			if (RequireDigit && item.All(c => !IsDigit(c)))
			{
				errors.Add(Resources.PasswordRequireDigit);
			}
			if (RequireLowercase && item.All(c => !IsLower(c)))
			{
				errors.Add(Resources.PasswordRequireLower);
			}
			if (RequireUppercase && item.All(c => !IsUpper(c)))
			{
				errors.Add(Resources.PasswordRequireUpper);
			}
			if (errors.Count == 0)
			{
				return Task.FromResult(IdentityResult.Success);
			}
			return Task.FromResult(IdentityResult.Failed(String.Join(" ", errors)));
		}
	}
}
