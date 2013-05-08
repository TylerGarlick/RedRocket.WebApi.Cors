RedRocket.WebApi.Cors
=====================

Web API CORS, nothing more, nothing less

Simple open up all your web apis for anyone to consume.  
I don't intend for this to be configurable nor a customizable solution.
I grabbed the code at: http://code.msdn.microsoft.com/Implementing-CORS-support-a677ab5d/sourcecode?fileId=49921&pathId=1366793369
My intention was to mainly "NuGet" it, because it was a pain to copy and paste over and over again.

Installation
-------------
    Install-Package RedRocket.WebApi.Cors

This adds in App_Start > CorsConfig.cs a file that self registers using the web activator.

Your done. :)

This package will be replaced when the new WebApi comes out:
+ https://aspnetwebstack.codeplex.com/wikipage?title=CORS%20support%20for%20ASP.NET%20Web%20API
+ http://weblogs.asp.net/scottgu/archive/2013/04/19/asp-net-web-api-cors-support-and-attribute-based-routing-improvements.aspx
