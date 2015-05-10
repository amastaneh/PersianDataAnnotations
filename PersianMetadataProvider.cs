using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace PersianDataAnnotations
{
	public class PersianMetadataProvider : DataAnnotationsModelMetadataProvider
	{
		protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
		{
			var items = attributes.ToList();
			for (var i = 0; i < items.Count(); i++)
			{
				if (!(items[i] is DisplayNameAttribute))
				{
					continue;
				}
				items[i] = new DisplayNameAttribute(DataAnnotationsResource.ResourceManager.GetString(propertyName));
			}
			return base.CreateMetadata(items, containerType, modelAccessor, modelType, propertyName);

		}
	}
}
