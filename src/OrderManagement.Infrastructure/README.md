## Infrastructure Project

In Clean Architecture, Infrastructure concerns are kept separate from the core business rules (or domain model in DDD).

It is the only project that has code concerned with EF, Files, Email, Web Services, Azure/AWS/GCP.

It depend on Core where abstractions (interfaces) exist.

Infrastructure classes implement interfaces found in the Core project.

These implementations are wired up at startup using DI. In this case using `Microsoft.Extensions.DependencyInjection` and extension methods defined in each project.
