using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace PersianDataAnnotationsCore
{
    public class PersianStringLocalizer : IStringLocalizer
    {
        private string _CultureName;

        public PersianStringLocalizer() : this(CultureInfo.CurrentUICulture)
        {
        }

        public PersianStringLocalizer(CultureInfo cultureInfo)
        {
            _CultureName = cultureInfo.Name;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        private string GetString(string name)
        {
            return $"ترجمه {name}";
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new PersianStringLocalizer(culture);
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            //return _db
            //    .Localizations
            //    .Where(l => l.Culture == _cultureName)
            //    .Select(l => new LocalizedString(l.Key, l.Value, true));

            return new List<LocalizedString>() { new LocalizedString("sample", "نمونه ترجمه") };
        }
    }
}