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

## [Chapter 10](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter10)
* *SendingAnEmailWithoutDI* - An example demonstrating a use case where you want to send an email when a user registers. The `EmailSender` class is created in code using `new` as shown in section 10.1.1 and Listing 10.3.
* *SendingAnEmailWithDI* - A refactoring of the *SendingAnEmailWithoutDI* project to use DI, showing how the `UserController` has been simplified.
* *InjectingMultipleImplementations* - Example demonstrating the behaviour when registering multiple instances of a service, as in section 10.2.4. Click the buttons shown on the home page and observe the console output to see the effect of the DI configuration
* *LifetimeExamples* - The effect of lifetime on DI. For details, see section 10.3 - the project broadly follows this outline, with slightly different naming to allow registering all the services in a single project.

## [Chapter 11](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter11)
* *ReplacingDefaultConfigProviders* - Demonstrating how you can replace the configuration providers added in `CreateDefaultBuilder`, as shown in section 11.3.1.
* *StoreViewerApplication* - A simple application that uses `IOptions<>` and strongly typed settings to bind configuration to POCOs. Optionally uses Google Maps to demonstrate loading settings from multiple sources.  Follow the [documentation from Google](https://developers.google.com/maps/documentation/javascript/get-api-key) to obtain an API key.
* *DesigningForAutomaticBinding* - Demonstrating how to create strongly typed settings that can be bound to configuration, and the limitations, as shown in section 11.4.3.
* *LifetimeExamples* - Demonstrates how to overwrite values based on the environment. In particular, observe how list values are overwritten.

## [Chapter 12](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter12)
* *InstallEFCore* - Demonstrating how to install EF Core, as shown in section 12.2. Starts from the Default Web App template from Visual Studio and installs the EF Core packages, adds the `Recipe` and `Ingredient` entities, configures the `AppDbContext`, and registers EF Core with the DI container. Configured by default for Local DB, but demonstrates how to configure the application for SQLite instead.
* *Migrate_LocalDb* - The same code as *InstallEfCore*, but with migrations added using the `dotnet-ef` global tool. Migrations generated for Local DB.
* *Migrate_SQLite* - The same as *Migrate_LocalDb* but configured for SQLite, and with SQLite-specific migrations generated by the `dotnet-ef` global tool.
* *RecipeApplication_LocalDb* - The final Razor Page application, using the Local DB database provider.
* *RecipeApplication_SQLite* - The final Razor Page application, using the SQLite database provider.

## [Chapter 13](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter13)
* *FilterPipelineExample* - A sample application with a single API Controller and a single Razor Page that contains one of each filter, and logs when the filter runs. Each filter contains commented out code to short-circuit the pipeline. Uncomment the code from each filter in turn to see the effect.
* *RecipeApplication* - The RecipeApplication from chapter 12 plus two API controllers. The `NoApiController` includes the code from listing 13.8, while the `RecipeApiController` includes the code from listing 13.9 where the code is refactored to use filters.

## [Chapter 14](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter14)
* *DefaultTemplate* - The default web app template for ASP.NET Core with Authentication, as discussed in section 14.3.
* *RecipeApplication* - The recipe application from chapter 13 with authentication added, as described in section 14.4. Also, the register page has been scaffolded to remove the references to external services, as described in section 14.5.
* *RecipeApplicationWithNameClaim* - The recipe application with an additional field added to the `RegisterModel` to record the `FullName`, as described in section 14.6. The field is added as an extra claim when the user registers, and is displayed in the menu bar when a user logs in.

## [Chapter 15](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter15)
* *Airport* - An analogy to the airport example presented in section 15.1. There are 4 steps, Home Page, Through security, Enter airport lounge, Board the plane. You can set the claims for a user when you register. Which claims you add will determine how far through the airport you can get.
* *RecipeApplication* - The recipe application from previous chapters, with authorization to prevent unauthorized users creating recipes, and resoure based authorization to ensure only the user which created a recipe can edit it.

## [Chapter 16](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter16)
* *RecipeApplication* - The Recipe application from previous chapters, for hosting in IIS. Changed the LocalDb migrations and connection string to use SqlLite as connecting to a LocalDb instance from IIS can be problematic. Also, added additional JS and CSS files to demonstrate bundling and minifying, and added *bundleconfig.json*

## [Chapter 17](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter17)

* *RecipeApplication* - The recipe application from previous chapters with some additional logging added to some Razor Pages.
* *FileLogger* - A simple Web API Project configured to write log messages to a rolling file by using a rolling file logging provider, as shown in section 17.3.1. Note that the log levels have been changed from the defaults in appsettings.json and appsettings.Development.json to show more in the logs.
* *SerilogLogger* - A simple Web API Project configured to write log messages to the console using Serilog, as shown in section 17.3.2.
* *LogFiltering* - A simple Web API Project configured to use the configuration filters defined in section 17.4.
* *SeqLogger* - A simple web API project to demonstrate structured logging using Seq, and using scopes to add additional properties to a log, as shown in section 17.5.

## [Chapter 18](https://github.com/andrewlock/asp-dot-net-core-in-action-2e/tree/master/Chapter18)

* *CustomHttpsCertificate* - A basic Razor Pages app using Kestrel with a self-signed certificate, similar to the way you would configure a certificate in production. Shows configuring the default certificate used by Kestrel in _appsettings.json_.

On Windows, you can generate a self-signed certificate using the *Install-Certificate.ps1* PowerShell script. This will create a self-signed certificate and add it to Windows' trusted certificate store.

You can generate a certificate on Ubuntu using *install_certificate.sh*. This uses *localhost.conf* to create a self signed certificate, and trusts it. On Linux, not all applications use the same store, so you may have to trust it explicitly for those applications. Use password `testpassword` to create the certificate.

* *CrossSiteScripting* - A simple app to demonstrate XSS attacks due to not encoding user input. The user submits content which is added to an internal list and is later rendered to the page. Using `@Html.Raw` renders the provided input exactly as it was entered - if the content is malicious, e.g. a `<script>` tag, then it is written into the page as a script tag, executing any code it contains. Instead, you should render content with the `@` symbol alone - that way the content is rendered as a string, and can be displayed safely.

* *CrossSiteRequestForgery* - A pair of apps to demonstrate a CSRF vulnerability. You can login to the banking application and view your balance. You can 'withdraw' funds using the provided form, and you'll see your balance reduce. The attacker website contains a form that posts to the banking application and withdraws funds for the currently logged in user. In the example you have to click the button to see the vulnerability, but this could easily be automated. To protect the endpoint, add the `[ValidateAntiForgeryToken]` attribute to the `BalanceController.Withdraw()` action. Run both applications by selecting "Set Startup Projects" in Visual Studio, or by running both applications using `dotnet run`.

* *CorsApplication* - A pair of apps to demonstrate CORS. The "shopping.com" site is a Razor Pages application, that loads a product list from a separate app, "api.shopping.com", hosted at a different host. With the default configuration, the request succeeds. Experiment by removing the default CORS policy from the `UseCors()` middleware configuration, and applying `[EnableCors]` to the `ProductsController` instead. Note that it's the _API_ that defines which applications can call it. Run both applications by selecting "Set Startup Projects" in Visual Studio, or by running both applications using `dotnet run`.
