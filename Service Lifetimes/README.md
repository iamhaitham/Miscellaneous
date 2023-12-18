# Service Lifetimes

## Introduction
>.NET [supports](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) the dependency injection (DI) software design pattern, which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies.

## About this solution
This solution aims to demonstrate [the three lifetimes of a service](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes):
* Singleton
* Scoped
* Transient
For this purpose I have created 3 services:
* ISingletonService -> SingletonService
* IScopedService -> ScopedService
* ITransientService -> TransientService
In addition to those, there are also 3 more services:
* ISingletonEquivalent -> SingletonEquivalent
* IScopedEquivalent -> ScopedEquivalent
* ITransientEquivalent -> TransientEquivalent

### Equivalent services
I have created these services in the consuming class rather than injecting them, which means I did not register them in the IoC Container either.\
The goal is to have more understanding on the topic, and how the registered services actually work.

## Useful resource
[Dependency Injection and Service Lifetimes in .NET Core](https://henriquesd.medium.com/dependency-injection-and-service-lifetimes-in-net-core-ab9189349420)