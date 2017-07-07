using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PersianDataAnnotationsCore
{
    /// <summary>
    /// این کلاس اعتبارسنجی سمت سرور و کلاینت را به زبان فارسی ترجمه می کند
    /// </summary>
    /// <example>
    /// برای راه اندازی کافیست همین یک خط را به پروژه اضافه فرمایید
    /// Startup.cs > ConfigureServices > 
    /// services.AddMvc(options => options.ModelMetadataDetailsProviders.Add(new PersianDataAnnotationsCore.PersianValidationMetadataProvider()));
    /// </example>
    public class PersianValidationMetadataProvider : IValidationMetadataProvider
    {
        private static SortedList<string, string> _LocalStrings = null;

        public void CreateValidationMetadata(ValidationMetadataProviderContext context) =>
            // 201704042333AMA
            // ابتدا همه اتریبیوت ها دریافت کرده و از بین آنها 
            // آنهایی که مربوط به اعتبارسنجی هستند را جدا می کنیم
            // سپس پراپرتی متن خطای آنها را تغییر می دهیم
            context
            .PropertyAttributes
            ?.Where(attribute => attribute is ValidationAttribute)
            ?.Cast<ValidationAttribute>()
            ?.ToList()
            ?.ForEach(att =>
            {
                if (!string.IsNullOrEmpty(att?.ErrorMessage ?? null))
                {
                    att.ErrorMessage = ToPersian(att.ErrorMessage);
                }
                else
                {
                    // 20170705056AMA: متغییر ErrorMessageString 
                    // همواره دارای مقدار صحیح است
                    // ولی دسترسی به آن می تواند باعث تاخیر در این متد شود
                    // این متد به علت فراخوانی زیاد باید بسیار سریع اجرا شود
                    // لذا این متن به صورت هارد.کد. اضافه شده است
                    switch (att)
                    {
                        case RequiredAttribute attRequired:
                            attRequired.ErrorMessage = ToPersian(DataAnnotationsResources.RequiredAttribute_ValidationError);
                            break;
                        case DataTypeAttribute attDataType:
                            switch (attDataType.DataType)
                            {
                                case DataType.Currency:
                                case DataType.CreditCard:
                                case DataType.Date:
                                case DataType.DateTime:
                                case DataType.Duration:
                                case DataType.EmailAddress:
                                case DataType.Html:
                                case DataType.ImageUrl:
                                case DataType.MultilineText:
                                case DataType.PhoneNumber:
                                case DataType.PostalCode:
                                case DataType.Password:
                                case DataType.Text:
                                case DataType.Time:
                                case DataType.Upload:
                                case DataType.Url:
                                    attDataType.ErrorMessage = ToPersian(DataAnnotationsResources.ValidationAttribute_ValidationError);
                                    break;
                                default:
                                    Debug.Assert(false, $"PersianDataAnnotationsCore: وضعیت پیش بینی نشده‌ای برای بومی سازی {att?.GetType()?.ToString() ?? "null"} باید بررسی شود!! لطفا اطلاع دهید.");
                                    att.ErrorMessage = typeof(ValidationAttribute).GetProperty("ErrorMessageString")?.GetValue(att)?.ToString();
                                    break;
                            }
                            break;
                        default:
                            Debug.Assert(false, $"PersianDataAnnotationsCore: وضعیت پیش بینی نشده‌ای برای بومی سازی {att?.GetType()?.ToString() ?? "null"} باید بررسی شود! لطفا اطلاع دهید.");
                            att.ErrorMessage = typeof(ValidationAttribute).GetProperty("ErrorMessageString")?.GetValue(att)?.ToString();
                            break;
                    }
                }
            });

        public static string ToPersian(string value)
        {
            // تهیه و ذخیره فهرست ترجمه در حافظه
            if (_LocalStrings == null)
            {
                // 201704050012AMA: باید مراقب بود که چند بار تلاش نشود چون متد پرتکراری است
                // ساختن یک نسخه باع می شود که در نوبت بعدی 
                // شرط نال تایید نشود و سراغ تلاش دوباره نیاید
                _LocalStrings = new SortedList<string, string>();
                try
                {
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
                catch { }
            }

            // شروط بازگشتی
            if (string.IsNullOrEmpty(value)) return null;
            if (_LocalStrings == null) return null;
            if (_LocalStrings.Count() < 1) return null;

            // پیدا کردن ترجمه
            string ReturnValue = "";
#if DEBUG
            ReturnValue = ((_LocalStrings.TryGetValue(value, out ReturnValue) ? ReturnValue : null) ?? null);
            Debug.Assert(!ReturnValue.Equals(value), $"عبارت '{value}' یافت نشد! لطفا اطلاع دهید.");
            return ReturnValue;
#else
            return ((_LocalStrings.TryGetValue(value, out ReturnValue) ? ReturnValue : null) ?? null);
#endif
        }
    }
}
