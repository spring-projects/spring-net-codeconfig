The Spring.NET CodeConfig project, Release 2.0.0 (8/31/2012)
--------------------------------------------------------------------
https://github.com/SpringSource/spring-net-codeconfig


1. INTRODUCTION

The 2.0.0 release of Spring.NET CodeConfig provides:

     * the ability to configure a Spring container using standard .NET attributes in addition to XML configuration
     * the ability to configure a Spring container using standard .NET code instead of or in addition to XML configuration

2. SUPPORTED .NET FRAMEWORK VERSIONS

Spring Code Config for .NET version 2.0.0 supports the .NET 3.5 and later framework runtimes (REQUIRES Visual Studio 2008 or later).

3. KNOWN ISSUES/LIMITATIONS

* Features
This relase of Spring Code Config for .NET supports the basic configuration of Object Definitions Metadata related to object construction but does not (yet) support the more advanced features of the Spring.NET Dependency Injection container including the application of Aspects, the subsitution of VariablePlaceholderValues, and others.  This support will be provided in subsequent releases of this project.

4. RELEASE INFO

Release contents:

* "src" contains the C# source files for the framework
* "test" contains the C# source files for the test suite
* "bin\net\3.5" contains the distribution dll files for .NET 3.5
* "bin\net\4.0" contains the distribution dll files for .NET 4.0
* "lib\net" contains common libraries needed for building the project
* "doc" contains reference documentation, MSDN-style API help, and the Spring Code Config for .NET xsd.
* "examples" contains sample applications.

The VS.NET solution for the framework and examples are provided.

Latest info is available at the public website: http://www.springframework.net/

Spring Code Config for .NET is released under the terms of the Apache Software License (see license.txt).

5. DISTRIBUTION DLLs

The "bin" directory contains the following distinct dll files for use in applications:

* bin\net\3.5\Spring.Core.CodeConfig.dll for .NET 3.5
* bin\net\4.0\Spring.Core.CodeConfig.dll for .NET 4.0


6. WHERE TO START?

Documentation can be found in the "docs" directory:
* The Spring.NET CodeConfig reference documentation

Documented sample applications can be found in "examples":

7. How to build

VS.NET
------
The is a solution file for different version of VS.NET

* Spring.Config.2008.sln for use with VS.NET 2008
* Spring.Config.2010.sln for use with VS.NET 2010

8. Support

The user forums at https://forum.springframework.net/ are available for you to submit questions, support requests, and interact with other Spring.NET users.

Bug and issue tracking can be found at https://jira.springsource.org/browse/SPRNET/component/11081

To get the sources, check them out at the git repository at https://github.com/SpringSource/spring-net-codeconfig

We are always happy to receive your feedback on the forums. If you think you found a bug, have an improvement suggestion
or feature request, please submit a ticket in JIRA (see link above).

9. Acknowledgements

InnovaSys Document X!
---------------------
InnovSys has kindly provided a license to generate the SDK documentation and supporting utilities for

10. Contributing to Spring.NET CodeConfig

Github is for social coding: if you want to write code, we encourage contributions through pull requests from forks of this repository (see https://help.github.com/forking/). Before we accept a non-trivial patch or pull request we will need you to sign the contributor's agreement (see https://support.springsource.com/spring_committer_signup). Signing the contributor's agreement does not grant anyone commit rights to the main repository, but it does mean that we can accept your contributions, and you will get an author credit if we do. Active contributors might be asked to join the core team, and given the ability to merge pull requests.