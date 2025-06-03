## Core (Domain Model) Project

The central focus here is on Entities and business rules.

In Domain-Driven Design, this is the Domain Model.

This project contain all of your Entities, Value Objects, and business logic.

Entities that are related and change together are grouped into an Aggregate.

Entities leverage encapsulation and minimize public setters.

Entities can leverage Domain Events to communicate changes to other parts of the system.

Entities define Specifications that can be used to query for them.

For mutable access, Entities are accessed through a Repository interface.

Read-only ad hoc queries use separate Query Services that don't use the Domain Model.
