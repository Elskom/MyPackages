# Sdk
All of the project files to help with building plugins for Els_kom as well as for Els_kom itself.

# NuGet


| Package | Version |
|:-------:|:-------:|
| Elskom.Sdk | [![NuGet Badge](https://buildstats.info/nuget/Elskom.Sdk?includePreReleases=true)](https://www.nuget.org/packages/Elskom.Sdk/) |
| newsmake | [![NuGet Badge](https://buildstats.info/nuget/newsmake?includePreReleases=true)](https://www.nuget.org/packages/newsmake/) |
| BlowFish | [![NuGet Badge](https://buildstats.info/nuget/BlowFish?includePreReleases=true)](https://www.nuget.org/packages/BlowFish/) |
| GenericPluginLoader | [![NuGet Badge](https://buildstats.info/nuget/GenericPluginLoader?includePreReleases=true)](https://www.nuget.org/packages/GenericPluginLoader/) |
| Elskom.Common | [![NuGet Badge](https://buildstats.info/nuget/Elskom.Common?includePreReleases=true)](https://www.nuget.org/packages/Elskom.Common/) |
| MessageManager | [![NuGet Badge](https://buildstats.info/nuget/MessageManager?includePreReleases=true)](https://www.nuget.org/packages/MessageManager/) |
| MiniDump | [![NuGet Badge](https://buildstats.info/nuget/MiniDump?includePreReleases=true)](https://www.nuget.org/packages/MiniDump/) |
| Elskom.PluginFramework | [![NuGet Badge](https://buildstats.info/nuget/Elskom.PluginFramework?includePreReleases=true)](https://www.nuget.org/packages/Elskom.PluginFramework/) |
| PluginUpdateCheck | [![NuGet Badge](https://buildstats.info/nuget/PluginUpdateCheck?includePreReleases=true)](https://www.nuget.org/packages/PluginUpdateCheck/) |
| ReleasePackaging | [![NuGet Badge](https://buildstats.info/nuget/ReleasePackaging?includePreReleases=true)](https://www.nuget.org/packages/ReleasePackaging/) |
| SettingsFile | [![NuGet Badge](https://buildstats.info/nuget/SettingsFile?includePreReleases=true)](https://www.nuget.org/packages/SettingsFile/) |
| UnluacNET | [![NuGet Badge](https://buildstats.info/nuget/UnluacNET?includePreReleases=true)](https://www.nuget.org/packages/UnluacNET/) |
| ZipAssembly | [![NuGet Badge](https://buildstats.info/nuget/ZipAssembly?includePreReleases=true)](https://www.nuget.org/packages/ZipAssembly/) |

# Build Status

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/602ea77e56864263b58c05c7beaadf5f)](https://app.codacy.com/gh/Elskom/Sdk?utm_source=github.com&utm_medium=referral&utm_content=Elskom/Sdk&utm_campaign=Badge_Grade_Settings)
![Build Status](https://github.com/Elskom/Sdk/workflows/.NET%20Core%20%28build%29/badge.svg)
![Build Status](https://github.com/Elskom/Sdk/workflows/.NET%20Core%20%28build%20%26%20publish%20release%29/badge.svg)
[![GitHub release](https://img.shields.io/github/release/Elskom/Sdk.svg)](https://GitHub.com/Elskom/Sdk/releases/)
[![GitHub repo size](https://img.shields.io/github/repo-size/Elskom/Sdk)](https://github.com/Elskom/Sdk)
[![GitHub issues-opened](https://img.shields.io/github/issues/Elskom/Sdk.svg)](https://GitHub.com/Elskom/Sdk/issues?q=is%3Aissue+is%3Aopened)
[![GitHub issues-closed](https://img.shields.io/github/issues-closed/Elskom/Sdk.svg)](https://GitHub.com/Elskom/Sdk/issues?q=is%3Aissue+is%3Aclosed)
[![GitHub pulls-opened](https://img.shields.io/github/issues-pr/Elskom/Sdk.svg)](https://github.com/Elskom/Sdk/pulls?q=is%3Aopen+is%3Apr)
[![Github pulls-pending](https://img.shields.io/github/issues-search/Elskom/Sdk?label=pending%20pull%20requests&query=is%3Aopen+status%3Apending+is%3apr&color=lightgray)](https://github.com/Elskom/Sdk/pulls?q=is%3Aopen+status%3Apending+is%3Apr)
[![Github pulls-passing](https://img.shields.io/github/issues-search/Elskom/Sdk?label=passing%20pull%20requests&query=is%3Aopen+status%3Asuccess+is%3Apr&color=limegreen)](https://github.com/Elskom/Sdk/pulls?q=is%3Aopen+status%3Asuccess+is%3Apr)
[![Github pulls-failing](https://img.shields.io/github/issues-search/Elskom/Sdk?label=failing%20pull%20requests&query=is%3Aopen+status%3Afailure+is%3Apr&color=red)](https://github.com/Elskom/Sdk/pulls?q=is%3Aopen+status%3Afailure+is%3Apr)
[![GitHub pulls-merged](https://img.shields.io/github/issues-search/Elskom/Sdk?label=merged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Amerged&color=darkviolet)](https://github.com/Elskom/Sdk/pulls?q=is%3Apr+is%3Aclosed+is%3Amerged)
[![GitHub pulls-unmerged](https://img.shields.io/github/issues-search/Elskom/Sdk?label=unmerged%20pull%20requests&query=is%3Apr%20is%3Aclosed%20is%3Aunmerged&color=red)](https://github.com/Elskom/Sdk/pulls?q=is%3Apr+is%3Aclosed+is%3Aunmerged)
[![GitHub contributors](https://img.shields.io/github/contributors/Elskom/Sdk.svg)](https://GitHub.com/Elskom/Sdk/graphs/contributors/)
![Commit activity](https://img.shields.io/github/commit-activity/y/Elskom/Sdk)

Note: all of my other nuget packages are provided with the Elskom.Sdk package all other packages except the ones from this repository and it's submodules are deprecated.

# newsmake Information

News / changelog making tool.

To build:
It's built with the rest of the projects using ``dotnet build``.

To install:

```ps
dotnet tool install -g newsmake
```

To update:

```ps
dotnet tool update -g newsmake
```

To uninstall:

```ps
dotnet tool uninstall -g newsmake
```

Any bugs can be filed in this repository's built in bug tracker.
This is for taking an changelog master config file with folders of the program's versions and then outputting every entry to those versions to the configured output file. The result is an perfectly autogenerated changelog.
