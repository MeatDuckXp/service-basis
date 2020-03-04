![Category overview screenshot](docs/images/Logo.jpg "Base for the plug in architecture")

# Servicebasis
The idea behind the servicebasis project is to provide a simple tool to support the plugin architecture. The host application would use the servicebasis packages in order to define the service interface and to load the service implementations without knowing anything about their implementaiton.

# Project Objectives 

Some of the main project objectives are:

- Provide a simple model to create application extensions
- Provide the application core just enough information to know how to access the extension implementation and how to load it
- Enable developers to parallel development. Features can be implemented as separate components and developed in parallel by different teams.
- Enforce simplicity since a plugin typically has one function, and so developers have a single focus
 
# Installation

- Install Nuget package `ServiceBasis.Abstraction`
- Install Nuget package `ServiceBasis`

# Example Usage

```C#
public interface IHelloWorldService : IServiceBase
{
   void PrintHelloWorld();

   void SumIt();

   string Version { get; }
}
```

# Build Status
|**master**|
|--|
[![Build status](https://ci.appveyor.com/api/projects/status/qmvq89f1p4y9fk0p/branch/master?svg=true)](https://ci.appveyor.com/project/MeatDuckXp/ServiceBasis/branch/master)
 
# Contributing
This project welcomes contributions and suggestions. 
