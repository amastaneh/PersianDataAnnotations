## Persian DataAnnotations
[![Gitter](https://badges.gitter.im/webdesigniran/PersianDataAnnotations.svg)](https://gitter.im/PersianDataAnnotations/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

Persian DataAnnotations as DataAnnotations localizer library, is a localization of System.ComponentModel.DataAnnotations for Persian (Farsi) language. It's useful for Persian ASP.NET Core MVC & ASP.NET MVC based applications. The localization of built-in resource of DataAnnotations is a bit hard to work (specialy in ASP.NET MVC) and this library helps your project for localization error messages just with single call a method. `Fork` and `Translate` RESX resources for your language ;-)


🌟 If you ❤️ library, please star it! 🌟


## &#x202b;اعتبار سنجی کنترل ها در .NET با Data Annotation ها
&#x202b;استفاده از `DataAnnotation` ها و افزودن `[Required]` یا `[DataType(DataType.Password)]` یا دیگر `Attribute` ها، کار اعتبارسنجی سمت کلاینت را بسیار ساده کرده است. برای فارسی سازی مقادیر پیش فرض کافی است این کتابخانه را با استفاده [نیوگت / NuGet](https://nuget.org/packages/PersianDataAnnotations) یا به صورت دستی به پروژه اضافه کنید. 



## &#x202b; شیوه استفاده در ASP.NET Core MVC

  1- &#x202b; با استفاده از [نیوگت / NuGet](https://nuget.org/packages/PersianDataAnnotationsCore) به سادگی می توانید این کتابخانه را به پروژه خود اضافه کنید
  
```
  PM> Install-Package PersianDataAnnotationsCore
```
  2- &#x202b; فقط همین یک خط را اضافه کنید و کار تمام میشود

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options => options.ModelMetadataDetailsProviders.Add(new PersianDataAnnotationsCore.PersianValidationMetadataProvider()));
}
```



## &#x202b; شیوه استفاده در ASP.NET MVC

  1- &#x202b; با استفاده از [نیوگت / NuGet](https://nuget.org/packages/PersianDataAnnotations) به سادگی می توانید این کتابخانه را به پروژه خود اضافه کنید
  
```
  PM> Install-Package PersianDataAnnotations -Version
```

  2- &#x202b; یعنی فقط همین یک خط را اضافه کنید و کار تمام میشود
```c#
protected void Application_Start()
{
    PersianDataAnnotations.PersianDataAnnotations.Register();
}
```

  3- &#x202b; فارسی سازی خطاهای مربوط به رمز عبور و قسمت ثبت نام

```c#
public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
{
    ...
    manager.PasswordValidator = new PasswordValidator 
    /// جایگزین شود با خط زیر
  	manager.PasswordValidator = new PersianPasswordValidator
    ...
}
```



## دمو
برای مشاهده دمو می توانید به فرم عضویت یا ورود کاربران در [طراحی وب ایران](http://webdesigniran.com) مراجعه کنید

<img alt="screencapture-webdesigniran" src="https://cloud.githubusercontent.com/assets/6195199/7538227/bfcb8226-f5b3-11e4-9bcc-b13baef6a4b7.png" width="320">

نمونه فارسی سازی خطاهای مربوط به رمز عبور

<img alt="screencapture-webdesigniran" src="https://cloud.githubusercontent.com/assets/6195199/7716477/dd77299a-fea7-11e4-8b85-695e9f919f00.png" width="320">



## ترجمه
&#x202b;‫هنوز احتمال دارد که خطاهایی فارسی نشده باشند. در نسخه های مربوط به پروژه های ASP.NET MVC یک متد استاتیک ترجمه نظیر به نظیر خطا هم اضافه شده که خطاها را می تواند قبل از نمایش تا حد امکان ترجمه کند.

```c#
private void AddErrors(IdentityResult result)
{
  foreach (var error in result.Errors)
	{
	  ModelState.AddModelError("", PersianDataAnnotations.TranslateError.Translate(error));
	}
}
```
&#x202b; متد بالا در کلاس های پیش فرض AccountController یا مشابه آن وجود دارد فقط به آن ترجمه متن خطا اضافه شده است

&#x202b;‫البته مشابه این متد استاتیک برای نسخه های ASP.NET Core MVC هم ارائه شده است
```c#
var result = PersianDataAnnotationsCore.PersianValidationMetadataProvider.ToPersian(value)
```



## نکات
*	&#x202b;امکان تغییر `Resource` برای جلوگیری از تکرار `ErrorMessageResourceType` در هنگام `RegisterAdapters` دیده شده است
*	&#x202b;با جستجوی عنوان پروژه در `NuGet` می توانید از ابزار `NuGet` در ویژوال استودیو استفاده کنید و کتابخانه را به سادگی به پروژه اضافه کنید
*	سعی شده نقطه از آخر پیام ها حذف شود برای انطباق بیشتر با برنامه های چپ به راست
*	سعی شده پیام ها با فارسی روان نه پارسی بسیار ادبی و دور از ادبیات عامه بیان شود
*	سعی شده از بیشتر از است به جای مصدر نادرست باشیدن استفاده شود



## پشتیبانی
لطفا اگر ترجمه بهتری برای یک عبارت یافته اید
لطفا اگر مشکلی مشاهده کردید
لطفا اگر پیشنهادی دارید
- &#x202b;یا Fork & Pull کنید
- &#x202b;یا Share Issue کنید
- &#x202b;یا لااقل یه تلفن یا موبایل بزنید به [طراحی وب ایران](http://webdesigniran.com)

## <a name="license"></a> License

The project is dedicated to public and is free for all uses, commercial or otherwise.
Supported by [Web Design Iran](http://webdesigniran.com)

این پروژه تحت حمایت 
[طراحی وب ایران](http://webdesigniran.com)
 بوده و برای استفاده تجاری یا غیر تجاری، رایگان است

