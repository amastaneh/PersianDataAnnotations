## PersianDataAnnotations
Persian DataAnnotations is Localized DataAnnotations which is localization of System.ComponentModel.DataAnnotations for Persian (Farsi) language. It's useful for Persian Asp .Net MVC and other type of Microsoft .Net based application.
The localization of built-in resource of DataAnnotations is a bit hard to work and this solution helps project to use of this solution (just for localization of error messages).

## &#x202b;اعتبار سنجی کنترل ها در .NET با Data Annotation ها
&#x202b;اعتبار سنجی های سمت کلاینت با استفاده از `DataAnnotation` ها و افزودن چند `Attribute` ساده مانند `[Required]` یا `[DataType(DataType.Password)]` بسیار ساده و تمیز است. برای فارسی سازی آن کافیست این کتابخانه را با استفاده نیوگت یا دستی به پروژه اضافه کرده و متد `RegisterAdapters` آن را فقط یکبار در مثلا `Application_Start` فراخوانی کنید. کار تمام است. 


## شیوه استفاده
  1- افزودن به پروژه
```
  PM> Install-Package PersianDataAnnotations
```

  2- نمونه فراخوانی و اجرا
```c#
protected void Application_Start()
{
    PersianDataAnnotationsValidator.RegisterAdapters();
}
```

  3- فارسی سازی خطاهای مربوط به رمز عبور
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

این پروژه تحت حمایت شرکت 
[طراحی وب ایران](http://webdesigniran.com)
 بوده و برای استفاده تجاری یا غیر تجاری، رایگان است

