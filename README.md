## PersianDataAnnotations
Persian DataAnnotations is Localized DataAnnotations which is localization of System.ComponentModel.DataAnnotations for Persian (Farsi) language. It's useful for Persian Asp .Net MVC and other type of Microsoft .Net based application.
The localization of built-in resource of DataAnnotations is a bit hard to work and this solution helps project to use of this solution (just for localization of error messages).

## اعتبار سنجی کنترل ها در .NET با Data Annotation ها
<div dir="rtl">
اعتبار سنجی های سمت کلاینت با استفاده از  
`DataAnnotation` 
ها و افزودن چند 
`Attribute` 
ساده مانند  
[Required] یا  [DataType(DataType.Password)] 
بسیار ساده و تمیز است. برای فارسی سازی آن کافیست این کتابخانه را با استفاده نیوگت یا دستی به پروژه اضافه کرده و متد 
`RegisterAdapters` 
آن را فقط یکبار در مثلا 
`Application_Start`  
فراخوانی کنید. کار تمام است. 
برای مشاهده 
DEMO 
می توانید به فرم عضویت یا ورود در [طراحی وب ایران](http://webdesigniran.com) مراجعه کنید
</div>

## شیوه استفاده
1. افزودن به پروژه

```
  PM> Install-Package PersianDataAnnotations
```

2. نمونه فراخوانی و اجرا

```c#
protected void Application_Start()
{
    PersianDataAnnotationsValidator.RegisterAdapters();
}
```

## نکات
<div dir="rtl">
*	امکان تغییر `Resource` برای جلوگیری از تکرار `ErrorMessageResourceType` در هنگام `RegisterAdapters` دیده شده است
*	با جستجوی عنوان پروژه در `Nuget` می توانید از ابزار `Nuget` در ویژوال استودیو استفاده کنید و کتابخانه را به سادگی به پروژه اضافه کنید
*	سعی شده نقطه از آخر پیام ها حذف شود برای انطباق بیشتر با برنامه های چپ به راست
*	سعی شده پیام ها با فارسی روان نه پارسی بسیار ادبی و دور از ادبیات عامه بیان شود
*	سعی شده از بیشتر از است به جای مصدر نادرست باشیدن استفاده شود
<div />

## پشتیبانی
لطفا اگر مشکلی مشاهده کردید
- یا Fork & pull
- یا Share Issue
- یا لااقل یه تلفن یا موبایل بزنید به [طراحی وب ایران](http://webdesigniran.com)

## <a name="license"></a> License

This project is dedicated to public and is free for all uses, commercial or otherwise.
Supported by [Web Design Iran](http://webdesigniran.com)

این پروژه تحت حمایت شرکت 
[طراحی وب ایران](http://webdesigniran.com)
 بوده و برای استفاده تجاری یا غیر تجاری، رایگان است
