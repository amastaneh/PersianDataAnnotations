using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianValidatorDataAnnotations : DataAnnotationsModelValidatorProvider
	{
		protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
		{
			var items = attributes.Where(a => a is ValidationAttribute).OfType<ValidationAttribute>().ToList();

			/// Add required REQUIRED atribute
			if (AddImplicitRequiredAttributeForValueTypes == true
				&& metadata.IsRequired
				&& !items.Any(a => a is RequiredAttribute))
			{
				items.Add(new RequiredAttribute());
			}

			if (items.Count > 0)
			{
				items.ForEach(attribute =>
				{
					attribute.ErrorMessage = DataAnnotationsResource.ResourceManager.GetString(attribute.GetType().Name + "_ErrorMessage");
				});
			}

			return base.GetValidators(metadata, context, attributes);
		}
	}
}