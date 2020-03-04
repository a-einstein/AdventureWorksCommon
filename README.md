## RCS.AdventureWorks.Common

#### Description
Library shared by my various shopping projects, mainly containing domain classes and data transfer classes.

#### Notes
* This is targeted on .Net Standard. 
* Because this  is currently used by both .Net Standard projects and one .Net Framework project it is mandatory to keep the .Net Standard version not higher than 2.0. Currently version 2.0 supports the .Net Framework  4.6.1 - 4.8, while version 2.1. no longer supports it.
* More details about [compatibility](https://dotnet.microsoft.com/platform/dotnet-standard) and [.Net Standard 2.1](https://devblogs.microsoft.com/dotnet/announcing-net-standard-2-1/).