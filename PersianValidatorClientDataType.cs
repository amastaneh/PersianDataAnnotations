using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianValidatorClientDataType : ClientDataTypeModelValidatorProvider
	{
		private static readonly HashSet<Type> _numericTypes = new HashSet<Type>(new Type[]
		{
			typeof(byte), typeof(sbyte),
			typeof(short), typeof(ushort),
			typeof(int), typeof(uint),
			typeof(long), typeof(ulong),
			typeof(float), typeof(double), typeof(decimal)
		});

		public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
		{
			if (base.GetValidators(metadata, context).Any())
			{
				/// DateTime
				if (metadata.ModelType == typeof(DateTime) && 
					!String.Equals(metadata.DataTypeName, "Time", StringComparison.OrdinalIgnoreCase))
				{
					yield return new DateModelValidator(metadata, context);
				}

				/// Numeric
				if (_numericTypes.Contains(metadata.ModelType))
				{
					yield return new NumericModelValidator(metadata, context);
				}

			}
		}
	}

	public class NumericModelValidator : ModelValidator
	{
		public NumericModelValidator(ModelMetadata metadata, ControllerContext controllerContext)
			: base(metadata, controllerContext)
		{ }

		public override IEnumerable<ModelValidationResult> Validate(object container)
		{
			yield break; // Do nothing for server-side validation 
		}

		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
		{
			yield return new ModelClientValidationRule
			{
				ValidationType = "number",
				ErrorMessage = DataAnnotationsResource.FieldMustBeNumeric
			};
		}
	}

	public class DateModelValidator : ModelValidator
	{
		public DateModelValidator(ModelMetadata metadata, ControllerContext controllerContext)
			: base(metadata, controllerContext)
		{ }

		public override IEnumerable<ModelValidationResult> Validate(object container)
		{
			yield break; // Do nothing for server-side validation 
		}

		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
		{
			yield return new ModelClientValidationRule
			{
				ValidationType = "date",
				ErrorMessage = DataAnnotationsResource.FieldMustBeDate
			};
		}
	}
}