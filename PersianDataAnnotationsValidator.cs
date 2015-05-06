using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianDataAnnotationsValidator : DataAnnotationsModelValidator<ValidationAttribute>
	{
		private static Func<ValidationAttribute, string> _resourceNameFunc = attr => attr.GetType().Name;

		/// <summary>
		/// The type of the resource which holds the error messqages
		/// </summary>
		public static Type DefaultResourceType { get; set; }

		/// <summary>
		/// Function to get the ErrorMessageResourceName from the Attribute
		/// </summary>
		public static Func<ValidationAttribute, string> ResourceNameFunc
		{
			get { return _resourceNameFunc; }
			set { _resourceNameFunc = value; }
		}

		public static void RegisterAdapters(Type resourceType = null)
		{
			Type adapterType = typeof(PersianDataAnnotationsValidator);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.CompareAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.CreditCardAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.CustomValidationAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.DataTypeAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.EmailAddressAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.EnumDataTypeAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.FileExtensionsAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.MaxLengthAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.MinLengthAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.PhoneAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.RegularExpressionAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.UrlAttribute), adapterType);
			DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(System.ComponentModel.DataAnnotations.ValidationAttribute), adapterType);
			PersianDataAnnotationsValidator.DefaultResourceType = resourceType ?? typeof(DataAnnotationsResource);
		}

		public PersianDataAnnotationsValidator(ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute) : base(metadata, context, attribute)
		{
			/// مقادیر در پراپرتی های زیر ذخیره می شوند
			/// ولی چون فقط مقادیر خطاها مورد نظر است
			/// نیاز به استفاده از رفلکشن نیست
			/// attribute._defaultErrorMessage
			/// attribute.ErrorMessageString

			if (Attribute.ErrorMessageResourceType == null)
			{
				this.Attribute.ErrorMessageResourceType = DefaultResourceType;
			}

			if (Attribute.ErrorMessageResourceName == null)
			{
				this.Attribute.ErrorMessageResourceName = metadata.DataTypeName + "Attribute_ErrorMessage";
			}
		}
	}
}