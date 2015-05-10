using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianValidatorDataErrorInfo : DataErrorInfoModelValidatorProvider
	{
		public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
		{
			if (typeof(IDataErrorInfo).IsAssignableFrom(metadata.ModelType))
			{
				//	yield return new DataErrorInfoClassModelValidator(metadata, context);
			}

			if (typeof(IDataErrorInfo).IsAssignableFrom(metadata.ContainerType))
			{
				// yield return new DataErrorInfoPropertyModelValidator(metadata, context);
			}

			return base.GetValidators(metadata, context);
		}
	}
}