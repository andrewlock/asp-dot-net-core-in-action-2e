Book project for ASP.NET Core in Action, Second Edition
==============================
This repository contains the code samples for *ASP.NET Core in Action, Second Edition*

## Chapter 1
*No code samples*

## [Chapter 2](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter02)
* *WebApplication1* - A sample web application, based on the Visual Studio Razor Pages template
* *ErrorHandler* - A sample application demonstrating the built-in error handling. The home page (_Pages/Index.cshtml.cs_ throws an exception when executed.

## [Chapter 3](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter03)
* *CreatingAHoldingPage* - 3.2.1 Simple pipeline scenario 1: A holding page
* *CreatingAStaticFileWebsite* - 3.2.2 Simple pipeline scenario 2: Handling static files
* *SimpleRazorPagesApplication* - 3.2.3 Simple pipeline scenario 3: A Razor Pages application
* *SimpleRazorPagesApplicationAndHoldingPage* - 3.2.3 Simple pipeline scenario 3: A Razor Pages web application + a holding page for "/"
* *DeveloperExceptionPage* - 3.3.1 Viewing exceptions in development: the DeveloperExceptionPage
* *ExceptionHandlerMiddleware* - 3.3.2 Handling exceptions in production: the ExceptionHandlerMiddleware
* *StatusCodePages* - 3.3.3 Handling other errors: the StatusCodePagesMiddleware
* *StatusCodePagesWithRexecute* - 3.3.3 Handling other errors: the StatusCodePagesMiddleware. Reexecuting the pipeline to create custom status code pages

## [Chapter 4](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter04)
* *ATypicalRazorPage* - 4.1.1 Exploring a Simple Razor Page
* *AddingRazorPagesToEmptyProject* - 4.1.4 Adding Razor Pages to an "Empty" web application template
* *ConvertingToMvc* - 4.2 An MVC application, with separate Model, View, and Controller files
* *PageHandlers* - 4.3 Using different Razor Page handlers to handle different HTTP verbs (`GET` and `POST`)

## [Chapter 5](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter05)
* *RoutingExamples* - Multiple examples of routing. In particular, see _Search.cshtml_,  _Products.cshtml_, and _ProductDetails/Index.cshtml_. _Index.cshtml_ includes links demonstrating route parameters
* *ChangingConventions* - 5.7. Customizing the URLs using conventions. See _Startup.cs_

## [Chapter 6](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter06)
* *ToDoList* - Basic application demonstrating the application in Figure 6.1
* *ExampleBinding_EditProduct* - Binding a custom class using Model Binding
* *ExampleBinding_Calculator* - Binding a custom class using Model Binding
* *SimpleCurrencyConverterBindings* - Model binding simple properties. Demonstrates Table 6.1, binding to route parameters, form parameters and the querystring
* *ListBinding* - Model binding to collections, as shown in Figure 6.5
* *ValidatingWithDataAnnotations* - A dummy checkout page, demonstrating Model validation using various `DataAnnotations`. Also shows POST-REDIRECT-GET
* *CurrencyConverter* - A dummy currency converter application. Demonstrates model binding, `DataAnnotations`, and a custom validation attribute
* *RazorPageFormLayout* - Organising a Razor Page for model binding, as in section 6.4

## [Chapter 7](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter07)
* *ManageUsers* - Display a list of users, and allow adding new users, as shown in figure 7.3
* *DynamicHtml* - Example of creating dynamic HTML by using C# in Razor templates.
* *ToDoList* - Example of writing model values to HTML in Razor templates, as shown in section 7.2
* *NestedLayouts* - Demonstrates using a nested layout, where a two column layout, `_TwoColumn.cshtml` is nested in `_Layout.cshtml`.
* *PartialViews* - Demonstrates extracting common code into a partial view, as in section 7.4.3. Also shows adding additional namespace to _ViewImports for `PartialViews.Models` namespace.
* *DefaultMVCProject* - Default MVC template, showing the default conventions for finding a view. Also shows how you can specify the template to Render - the `HomeController` specifies alternative view to render at the URL `/Home/IndexThatRendersPrivacy`

## [Chapter 8](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter08)
* *CurrencyConverter* - A demo currency converter application using TagHelpers to generate form elements.
* *TagHelpers* - Demonstrates the input types generated for various property types and `DataAnnotations`, as described table 8.1.
* *SelectLists* - Generating a variety of select lists, as shown in section 8.2.4
* *EnvironmentTag* - Using the environment tag to conditionally render content, as shown in section 8.5

## [Chapter 9](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter09)
* *BlazorWebAssemblyProject* - A basic Blazor WebAssembly web application, as shown in Figure 9.1, created using the Blazor WebAssembly template. Follow the instructions at https://docs.microsoft.com/en-gb/aspnet/core/blazor/get-started to try it for yourself.
* *DefaultWebApiProject* - The default Web API project, created using the Visual Studio API template, as in section 9.2.
* *BasicWebApiProject* - A basic Web API project, returning a list of fruit, as demonstrated in section 9.2.
* *UsingApiControllerAttribute* - A project containing 2 controllers, demonstrating the additional code required if you don't use the `[ApiController]` attribute, as in section 9.5.
* *ProblemDetailsExample* - A simple API controller that demonstrates automatically returning a `ValidationProblemDetails` object when the binding model (the `myValue` route parameter) is empty.
* *CarsWebApi* - A Web API controller that demonstrates generating various different response types. Is configured to allow XML output in Startup.cs Use https://www.getpostman.com to make requests to the API. Also configured to use the _Newtonsoft.Json_ formatter instead of the _System.Text.Json_ formatter.