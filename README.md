# ImageHunt
https://travis-ci.org/vickywhack/ImageHunt.svg?branch=main

# Problem Statement
Create a program with a graphical user interface that takes in a search string and displays photographs that match the search string. Use Flickr’s public photo feed at https://www.flickr.com/services/feeds/docs/photos_public/ as your service.
- Build a .NET application using public API’s from Flickr.

# Evaluation Criteria
1 Working application – that looks cleans and works as expected
2 Modularity of design, application of SOLID principles
3 Code elegance – readability, naming conventions.
4 Testability – unit testing, test driven development.
5 CI design

# Solution
- .NET application      : Xamarin.Forms targeting to Android & UWP (Universal Windows Phone)
- Developer Environment : Windows; VS2017 Professional
- Test Machine          : Linux (as provided by Travis CI) (Windows dotnet: 2.2 or any is not supporting in TravisCI)
- Unit Test             : NUnit via. .Net Core 2.2
- Architecture          : Model–view–viewmodel (MVVM) as a Software Architectural Pattern (3-Layer Architecture)
- Dependency Injection  : Unity Framwork
- UI                    : XAML
- Language              : c# (csharp) 7.0
- Target Framwork       : .NET Standard 2.0
- Target Android ver.   : Android 5.0(API level 21) - Android 9.0(API level 28)
- Target Windows ver.   : Windows 10 Fall Creators Update(10.0, Build 162xx) - Windows 10, version 1809(10.0, Build 17763) :: UWP
- CI Pipeline           : Travis CI - Build & Test