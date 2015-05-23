using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianDataAnnotations
	{
		public static void Register()
		{
			/// Model Metadata
			ModelMetadataProviders.Current = new PersianMetadataProvider();

			/// Model Validator
			ModelValidatorProviders.Providers.Clear();
			ModelValidatorProviders.Providers.Add(new PersianValidatorDataAnnotations());
			ModelValidatorProviders.Providers.Add(new PersianValidatorDataErrorInfo());
			ModelValidatorProviders.Providers.Add(new PersianValidatorClientDataType());

			/// DefaultModelBinder 

			ModelBinders.Binders.DefaultBinder = new PersianModelBinder();
		}

	}
}