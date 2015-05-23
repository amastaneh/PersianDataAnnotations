using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianDataAnnotations
{
	public static class TranslateError
	{
		public static string Translate(string value)
		{
			if (string.IsNullOrEmpty(value)) return null;
			string result = TranslateResource.ResourceManager.GetString(value.Replace(' ', '_'));
			if (string.IsNullOrEmpty(result)) return value;
			return result;
        }
	}
}
