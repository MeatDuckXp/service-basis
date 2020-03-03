![Category overview screenshot](docs/images/logo_w.png "Base for the plug in")

# Service basis
The idea behind the service basis project is to provide a simple tool to support the plug in architecure. The host applicaiton would use the service base packages in order to define the service inteface and to load the service implementaitions wihout knowing anything about their implementaiton.

# Project Objectives 

Some of the main project objectives are:

- Provide a simple model to create applicaiton extensions
- Provide the application core just enough infomration to know how to access the extension implemenation and how to load it
- Enable developers parallel development. Features can be implemented as separate components and developed in parallel by different teams.
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
[![Build Status](https://vedranfilipovic.visualstudio.com/Build/_apis/build/status/Servicebasis?branchName=master)](https://vedranfilipovic.visualstudio.com/Build/_build/latest?definitionId=2&branchName=master)
 
# Contributing
This project welcomes contributions and suggestions. 
