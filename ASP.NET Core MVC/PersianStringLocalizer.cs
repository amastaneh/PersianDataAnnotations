using System;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace PersianDataAnnotationsCore
{
    // 201707050022AMA: این کلاس و این شیوه به علت عدم پوشش ترجمه 
    // همه متن ها خصوصا متن های اعتبارسنجی های سمت سرور کنارگذاشته شد
    [Obsolete]
    public class PersianStringLocalizer : IStringLocalizer
    {
        private string _CultureName = null;
        private bool _JustInPersianCulture = false;
        private static SortedList<string, string> _LocalStrings = null;

        // در صورتی که تنظیم شده باشد که در فرهنگ فارسی کند برای سایر فرهنگ ها نیازی به ترجمه نیست
        private bool IsLocalizationRequired => !(_JustInPersianCulture && _CultureName != "fa-IR");


        public PersianStringLocalizer() : this(CultureInfo.CurrentUICulture, false) { }

        /// <param name="justInPersianCulture">فقط در حالتی که فرهنگ برای ایران تنظیم شده باشد اعمال شود. مناسب برای برنامه های چند زبانه.</param>
        public PersianStringLocalizer(CultureInfo cultureInfo, bool justInPersianCulture = false)
        {
            _CultureName = cultureInfo?.Name;
            _JustInPersianCulture = justInPersianCulture;

            // تهیه و ذخیره فهرست ترجمه در حافظه
            // اگر قرار به ترجمه نیست نیازی به پر کردن لیست هم نیست
            if (IsLocalizationRequired && _LocalStrings == null)
            {
                _LocalStrings = new SortedList<string, string>();
                typeof(DataAnnotationsResources)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty)
                    .ToList()
                    .ForEach(info =>
                    {
                        string Key = info?.Name;
                        string Value = info?.GetValue(null)?.ToString()?.Trim() ?? null;
                        string ValueFa = DataAnnotationsResourcesFa.ResourceManager?.GetString(Key)?.Trim();
                        if (!string.IsNullOrEmpty(Value) && !string.IsNullOrEmpty(ValueFa))
                        {
                            _LocalStrings.Add(Value, ValueFa);
                        }
                    });
            }
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetTranslateString(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetTranslateString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }

        private string GetTranslateString(string name)
        {
            if (!IsLocalizationRequired) return null;
            if (_LocalStrings == null) return null;

            // پیدا کردن ترجمه
            string StringResult = "";
            return ((_LocalStrings.TryGetValue(name, out StringResult) ? StringResult : null) ?? null);
        }

        public IStringLocalizer WithCulture(CultureInfo culture) => new PersianStringLocalizer(culture);


        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            if (IsLocalizationRequired == false || _LocalStrings == null || _LocalStrings.Count() < 1)
            {
                return typeof(DataAnnotationsResourcesFa)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty)
                    .ToList()
                    .Select(info => new LocalizedString(info.Name, info.GetValue(null)?.ToString() ?? null));
            }
            else
            {
                return _LocalStrings?.Select(str => new LocalizedString(str.Key, str.Value));
            }
        }
    }
}