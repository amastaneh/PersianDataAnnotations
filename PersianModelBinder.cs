using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianModelBinder : DefaultModelBinder
	{
		protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
		{
			base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);

			string PropertyName = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
			ModelState ModelState = bindingContext.ModelState[PropertyName];
			// Find all errors that were caused by FormatException during conversion and replace it with custom message.
			// Some information may be found there: http://forums.asp.net/t/1512140.aspx
			if (ModelState != null && ModelState.Errors != null)
			{
				foreach (ModelError error in new List<ModelError>(ModelState.Errors))
				{
					if (String.IsNullOrEmpty(error.ErrorMessage) && error.Exception != null)
					{
						for (Exception exception = error.Exception; exception != null; exception = exception.InnerException)
						{
							if (exception is FormatException)
							{
								var DisplayName = bindingContext.PropertyMetadata[propertyDescriptor.Name].DisplayName;
								var ErrorFormat = DataAnnotationsResource.PropertyValueInvalid;
								var ErrorMessage = String.Format(ErrorFormat, ModelState.Value.AttemptedValue, DisplayName);
								ModelState.Errors.Remove(error);
								ModelState.Errors.Add(ErrorMessage);
								break;
							}
						}
					}
				}
			}
		}

		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
		{
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);

			string PropertyName = CreateSubPropertyName(bindingContext.ModelName, propertyDescriptor.Name);
			ModelState ModelState = bindingContext.ModelState[PropertyName];
			if (ModelState != null && ModelState.Errors != null)
			{
				foreach (ModelError error in new List<ModelError>(ModelState.Errors))
				{
					if (String.IsNullOrEmpty(error.ErrorMessage) && error.Exception != null)
					{
						for (Exception exception = error.Exception; exception != null; exception = exception.InnerException)
						{
							if (exception is FormatException)
							{
								var DisplayName = bindingContext.PropertyMetadata[propertyDescriptor.Name].DisplayName;
								var ErrorFormat = DataAnnotationsResource.PropertyValueInvalid;
								var ErrorMessage = String.Format(ErrorFormat, ModelState.Value.AttemptedValue, DisplayName);
								ModelState.Errors.Remove(error);
								ModelState.Errors.Add(ErrorMessage);
								break;
							}
						}
					}
				}
			}
		}
	}
}
