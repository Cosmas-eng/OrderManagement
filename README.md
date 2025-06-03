[![.NET Core](https://github.com/ardalis/CleanArchitecture/workflows/.NET%20Core/badge.svg)](https://dotnet.microsoft.com/en-us/apps/aspnet)
[![Ardalis.CleanArchitecture.Template on NuGet](https://img.shields.io/nuget/v/Ardalis.CleanArchitecture.Template?label=Ardalis.CleanArchitecture.Template)](https://www.nuget.org/packages/Ardalis.CleanArchitecture.Template/)

# Introductions

This is a Back-End test project for a Sr. DotNet Developer job opening at [Smoothstack](https://smoothstack.com/). It is an ASP.NET Core project based off of [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html). A Domain Driven, loosely-coupled and dependency-inverted design architecture.

This project applies the whole Clean Architecture template, it implements the four layers that are synonimous with the design. These layers include, the `OrderManagement.Web` layer, the `OrderManagement.UseCases` layer, the `OrderManagement.Core` layer and the `OrderManagement.Infrastructure` layer.

## Table Of Contents

- [Introduction](#introductions)
  - [Table Of Contents](#table-of-contents)
- [Project Properties](#project-propertise)
  - [.NET Version](#net-version)
  - [APIs](#apis)
  - [The Core Project](#the-core-project-ordermanagementcore)
  - [The Infrastructure Project](#the-infrastructure-project-ordermanagementinfrastructure)
  - [The Use Cases Project](#the-usecases-project-ordermanagementusecases)
  - [The Web Project](#the-web-project-ordermanagementweb)
  - [The SharedKernel Project](#the-sharedkernel-package)
  - [The Test Projects](#the-test-projects)
- [Patterns Used](#patterns-used)
  - [Domain Events](#domain-events)
  - [Factory Design Pattern](#factory-design-pattern)
  - [Related Projects](#related-projects)

# Project Propertise

## .NET Version

The project is using **.NET 8**

## APIs

This solution only has support for API Endpoints using the [FastEndpoints](https://fast-endpoints.com/) library. There are three fully documented API endpoints which fully cover the requirements of the assignment: the `ApplyDiscount` endpoint that applies discount to an order whose Id is provided in the route, the `UpdateStatus` endpoint that updates the status of an order whose Id is provide in the route to the status in the request; the state transition for this is handled in the order domain enitity, and lastly the `OrderAnalytics` endpoint that returns data on either all the orders in the database or orders from a specific period.

## The Core Project (`OrderManagement.Core`)

The Core project is the center of the design, and all other project dependencies point toward it. As such, it has very few external dependencies. The Core project include the Domain Model with the following:

- Entities
- Aggregates
- Value Objects
- Domain Events
- Domain Event Handlers
- Domain Services
- Interfaces
- DTOs

The central focus here is on Entities and business rules. Entities that are related and change together are grouped into an Aggregate employing encapsulation and minimize public setters. They can leverage Domain Events to communicate changes to other parts of the system.

Entities also define Specifications that can be used to query for them and for mutable access, Entities are accessed through a Repository interface.

Read-only ad hoc queries use separate Query Services that don't use the Domain Model.

## The Infrastructure Project (`OrderManagement.Infrastructure`)

Most of the application's dependencies on external resources are implemented in classes defined in this project. These classes implement interfaces defined in Core. The project includes data access and domain event implementations, but one would also include things like email providers, file access, web api clients, etc. so they're not adding coupling to the Core or UI projects.

## The UseCases Project (`OrderManagement.UseCases`)

The is a relatively thin layer that wraps the domain model with the Use Cases organized by feature grouped into Commands and Queries, following CQRS. Its intention is to reduce the amount of logic in UI and Infrastructure projects when there is a lot of logic. Typically, in smaller project like this one, it could always be ommited.

## The Web Project (`OrderManagement.Web`)

The entry point of the application is the ASP.NET Core web project. A console application, with a `public static void Main` method in `Program.cs`. It leverages [FastEndpoints](https://fast-endpoints.com/) and the REPR pattern to organize the API endpoints.

## The SharedKernel Package

A [Shared Kernel](https://deviq.com/domain-driven-design/shared-kernel) is used to share common elements between bounded contexts. It's a DDD term but many organizations leverage "common" projects or packages for things that are useful to share between several applications.

## The Test Projects

The test projects are organized based on the kind of test, with unit, functional and integration test projects existing in this solution.

# Patterns Used

This solution template has code built in to support a few common patterns, especially Domain-Driven Design patterns. Bellow is a brief overview:

## Domain Events

Domain events are a great pattern for decoupling a trigger for an operation from its implementation. This is especially useful from within domain entities since the handlers of the events can have dependencies while the entities themselves typically do not.

## Factory Design Pattern

The solution uses this design pattern to solve the different discount per customer segment situation by having a factory in the discount service provide the appropriate discount implementation per customer from the customer segment.

## Related Projects

- [ApiEndpoints](https://github.com/ardalis/apiendpoints)
- [GuardClauses](https://github.com/ardalis/guardclauses)
- [HttpClientTestExtensions](https://github.com/ardalis/HttpClientTestExtensions)
- [Result](https://github.com/ardalis/result)
- [SharedKernel](https://github.com/ardalis/Ardalis.SharedKernel)
- [SmartEnum](https://github.com/ardalis/SmartEnum)
- [FastEndpoints](https://fast-endpoints.com/)
- [Scrutor](https://github.com/khellang/Scrutor)