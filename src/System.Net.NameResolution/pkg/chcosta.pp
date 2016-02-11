The target "ResolveReferences" listed in a BeforeTargets attribute at "e:\gh\chcosta\corefx\Tools\FrameworkTargeting.targets (46,7)" does not exist in the project, and will be ignored.
The target "ResolveAssemblyReferences" listed in an AfterTargets attribute at "e:\gh\chcosta\corefx\Tools\FrameworkTargeting.targets (89,54)" does not exist in the project, and will be ignored.
The target "AssignProjectConfiguration" listed in a BeforeTargets attribute at "e:\gh\chcosta\corefx\Tools\FrameworkTargeting.targets (101,62)" does not exist in the project, and will be ignored.
The target "ResolveReferences" listed in an AfterTargets attribute at "e:\gh\chcosta\corefx\Tools\PackageLibs.targets (158,11)" does not exist in the project, and will be ignored.
<?xml version="1.0" encoding="IBM437"?>
<!--
============================================================================================================================================
e:\gh\chcosta\corefx\src\System.Net.NameResolution\pkg\System.Net.NameResolution.pkgproj
============================================================================================================================================
-->
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" InitialTargets="CheckForBuildTools;CheckDesignTime">
  <!--
============================================================================================================================================
  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), dir.props))\dir.props">

e:\gh\chcosta\corefx\src\dir.props
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="..\dir.props">

e:\gh\chcosta\corefx\dir.props
============================================================================================================================================
-->
  <!--<Import Project="..\dir.props" Condition="Exists('..\dir.props')" />-->
  <!--
============================================================================================================================================
  <Import Project="src\BuildValues.props">

e:\gh\chcosta\corefx\src\BuildValues.props
============================================================================================================================================
-->
  <PropertyGroup>
    <!--
      the value of BuildNumber must be numeric and contain enough
      leading zeroes to satisfy a 16-bit integer in base-10 format.  this
      is needed because SemVer v1 performs a lexical comparison of the
      prerelease version number and without the leading zeroes foo-20 is
      smaller than foo-4.
    -->
    <RevisionNumber>00001</RevisionNumber>
  </PropertyGroup>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\dir.props
============================================================================================================================================
-->
  <!--
    $(OS) is set to Unix/Windows_NT. This comes from an environment variable on Windows and MSBuild on Unix.
  -->
  <PropertyGroup>
    <OsEnvironment Condition="'$(OsEnvironment)'==''">$(OS)</OsEnvironment>
  </PropertyGroup>
  <!-- Build Tools Versions -->
  <PropertyGroup>
    <RoslynVersion>1.0.0-rc3-20150510-01</RoslynVersion>
    <RoslynPackageName>Microsoft.Net.ToolsetCompilers</RoslynPackageName>
  </PropertyGroup>
  <ItemGroup>
    <AssemblyMetadata Include=".NETFrameworkAssembly">
      <Value />
    </AssemblyMetadata>
    <AssemblyMetadata Include="Serviceable">
      <Value>True</Value>
    </AssemblyMetadata>
  </ItemGroup>
  <!--
    Switching to the .NET Core version of the BuildTools tasks seems to break numerous scenarios, such as VS intellisense and resource designer
    as well as runnning the build on mono. Until we can get these sorted out we will continue using the .NET 4.5 version of the tasks.
  -->
  <PropertyGroup>
    <BuildToolsTargets45>true</BuildToolsTargets45>
  </PropertyGroup>
  <!-- Common repo directories -->
  <PropertyGroup>
    <ProjectDir>$(MSBuildThisFileDirectory)</ProjectDir>
    <SourceDir>$(ProjectDir)src\</SourceDir>
    <!-- Output directories -->
    <BinDir Condition="'$(BinDir)'==''">$(ProjectDir)bin/</BinDir>
    <ObjDir Condition="'$(ObjDir)'==''">$(BinDir)obj/</ObjDir>
    <TestWorkingDir Condition="'$(TestWorkingDir)'==''">$(BinDir)tests/</TestWorkingDir>
    <PackagesOutDir Condition="'$(PackagesOutDir)'==''">$(BinDir)packages/</PackagesOutDir>
    <!-- Input Directories -->
    <PackagesDir Condition="'$(PackagesDir)'==''">$(ProjectDir)packages/</PackagesDir>
    <ToolRuntimePath Condition="'$(ToolRuntimePath)'==''">$(ProjectDir)Tools/</ToolRuntimePath>
    <ToolsDir Condition="'$(UseToolRuntimeForToolsDir)'=='true'">$(ToolRuntimePath)</ToolsDir>
    <ToolsDir Condition="'$(ToolsDir)'==''">$(ProjectDir)Tools/</ToolsDir>
    <DotnetCliPath Condition="'$(DotnetCliPath)'==''">$(ToolRuntimePath)dotnetcli/bin/</DotnetCliPath>
    <BuildToolsTaskDir Condition="'$(BuildToolsTargets45)' == 'true'">$(ToolsDir)net45/</BuildToolsTaskDir>
    <!-- Packaging configuration -->
    <PreReleaseLabel>rc3</PreReleaseLabel>
    <PackageDescriptionFile>$(ProjectDir)pkg/descriptions.json</PackageDescriptionFile>
    <RuntimeIdGraphDefinitionFile>$(ProjectDir)pkg/Microsoft.NETCore.Platforms/runtime.json</RuntimeIdGraphDefinitionFile>
    <!-- Add a condition for this when we are able to run on .NET Core -->
    <PackagingTaskDir>$(ToolsDir)net45/</PackagingTaskDir>
    <BuildNumberMajor Condition="'$(BuildNumberMajor)' == ''">$(RevisionNumber)</BuildNumberMajor>
    <!-- defined in buildtools packaging.targets, but we need this before targets are imported -->
    <PackagePlatform Condition="'$(PackagePlatform)' == ''">$(Platform)</PackagePlatform>
    <PackagePlatform Condition="'$(PackagePlatform)' == 'amd64'">x64</PackagePlatform>
    <NativePackagePath>$(MSBuildThisFileDirectory)src/Native/pkg</NativePackagePath>
  </PropertyGroup>
  <!-- Import Build tools common props file where repo-independent properties are found -->
  <!--
============================================================================================================================================
  <Import Project="$(ToolsDir)Build.Common.props">

e:\gh\chcosta\corefx\Tools\Build.Common.props
============================================================================================================================================
-->
  <!-- 
     This file will contain all of the common properties from most repos. The intention is to only have 
     repo specific properties inside the repos, and move to this file everything that is common.
  -->
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\dir.props
============================================================================================================================================
-->
  <!-- Test runtime -->
  <PropertyGroup>
    <TestRuntimeProjectJson Condition="'$(TestRuntimeProjectJson)' == ''">$(SourceDir)Common/test-runtime/project.json</TestRuntimeProjectJson>
    <TestRuntimeProjectLockJson Condition="'$(TestRuntimeProjectLockJson)' == ''">$(SourceDir)Common/test-runtime/project.lock.json</TestRuntimeProjectLockJson>
  </PropertyGroup>
  <!-- Package dependency validation -->
  <PropertyGroup>
    <ValidatePackageVersions>true</ValidatePackageVersions>
    <ProhibitFloatingDependencies>true</ProhibitFloatingDependencies>
  </PropertyGroup>
  <ItemGroup>
    <ValidationPattern Include="^((System\..*)|(Microsoft\.CSharp)|(Microsoft\.NETCore.*)|(Microsoft\.Win32\..*)|(Microsoft\.VisualBasic))(?&lt;!TestData)$">
      <ExpectedPrerelease>rc2-23713</ExpectedPrerelease>
    </ValidationPattern>
    <ValidationPattern Include="^(System\..*TestData)$">
      <ExpectedVersion>1.0.0-prerelease</ExpectedVersion>
    </ValidationPattern>
    <ValidationPattern Include="^xunit$">
      <ExpectedVersion>2.1.0</ExpectedVersion>
    </ValidationPattern>
    <ValidationPattern Include="^xunit\.netcore\.extensions$">
      <ExpectedVersion>1.0.0-prerelease-00123</ExpectedVersion>
    </ValidationPattern>
  </ItemGroup>
  <!-- list of nuget package sources passed to nuget.exe -->
  <ItemGroup Condition="'$(ExcludeInternetFeeds)' != 'true'">
    <NuGetSourceList Include="https:%2F%2Fwww.myget.org/F/dotnet-buildtools" />
    <NuGetSourceList Include="https:%2F%2Fwww.nuget.org/api/v2" />
  </ItemGroup>
  <!-- Common nuget properties -->
  <PropertyGroup>
    <NuGetToolPath Condition="'$(NuGetToolPath)'==''">$(PackagesDir)NuGet.exe</NuGetToolPath>
    <NuGetPackageSource>@(NuGetSourceList -> '-source %(Identity)', ' ')</NuGetPackageSource>
    <NuGetConfigCommandLine>$(NuGetPackageSource)</NuGetConfigCommandLine>
    <NugetRestoreCommand>"$(NuGetToolPath)"</NugetRestoreCommand>
    <NugetRestoreCommand>$(NugetRestoreCommand) install</NugetRestoreCommand>
    <!-- NuGet.exe doesn't like trailing slashes in the output directory argument -->
    <NugetRestoreCommand>$(NugetRestoreCommand) -OutputDirectory "$(PackagesDir.TrimEnd('/\'.ToCharArray()))"</NugetRestoreCommand>
    <NugetRestoreCommand>$(NugetRestoreCommand) $(NuGetConfigCommandLine)</NugetRestoreCommand>
    <NugetRestoreCommand>$(NugetRestoreCommand) -Verbosity detailed</NugetRestoreCommand>
    <NugetRestoreCommand Condition="'$(OsEnvironment)'=='Unix'">mono $(NuGetRestoreCommand)</NugetRestoreCommand>
  </PropertyGroup>
  <!-- list of nuget package sources passed to dnu -->
  <ItemGroup Condition="'$(ExcludeInternetFeeds)' != 'true'">
    <!-- Need to escape double forward slash (%2F) or MSBuild will normalize to one slash on Unix. -->
    <DnuSourceList Include="https:%2F%2Fwww.myget.org/F/dotnet-core/" />
    <DnuSourceList Include="https:%2F%2Fwww.myget.org/F/dotnet-coreclr/" />
    <DnuSourceList Include="https:%2F%2Fwww.myget.org/F/dotnet-corefxtestdata/" />
    <DnuSourceList Include="https:%2F%2Fwww.myget.org/F/dotnet-buildtools/" />
    <DnuSourceList Include="https:%2F%2Fwww.nuget.org/api/v2/" />
  </ItemGroup>
  <!-- list of directories to perform batch restore -->
  <ItemGroup>
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src" />
    <DnuRestoreDir Include="$(ToolsDir)" />
    <!-- workaround to address issue where DNX won't recurse directories under a project.json
         https://github.com/aspnet/dnx/commit/0dda8bf86863364cc20421f1af7494f1b2a3256f -->
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src\*\src\**\project.json" />
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src\*\ref\*\project.json" />
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src\*\tests\*\project.json" />
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src\*\*\netcore50aot\project.json" />
    <DnuRestoreDir Include="$(MSBuildProjectDirectory)\src\Common\tests\**\project.json" />
  </ItemGroup>
  <PropertyGroup>
    <DnxPackageDir Condition="'$(DnxPackageDir)'==''">$(PackagesDir)/$(DnxPackageName)/</DnxPackageDir>
    <DnuToolPath Condition="'$(DnuToolPath)'=='' and '$(OsEnvironment)'!='Unix'">$(DnxPackageDir)\bin\dnu.cmd</DnuToolPath>
    <DnuToolPath Condition="'$(DnuToolPath)'=='' and '$(OsEnvironment)'=='Unix'">$(DnxPackageDir)/bin/dnu</DnuToolPath>
    <DotnetToolCommand Condition="'$(DotnetToolCommand)' == '' and '$(OsEnvironment)'!='Unix'">$(DotnetCliPath)dotnet.exe</DotnetToolCommand>
    <DotnetToolCommand Condition="'$(DotnetToolCommand)' == '' and '$(OsEnvironment)'=='Unix'">$(DotnetCliPath)dotnet</DotnetToolCommand>
    <DnuToolPath>$(DotnetToolCommand)</DnuToolPath>
    <DnuRestoreSource>@(DnuSourceList -> '--source %(Identity)', ' ')</DnuRestoreSource>
    <DnuRestoreCommand>"$(DnuToolPath)"</DnuRestoreCommand>
    <DnuRestoreCommand>$(DnuRestoreCommand) restore</DnuRestoreCommand>
    <DnuRestoreCommand Condition="'$(ParallelRestore)'=='true'">$(DnuRestoreCommand) --parallel</DnuRestoreCommand>
    <DnuRestoreCommand>$(DnuRestoreCommand) --packages "$(PackagesDir.TrimEnd('/\'.ToCharArray()))" $(DnuRestoreSource)</DnuRestoreCommand>
    <DnuRestoreCommand Condition="'$(LockDependencies)' == 'true'">$(DnuRestoreCommand) --lock</DnuRestoreCommand>
  </PropertyGroup>
  <!-- Create a collection of all project.json files for dependency updates. -->
  <ItemGroup>
    <ProjectJsonFiles Include="$(SourceDir)**\project.json" />
  </ItemGroup>
  <PropertyGroup Condition="'$(BuildAllProjects)'=='true'">
    <!-- When we do a traversal build we get all packages up front, don't restore them again -->
    <RestorePackages>false</RestorePackages>
  </PropertyGroup>
  <!--
    On Unix we always use a version of Roslyn we restore from NuGet and we have to work around some known issues.
  -->
  <PropertyGroup Condition="'$(OsEnvironment)'=='Unix'">
    <RoslynPackageDir>$(PackagesDir)/$(RoslynPackageName).$(RoslynVersion)/</RoslynPackageDir>
    <RoslynPropsFile>$(RoslynPackageDir)build/Microsoft.Net.ToolsetCompilers.props</RoslynPropsFile>
    <!--
      PDB support isn't implemented yet. https://github.com/dotnet/roslyn/issues/2449
      Note that both DebugSymbols and DebugType need set or project references will assume they need to copy pdbs and fail.
    -->
    <DebugSymbols>false</DebugSymbols>
    <DebugType>none</DebugType>
    <!--
      Delay signing with the ECMA key currently doesn't work.
      https://github.com/dotnet/roslyn/issues/2444
    -->
    <UseECMAKey>false</UseECMAKey>
    <!--
      Mono currently doesn't include VB targets for portable, notably /lib/mono/xbuild/Microsoft/Portable/v4.5/Microsoft.Portable.VisualBasic.targets.
      Fixed in https://github.com/mono/mono/pull/1726.
    -->
    <IncludeVbProjects>false</IncludeVbProjects>
    <!--
      Building packages fails for two reasons.
      First, nuget doesn't like the paths in the nuspec having backslashes as directory separators.
      Second, we aren't yet building pdbs, which the nuspecs specify.
    -->
    <SkipBuildPackages>true</SkipBuildPackages>
  </PropertyGroup>
  <PropertyGroup>
    <!-- By default make all libraries to be AnyCPU but individual projects can override it if they need to -->
    <Platform>AnyCPU</Platform>
    <OutputType>Library</OutputType>
  </PropertyGroup>
  <!--
  Projects that have no OS-specific implementations just use Debug and Release for $(Configuration).
  Projects that do have OS-specific implementations use OS_Debug and OS_Release, for all OS's we support even
  if the code is the same between some OS's (so if you have some project that just calls POSIX APIs, we still have
  OSX_[Debug|Release] and Linux_[Debug|Release] configurations.  We do this so that we place all the output under
  a single binary folder and can have a similar experience between the command line and Visual Studio.
  -->
  <!--
  If Configuration is empty that means we are not being built in VS and so folks need to explicitly pass the different
  values for $(ConfigurationGroup), $(TargetGroup), or $(OSGroup) or accept the defaults for them.
  -->
  <PropertyGroup Condition="'$(Configuration)'==''">
    <ConfigurationGroup Condition="'$(ConfigurationGroup)'==''">Debug</ConfigurationGroup>
    <Configuration>$(ConfigurationGroup)</Configuration>
    <Configuration Condition="'$(TargetGroup)'!=''">$(TargetGroup)_$(Configuration)</Configuration>
    <Configuration Condition="'$(OSGroup)'!='' and '$(OSGroup)'!='AnyOS'">$(OSGroup)_$(Configuration)</Configuration>
  </PropertyGroup>
  <!--
  If Configuration is set then someone explicitly passed it in or we building from VS. In either case
  default $(ConfigurationGroup), $(TargetGroup), or $(OSGroup) from the Configuration if they aren't
  already explicitly set.
  -->
  <PropertyGroup Condition="'$(Configuration)'!=''">
    <ConfigurationGroup Condition="'$(ConfigurationGroup)'=='' and $(Configuration.EndsWith('Debug'))">Debug</ConfigurationGroup>
    <ConfigurationGroup Condition="'$(ConfigurationGroup)'=='' and $(Configuration.EndsWith('Release'))">Release</ConfigurationGroup>
    <ConfigurationGroup Condition="'$(ConfigurationGroup)'==''">Debug</ConfigurationGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('Windows'))">Windows_NT</OSGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('Linux'))">Linux</OSGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('OSX'))">OSX</OSGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('FreeBSD'))">FreeBSD</OSGroup>
    <OSGroup Condition="'$(OSGroup)'==''">AnyOS</OSGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('netcore50aot'))">netcore50aot</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('netcore50'))">netcore50</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('dnxcore50'))">dnxcore50</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('net462'))">net462</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('net461'))">net461</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('net46'))">net46</TargetGroup>
    <TargetGroup Condition="'$(TargetGroup)'=='' and $(Configuration.Contains('net45'))">net45</TargetGroup>
  </PropertyGroup>
  <!-- Set up Default symbol and optimization for Configuration -->
  <Choose>
    <When Condition="'$(ConfigurationGroup)'=='Debug'">
      <PropertyGroup>
        <DebugSymbols Condition="'$(DebugSymbols)' == ''">true</DebugSymbols>
        <Optimize Condition="'$(Optimize)' == ''">false</Optimize>
        <DebugType Condition="'$(DebugType)' == ''">full</DebugType>
        <DefineConstants>$(DefineConstants),DEBUG,TRACE</DefineConstants>
      </PropertyGroup>
    </When>
    <When Condition="'$(ConfigurationGroup)' == 'Release'">
      <PropertyGroup>
        <DebugSymbols Condition="'$(DebugSymbols)' == ''">true</DebugSymbols>
        <Optimize Condition="'$(Optimize)' == ''">true</Optimize>
        <DebugType Condition="'$(DebugType)' == ''">pdbonly</DebugType>
        <DefineConstants>$(DefineConstants),TRACE</DefineConstants>
      </PropertyGroup>
    </When>
    <Otherwise>
      <PropertyGroup>
        <ConfigurationErrorMsg>$(ConfigurationErrorMsg);Unknown ConfigurationGroup [$(ConfigurationGroup)] specificed in your project.</ConfigurationErrorMsg>
      </PropertyGroup>
    </Otherwise>
  </Choose>
  <!-- Setup properties per OSGroup -->
  <Choose>
    <When Condition="'$(OSGroup)'=='AnyOS'">
      <PropertyGroup />
    </When>
    <When Condition="'$(OSGroup)'=='Windows_NT'">
      <PropertyGroup>
        <TargetsWindows>true</TargetsWindows>
        <TestNugetRuntimeId>win7-x64</TestNugetRuntimeId>
      </PropertyGroup>
    </When>
    <When Condition="'$(OSGroup)'=='Linux'">
      <PropertyGroup>
        <TargetsUnix>true</TargetsUnix>
        <TargetsLinux>true</TargetsLinux>
        <TestNugetRuntimeId>ubuntu.14.04-x64</TestNugetRuntimeId>
      </PropertyGroup>
    </When>
    <When Condition="'$(OSGroup)'=='OSX'">
      <PropertyGroup>
        <TargetsUnix>true</TargetsUnix>
        <TargetsOSX>true</TargetsOSX>
        <TestNugetRuntimeId>osx.10.10-x64</TestNugetRuntimeId>
      </PropertyGroup>
    </When>
    <When Condition="'$(OSGroup)'=='FreeBSD'">
      <PropertyGroup>
        <TargetsUnix>true</TargetsUnix>
        <TargetsFreeBSD>true</TargetsFreeBSD>
        <TestNugetRuntimeId>ubuntu.14.04-x64</TestNugetRuntimeId>
      </PropertyGroup>
    </When>
    <Otherwise>
      <PropertyGroup>
        <ConfigurationErrorMsg>$(ConfigurationErrorMsg);Unknown OSGroup [$(OSGroup)] specificed in your project.</ConfigurationErrorMsg>
      </PropertyGroup>
    </Otherwise>
  </Choose>
  <PropertyGroup>
    <TargetsUnknownUnix Condition="'$(TargetsUnix)' == 'true' AND '$(OSGroup)' != 'FreeBSD' AND '$(OSGroup)' != 'Linux' AND '$(OSGroup)' != 'OSX'">true</TargetsUnknownUnix>
  </PropertyGroup>
  <!-- Setup properties per TargetGroup -->
  <Choose>
    <When Condition="'$(TargetGroup)'==''">
      <PropertyGroup />
    </When>
    <When Condition="'$(TargetGroup)'=='netcore50'">
      <PropertyGroup>
        <PackageTargetFramework>netcore50</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.Private.NetNative</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETCore,Version=v5.0</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='netcore50aot'">
      <PropertyGroup>
        <PackageTargetFramework>netcore50</PackageTargetFramework>
        <PackageTargetRuntime>aot</PackageTargetRuntime>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.Private.NetNative</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETCore,Version=v5.0</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='dnxcore50'">
      <PropertyGroup>
        <PackageTargetFramework>dnxcore50</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.Private.CoreCLR</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>DNXCore,Version=v5.0</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='net462'">
      <PropertyGroup>
        <PackageTargetFramework>net462</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.NETFramework.v4.6.2</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETFramework,Version=v4.6.2</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='net461'">
      <PropertyGroup>
        <PackageTargetFramework>net461</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.NETFramework.v4.6.1</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETFramework,Version=v4.6.1</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='net46'">
      <PropertyGroup>
        <PackageTargetFramework>net46</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.NETFramework.v4.6</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETFramework,Version=v4.6</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <When Condition="'$(TargetGroup)'=='net45'">
      <PropertyGroup>
        <PackageTargetFramework>net45</PackageTargetFramework>
        <TargetingPackNugetPackageId>Microsoft.TargetingPack.NETFramework.v4.5</TargetingPackNugetPackageId>
        <NuGetTargetMoniker>.NETFramework,Version=v4.5</NuGetTargetMoniker>
      </PropertyGroup>
    </When>
    <Otherwise>
      <PropertyGroup>
        <ConfigurationErrorMsg>$(ConfigurationErrorMsg);Unknown TargetGroup [$(TargetGroup)] specificed in your project.</ConfigurationErrorMsg>
      </PropertyGroup>
    </Otherwise>
  </Choose>
  <!-- Provide defaults for ToolNugetRuntimeId -->
  <PropertyGroup Condition="'$(ToolNugetRuntimeId)'== ''">
    <ToolNugetRuntimeId Condition="'$(OsEnvironment)'=='Windows_NT'">win7-x64</ToolNugetRuntimeId>
    <!-- This is a bit of a hack because inside MSBuild we have no real concept of the host distro, so we'll assume
         that if you are building on not windows, your host OS is the same as your target.  If that's not
         the case, you'll have to provide your own ToolNugetRuntimeId, which is not the end of the world (build.sh will
         do this for you, for example). -->
    <ToolNugetRuntimeId Condition="'$(OsEnvironment)'=='Unix'">$(TestNugetRuntimeId)</ToolNugetRuntimeId>
  </PropertyGroup>
  <!-- Disable some standard properties for building our projects -->
  <PropertyGroup>
    <NoStdLib>true</NoStdLib>
    <NoExplicitReferenceToStdLib>true</NoExplicitReferenceToStdLib>
    <AddAdditionalExplicitAssemblyReferences>false</AddAdditionalExplicitAssemblyReferences>
    <GenerateTargetFrameworkAttribute>false</GenerateTargetFrameworkAttribute>
  </PropertyGroup>
  <!-- Set up handling of build warnings -->
  <PropertyGroup>
    <WarningLevel>4</WarningLevel>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  </PropertyGroup>
  <!-- Temporary until build/CI system is upgraded to C# 6: disable C# 6 features -->
  <PropertyGroup Condition="'$(MSBuildProjectExtension)' == '.csproj' OR '$(Language)' == 'C#'">
    <LangVersion>5</LangVersion>
  </PropertyGroup>
  <!-- Set up some common paths -->
  <PropertyGroup>
    <CommonPath>$(SourceDir)Common\src</CommonPath>
    <CommonTestPath>$(SourceDir)Common\tests</CommonTestPath>
  </PropertyGroup>
  <!-- Set up the default output and intermediate paths -->
  <PropertyGroup>
    <OSPlatformConfig>$(OSGroup).$(Platform).$(ConfigurationGroup)</OSPlatformConfig>
    <TargetOutputRelPath Condition="'$(TargetGroup)'!=''">$(TargetGroup)\</TargetOutputRelPath>
    <BaseOutputPath Condition="'$(BaseOutputPath)'==''">$(BinDir)</BaseOutputPath>
    <OutputPath Condition="'$(OutputPath)'==''">$(BaseOutputPath)$(OSPlatformConfig)\$(MSBuildProjectName)\$(TargetOutputRelPath)</OutputPath>
    <BaseIntermediateOutputPath Condition="'$(BaseIntermediateOutputPath)'==''">$(ObjDir)</BaseIntermediateOutputPath>
    <IntermediateOutputRootPath Condition="'$(IntermediateOutputRootPath)' == ''">$(BaseIntermediateOutputPath)$(OSPlatformConfig)\</IntermediateOutputRootPath>
    <IntermediateOutputPath Condition="'$(IntermediateOutputPath)' == ''">$(IntermediateOutputRootPath)$(MSBuildProjectName)\$(TargetOutputRelPath)</IntermediateOutputPath>
    <TestPath Condition="'$(TestPath)'==''">$(TestWorkingDir)$(OSPlatformConfig)\$(MSBuildProjectName)\</TestPath>
    <PackagesBasePath Condition="'$(PackagesBasePath)'==''">$(BinDir)$(OSPlatformConfig)</PackagesBasePath>
  </PropertyGroup>
  <PropertyGroup>
    <!-- Don't run tests if we're building another platform's binaries on Windows -->
    <SkipTests Condition="'$(SkipTests)'=='' and ('$(OsEnvironment)'=='Windows_NT' and '$(TargetsWindows)'!='true' and '$(OSGroup)'!='AnyOS')">true</SkipTests>
  </PropertyGroup>
  <!--<Import Project="$(RoslynPropsFile)" Condition="'$(OsEnvironment)'=='Unix' and Exists('$(RoslynPropsFile)')" />-->
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\src\dir.props
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\src\System.Net.NameResolution\pkg\System.Net.NameResolution.pkgproj
============================================================================================================================================
-->
  <ItemGroup>
    <ProjectReference Include="..\ref\System.Net.NameResolution.csproj">
      <SupportedFramework>net46;netcore50;dnxcore50</SupportedFramework>
    </ProjectReference>
    <ProjectReference Include="win\System.Net.NameResolution.pkgproj" />
    <ProjectReference Include="unix\System.Net.NameResolution.pkgproj" />
  </ItemGroup>
  <ItemGroup>
    <InboxOnTargetFramework Include="MonoAndroid10" />
    <InboxOnTargetFramework Include="MonoTouch10" />
    <InboxOnTargetFramework Include="xamarinios10" />
    <InboxOnTargetFramework Include="xamarinmac20" />
  </ItemGroup>
  <!--
============================================================================================================================================
  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), dir.targets))\dir.targets">

e:\gh\chcosta\corefx\src\dir.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <ErrorIfBuildToolsRestoredFromIndividualProject Condition="!Exists('$(ToolsDir)')">true</ErrorIfBuildToolsRestoredFromIndividualProject>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="..\dir.targets">

e:\gh\chcosta\corefx\dir.targets
============================================================================================================================================
-->
  <Target Name="CheckForBuildTools">
    <Error Condition="!Exists('$(ToolsDir)') and '$(OverrideToolsDir)'=='true'" Text="The tools directory [$(ToolsDir)] does not exist. Please run sync in your enlistment to ensure the tools are installed before attempting to build an individual project." />
    <Error Condition="!Exists('$(ToolsDir)') and '$(OverrideToolsDir)'!='true'" Text="The tools directory [$(ToolsDir)] does not exist. Please run init-tools.cmd in your enlistment to ensure the tools are installed before attempting to build an individual project." />
  </Target>
  <!-- Provide default targets which can be hooked onto or overridden as necessary -->
  <Target Name="BuildAndTest" DependsOnTargets="Build;Test" />
  <Target Name="RebuildAndTest" DependsOnTargets="Rebuild;Test" />
  <Target Name="Test" />
  <!--
============================================================================================================================================
  <Import Project="$(ToolsDir)/Build.Common.targets">

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <BuildToolsTaskDir Condition="'$(BuildToolsTaskDir)' == ''">$(ToolsDir)</BuildToolsTaskDir>
    <!-- A number of the imports below depend on these default properties -->
    <IsTestProject Condition="'$(IsTestProject)'=='' And $(MSBuildProjectName.EndsWith('.Tests'))">true</IsTestProject>
    <AssemblyVersion Condition="'$(AssemblyVersion)'==''">999.999.999.999</AssemblyVersion>
    <CLSCompliant Condition="'$(CLSCompliant)'=='' and '$(IsTestProject)'=='true'">false</CLSCompliant>
    <CLSCompliant Condition="'$(CLSCompliant)'==''">true</CLSCompliant>
    <!--
      Check if the project has been localized by looking for the existence of the .de.xlf file.  By convention, we assume that if 
      a project is localized in German, then it is localized in all languages.
    -->
    <ExcludeLocalizationImport Condition="'$(ExcludeLocalizationImport)'=='' And !Exists('$(MSBuildProjectDirectory)\MultilingualResources\$(MSBuildProjectName).de.xlf')">true</ExcludeLocalizationImport>
  </PropertyGroup>
  <!--
    Import the provides support for EnsureBuildToolsRuntime target which will restore a .NET Core based 
    runtime and setup a $(ToolRuntimePath) and $(ToolHost) for others to consume.
    
    This must be imported before any tools that need to use it are imported.
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)toolruntime.targets" Condition="'$(ExcludeToolRuntimeImport)' != 'true'">

e:\gh\chcosta\corefx\Tools\toolruntime.targets
============================================================================================================================================
-->
  <UsingTask TaskName="PrereleaseResolveNuGetPackageAssets" AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" />
  <PropertyGroup>
    <!-- Invoke with the correct casing of corerun per-OS.  There are some process Tools
         that check the invoked process name against known casing which fail under code coverage.
         This is probably because the code coverage target invocation does not canonicalize the
         process name. -->
    <ToolHost Condition="'$(OS)' == 'Windows_NT'">CoreRun.exe</ToolHost>
    <ToolHost Condition="'$(OS)' != 'Windows_NT'">corerun</ToolHost>
    <ToolTargetFramework Condition="'$(ToolTargetFramework)' == ''">DNXCore,Version=v5.0</ToolTargetFramework>
    <ToolArchitecture Condition="'$(ToolArchitecture)' == ''">x64</ToolArchitecture>
    <ToolNugetRuntimeId Condition="'$(ToolNugetRuntimeId)' == ''">win7-$(ToolArchitecture)</ToolNugetRuntimeId>
    <ToolRuntimePath Condition="'$(ToolRuntimePath)' == ''">$(ProjectDir)Tools\</ToolRuntimePath>
    <ToolHostCmd>"$(ToolRuntimePath)$(ToolHost)"</ToolHostCmd>
    <!-- If COMPLUS_InstallRoot is set clear it before calling the ToolHost otherwise some root activations like PDB COM activation will fail -->
    <ToolHostCmd Condition="'$(COMPLUS_InstallRoot)' != ''">(set COMPLUS_InstallRoot=) &amp; $(ToolHostCmd)</ToolHostCmd>
  </PropertyGroup>
  <Target Name="EnsureBuildToolsRuntime">
    <Error Condition="!Exists('$(ToolRuntimePath)')" Text="The Tool Runtime directory [$(ToolRuntimePath)] does not exist. Please run $(SourceDir)Build.cmd to ensure the tools are installed before attempting to build an individual project." />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!--
    Import the reference assembly targets
    
    This must be imported early because it modifies OutputPath and IntermediateOutputPath
    used by other targets
    
      Depends on Properties:
        AssemblyVersion - Needed to determine API version used in
    
      Sets Properties:
        IsReferenceAssembly - Set if the project is in the ref assm path
        APIVersion - Major.Minor assembly version for the project
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)ReferenceAssemblies.targets" Condition="'$(ExcludeReferenceAssembliesImport)'!='true'">

e:\gh\chcosta\corefx\Tools\ReferenceAssemblies.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <IsReferenceAssembly Condition="'$(IsReferenceAssembly)'=='' AND ($(MSBuildProjectFullPath.Contains('\ref\')) OR $(MSBuildProjectFullPath.Contains('/ref/')))">true</IsReferenceAssembly>
    <!-- The first two parts of the assembly version represent API version, 
         the third part is for bugfixes, the fourth is for hotfixes/securtity-updates -->
    <APIVersion>$([System.Version]::Parse('$(AssemblyVersion)').ToString(2))</APIVersion>
    <_usingRoslyn Condition="'$(MSBuildToolsVersion)' == 'dogfood' OR '$(MSBuildToolsVersion)' &gt;= '14.0'">true</_usingRoslyn>
    <!-- Roslyn requires the runtimemetadataversion parameter when building a core assembly -->
    <CompilerResponseFile Condition="'$(IsCoreAssembly)' == 'true' AND '$(_usingRoslyn)' == 'true'">$(MSBuildThisFileDirectory)coreAssembly.rsp</CompilerResponseFile>
    <!-- Create a common root output directory for all reference assemblies -->
    <ReferenceAssemblyOutputPath Condition="'$(ReferenceAssemblyOutputPath)' == ''">$(BaseOutputPath)ref\</ReferenceAssemblyOutputPath>
  </PropertyGroup>
  <PropertyGroup Condition="'$(IsReferenceAssembly)'=='true'">
    <AssemblyName Condition="'$(AssemblyName)' == ''">$(MSBuildProjectName)</AssemblyName>
    <OutputPath>$(ReferenceAssemblyOutputPath)$(AssemblyName)\$(AssemblyVersion)</OutputPath>
    <IntermediateOutputPath>$(BaseIntermediateOutputPath)ref\$(AssemblyName)\$(AssemblyVersion)</IntermediateOutputPath>
    <OmitTransitiveCompileReferences>true</OmitTransitiveCompileReferences>
    <!-- if this is a reference assembly deployment project use compile assets 
         instead of runtime -->
    <NuGetDeploySourceItem>Reference</NuGetDeploySourceItem>
  </PropertyGroup>
  <ItemGroup Condition="'$(IsReferenceAssembly)'=='true'">
    <!-- All reference assemblies are marked APTCA. An internal tool used to generate reference 
         assembly source normalizes the security annotations from seed -> reference assembly 
         under that assumption. -->
    <!-- NOTE: Reference assemblies are not executable so this is for reference only and does 
         not provide any security privileges at runtime. -->
    <AssemblyInfoLines Include="[assembly:System.Security.AllowPartiallyTrustedCallers]" />
    <!-- All reference assemblies should have the 0x70 flag which prevents them from loading 
         and the ReferenceAssemblyAttribute. -->
    <AssemblyInfoLines Include="[assembly:System.Runtime.CompilerServices.ReferenceAssembly]" />
    <AssemblyInfoLines Include="[assembly:System.Reflection.AssemblyFlags((System.Reflection.AssemblyNameFlags)0x70)]" />
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)Packaging.targets" Condition="'$(ExcludePackagingImport)'!='true' AND '$(MSBuildProjectExtension)' == '.pkgproj'">

e:\gh\chcosta\corefx\Tools\Packaging.targets
============================================================================================================================================
-->
  <!-- The following properties are expected to change as we transition from
       Beta -> RC - RTM. We should set $(IncludeBuildNumberInPackageVersion)
       to false for the Beta/RC builds that get uploaded to NuGet.
  -->
  <PropertyGroup>
    <Version Condition="'$(StableVersion)' != ''">$(StableVersion)</Version>
    <PreReleaseLabel Condition="'$(PreReleaseLabel)' == ''">rc2</PreReleaseLabel>
    <IncludeBuildNumberInPackageVersion Condition="'$(IncludeBuildNumberInPackageVersion)' == ''">true</IncludeBuildNumberInPackageVersion>
    <VersionSuffix Condition="'$(PreReleaseLabel)' != ''">-$(PreReleaseLabel)</VersionSuffix>
    <VersionSuffix Condition="'$(IncludeBuildNumberInPackageVersion)' == 'true'">$(VersionSuffix)-$(BuildNumberMajor)</VersionSuffix>
    <!--
      Empty out the project properties because we want configuration and platform to come from the individual
      projects instead of being overridden by the value the packages have.
    -->
    <ProjectProperties />
    <PackageRevStableToPrerelease Condition="'$(PackageRevStableToPrerelease)' == ''">false</PackageRevStableToPrerelease>
    <DependencyRevStableToPrerelease Condition="'$(PackageRevStableToPrerelease)' == ''">false</DependencyRevStableToPrerelease>
    <!-- By default we'll build libraries referenced by packages -->
    <BuildPackageLibraryReferences Condition="'$(BuildPackageLibraryReferences)' == ''">true</BuildPackageLibraryReferences>
  </PropertyGroup>
  <PropertyGroup Condition="'$(IsRuntimePackage)' == 'true' or '$(PackageTargetRuntime)' != ''">
    <IdPrefix>runtime.</IdPrefix>
    <IdPrefix Condition="'$(PackageTargetRuntime)' != ''">$(IdPrefix)$(PackageTargetRuntime).</IdPrefix>
    <IdPrefix Condition="'$(PackageTargetFramework)' != ''">$(IdPrefix)$(PackageTargetFramework).</IdPrefix>
  </PropertyGroup>
  <!--
       NuSpec configuration.

       NOTE: It's by design that these properties override the project. We don't
       want projects to specify any metadata, most of the metadata should be
       the same for all packages, and the rest will be centralized.
  -->
  <PropertyGroup>
    <BaseId>$(MSBuildProjectName)</BaseId>
    <Id>$(IdPrefix)$(BaseId)</Id>
    <!-- It is by design that the Title matches the Id. We want users to get an assembly view. -->
    <Title>$(Id)</Title>
    <Authors>Microsoft</Authors>
    <Owners>microsoft,dotnetframework</Owners>
    <Description>TODO</Description>
    <ReleaseNotes />
    <ProjectUrl />
    <LicenseUrl>http://go.microsoft.com/fwlink/?LinkId=329770</LicenseUrl>
    <IconUrl>http://go.microsoft.com/fwlink/?LinkID=288859</IconUrl>
    <Copyright>c Microsoft Corporation.  All rights reserved.</Copyright>
    <Tags />
    <RequireLicenseAcceptance>true</RequireLicenseAcceptance>
    <!-- we depend on nuget v3 behavior -->
    <MinClientVersion Condition="'$(MinClientVersion)' == ''">3.0</MinClientVersion>
  </PropertyGroup>
  <!-- Shared properties -->
  <PropertyGroup>
    <PackageOutputPath Condition="'$(PackageOutputPath)' == ''">$(BaseOutputPath)pkg\</PackageOutputPath>
    <OutputPath>$(PackageOutputPath)</OutputPath>
    <NuSpecOutputPath Condition="'$(NuSpecOutputPath)' == ''">$(PackageOutputPath)specs\</NuSpecOutputPath>
    <NuSpecPath>$(NuSpecOutputPath)$(Id)$(NuspecSuffix).nuspec</NuSpecPath>
    <RuntimeFilePath Condition="'$(RuntimeFilePath)' == ''">$(NuSpecOutputPath)$(Id)$(NuspecSuffix)\runtime.json</RuntimeFilePath>
    <PlaceholderFile>$(MSBuildThisFileDirectory)_._</PlaceholderFile>
    <PackageDescriptionFile Condition="'$(PackageDescriptionFile)' == ''">path to descriptions.json must be specified</PackageDescriptionFile>
    <RuntimeIdGraphDefinitionFile Condition="'$(RuntimeIdGraphDefinitionFile)' == ''">$(MSBuildThisFileDirectory)runtime.json</RuntimeIdGraphDefinitionFile>
    <FrameworkListsPath Condition="'$(FrameworkListsPath)' == ''">$(MSBuildThisFileDirectory)FrameworkLists</FrameworkListsPath>
    <ValidationSuppressionFile Condition="'$(ValidationSuppressionFile)' == ''">ValidationSuppression.txt</ValidationSuppressionFile>
    <SyncInfoFile Condition="'$(SyncInfoFile)' == ''">unspecified</SyncInfoFile>
    <PackagingTaskDir Condition="'$(PackagingTaskDir)' == ''">$(MSBuildThisFileDirectory)</PackagingTaskDir>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="stable.packages.targets">

e:\gh\chcosta\corefx\Tools\stable.packages.targets
============================================================================================================================================
-->
  <ItemGroup>
    <!-- Packages shipped stable at Dev14 RTM -->
    <StablePackage Include="Microsoft.CSharp">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.VisualBasic">
      <Version>10.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.Win32.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.AppContext">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Collections.Concurrent">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Collections">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Collections.NonGeneric">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Collections.Specialized">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.Annotations">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.EventBasedAsync">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.TypeConverter">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Data.Common">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Contracts">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Debug">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.StackTrace">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Tools">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Tracing">
      <Version>4.0.20</Version>
    </StablePackage>
    <StablePackage Include="System.Dynamic.Runtime">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Globalization">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Globalization.Calendars">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Globalization.Extensions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.Compression">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.Compression.ZipFile">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.IO.FileSystem.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.FileSystem">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.UnmanagedMemoryStream">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Linq">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Linq.Expressions">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Linq.Queryable">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Linq.Parallel">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Http">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Http.Rtc">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.NetworkInformation">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Primitives">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Requests">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Sockets">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.WebHeaderCollection">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Numerics.Vectors">
      <Version>4.1.0</Version>
    </StablePackage>
    <StablePackage Include="System.ObjectModel">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Context">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.DispatchProxy">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Extensions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.TypeExtensions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Resources.ResourceManager">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime">
      <Version>4.0.20</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Extensions">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.InteropServices">
      <Version>4.0.20</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.InteropServices.WindowsRuntime">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Handles">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Numerics">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Serialization.Json">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Serialization.Primitives">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Serialization.Xml">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.WindowsRuntime">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.WindowsRuntime.UI.Xaml">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Security.Claims">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Security.Principal">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Duplex">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Http">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.NetTcp">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Security">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Text.Encoding">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Text.Encoding.CodePages">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Text.Encoding.Extensions">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Text.RegularExpressions">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Threading">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Tasks">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Tasks.Parallel">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Timer">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Overlapped">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.ReaderWriter">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XDocument">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XmlDocument">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XmlSerializer">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XPath">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XPath.XDocument">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XPath.XmlDocument">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.IsolatedStorage">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore">
      <Version>5.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Platforms">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Portable.Compatibility">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Runtime">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Runtime.CoreCLR-arm">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Runtime.CoreCLR-x64">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Runtime.CoreCLR-x86">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Runtime.Native">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Targets">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Targets.DNXCore">
      <Version>4.9.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Targets.NETFramework">
      <Version>4.6.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Targets.UniversalWindowsPlatform">
      <Version>5.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.UniversalWindowsPlatform">
      <Version>5.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Windows.ApiSets-x86">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="Microsoft.NETCore.Windows.ApiSets-x64">
      <Version>1.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Collections.Immutable">
      <Version>1.1.37</Version>
    </StablePackage>
    <StablePackage Include="System.IO.Compression.clrcompression-arm">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.Compression.clrcompression-x64">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO.Compression.clrcompression-x86">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Numerics.Vectors.WindowsRuntime">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Private.Uri">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Private.Networking">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Private.ServiceModel">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Private.DataContractSerialization">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Emit">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Emit.ILGeneration">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Emit.Lightweight">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Metadata">
      <Version>1.0.22</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection.Metadata">
      <Version>1.1.0</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Tasks.Dataflow">
      <Version>4.5.25</Version>
    </StablePackage>
    <StablePackage Include="System.Numerics.Vectors.WindowsRuntime">
      <Version>4.0.0</Version>
    </StablePackage>
    <!-- Dowlevel packages that shipped in a previous release -->
    <StablePackage Include="System.Collections.Concurrent">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Collections">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.Annotations">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ComponentModel.EventBasedAsync">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Debug">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Tracing">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Diagnostics.Tracing">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Dynamic.Runtime">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Globalization">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.IO">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Linq.Expressions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Primitives">
      <Version>3.9.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Requests">
      <Version>3.9.0</Version>
    </StablePackage>
    <StablePackage Include="System.Net.Requests">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ObjectModel">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Reflection">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Extensions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.InteropServices">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.InteropServices">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Serialization.Primitives">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.Serialization.Xml">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime.WindowsRuntime">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Runtime">
      <Version>4.0.10</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Http">
      <Version>3.9.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Http">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Primitives">
      <Version>3.9.0</Version>
    </StablePackage>
    <StablePackage Include="System.ServiceModel.Security">
      <Version>3.9.0</Version>
    </StablePackage>
    <StablePackage Include="System.Text.Encoding.Extensions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Text.Encoding">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Text.RegularExpressions">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Threading.Tasks">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Threading">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.ReaderWriter">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XDocument">
      <Version>4.0.0</Version>
    </StablePackage>
    <StablePackage Include="System.Xml.XmlSerializer">
      <Version>4.0.0</Version>
    </StablePackage>
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Packaging.targets
============================================================================================================================================
-->
  <!-- If this package explicitly sets the StableVersion then add it to the stable list -->
  <ItemGroup Condition="'$(StableVersion)' != ''">
    <StablePackage Include="$(MSBuildProjectName)">
      <Version>$(StableVersion)</Version>
    </StablePackage>
  </ItemGroup>
  <UsingTask TaskName="ApplyPreReleaseSuffix" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GetAssemblyReferences" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GenerateRuntimeDependencies" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GetPackageDescription" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GetInboxFrameworks" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GetPackageVersion" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="EnsureOOBFramework" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="ValidatePackage" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="CreateTrimDependencyGroups" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="GenerateNuSpec" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <UsingTask TaskName="NuGetPack" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <!-- Determine if we actually need to build for this architecture -->
  <!-- Packages can specifically control their architecture by specifying the PackagePlatforms
       property as a semi-colon delimited list.
       If this is not done then the package will build if the target runtime contains the current
       architecture or if we're building for x86. -->
  <PropertyGroup>
    <PackagePlatform Condition="'$(PackagePlatform)' == ''">$(Platform)</PackagePlatform>
    <PackagePlatform Condition="'$(PackagePlatform)' == 'amd64'">x64</PackagePlatform>
    <!-- build if the package specifically requests current architecture via PackagePlatforms -->
    <ShouldGenerateNuSpec Condition="$(PackagePlatforms.Contains('$(PackagePlatform);'))">true</ShouldGenerateNuSpec>
    <!-- build if PackagePlatforms is not specified and the PackageTargetRuntime contains the current architecture -->
    <ShouldGenerateNuSpec Condition="'$(PackagePlatforms)' == '' AND $(PackageTargetRuntime.Contains('-$(PackagePlatform)'))">true</ShouldGenerateNuSpec>
    <!-- build if PackagePlatforms is not specified and arch is x86 or AnyCPU -->
    <ShouldGenerateNuSpec Condition="'$(PackagePlatforms)' == '' AND ('$(PackagePlatform)' == 'x86' OR '$(PackagePlatform)' == 'AnyCPU')">true</ShouldGenerateNuSpec>
    <!-- if we built a nuspec, also pack unless explicitly set -->
    <ShouldCreatePackage Condition="'$(ShouldCreatePackage)' == ''">$(ShouldGenerateNuSpec)</ShouldCreatePackage>
    <BuildDependsOn Condition="'$(ShouldGenerateNuSpec)' == 'true'">GenerateNuSpec</BuildDependsOn>
    <BuildDependsOn Condition="'$(ShouldCreatePackage)' == 'true'">$(BuildDependsOn);CreatePackage</BuildDependsOn>
  </PropertyGroup>
  <!-- Redefine build to just create the NuSpec only, we'll create the package during ArcProjects phase -->
  <Target Name="Build" DependsOnTargets="$(BuildDependsOn)">
    <Message Condition="'$(ShouldGenerateNuSpec)' == 'true'" Text="$(MSBuildProjectName) -&gt; $(NuSpecPath)" Importance="high" />
    <Message Condition="'$(ShouldGenerateNuSpec)' != 'true'" Text="Skipping nuspec generation for this platform." Importance="high" />
  </Target>
  <Target Name="Clean">
    <!-- package version is calculated so read the last version from the marker file. -->
    <ReadLinesFromFile File="$(NuSpecPath).pkgpath" Condition="Exists('$(NuSpecPath).pkgpath')">
      <Output TaskParameter="Lines" ItemName="_ToBeDeleted" />
    </ReadLinesFromFile>
    <ItemGroup>
      <_ToBeDeleted Include="$(NuSpecPath)" />
      <_ToBeDeleted Include="$(NuSpecPath).pkgpath" />
      <_ToBeDeleted Include="$(RuntimeFilePath)" />
    </ItemGroup>
    <Delete Files="@(_ToBeDeleted)" />
  </Target>
  <Target Name="Rebuild" DependsOnTargets="Clean;Build" />
  <Target Name="SplitProjectReferences" DependsOnTargets="_GetProjectClosure">
    <ItemGroup>
      <!-- Split direct and indirect project dependencies -->
      <_PkgProjProjectReferenceClosure Include="@(_ProjectReferenceClosure)" Condition="'%(_ProjectReferenceClosure.Extension)' == '.pkgproj'" />
      <_NonPkgProjProjectReferenceClosure Include="@(_ProjectReferenceClosure)" Condition="'%(_ProjectReferenceClosure.Extension)' != '.pkgproj'" />
      <!-- Split direct project dependencies -->
      <_PkgProjProjectReference Include="@(_PkgProjProjectReferenceClosure)" Condition="'%(DependencyKind)' == 'Direct'" />
      <_NonPkgProjProjectReference Include="@(_NonPkgProjProjectReferenceClosure)" Condition="'%(DependencyKind)' == 'Direct'" />
    </ItemGroup>
  </Target>
  <Target Name="GetPkgProjPackageDependencies" Returns="@(PkgProjDependency)" Inputs="%(_PkgProjProjectReferenceClosure.DependencyKind)" Outputs="fake" DependsOnTargets="SplitProjectReferences">
    <MSBuild Targets="GetPackageIdentity" Projects="@(_PkgProjProjectReferenceClosure)" Properties="%(_PkgProjProjectReferenceClosure.SetConfiguration); %(_PkgProjProjectReferenceClosure.SetPlatform)">
      <Output TaskParameter="TargetOutputs" ItemName="_PkgProjDependency" />
    </MSBuild>
    <ItemGroup>
      <PkgProjDependency Include="@(_PkgProjDependency)">
        <DependencyKind>%(_PkgProjProjectReferenceClosure.DependencyKind)</DependencyKind>
      </PkgProjDependency>
    </ItemGroup>
  </Target>
  <Target Name="GetFiles" Returns="@(File)" DependsOnTargets="ConvertItems" />
  <Target Name="ConvertItems" DependsOnTargets="ExpandProjectReferences">
    <CreateItem Include="@(ProjectReferenceOutput)">
      <Output TaskParameter="Include" ItemName="File" />
    </CreateItem>
    <ItemGroup>
      <_LinkedContentFiles Include="@(Content)" Condition="'%(Content.Link)' != ''" />
      <_UnlinkedContentFiles Include="@(Content)" Condition="'%(Content.Link)' == ''" />
    </ItemGroup>
    <CreateItem Include="@(_LinkedContentFiles)" AdditionalMetadata="TargetPath=%(Link)">
      <Output TaskParameter="Include" ItemName="File" />
    </CreateItem>
    <CreateItem Include="@(_UnlinkedContentFiles)" AdditionalMetadata="TargetPath=%(RelativeDir)">
      <Output TaskParameter="Include" ItemName="File" />
    </CreateItem>
    <!-- We need to special case library files in later phases. In order to make this
         easier, we add custom metadata 'IsLibrary' that indicates whether the file is
         targeting the lib folder or not. -->
    <ItemGroup>
      <_FileWithIsLibrary Include="@(File)" Condition="'%(File.TargetPath)' == 'lib' OR&#xD;&#xA;                                     $([System.String]::Copy('%(File.TargetPath)').ToLower().StartsWith('lib\')) OR&#xD;&#xA;                                     $([System.String]::Copy('%(File.TargetPath)').ToLower().StartsWith('lib/'))">
        <PackageDirectory>Lib</PackageDirectory>
      </_FileWithIsLibrary>
      <_FileWithIsLibrary Include="@(File)" Condition="'%(File.TargetPath)' != 'lib' AND&#xD;&#xA;                                     !$([System.String]::Copy('%(File.TargetPath)').ToLower().StartsWith('lib\')) AND&#xD;&#xA;                                     !$([System.String]::Copy('%(File.TargetPath)').ToLower().StartsWith('lib/'))">
        <PackageDirectory />
      </_FileWithIsLibrary>
      <File Remove="@(File)" />
      <File Include="@(_FileWithIsLibrary)" />
    </ItemGroup>
  </Target>
  <Target Name="GetPackageDependencies" DependsOnTargets="AssignPkgProjPackageDependenciesTargetFramework;GetNuGetPackageDependencies" Returns="@(Dependency)">
    <ItemGroup>
      <Dependency Include="@(PkgProjDependency)" Condition="'%(PkgProjDependency.DependencyKind)' == 'Direct'" />
      <Dependency Include="@(NuGetDependency)" Condition="'%(NuGetDependency.DependencyKind)' == 'Direct'" />
    </ItemGroup>
  </Target>
  <Target Name="GenerateNuSpec" DependsOnTargets="GetPackageDependencies;GenerateRuntimeDependencies;GetPackageFiles;$(VersionDependsOn)">
    <!-- Please Note:
         In order to avoid incremental build issues this target will always run.
         However, the task will make sure that it doesn't touch the file if the
         contents it would generate are identical to a previously generated
         nuspec. -->
    <GenerateNuSpec InputFileName="$(NuSpecTemplate)" OutputFileName="$(NuSpecPath)" MinClientVersion="$(MinClientVersion)" Id="$(Id)" Version="$(Version)" Title="$(Title)" Authors="$(Authors)" Owners="$(Owners)" Description="$(Description)" ReleaseNotes="$(ReleaseNotes)" Summary="$(Summary)" Language="$(Language)" ProjectUrl="$(ProjectUrl)" IconUrl="$(IconUrl)" LicenseUrl="$(LicenseUrl)" Copyright="$(Copyright)" RequireLicenseAcceptance="$(RequireLicenseAcceptance)" Tags="$(Tags)" DevelopmentDependency="$(DevelopmentDependency)" Dependencies="@(Dependency)" References="@(Reference)" FrameworkReferences="@(FrameworkReference)" Files="@(PackageFile)" />
  </Target>
  <PropertyGroup>
    <!-- exclude reference assets for runtime packages
         these assets are only packaged in the reference packages.  Even
         if they have a runtime asset we package it in the reference package
         for better compression.  -->
    <ExcludeReferenceAssets Condition="'$(ExcludeReferenceAssets)' == '' AND '$(PackageTargetRuntime)' != ''">true</ExcludeReferenceAssets>
  </PropertyGroup>
  <!-- We define a custom target: GetFilesToPackage which does a minimal build of the project
       and passes all information in a single item group.
       This helps minimize the number of project evaluations and targets that build in order
       to determine the contents of the package-->
  <Target Name="ExpandProjectReferences" DependsOnTargets="SplitProjectReferences">
    <!-- Only rebuild project references when specified -->
    <MSBuild Targets="Build" Condition="'$(BuildPackageLibraryReferences)' == 'true'" Projects="@(_NonPkgProjProjectReference)" Properties="$(ProjectProperties)" ContinueOnError="WarnAndContinue" />
    <MSBuild Targets="GetFilesToPackage" BuildInParallel="$(BuildInParallel)" Projects="@(_NonPkgProjProjectReference)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_FilesToPackage" />
    </MSBuild>
    <ItemGroup>
      <_FilesToPackage Remove="@(_FilesToPackage)" Condition="'$(ExcludeReferenceAssets)' == 'true' AND '%(_FilesToPackage.IsReferenceAsset)' == 'true'" />
      <File Include="@(_FilesToPackage)">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <!-- Some packages support legacy portable profiles where dependencies are provided by targeting pack -->
        <HarvestDependencies Condition="!$([System.String]::new('%(_FilesToPackage.TargetFramework)').StartsWith('portable-'))">true</HarvestDependencies>
      </File>
    </ItemGroup>
    <Error Condition="'$(SkipPackageFileCheck)' != 'true' AND&#xD;&#xA;                      '%(File.SkipPackageFileCheck)' != 'true' AND&#xD;&#xA;                      '%(File.FileName)' != '_' AND&#xD;&#xA;                      '%(File.FileName)%(File.Extension)' != 'runtime.json' AND&#xD;&#xA;                      !$(ID.Contains('%(File.FileName)'))" Text="Package $(ID) contains file with name %(File.FileName).  If this is expected you can disable this filename checking for this item or package by setting SkipPackageFileCheck = true" ContinueOnError="ErrorAndContinue" />
  </Target>
  <!-- Permit setting TargetFramework and add our own metadata (TargetRuntime) -->
  <Target Name="GetPackageIdentity" Returns="@(_PackageIdentity)" DependsOnTargets="$(VersionDependsOn)">
    <ItemGroup>
      <_PackageIdentity Include="$(Id)">
        <Version>$(Version)</Version>
        <TargetFramework Condition="'$(PackageTargetFramework)' != ''">$(PackageTargetFramework)</TargetFramework>
        <TargetRuntime Condition="'$(PackageTargetRuntime)' != ''">$(PackageTargetRuntime)</TargetRuntime>
      </_PackageIdentity>
    </ItemGroup>
  </Target>
  <!-- Don't actually walk the closure all the time, conditioned on GetClosure metadata on ProjectReference.
       Walking the closure is very expensive for many of our packages and is unecessary since we are very
       strict about assets that are included in the package.  -->
  <Target Name="_GetProjectClosure" DependsOnTargets="ConvertCommonMetadataToAdditionalProperties" Returns="@(_ProjectReferenceClosure)">
    <!-- Get closure of indirect references if they opt-in -->
    <MSBuild Projects="@(ProjectReference)" Targets="_GetProjectClosure" Properties="$(ProjectProperties)" ContinueOnError="WarnAndContinue" BuildInParallel="$(BuildInParallel)" Condition="'%(ProjectReference.GetClosure)' == 'true'">
      <Output TaskParameter="TargetOutputs" ItemName="_ProjectReferenceClosureWithDuplicates" />
    </MSBuild>
    <!-- Remove duplicates from closure -->
    <RemoveDuplicates Inputs="@(_ProjectReferenceClosureWithDuplicates)">
      <Output TaskParameter="Filtered" ItemName="_ProjectReferenceClosureWithoutMetadata" />
    </RemoveDuplicates>
    <ItemGroup>
      <!-- Remove references that are also direct references -->
      <_ProjectReferenceClosureWithoutMetadata Remove="%(ProjectReference.FullPath)" />
      <!-- We can now mark all the closure references as indirect -->
      <_ProjectReferenceClosure Include="@(_ProjectReferenceClosureWithoutMetadata)">
        <DependencyKind>Indirect</DependencyKind>
        <PackageDirectory>%(ProjectReference.PackageDirectory)</PackageDirectory>
      </_ProjectReferenceClosure>
      <!-- Now add the direct references, preserving metadata -->
      <_ProjectReferenceClosure Include="@(ProjectReference->'%(FullPath)')">
        <DependencyKind>Direct</DependencyKind>
      </_ProjectReferenceClosure>
    </ItemGroup>
  </Target>
  <Target Name="AssignPkgProjPackageDependenciesTargetFramework" DependsOnTargets="GetPkgProjPackageDependencies;GetFiles;EnsureOOBFramework">
    <ItemGroup>
      <!-- ensure that unconstrained dependencies are also expanded in constrained TFM groups -->
      <_PkgProjDependencyWithoutTFM Include="@(PkgProjDependency)" Condition="'%(PkgProjDependency.TargetFramework)' == '' AND '%(PkgProjDependency.DoNotExpand)' != 'true'" />
      <_AllPkgProjTFMs Include="%(PkgProjDependency.TargetFramework)" Condition="'%(PkgProjDependency.DependencyKind)' == 'Direct'" />
      <!-- Include file TFMs -->
      <_AllPkgProjTFMs Include="%(File.TargetFramework)" Condition="'%(File.TargetFramework)' != ''" />
      <!-- Remove dependencies without a TFM so they can be replaced -->
      <PkgProjDependency Remove="@(_PkgProjDependencyWithoutTFM)" />
      <!-- operate on pkgproj dependencies and file dependencies -->
      <PkgProjDependency Include="@(_PkgProjDependencyWithoutTFM)">
        <TargetFramework>%(_AllPkgProjTFMs.Identity)</TargetFramework>
      </PkgProjDependency>
    </ItemGroup>
  </Target>
  <!-- Don't do any filtering of files.
       We explicitly determine package content so we do not need to
       filter out files that come from dependent packages. -->
  <Target Name="GetPackageFiles" Returns="@(PackageFile)" DependsOnTargets="GetFiles;EnsureOOBFramework;$(VersionDependsOn)">
    <ItemGroup>
      <PackageFile Include="@(File)" />
      <PackageFile Condition="'%(PackageFile.PackageId)' == ''">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
      </PackageFile>
      <!-- Nuget will treat TargetPath as a directory if the extensions dont match,
           however we need to package files without an extension (Unix exectuables).
           As such nuget will always consider TargetPath to be a file path for these
           files.  Ensure that the TargetPath is the file path for these files. -->
      <PackageFile Condition="'%(Extension)' == ''">
        <TargetPath>%(PackageFile.TargetPath)/%(FileName)</TargetPath>
      </PackageFile>
    </ItemGroup>
  </Target>
  <!-- Harvest dependencies from assembly references.
       Assume version of package dependency == assembly version of dependency (3-part).
       For prerelease (not stable) packages apply a pre-release suffix to the dependency -->
  <Target Name="GetNuGetPackageDependencies" Returns="@(NuGetDependency)" DependsOnTargets="EnsureOOBFramework" Condition="'$(OmitDependencies)' != 'true'" Inputs="%(File.Identity);%(File.TargetFramework)" Outputs="fake">
    <!-- Generate package references based on assembly dependencies -->
    <GetAssemblyReferences Assemblies="@(File)" Condition="'%(File.HarvestDependencies)' == 'true' and '%(File.Extension)' == '.dll'">
      <Output TaskParameter="ReferencedAssemblies" ItemName="_FileReferencedAssemblies" />
    </GetAssemblyReferences>
    <PropertyGroup>
      <_IsClassicAssembly>false</_IsClassicAssembly>
      <_IsClassicAssembly Condition="'%(_FileReferencedAssemblies.FileName)' == 'mscorlib'">true</_IsClassicAssembly>
      <_IsClassicAssembly Condition="'%(_FileReferencedAssemblies.FileName)' == 'System.Private.Corelib'">true</_IsClassicAssembly>
      <_TargetFramework>%(File.TargetFramework)</_TargetFramework>
    </PropertyGroup>
    <ItemGroup Condition="'@(_FileReferencedAssemblies)' != ''">
      <_FilePackageReference Include="@(_FileReferencedAssemblies)" Exclude="corefx;mscorlib;System;System.Core;System.Xml;Windows">
        <AssemblyVersion>%(Version)</AssemblyVersion>
      </_FilePackageReference>
      <_FilePackageReference Remove="@(_FilePackageReference)" Condition="$([System.String]::new('%(Identity)').StartsWith('Internal.'))" />
      <_FilePackageReference Remove="@(_FilePackageReference)" Condition="$([System.String]::new('%(Identity)').StartsWith('System.Private.'))" />
      <_FilePackageReference Remove="@(PackageDependencyExclude)" />
      <!-- Projects may specify additional references by assembly name & identity that we'll process
           applying pre-release logic -->
      <_FilePackageReference Include="@(AdditionalAssemblyReference)" />
      <_FilePackageReference Condition="'%(Identity)' == '@(FileRuntimeDependency)'">
        <TargetRuntime>@(FileRuntimeDependency->'%(TargetRuntime)')</TargetRuntime>
      </_FilePackageReference>
    </ItemGroup>
    <ApplyPreReleaseSuffix Condition="'@(_FilePackageReference)' != ''" StablePackages="@(StablePackage)" OriginalPackages="@(_FilePackageReference)" PreReleaseSuffix="$(VersionSuffix)" RevStableToPrerelease="$(DependencyRevStableToPrerelease)">
      <Output TaskParameter="UpdatedPackages" ItemName="_FilePackageReferenceFinal" />
    </ApplyPreReleaseSuffix>
    <ItemGroup>
      <Dependency Condition="'$(_IsClassicAssembly)' != 'true' OR !$(_TargetFramework.StartsWith('net4'))" Include="@(_FilePackageReferenceFinal)">
        <TargetFramework Condition="'$(_TargetFramework)' != ''">$(_TargetFramework)</TargetFramework>
      </Dependency>
      <FrameworkReference Condition="'$(_IsClassicAssembly)' == 'true' AND $(_TargetFramework.StartsWith('net4'))" Include="%(_FileReferencedAssemblies.Identity)">
        <TargetFramework>$(_TargetFramework)</TargetFramework>
      </FrameworkReference>
    </ItemGroup>
  </Target>
  <!-- Walks every project gathering its AssemblyVersion, choosing the highest -->
  <!-- Skipped if the package explicitly defines a version -->
  <Target Name="GetAssemblyVersionFromProjects" Condition="$(Version) == ''" DependsOnTargets="ExpandProjectReferences">
    <GetPackageVersion Files="@(File)">
      <Output TaskParameter="Version" PropertyName="_AssemblyVersion" />
    </GetPackageVersion>
    <Error Condition="'$(_AssemblyVersion)' == ''" Text="No assembly version could be determined." ContinueOnError="ErrorAndContinue" />
  </Target>
  <!-- Calculates the package version including any prerelease suffix -->
  <Target Name="CalculatePackageVersion" BeforeTargets="GenerateNuSpec;GetPackageIdentity" DependsOnTargets="GetAssemblyVersionFromProjects">
    <Error Text="No version could be detected.  Either specify the Version property or provide at least one managed assembly." Condition="'$(Version)' == '' AND '$(_AssemblyVersion)' == ''" ContinueOnError="ErrorAndContinue" />
    <ItemGroup>
      <_thisPackage Include="$(Id)">
        <Version Condition="'$(Version)' != ''">$(Version)</Version>
        <Version Condition="'$(Version)' == ''">$(_AssemblyVersion)</Version>
      </_thisPackage>
    </ItemGroup>
    <ApplyPreReleaseSuffix StablePackages="@(StablePackage)" OriginalPackages="@(_thisPackage)" PreReleaseSuffix="$(VersionSuffix)" RevStableToPrerelease="$(PackageRevStableToPrerelease)">
      <Output TaskParameter="UpdatedPackages" ItemName="_thisPackageFinal" />
    </ApplyPreReleaseSuffix>
    <PropertyGroup>
      <Version>%(_thisPackageFinal.Version)</Version>
    </PropertyGroup>
  </Target>
  <!-- Updates version metadata of a pinned dependency to be a fixed version -->
  <Target Name="PinDependencies" DependsOnTargets="GetPackageDependencies">
    <ItemGroup>
      <DependenciesToPin Include="@(Dependency)" Condition="'@(PinDependency)' == '%(Identity)'" />
      <Dependency Remove="@(DependenciesToPin)" />
      <Dependency Include="@(DependenciesToPin)">
        <Version>[%(DependenciesToPin.Version)]</Version>
      </Dependency>
    </ItemGroup>
  </Target>
  <Target Name="DetermineRuntimeDependencies" DependsOnTargets="PinDependencies" Returns="@(RuntimeDependency)">
    <!-- see if we have any runtime dependencies to write to runtime.json -->
    <ItemGroup>
      <RuntimeDependency Condition="'%(Dependency.TargetRuntime)' != ''" Include="@(Dependency)" />
      <RuntimeDependency>
        <TargetPackage Condition="'%(RuntimeDependency.TargetPackage)' == ''">$(Id)</TargetPackage>
      </RuntimeDependency>
      <!-- don't include runtime depdendencies in the dependency list, they'll be written to the runtime.json -->
      <Dependency Remove="@(RuntimeDependency)" />
    </ItemGroup>
    <Error Text="Packages that are constrained by runtime should not have runtime dependencies.  They will be ignored by nuget" Condition="'$(PackageTargetRuntime)' != '' AND '@(RuntimeDependency)' != ''" ContinueOnError="ErrorAndContinue" />
    <!-- determine if there is a file to be updated, and setup the output file -->
    <PropertyGroup>
      <RuntimeFileSource Condition="'%(File.FileName)%(File.Extension)' == 'runtime.json'">%(File.Identity)</RuntimeFileSource>
    </PropertyGroup>
    <ItemGroup Condition="'@(RuntimeDependency)' != ''">
      <!-- if we are updating, remove it from the file group, we'll replace it with the generated version -->
      <PackageFile Condition="'$(RuntimeFileSource)' != ''" Remove="$(RuntimeFileSource)" />
      <PackageFile Include="$(RuntimeFilePath)">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <IsLibrary>false</IsLibrary>
      </PackageFile>
    </ItemGroup>
  </Target>
  <Target Name="EnsureEmptyPackage" DependsOnTargets="DetermineRuntimeDependencies" BeforeTargets="GenerateNuSpec">
    <!-- Nuget will include all files when nuspec is empty, ensure we have at least one file to avoid that -->
    <ItemGroup Condition="'@(PackageFile)' == ''">
      <PackageFile Include="$(PlaceholderFile)">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <IsLibrary>false</IsLibrary>
      </PackageFile>
    </ItemGroup>
  </Target>
  <!-- If the "PreventImplementationReference" property is true, then don't permit references to the
    package implementation from lib.  This is used in the platform specific packages which should
    not be directly referenced by projects for implemtation dependencies. -->
  <Target Name="PreventImplementationReference" BeforeTargets="EnsureEmptyPackage">
    <ItemGroup Condition="'$(PreventImplementationReference)' == 'true'">
      <PackageFile Include="$(PlaceholderFile)">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <TargetPath>ref/dotnet</TargetPath>
      </PackageFile>
    </ItemGroup>
  </Target>
  <!--
      InboxOnTargetFramework: contract implementation and reference are inbox, use placeholders for both
      NotSupportedOnTargetFramework: contract should not be supported, use place holder for lib
      ExternalOnTargetFramework: contract implementation is provided by another package, use placeholders for both
  -->
  <Target Name="AddPlaceholders" DependsOnTargets="ExpandProjectReferences" Inputs="%(InboxOnTargetFramework.Identity);%(NotSupportedOnTargetFramework.Identity);%(ExternalOnTargetFramework.Identity)" Outputs="fake" BeforeTargets="ConvertItems">
    <ItemGroup>
      <_targetItem Include="@(InboxOnTargetFramework)" />
      <_targetItem Include="@(NotSupportedOnTargetFramework)" />
      <_targetItem Include="@(ExternalOnTargetFramework)" />
    </ItemGroup>
    <PropertyGroup>
      <_target>%(_targetItem.Identity)</_target>
      <_targetRuntime>$(PackageTargetRuntime)</_targetRuntime>
      <_targetRuntime Condition="'%(_targetItem.PackageTargetRuntime)' != ''">%(_targetItem.PackageTargetRuntime)</_targetRuntime>
      <!-- don't use 'any' in paths due to https://github.com/NuGet/Home/issues/1676 -->
      <_targetRuntime Condition="'$(_targetRuntime)' == 'any'" />
      <!-- include a ref placeholder for everything but NotSupportedOnTargetFramework, never put placeholders in runtime packages -->
      <_targetRef Condition="'%(NotSupportedOnTargetFramework.Identity)' == '' AND '$(PackageTargetRuntime)' == ''">true</_targetRef>
    </PropertyGroup>
    <ItemGroup>
      <File Include="$(PlaceholderFile)">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <TargetPath Condition="'$(_targetRuntime)' != ''">runtimes/$(_targetRuntime)/lib/$(_target)</TargetPath>
        <TargetPath Condition="'$(_targetRuntime)' == ''">lib/$(_target)</TargetPath>
      </File>
      <File Include="$(PlaceholderFile)" Condition="'$(_targetRef)' == 'true'">
        <PackageId>$(Id)</PackageId>
        <PackageVersion>$(Version)</PackageVersion>
        <TargetPath>ref/$(_target)</TargetPath>
      </File>
      <FrameworkReference Condition="'%(InboxOnTargetFramework.AsFrameworkReference)' == 'true'" Include="$(Id)">
        <TargetFramework>$(_target)</TargetFramework>
      </FrameworkReference>
      <Dependency Include="_._">
        <TargetFramework>$(_target)</TargetFramework>
      </Dependency>
    </ItemGroup>
  </Target>
  <!-- Ensures that OOB frameworks aren't obscured by placeholders for inbox frameworks
       This is needed because nuget treats portable implementations as having less
       precedence than platform specific implementations of any version and we
       put a place-holder in the platform specific folder when an asset is inbox. -->
  <ItemGroup>
    <OutOfBoxFramework Include="netcore50" />
  </ItemGroup>
  <Target Name="EnsureOOBFramework" DependsOnTargets="AddPlaceholders;GetFiles">
    <EnsureOOBFramework Condition="'@(OutOfBoxFramework)' != ''" OOBFrameworks="@(OutOfBoxFramework)" Files="@(File)" RuntimeJson="$(RuntimeIdGraphDefinitionFile)" RuntimeId="$(PackageTargetRuntime)">
      <Output TaskParameter="AdditionalFiles" ItemName="File" />
    </EnsureOOBFramework>
  </Target>
  <!-- We can reduce the number of dependencies listed for any framework that has
       inbox implementations since that framework doesn't need the packages for
       compile/runtime.  This reduces the noise when consuming our packages in
       packages.config based projects.  -->
  <Target Name="TrimInboxDependencies" BeforeTargets="GenerateNuSpec" Condition="'$(PackageTargetRuntime)' == ''">
    <CreateTrimDependencyGroups Dependencies="@(Dependency)" FrameworkListsPath="$(FrameworkListsPath)" TrimFrameworks="@(InboxOnTargetFramework);@(NotSupportedOnTargetFramework);@(ExternalOnTargetFramework)" Files="@(File)" Condition="'@(Dependency)' != ''">
      <Output TaskParameter="TrimmedDependencies" ItemName="TrimmedDependency" />
    </CreateTrimDependencyGroups>
    <ItemGroup>
      <Dependency Include="@(TrimmedDependency)" />
    </ItemGroup>
  </Target>
  <!-- Generates a runtime.json file containing all dependencies with TargetRuntime -->
  <Target Name="GenerateRuntimeDependencies" DependsOnTargets="DetermineRuntimeDependencies" BeforeTargets="GenerateNuspec">
    <ItemGroup>
      <LineupProjectReference Include="@(ProjectReference)" />
    </ItemGroup>
    <!-- Lineups need to have all runtime dependencies to ensure that they are part of the compile graph -->
    <MSBuild Projects="@(LineupProjectReference)" Targets="DetermineRuntimeDependencies" Condition="'$(IsLineupPackage)' == 'true'" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_indirectRuntimeDependencies" />
    </MSBuild>
    <!-- pass both RuntimeDependencies and regular dependencies.
         Only RuntimeDependencies will be generated, but Dependencies are required
         since they may be the target of a RuntimeDependency -->
    <GenerateRuntimeDependencies Condition="'@(RuntimeDependency)' != '' OR '@(_indirectRuntimeDependencies)' != ''" Dependencies="@(RuntimeDependency);@(Dependency);@(_indirectRuntimeDependencies)" PackageId="$(Id)" RuntimeJsonTemplate="$(RuntimeFileSource)" RuntimeJson="$(RuntimeFilePath)" EnsureBase="$(IsLineupPackage)" />
  </Target>
  <Target Name="GetSyncInfo" BeforeTargets="GetPackageDescription" Condition="Exists('$(SyncInfoFile)')">
    <ReadLinesFromFile File="$(SyncInfoFile)">
      <Output TaskParameter="Lines" ItemName="SyncInfoLines" />
    </ReadLinesFromFile>
  </Target>
  <Target Name="GetPackageDescription" BeforeTargets="GenerateNuspec">
    <PropertyGroup>
      <UseRuntimePackageDescription Condition="'$(UseRuntimePackageDescription)' == '' AND $(BaseId.StartsWith('runtime.native'))">true</UseRuntimePackageDescription>
    </PropertyGroup>
    <GetPackageDescription DescriptionFile="$(PackageDescriptionFile)" Condition="'$(UseRuntimePackageDescription)' != 'true'" PackageId="$(BaseId)">
      <Output TaskParameter="Description" PropertyName="Description" />
    </GetPackageDescription>
    <GetPackageDescription DescriptionFile="$(PackageDescriptionFile)" Condition="'$(PackageTargetRuntime)' != '' OR '$(UseRuntimePackageDescription)' == 'true'" PackageId="RuntimePackage">
      <Output TaskParameter="Description" PropertyName="RuntimeDisclaimer" />
    </GetPackageDescription>
    <PropertyGroup>
      <Description Condition="'$(UseRuntimePackageDescription)' == 'true' AND '$(RuntimeDisclaimer)' != ''">$(RuntimeDisclaimer)</Description>
      <Description Condition="'$(UseRuntimePackageDescription)' != 'true' AND '$(RuntimeDisclaimer)' != ''">$(RuntimeDisclaimer) \r\n $(Description)</Description>
      <Description Condition="'@(SyncInfoLines)' != ''">$(Description) \r\n %(SyncInfoLines.Identity)</Description>
    </PropertyGroup>
  </Target>
  <ItemGroup>
    <!-- Default validation frameworks : every framework that supports contracts -->
    <DefaultValidateFramework Include="dnxcore50">
      <RuntimeIDs>win7-x86;win7-x64;osx.10.11-x64;centos.7.1-x64;ubuntu.14.04-x64;linuxmint.17-x64</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="netcore50">
      <RuntimeIDs>win10-x86;win10-x86-aot;win10-x64;win10-x64-aot;win10-arm;win10-arm-aot</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="netcore45">
      <RuntimeIDs>win8-x86;win8-x64;win8-arm</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="netcore451">
      <RuntimeIDs>win81-x86;win81-x64;win81-arm</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="net45" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <RuntimeIDs>win-x86;win-x64</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="net451" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <RuntimeIDs>win-x86;win-x64</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="net46" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <!-- add additional win7 RIDs to validate up-level authoring -->
      <RuntimeIDs>win-x86;win-x64;win7-x86;win7-x64</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="net461" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <!-- add additional win7 RIDs to validate up-level authoring -->
      <RuntimeIDs>win-x86;win-x64;win7-x86;win7-x64</RuntimeIDs>
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="wpa81">
      <!-- Intentionally empty, no RIDs defined for phone-->
      <RuntimeIDs />
    </DefaultValidateFramework>
    <DefaultValidateFramework Include="wp8">
      <!-- Intentionally empty, no RIDs defined for phone-->
      <RuntimeIDs />
    </DefaultValidateFramework>
  </ItemGroup>
  <PropertyGroup>
    <!-- Skip validation of runtime packages, they will be validated in the context of their reference package -->
    <SkipValidatePackage Condition="'$(SkipValidateTargetFrameworks)' == '' AND '$(PackageTargetRuntime)' != ''">true</SkipValidatePackage>
    <SkipSupportCheck Condition="'$(SkipSupportCheck)' == '' AND ($(Id.StartsWith('System.Private.')) OR $(Id.StartsWith('Microsoft.NETCore.')))">true</SkipSupportCheck>
  </PropertyGroup>
  <Target Name="ValidatePackage" DependsOnTargets="GetPackageFiles;DetermineRuntimeDependencies" BeforeTargets="GenerateNuspec" Condition="'$(SkipValidatePackage)' != 'true'">
    <ItemGroup>
      <RuntimeDependencyProject Include="%(RuntimeDependency.OriginalItemSpec)" KeepDuplicates="false" />
      <!-- map back to the project references -->
      <RuntimeDependencyProjectFullPath Include="@(RuntimeDependencyProject->'%(FullPath)')" />
      <ProjectReferenceFullPath Include="@(ProjectReference->'%(FullPath)')" />
      <RuntimeProjectReference Include="@(ProjectReferenceFullPath)" Condition="'@(ProjectReferenceFullPath)' == '@(RuntimeDependencyProjectFullPath)' AND '%(Identity)' != ''" />
    </ItemGroup>
    <ItemGroup>
      <!-- Validation framework metadata can be sepecified in multiple ways.
           By default we have a set of frameworks that we validate for.  If a package includes SupportedFramework items it will
           be tested for support of those frameworks, and not support of any thing in the default set and not the supported set.
           The default set may be completely replaced by setting IncludeDefaultValidateFramework=false and populating
           the ValidateFramework item yourself (eg: at the repo level), or by excluding individual frameworks by setting
           ExcludeDefaultValidateFramework.  Excluding a framework just means we won't explicitly validate it. -->
      <ValidateFramework Condition="'$(IncludeDefaultValidateFramework)' != 'false'" Include="@(DefaultValidateFramework)" Exclude="@(ExcludeDefaultValidateFramework)" />
    </ItemGroup>
    <ItemGroup>
      <!-- Allow for SupportedFramework to be defined as metadata on project references -->
      <SupportedFramework Include="%(File.SupportedFramework)" Condition="'%(File.SupportedFramework)' != '' AND '%(File.AssemblyVersion)' != ''">
        <Version>%(File.AssemblyVersion)</Version>
      </SupportedFramework>
    </ItemGroup>
    <ItemGroup>
      <!-- default to the current version for any unspecified SupportedFrameworks with unspecified version -->
      <SupportedFramework Condition="'%(SupportedFramework.Version)' == ''">
        <Version>$(_AssemblyVersion)</Version>
      </SupportedFramework>
    </ItemGroup>
    <!-- Get all the files from runtime implementation packages to include in reference path-->
    <MSBuild Projects="@(RuntimeProjectReference)" Targets="GetPackageFiles" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="RuntimeFile" />
    </MSBuild>
    <ValidatePackage ContractName="$(BaseId)" PackageId="$(Id)" Files="@(PackageFile);@(RuntimeFile)" SupportedFrameworks="@(SupportedFramework)" Frameworks="@(ValidateFramework)" RuntimeFile="$(RuntimeIdGraphDefinitionFile)" FrameworkListsPath="$(FrameworkListsPath)" SkipGenerationCheck="$(SkipGenerationCheck)" SkipSupportCheck="$(SkipSupportCheck)" SuppressionFile="$(ValidationSuppressionFile)" ContinueOnError="ErrorAndContinue" />
  </Target>
  <Target Name="ValidateMetaPackageFramework" Condition="'$(MetaPackageFramework)' != ''" BeforeTargets="GenerateNuspec">
    <ItemGroup>
      <_ExpectedMetaDependencies Include="@(ContractAssembly)" Condition="'%(ContractAssembly.Platform)' == '$(MetaPackageFramework)'" />
      <_ExpectedMetaDependencies Remove="@(ExcludePackage);@(NoPackage)" />
      <_ActualMetaDependencies Include="@(Dependency);@(RuntimeDependency)" />
      <!-- also consider indirect dependencies that may come from the core package -->
      <_ActualMetaDependencies Include="@(PkgProjDependency)" Condition="'%(PkgProjDependency.DependencyKind)' == 'Indirect'" />
      <_MissingMetaDependencies Include="@(_ExpectedMetaDependencies)" Exclude="@(_ActualMetaDependencies)" />
    </ItemGroup>
    <Error Text="Packages @(_MissingMetaDependencies) should be included." Condition="'@(_MissingMetaDependencies)' != ''" ContinueOnError="ErrorAndContinue" />
  </Target>
  <Target Name="CreatePackage" Inputs="$(NuSpecPath)" Outputs="$(PackageOutputPath)$(Id).$(Version).nupkg">
    <ItemGroup>
      <_missingFiles Include="@(PackageFile)" Condition="!Exists(%(FullPath))" />
    </ItemGroup>
    <PropertyGroup>
      <_SkipCreatePackage Condition="'$(SkipCreatePackageOnMissingFiles)' == 'true' AND '@(_missingFiles)' != ''">true</_SkipCreatePackage>
    </PropertyGroup>
    <Warning Condition="'$(_SkipCreatePackage)' == 'true'" Text="Skipping package creation for $(NuSpecPath) because the following files do not exist: @(_missingFiles)" />
    <NugetPack Nuspecs="$(NuSpecPath)" OutputDirectory="$(PackageOutputPath)" ExcludeEmptyDirectories="true" Condition="'$(_SkipCreatePackage)' != 'true'" />
    <!-- Create a marker that records the path to the generated package -->
    <WriteLinesToFile Lines="$(PackageOutputPath)$(Id).$(Version).nupkg" File="$(NuSpecPath).pkgpath" Overwrite="true" Condition="'$(_SkipCreatePackage)' != 'true'" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the default target framework targets.
    
    Inputs:
      TargetFrameworkIdentifier - If not set defaults to .NETPortable
      TargetFrameworkVersion - If not set defaults to v4.5
      TargetFrameworkProfile - If not set defaults to Profile7
    
    This Imports portable.csharp/visualbasic.targets if .NETPortable is the identifier otherwise it imports csharp/visualbasic.targets  
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)FrameworkTargeting.targets" Condition="'$(ExcludeFrameworkTargetingImport)'!='true'">

e:\gh\chcosta\corefx\Tools\FrameworkTargeting.targets
============================================================================================================================================
-->
  <PropertyGroup Condition=" '$(TargetFrameworkIdentifier)' == ''&#xD;&#xA;                         and '$(TargetFrameworkVersion)'    == ''&#xD;&#xA;                         and '$(TargetFrameworkProfile)'    == '' ">
    <TargetingDefaultPlatform>true</TargetingDefaultPlatform>
  </PropertyGroup>
  <PropertyGroup Condition="'$(TargetFrameworkIdentifier)' == ''">
    <TargetFrameworkIdentifier>.NETPortable</TargetFrameworkIdentifier>
  </PropertyGroup>
  <!--
    Limit the assembly resolution to just explicit locations.
    Don't search anything machine-wide or build-order dependent.
   -->
  <PropertyGroup>
    <AssemblySearchPaths>{HintPathFromItem};{RawFileName}</AssemblySearchPaths>
  </PropertyGroup>
  <!--
    When targeting an explicit platform other than the default,
    also allow the target framework directory.
  -->
  <PropertyGroup Condition="'$(TargetingDefaultPlatform)' != 'true'">
    <AssemblySearchPaths>$(AssemblySearchPaths);{TargetFrameworkDirectory}</AssemblySearchPaths>
  </PropertyGroup>
  <!-- Setup the default target for projects not already explicitly targeting another platform -->
  <PropertyGroup Condition="'$(TargetingDefaultPlatform)' == 'true'">
    <!-- Setting a default portable profile, although nothing should resolve from there as we want to use the pacakge refs -->
    <TargetPlatformIdentifier>Portable</TargetPlatformIdentifier>
    <TargetFrameworkIdentifier>.NETPortable</TargetFrameworkIdentifier>
    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>
    <TargetFrameworkProfile>Profile7</TargetFrameworkProfile>
    <TargetFrameworkMonikerDisplayName>.NET Portable Subset</TargetFrameworkMonikerDisplayName>
    <ImplicitlyExpandTargetFramework>false</ImplicitlyExpandTargetFramework>
    <!-- Disable RAR complaining about us referencing higher .NET Portable libraries as we aren't a traditional portable library -->
    <ResolveAssemblyReferenceIgnoreTargetFrameworkAttributeVersionMismatch>true</ResolveAssemblyReferenceIgnoreTargetFrameworkAttributeVersionMismatch>
  </PropertyGroup>
  <!-- Need to add references to the mscorlib design-time facade for some old-style portable dependencies like xunit -->
  <Target Name="AddDesignTimeFacadeReferences" Condition="'$(TargetingDefaultPlatform)' == 'true' AND '$(IsReferenceAssembly)' != 'true' AND '$(ExcludeMscorlibFacade)' != 'true'" BeforeTargets="ResolveReferences" DependsOnTargets="GetReferenceAssemblyPaths">
    <PropertyGroup>
      <_resolvedMscorlib Condition="'%(ReferencePath.FileName)' == 'mscorlib'">true</_resolvedMscorlib>
    </PropertyGroup>
    <ItemGroup>
      <PossibleTargetFrameworks Include="$(_TargetFrameworkDirectories)" />
      <ReferencePath Include="%(PossibleTargetFrameworks.Identity)mscorlib.dll" Condition="'$(_resolvedMscorlib)' != 'true' and '%(PossibleTargetFrameworks.Identity)' != '' and Exists('%(PossibleTargetFrameworks.Identity)mscorlib.dll')" />
    </ItemGroup>
  </Target>
  <!--<Import Project="depProj.targets" Condition="'$(MSBuildProjectExtension)' == '.depproj'" />-->
  <!--<Import Project="$(MSBuildExtensionsPath32)\Microsoft\Portable\$(TargetFrameworkVersion)\Microsoft.Portable.CSharp.targets" Condition="'$(TargetFrameworkIdentifier)' == '.NETPortable' and '$(MSBuildProjectExtension)' == '.csproj'" />-->
  <!--<Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" Condition="'$(TargetFrameworkIdentifier)' != '.NETPortable' and '$(MSBuildProjectExtension)' == '.csproj'" />-->
  <!--<Import Project="$(MSBuildExtensionsPath32)\Microsoft\Portable\$(TargetFrameworkVersion)\Microsoft.Portable.VisualBasic.targets" Condition="'$(TargetFrameworkIdentifier)' == '.NETPortable' and '$(MSBuildProjectExtension)' == '.vbproj'" />-->
  <!--<Import Project="$(MSBuildToolsPath)\Microsoft.VisualBasic.targets" Condition="'$(TargetFrameworkIdentifier)' != '.NETPortable' and '$(MSBuildProjectExtension)' == '.vbproj'" />-->
  <PropertyGroup Condition="'$(TargetFrameworkIdentifier)' != '.NETFramework' and '$(OutputType)' == 'exe'">
    <!-- RAR thinks all EXEs require binding redirects.  That's not the case for CoreCLR -->
    <AutoUnifyAssemblyReferences>true</AutoUnifyAssemblyReferences>
    <GenerateBindingRedirectsOutputType>false</GenerateBindingRedirectsOutputType>
  </PropertyGroup>
  <!-- We need to point $(FrameworkPathOverride) to the directory that contains explicitly referenced System.Runtime.dll, if any.
       Otherwise, if $(FrameworkPathOverride)\System.Runtime.dll is not the same file as the one referenced explicitly,
       VS2013 VB compiler would load it and then it would complain about ambiguous type declarations.
  -->
  <PropertyGroup Condition="'$(MSBuildProjectExtension)' == '.vbproj'">
    <CoreCompileDependsOn>$(CoreCompileDependsOn);OverrideFrameworkPathForVisualBasic</CoreCompileDependsOn>
  </PropertyGroup>
  <Target Name="OverrideFrameworkPathForVisualBasic" AfterTargets="ResolveAssemblyReferences" Condition="'$(MSBuildProjectExtension)' == '.vbproj'">
    <ItemGroup>
      <FrameworkPathOverrideCandidate Include="%(ReferencePath.RootDir)%(ReferencePath.Directory)" Condition="'%(ReferencePath.Filename)%(ReferencePath.Extension)' == 'System.Runtime.dll'" />
    </ItemGroup>
    <PropertyGroup Condition="'@(FrameworkPathOverrideCandidate-&gt;Count())' == '1'">
      <FrameworkPathOverride>@(FrameworkPathOverrideCandidate)</FrameworkPathOverride>
    </PropertyGroup>
  </Target>
  <Target Name="ConvertCommonMetadataToAdditionalProperties" BeforeTargets="AssignProjectConfiguration">
    <!-- list each append as a seperate item to force re-evaluation of AdditionalProperties metadata -->
    <ItemGroup>
      <!-- Set some basic configuration properties and pass them along to ProjectReference's -->
      <ProjectReference>
        <OSGroup Condition="'%(ProjectReference.OSGroup)'=='' and '$(OSGroup)'!='' and '$(OSGroup)'!='AnyOS'">$(OSGroup)</OSGroup>
      </ProjectReference>
      <ProjectReference>
        <TargetGroup Condition="'%(ProjectReference.TargetGroup)'=='' and '$(TargetGroup)'!=''">$(TargetGroup)</TargetGroup>
      </ProjectReference>
      <!-- Configuration property shortcuts -->
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.TargetGroup)'!=''">TargetGroup=%(ProjectReference.TargetGroup);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.OSGroup)'!=''">OSGroup=%(ProjectReference.OSGroup);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
      <!-- Packaging property shortcuts -->
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.PackageTargetFramework)' != ''">PackageTargetFramework=%(ProjectReference.PackageTargetFramework);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.PackageTargetPath)' != ''">PackageTargetPath=%(ProjectReference.PackageTargetPath);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.PackageTargetRuntime)' != ''">PackageTargetRuntime=%(ProjectReference.PackageTargetRuntime);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.Platform)' != ''">Platform=%(ProjectReference.Platform);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the default package restore and resolve targets 
  
      Inputs:
        ProjectJson - If not set defaults to $(MSBuildProjectDirectory)\project.json
        RestorePackages - If not set defaults to the existence of the $(ProjectJson)
        ResolveNuGetPackages - If not set defaults to the existance of $(ProjectJson)
      
      Depends on properties:
        NugetRestoreCommand - Used to restore the project packages from packages.config
        DnuRestoreCommand - Used to restore the project packages from project.json
        PackagesDir - Packages are restored to and resolved from this location

      Depends on properties set by csharp/visualbasic.targets so needs to be imported after.
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)packageresolve.targets" Condition="'$(ExcludePackageResolveImport)'!='true'">

e:\gh\chcosta\corefx\Tools\packageresolve.targets
============================================================================================================================================
-->
  <UsingTask TaskName="PrereleaseResolveNuGetPackageAssets" AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" />
  <UsingTask TaskName="ValidateProjectDependencyVersions" AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" />
  <PropertyGroup>
    <ProjectJson Condition="'$(ProjectJson)'=='' and Exists('$(MSBuildProjectDirectory)/project.json')">$(MSBuildProjectDirectory)/project.json</ProjectJson>
    <ProjectLockJson Condition="Exists('$(ProjectJson)') and '$(ProjectLockJson)'==''">$(MSBuildProjectDirectory)/project.lock.json</ProjectLockJson>
    <ResolveNugetProjectFile Condition="'$(ResolveNugetProjectFile)' == ''">$(MSBuildProjectFullPath)</ResolveNugetProjectFile>
    <RestorePackages Condition="'$(RestorePackages)'!='false' and Exists('$(ProjectJson)') and '$(DesignTimeBuild)' != 'true'">true</RestorePackages>
    <PrereleaseResolveNuGetPackages Condition="'$(PrereleaseResolveNuGetPackages)'!='false' and Exists('$(ProjectJson)')">true</PrereleaseResolveNuGetPackages>
    <!-- 
        For now, prevent built-in task (if available) from running.
        More changes are needed to light up on their availability
        and use them instead of what we have here. See buildtools
        issue #192.
     -->
    <ResolveNugetPackages>false</ResolveNugetPackages>
  </PropertyGroup>
  <!-- Restoring packages during a background (designtime) build will cause VS 2015 (v14) to get into an endless loop of resolving references. -->
  <Target Name="RestorePackages" BeforeTargets="ResolveNuGetPackages;ValidatePackageVersions" Condition="'$(RestorePackages)'=='true' and !('$(VSDesignTimeBuild)'=='true' and '$(VisualStudioVersion)' &gt;= '14.0')">
    <Error Condition="'$(DnuRestoreCommand)'=='' and Exists('$(ProjectJson)')" Text="RestorePackages target needs a predefined DnuRestoreCommand property set in order to restore $(ProjectJson)" />
    <Exec Condition="Exists('$(ProjectJson)')" Command="$(DnuRestoreCommand) &quot;$(ProjectJson)&quot;" StandardOutputImportance="Low" CustomErrorRegularExpression="^Unable to locate .*" />
  </Target>
  <ItemGroup Condition="'$(ResolvePackages)'=='true' or '$(PrereleaseResolveNuGetPackages)'=='true'">
    <CustomAdditionalCompileInputs Condition="Exists('$(ProjectJson)')" Include="$(ProjectJson)" />
  </ItemGroup>
  <PropertyGroup>
    <ResolveAssemblyReferencesDependsOn>
      $(ResolveAssemblyReferencesDependsOn);
      ResolveNuGetPackages;
      ValidatePackageVersions;
    </ResolveAssemblyReferencesDependsOn>
    <!-- temporarily accept the old name NuGetTargetFrameworkMoniker until all projects are moved forward -->
    <NuGetTargetMoniker Condition="'$(NuGetTargetMoniker)' == ''">$(NuGetTargetFrameworkMoniker)</NuGetTargetMoniker>
    <!-- We use dotnet as the framework for our reference assemblies, in the future we'll move to 
         targets that are closer to what shipped in Dev14 and we won't need to special case this.-->
    <NuGetTargetMoniker Condition="'$(NuGetTargetMoniker)' == '' and '$(IsReferenceAssembly)' == 'true'">.NETPlatform,Version=v5.0</NuGetTargetMoniker>
    <UseTargetPlatformAsNuGetTargetMoniker Condition="'$(UseTargetPlatformAsNuGetTargetMoniker)' == '' AND '$(TargetFrameworkMoniker)' == '.NETCore,Version=v5.0'">true</UseTargetPlatformAsNuGetTargetMoniker>
    <NuGetTargetMoniker Condition="'$(NuGetTargetMoniker)' == '' AND '$(UseTargetPlatformAsNuGetTargetMoniker)' == 'true'">$(TargetPlatformIdentifier),Version=v$([System.Version]::Parse('$(TargetPlatformMinVersion)').ToString(3))</NuGetTargetMoniker>
    <NuGetTargetMoniker Condition="'$(NuGetTargetMoniker)' == '' AND '$(UseTargetPlatformAsNuGetTargetMoniker)' != 'true'">$(TargetFrameworkMoniker)</NuGetTargetMoniker>
    <BaseNuGetRuntimeIdentifier Condition="'$(BaseNuGetRuntimeIdentifier)' == '' and '$(TargetPlatformIdentifier)' == 'UAP'">win10</BaseNuGetRuntimeIdentifier>
    <BaseNuGetRuntimeIdentifier Condition="'$(BaseNuGetRuntimeIdentifier)' == ''">win</BaseNuGetRuntimeIdentifier>
    <CopyNuGetImplementations Condition="'$(CopyNuGetImplementations)' == '' and '$(OutputType)' != 'library' and ('$(OutputType)' != 'winmdobj' or '$(AppxPackage)' == 'true')">true</CopyNuGetImplementations>
  </PropertyGroup>
  <!-- If a RuntimeIndentifier wasn't already specified, let's go generate it -->
  <PropertyGroup Condition="'$(NuGetRuntimeIdentifier)' == '' and '$(CopyNuGetImplementations)' == 'true'">
    <_NuGetRuntimeIdentifierWithoutAot>$(BaseNuGetRuntimeIdentifier)-$(PlatformTarget.ToLower())</_NuGetRuntimeIdentifierWithoutAot>
    <NuGetRuntimeIdentifier>$(_NuGetRuntimeIdentifierWithoutAot)</NuGetRuntimeIdentifier>
    <NuGetRuntimeIdentifier Condition="'$(UseDotNetNativeToolchain)' == 'true'">$(_NuGetRuntimeIdentifierWithoutAot)-aot</NuGetRuntimeIdentifier>
  </PropertyGroup>
  <Target Name="ResolveNuGetPackages" Condition="'$(PrereleaseResolveNuGetPackages)'=='true'">
    <PropertyGroup>
      <!-- Temporary workaround -->
      <NuGetTargetMoniker Condition="'$(NuGetTargetMoniker)' == '.NETPortable,Version=v4.5,Profile=Profile7'">DNXCore,Version=v5.0</NuGetTargetMoniker>
    </PropertyGroup>
    <PrereleaseResolveNuGetPackageAssets Condition="Exists('$(ProjectLockJson)')" AllowFallbackOnTargetSelection="true" IncludeFrameworkReferences="false" NuGetPackagesDirectory="$(PackagesDir)" RuntimeIdentifier="$(NuGetRuntimeIdentifier)" ProjectLanguage="$(Language)" ProjectLockFile="$(ProjectLockJson)" TargetMonikers="$(NuGetTargetMoniker)">
      <Output TaskParameter="ResolvedAnalyzers" ItemName="Analyzer" />
      <Output TaskParameter="ResolvedReferences" ItemName="Reference" />
      <Output TaskParameter="ResolvedCopyLocalItems" ItemName="ReferenceCopyLocalPaths" />
      <Output TaskParameter="ReferencedPackages" ItemName="ReferencedNuGetPackages" />
    </PrereleaseResolveNuGetPackageAssets>
    <!-- We may have an indirect package reference that we want to replace with a project reference -->
    <ItemGroup>
      <!-- Intersect project-refs with package-refs -->
      <_ReferenceFileNamesToRemove Include="@(Reference)" Condition="'@(_ResolvedProjectReferencePaths->'%(FileName)%(Extension)')' == '%(FileName)%(Extension)'" />
      <_ReferenceCopyLocalPathsFileNamesToRemove Include="@(ReferenceCopyLocalPaths)" Condition="'@(_ResolvedProjectReferencePaths->'%(FileName)%(Extension)')' == '%(FileName)%(Extension)'" />
      <Reference Remove="@(_ReferenceFileNamesToRemove)" />
      <ReferenceCopyLocalPaths Remove="@(_ReferenceCopyLocalPathsFileNamesToRemove)" />
    </ItemGroup>
    <Message Text="Excluding @(_ReferenceFileNamesToRemove);@(_ReferenceCopyLocalPathsFileNamesToRemove) from package references since the same file is provided by a project refrence." Condition="'@(_ReferenceFileNamesToRemove)' != '' or '@(_ReferenceCopyLocalPathsFileNamesToRemove)' != ''" />
  </Target>
  <Target Name="RemoveTransitiveCompileReferences" AfterTargets="ResolveNuGetPackages">
    <ItemGroup Condition="'$(OmitTransitiveCompileReferences)' == 'true'">
      <!-- get all references from nuget packages as ID so that we can substract the direct ref IDs-->
      <_ReferenceAsPackageId Include="@(Reference->'%(NuGetPackageId)')" Condition="'%(Reference.NuGetPackageId)' != ''">
        <OriginalIdentity>%(Identity)</OriginalIdentity>
      </_ReferenceAsPackageId>
      <!-- Indirect references are any references whose PackageId isn't in the direct reference set: ReferencedNuGetPackages -->
      <_IndirectReferenceAsPackageId Include="@(_ReferenceAsPackageId)" Exclude="@(ReferencedNuGetPackages)" />
      <!-- Transform back to original -->
      <IndirectReference Include="@(_IndirectReferenceAsPackageId->'%(OriginalIdentity)')" />
      <Reference Remove="@(IndirectReference)" />
    </ItemGroup>
  </Target>
  <Target Name="ValidatePackageVersions" Condition="'$(RestorePackages)'=='true' and '$(ValidatePackageVersions)'=='true' and Exists('$(ProjectJson)')">
    <ValidateProjectDependencyVersions ProjectJsons="$(ProjectJson)" ProhibitFloatingDependencies="$(ProhibitFloatingDependencies)" ValidationPatterns="@(ValidationPattern)" />
  </Target>
  <Target Name="FilterTargetingPackResolvedNugetPackages" AfterTargets="ResolveNuGetPackages" Condition="'$(TargetingPackNugetPackageId)' != ''">
    <ItemGroup>
      <ResolvedTargetingPackReference Include="@(Reference)" Condition="'%(Reference.NuGetPackageId)' == '$(TargetingPackNugetPackageId)'" />
      <ResolvedTargetingPackReferenceFilename Include="@(ResolvedTargetingPackReference -> '%(Filename)')">
        <OriginalIdentity>%(Identity)</OriginalIdentity>
      </ResolvedTargetingPackReferenceFilename>
      <ResolvedTargetingPackReferenceFilename Remove="@(TargetingPackReference)" />
      <PackageReferencesToRemove Include="@(ResolvedTargetingPackReferenceFilename -> '%(OriginalIdentity)')" />
      <Reference Remove="@(PackageReferencesToRemove)" />
    </ItemGroup>
    <Message Importance="Low" Text="Removed all ResolvedTagetingPackReferences that were not specified explicitly as a TargetingPackReference=[@(TargetingPackReference)]. PackageReferencesToRemove=[@(PackageReferencesToRemove)]." />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the default SR resource generation targets 
  
      Inputs:
        ResourcesSourceOutputDirectory - If not set defaults to $(MSBuildProjectDirectory)\Resources.
        StringResourcesPath - If not set defaults to $(ResourcesSourceOutputDirectory\Strings.resx if it exists. If the file exists
          then the targets generates the strongly typed $(ResourcesSourceOutputDirectory)\SR.cs/vb file based on resource strings.  
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)resources.targets" Condition="'$(ExcludeResourcesImport)'!='true'">

e:\gh\chcosta\corefx\Tools\resources.targets
============================================================================================================================================
-->
  <UsingTask TaskName="GenerateResourcesCode" AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" />
  <PropertyGroup>
    <ResourcesSourceOutputDirectory Condition="'$(ResourcesSourceOutputDirectory)' == ''">$(MSBuildProjectDirectory)/Resources/</ResourcesSourceOutputDirectory>
    <StringResourcesPath Condition="'$(StringResourcesPath)'=='' And Exists('$(ResourcesSourceOutputDirectory)Strings.resx')">$(ResourcesSourceOutputDirectory)/Strings.resx</StringResourcesPath>
    <IntermediateResOutputFileFullPath Condition="'$(MSBuildProjectExtension)' == '.csproj'">$(IntermediateOutputPath)SR.cs</IntermediateResOutputFileFullPath>
    <IntermediateResOutputFileFullPath Condition="'$(MSBuildProjectExtension)' == '.vbproj'">$(IntermediateOutputPath)SR.vb</IntermediateResOutputFileFullPath>
    <DefineConstants Condition="'$(ConfigurationGroup)' == 'Debug'">$(DefineConstants);DEBUGRESOURCES</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(StringResourcesPath)'!=''">
    <CompileDependsOn>
          GenerateResourcesSource;
          $(CompileDependsOn);
      </CompileDependsOn>
  </PropertyGroup>
  <Target Name="GenerateResourcesSource" Condition="'$(StringResourcesPath)'!=''" Inputs="$(StringResourcesPath)" Outputs="$(IntermediateResOutputFileFullPath)">
    <GenerateResourcesCode ResxFilePath="$(StringResourcesPath)" OutputSourceFilePath="$(IntermediateResOutputFileFullPath)" AssemblyName="$(AssemblyName)" />
    <ItemGroup>
      <!-- The following Compile element has to be included dynamically inside the Target otherwise intellisense will not work -->
      <Compile Include="$(IntermediateResOutputFileFullPath)" />
    </ItemGroup>
    <ItemGroup>
      <FileWrites Include="$(IntermediateResOutputFileFullPath)" />
    </ItemGroup>
  </Target>
  <ItemGroup Condition="'$(StringResourcesPath)'!=''">
    <EmbeddedResource Include="$(StringResourcesPath)">
      <Visible>true</Visible>
      <LogicalName>FxResources.$(AssemblyName).SR.resources</LogicalName>
    </EmbeddedResource>
  </ItemGroup>
  <ItemGroup Condition="Exists('$(StringResourcesPath)') And '$(SkipCommonResourcesIncludes)'==''">
    <Compile Condition="'$(MSBuildProjectExtension)' == '.csproj'" Include="$(CommonPath)\System\SR.cs">
      <Visible>true</Visible>
      <Link>Resources\Common\SR.cs</Link>
    </Compile>
    <Compile Condition="'$(MSBuildProjectExtension)' == '.vbproj'" Include="$(CommonPath)\System\SR.vb">
      <Visible>true</Visible>
      <Link>Resources\Common\SR.vb</Link>
    </Compile>
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the default assembly info generation targets
    
      Inputs:
        GenerateAssemblyInfo - Controls whether or not to generate the assembly info file and defaults to true if not set.
        AssemblyVersion - If not set defaults to 1.0.0.0 but it is expected to be set in csproj files.
        CLSCompliant - If not set defaults to true and if it is true then adds the assembly level CLSCompliant(true) attribute.

      File Version Inputs:
        MajorVersion - If not set defaults to 1.
        MinorVersion - If not set defaults to 0.
        BuildNumberMajor - If not set defaults to 0.
        BuildNumberMinor - If not set defaults to 0. 
        AssemblyFileVersion - If not set defaults to $(MajorVersion).$(MinorVersion).$(BuildNumberMajor).$(BuildNumberMinor). 
        
      BuildNumberTarget - If this property is set it will try to import the file which allows for it to override the properties above.
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)versioning.targets" Condition="'$(ExcludeVersioningImport)'!='true'">

e:\gh\chcosta\corefx\Tools\versioning.targets
============================================================================================================================================
-->
  <!-- Setup the default file version information -->
  <PropertyGroup>
    <MajorVersion Condition="'$(MajorVersion)' == ''">1</MajorVersion>
    <MinorVersion Condition="'$(MinorVersion)' == ''">0</MinorVersion>
    <!-- These should be set by importing the targets below but initializing to 0 for consistency -->
    <BuildNumberMajor Condition="'$(BuildNumberMajor)' == ''">0</BuildNumberMajor>
    <BuildNumberMinor Condition="'$(BuildNumberMinor)' == ''">0</BuildNumberMinor>
  </PropertyGroup>
  <!-- Import a build target that includes the build numbers -->
  <!--<Import Project="$(BuildNumberTarget)" Condition="Exists('$(BuildNumberTarget)')" />-->
  <!-- #################################### -->
  <!-- Generate Assembly Info -->
  <!-- #################################### -->
  <PropertyGroup>
    <AssemblyVersion Condition="'$(AssemblyVersion)'==''">1.0.0.0</AssemblyVersion>
    <CLSCompliant Condition="'$(CLSCompliant)'==''">false</CLSCompliant>
    <AssemblyFileVersion Condition="'$(AssemblyFileVersion)'==''">$(MajorVersion).$(MinorVersion).$(BuildNumberMajor).$(BuildNumberMinor)</AssemblyFileVersion>
  </PropertyGroup>
  <PropertyGroup>
    <GenerateAssemblyInfo Condition="'$(GenerateAssemblyInfo)'==''">true</GenerateAssemblyInfo>
    <BuiltByString Condition="'$(BuiltByString)'==''">%20built by: $(COMPUTERNAME)-$(USERNAME)</BuiltByString>
  </PropertyGroup>
  <PropertyGroup Condition="'$(GenerateAssemblyInfo)'=='true'">
    <AssemblyInfoFile Condition="'$(MSBuildProjectExtension)' == '.csproj'">$(IntermediateOutputPath)_AssemblyInfo.cs</AssemblyInfoFile>
    <AssemblyInfoFile Condition="'$(MSBuildProjectExtension)' == '.vbproj'">$(IntermediateOutputPath)_AssemblyInfo.vb</AssemblyInfoFile>
    <AssemblyInfoPartialFile Condition="'$(MSBuildProjectExtension)' == '.csproj'">$(MSBuildThisFileDirectory)AssemblyInfoPartial.cs</AssemblyInfoPartialFile>
    <AssemblyInfoPartialFile Condition="'$(MSBuildProjectExtension)' == '.vbproj'">$(MSBuildThisFileDirectory)AssemblyInfoPartial.vb</AssemblyInfoPartialFile>
    <AssemblyInfoPartialFileLink Condition="'$(MSBuildProjectExtension)' == '.csproj'">Properties\_AssemblyInfo.cs</AssemblyInfoPartialFileLink>
    <AssemblyInfoPartialFileLink Condition="'$(MSBuildProjectExtension)' == '.vbproj'">My Project\_AssemblyInfo.vb</AssemblyInfoPartialFileLink>
    <CoreCompileDependsOn>$(CoreCompileDependsOn);GenerateAssemblyInfo</CoreCompileDependsOn>
  </PropertyGroup>
  <Target Name="GenerateAssemblyInfo" Inputs="$(MSBuildProjectFile)" Outputs="$(AssemblyInfoFile)" Condition="'$(GenerateAssemblyInfo)'=='true'">
    <Error Condition="!Exists('$(IntermediateOutputPath)')" Text="GenerateAssemblyInfo failed because IntermediateOutputPath isn't set to a valid directory" />
    <ItemGroup Condition="'$(MSBuildProjectExtension)' == '.csproj'">
      <AssemblyInfoUsings Include="using System%3B" />
      <AssemblyInfoUsings Include="using System.Reflection%3B" />
      <AssemblyInfoLines Include="[assembly:AssemblyTitle(&quot;$(AssemblyName)&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyDescription(&quot;$(AssemblyName)&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyDefaultAlias(&quot;$(AssemblyName)&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyCompany(&quot;Microsoft Corporation&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyProduct(&quot;Microsoft\x00ae .NET Framework&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyCopyright(&quot;\x00a9 Microsoft Corporation.  All rights reserved.&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyVersion(&quot;$(AssemblyVersion)&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyFileVersion(&quot;$(AssemblyFileVersion)&quot;)]" />
      <AssemblyInfoLines Include="[assembly:AssemblyInformationalVersion(@&quot;$(AssemblyFileVersion)$(BuiltByString)&quot;)]" />
      <AssemblyInfoLines Condition="'$(CLSCompliant)'=='true'" Include="[assembly:CLSCompliant(true)]" />
      <AssemblyInfoLines Condition="'$(AssemblyComVisible)'!=''" Include="[assembly:System.Runtime.InteropServices.ComVisible($(AssemblyComVisible))]" />
      <AssemblyInfoLines Condition="'$(SkipFrameworkAssemblyMetadata)' != 'true'" Include="[assembly:System.Reflection.AssemblyMetadata(&quot;%(AssemblyMetadata.Identity)&quot;, &quot;%(AssemblyMetadata.Value)&quot;)]" />
    </ItemGroup>
    <ItemGroup Condition="'$(MSBuildProjectExtension)' == '.vbproj'">
      <AssemblyInfoUsings Include="Imports System" />
      <AssemblyInfoUsings Include="Imports System.Reflection" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyTitle(&quot;$(AssemblyName)&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyDescription(&quot;$(AssemblyName)&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyDefaultAlias(&quot;$(AssemblyName)&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyCompany(&quot;Microsoft Corporation&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyProduct(&quot;Microsoft\x00ae .NET Framework&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyCopyright(&quot;\x00a9 Microsoft Corporation.  All rights reserved.&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyVersion(&quot;$(AssemblyVersion)&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyFileVersion(&quot;$(AssemblyFileVersion)&quot;)&gt;" />
      <AssemblyInfoLines Include="&lt;Assembly:AssemblyInformationalVersion(&quot;$(AssemblyFileVersion)$(BuiltByString)&quot;)&gt;" />
      <AssemblyInfoLines Condition="'$(CLSCompliant)'=='true'" Include="&lt;Assembly:CLSCompliant(True)&gt;" />
      <AssemblyInfoLines Condition="'$(AssemblyComVisible)'!=''" Include="&lt;Assembly:System.Runtime.InteropServices.ComVisible($(AssemblyComVisible))&gt;" />
      <AssemblyInfoLines Condition="'$(SkipFrameworkAssemblyMetadata)' != 'true'" Include="&lt;assembly:System.Reflection.AssemblyMetadata(&quot;%(AssemblyMetadata.Identity)&quot;, &quot;%(AssemblyMetadata.Value)&quot;)&gt;" />
    </ItemGroup>
    <ItemGroup Condition="'$(MSBuildProjectExtension)' == '.csproj' And '$(GenerateThisAssemblyClass)' == 'true'">
      <AssemblyInfoLines Include="internal static class ThisAssembly" />
      <AssemblyInfoLines Include="{" />
      <AssemblyInfoLines Include="%20%20%20%20internal const string Title = &quot;$(AssemblyName)&quot;%3B" />
      <AssemblyInfoLines Include="%20%20%20%20internal const string Copyright = &quot;\u00A9 Microsoft Corporation.  All rights reserved.&quot;%3B" />
      <AssemblyInfoLines Include="%20%20%20%20internal const string Version = &quot;$(AssemblyVersion)&quot;%3B" />
      <AssemblyInfoLines Include="%20%20%20%20internal const string InformationalVersion = &quot;$(AssemblyFileVersion)&quot;%3B" />
      <AssemblyInfoLines Include="}" />
    </ItemGroup>
    <WriteLinesToFile File="$(AssemblyInfoFile)" Lines="@(AssemblyInfoUsings);@(AssemblyInfoLines)" Overwrite="true" />
    <ItemGroup>
      <Compile Include="$(AssemblyInfoFile)" />
      <FileWrites Include="$(AssemblyInfoFile)" />
    </ItemGroup>
  </Target>
  <ItemGroup Condition="'$(GenerateAssemblyInfo)'=='true' AND '$(StringResourcesPath)' != '' AND '$(ExcludeAssemblyInfoPartialFile)' != 'true'">
    <Compile Include="$(AssemblyInfoPartialFile)">
      <Visible>true</Visible>
      <Link>$(AssemblyInfoPartialFileLink)</Link>
    </Compile>
  </ItemGroup>
  <PropertyGroup>
    <GenerateNativeVersionInfo Condition="'$(GenerateNativeVersionInfo)'==''">false</GenerateNativeVersionInfo>
  </PropertyGroup>
  <PropertyGroup Condition="'$(GenerateNativeVersionInfo)'=='true'">
    <NativeVersionHeaderFile>$(IntermediateOutputPath)_version.h</NativeVersionHeaderFile>
    <BeforeResourceCompileTargets>$(BeforeResourceCompileTargets);GenerateVersionHeader</BeforeResourceCompileTargets>
    <GenerateVersionHeader>true</GenerateVersionHeader>
    <Win32Resource>$(IntermediateOutputPath)\Native.res</Win32Resource>
    <CoreCompileDependsOn>$(CoreCompileDependsOn);NativeResourceCompile</CoreCompileDependsOn>
  </PropertyGroup>
  <Target Name="GenerateVersionHeader" Inputs="$(MSBuildProjectFile)" Outputs="$(NativeVersionHeaderFile)" Condition="'$(NativeVersionHeaderFile)'!='' and '$(GenerateVersionHeader)'=='true'">
    <ItemGroup>
      <NativeVersionLines Include="#define VER_COMPANYNAME_STR         &quot;Microsoft Corporation&quot;" />
      <NativeVersionLines Include="#define VER_FILEDESCRIPTION_STR     &quot;$(AssemblyName)&quot;" />
      <NativeVersionLines Include="#define VER_INTERNALNAME_STR        VER_FILEDESCRIPTION_STR" />
      <NativeVersionLines Include="#define VER_ORIGINALFILENAME_STR    VER_FILEDESCRIPTION_STR" />
      <NativeVersionLines Include="#define VER_PRODUCTNAME_STR         &quot;Microsoft\xae .NET Framework&quot;" />
      <NativeVersionLines Include="#define VER_PRODUCTVERSION          $(MajorVersion),$(MinorVersion),$(BuildNumberMajor),$(BuildNumberMinor)" />
      <NativeVersionLines Include="#define VER_PRODUCTVERSION_STR      &quot;$(MajorVersion).$(MinorVersion).$(BuildNumberMajor).$(BuildNumberMinor)$(BuiltByString)&quot;" />
      <NativeVersionLines Include="#define VER_FILEVERSION             $(MajorVersion),$(MinorVersion),$(BuildNumberMajor),$(BuildNumberMinor)" />
      <NativeVersionLines Include="#define VER_FILEVERSION_STR         &quot;$(MajorVersion).$(MinorVersion).$(BuildNumberMajor).$(BuildNumberMinor)$(BuiltByString)&quot;" />
      <NativeVersionLines Include="#define VER_LEGALCOPYRIGHT_STR      &quot;\xa9 Microsoft Corporation.  All rights reserved.&quot;" />
      <NativeVersionLines Condition="'$(Configuration)'=='Debug'" Include="#define VER_DEBUG                   VS_FF_DEBUG" />
      <NativeVersionLines Condition="'$(Configuration)'!='Debug'" Include="#define VER_DEBUG                   0" />
    </ItemGroup>
    <WriteLinesToFile File="$(NativeVersionHeaderFile)" Lines="@(NativeVersionLines)" Overwrite="true" />
    <ItemGroup>
      <FileWrites Include="$(NativeVersionHeaderFile)" />
    </ItemGroup>
  </Target>
  <Target Name="NativeResourceCompile" DependsOnTargets="$(BeforeResourceCompileTargets)" Inputs="$(MsBuildThisFileDirectory)NativeVersion.rc" Outputs="$(Win32Resource)">
    <Error Condition="!Exists('$(RCPATH)')" Text="NativeResourceCompile failed because RCPath is set to an non-existing rc.exe path." />
    <Exec Command="&quot;$(RCPath)&quot; /i $(IntermediateOutputPath) /i $(WindowsSDKPath)\inc /i $(VCSDKPath)\Include /D _UNICODE /D UNICODE /l&quot;0x0409&quot; /r /fo &quot;$(Win32Resource)&quot; &quot;$(MsBuildThisFileDirectory)NativeVersion.rc&quot;" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!--
    Import the localization target
  -->
  <!--<Import Project="$(MSBuildThisFileDirectory)localization.targets" Condition="'$(ExcludeLocalizationImport)'!='true'" />-->
  <!-- 
    Import the partial facade generation targets
    
      Inputs:
        IsPartialFacadeAssembly - Determines whether the partial facade generation targets will be as a post-processing step on the
          assembly. Also invokes special logic for determining References.
        AssemblyName - Needed to determine which contract name to map to
        AssemblyVersion - Needed to determine which contract version to map to
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)partialfacades.targets" Condition="'$(ExcludePartialFacadesImport)' != 'true'">

e:\gh\chcosta\corefx\Tools\partialfacades.targets
============================================================================================================================================
-->
  <UsingTask TaskName="PrereleaseResolveNuGetPackageAssets" AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" />
  <!-- Hook both partial-facade-related targets into TargetsTriggeredByCompilation. This will cause them
          to only be invoked upon a successful compilation; they can conceptualized as an extension
          of the assembly compilation process.
  -->
  <PropertyGroup>
    <TargetsTriggeredByCompilation Condition="'$(IsPartialFacadeAssembly)' == 'true'">
      $(TargetsTriggeredByCompilation);FillPartialFacade
    </TargetsTriggeredByCompilation>
  </PropertyGroup>
  <!-- If a reference assembly project exists for the partial facade, prefer that over the package  -->
  <PropertyGroup Condition="'$(IsPartialFacadeAssembly)' == 'true'">
    <ResolveReferencesDependsOn>
      FindPartialFacadeProjectReference;
      $(ResolveReferencesDependsOn)
    </ResolveReferencesDependsOn>
    <CleanDependsOn>
      FindPartialFacadeProjectReference;
      $(CleanDependsOn);
    </CleanDependsOn>
  </PropertyGroup>
  <Target Name="FindPartialFacadeProjectReference">
    <PropertyGroup>
      <_referenceAssemblyProject>$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildProjectDirectory), 'ref/$(AssemblyName).csproj'))/ref/$(AssemblyName).csproj</_referenceAssemblyProject>
      <_versionReferenceAssemblyProject>$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildProjectDirectory), 'ref/$(APIVersion)/$(AssemblyName).csproj'))/ref/$(APIVersion)/$(AssemblyName).csproj</_versionReferenceAssemblyProject>
    </PropertyGroup>
    <ItemGroup>
      <!-- first check for a specific version -->
      <ProjectReference Include="$(_versionReferenceAssemblyProject)" Condition="Exists('$(_versionReferenceAssemblyProject)')">
        <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
        <OutputItemType>ResolvedMatchingContract</OutputItemType>
        <UndefineProperties>OSGroup;TargetGroup</UndefineProperties>
      </ProjectReference>
      <!-- fall back to 'current' version -->
      <ProjectReference Include="$(_referenceAssemblyProject)" Condition="!Exists('$(_versionReferenceAssemblyProject)') AND Exists('$(_referenceAssemblyProject)')">
        <ReferenceOutputAssembly>false</ReferenceOutputAssembly>
        <OutputItemType>ResolvedMatchingContract</OutputItemType>
        <UndefineProperties>OSGroup;TargetGroup</UndefineProperties>
      </ProjectReference>
    </ItemGroup>
  </Target>
  <!-- Inputs and outputs of FillPartialFacade -->
  <PropertyGroup Condition="'$(IsPartialFacadeAssembly)' == 'true'">
    <PartialFacadeAssemblyPath>$(IntermediateOutputPath)$(TargetName)$(TargetExt)</PartialFacadeAssemblyPath>
    <PartialFacadeSymbols>$(IntermediateOutputPath)$(TargetName).pdb</PartialFacadeSymbols>
    <GenFacadesInputPath>$(IntermediateOutputPath)PreGenFacades\</GenFacadesInputPath>
    <GenFacadesInputAssembly>$(GenFacadesInputPath)$(TargetName)$(TargetExt)</GenFacadesInputAssembly>
    <GenFacadesInputSymbols>$(GenFacadesInputPath)$(TargetName).pdb</GenFacadesInputSymbols>
    <GenFacadesOutputPath>$(IntermediateOutputPath)</GenFacadesOutputPath>
  </PropertyGroup>
  <!-- FillPartialFacade
       Inputs:
         * An "input assembly"
         * A contract assembly
         * Seed assemblies

       Fills the "input assembly" by finding types in the contract assembly that are missing from it, and adding type-forwards
         to those matching types in the seed assemblies.
  -->
  <Target Name="FillPartialFacade" DependsOnTargets="EnsureBuildToolsRuntime">
    <ItemGroup>
      <!-- References used for compilation are automatically included as seed assemblies -->
      <GenFacadesSeeds Include="@(ReferencePath)" />
    </ItemGroup>
    <Error Text="No single matching contract found." Condition="'@(ResolvedMatchingContract-&gt;Count())' != '1'" />
    <PropertyGroup>
      <GenFacadesArgs>-partialFacadeAssemblyPath:"$(GenFacadesInputAssembly)"</GenFacadesArgs>
      <GenFacadesArgs>$(GenFacadesArgs) -contracts:"%(ResolvedMatchingContract.Identity)"</GenFacadesArgs>
      <GenFacadesArgs>$(GenFacadesArgs) -seeds:"@(GenFacadesSeeds, ';')"</GenFacadesArgs>
      <GenFacadesArgs>$(GenFacadesArgs) -facadePath:"$(GenFacadesOutputPath.TrimEnd('\'))"</GenFacadesArgs>
      <GenFacadesArgs Condition="'$(DebugSymbols)' == 'false'">$(GenFacadesArgs) -producePdb:false</GenFacadesArgs>
      <GenFacadesArgs Condition="'@(SeedTypePreference)' != ''">$(GenFacadesArgs) -preferSeedType:"@(SeedTypePreference->'%(Identity)=%(Assembly)', ',')"</GenFacadesArgs>
    </PropertyGroup>
    <!-- Move the assembly into a subdirectory for GenFacades -->
    <Move SourceFiles="$(PartialFacadeAssemblyPath)" DestinationFolder="$(GenFacadesInputPath)" />
    <!-- Move the PDB into a subdirectory for GenFacades if we are producing PDBs -->
    <Move SourceFiles="$(PartialFacadeSymbols)" DestinationFolder="$(GenFacadesInputPath)" Condition="'$(DebugSymbols)' != 'false'" />
    <PropertyGroup>
      <GenFacadesCmd>$(ToolHostCmd) "$(ToolsDir)GenFacades.exe"</GenFacadesCmd>
    </PropertyGroup>
    <Exec Command="$(GenFacadesCmd) $(GenFacadesArgs)" WorkingDirectory="$(ToolRuntimePath)" />
    <ItemGroup>
      <FileWrites Include="$(GenFacadesInputAssembly)" />
      <FileWrites Include="$(GenFacadesInputSymbols)" />
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the default signing targets which will setup the authenticode properties and do OpenSourceSigning
    
    Inputs:
      SkipSigning - For projects that want to opt-out of strong name signing the can set this to true.    
  -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)sign.targets" Condition="'$(ExcludeSigningImport)'!='true'">

e:\gh\chcosta\corefx\Tools\sign.targets
============================================================================================================================================
-->
  <!-- metadata used for Authenticode and strong-name signing in official VSO builds -->
  <ItemGroup Condition="'$(IsTestProject)' != 'true'">
    <FilesToSign Include="$(TargetPath)">
      <Authenticode>Microsoft</Authenticode>
      <StrongName Condition="'$(SkipSigning)' != 'true'">StrongName</StrongName>
    </FilesToSign>
  </ItemGroup>
  <UsingTask AssemblyFile="$(BuildToolsTaskDir)Microsoft.DotNet.Build.Tasks.dll" TaskName="OpenSourceSign" />
  <PropertyGroup Condition="'$(SkipSigning)'!='true'">
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>$(ToolsDir)MSFT.snk</AssemblyOriginatorKeyFile>
    <AssemblyOriginatorKeyFile Condition="'$(UseECMAKey)' == 'true'">$(ToolsDir)ECMA.snk</AssemblyOriginatorKeyFile>
    <DelaySign>true</DelaySign>
    <DefineConstants>$(DefineConstants);SIGNED</DefineConstants>
    <UseOpenSourceSign Condition="'$(UseOpenSourceSign)' == ''">true</UseOpenSourceSign>
  </PropertyGroup>
  <!-- 
    NOTE: This mechanism for wiring in the OpenSourceSign target can't be changed to any of the following:

        * AfterTargets=Compile -> hit by intellisense builds while @(IntermediateAssembly) doesn't exist yet.
        * AfterTargets=PrepareForRun -> hit after @(IntermediateAssembly) has already been copied to output.
        * BeforeTargets=CopyFilesToOutputDirectory -> does not work on Mono.
  -->
  <PropertyGroup>
    <PrepareForRunDependsOn>OpenSourceSign;$(PrepareForRunDependsOn)</PrepareForRunDependsOn>
  </PropertyGroup>
  <Target Name="OpenSourceSign" Condition="'$(DelaySign)' == 'true' and '@(IntermediateAssembly)' != '' and '$(SkipSigning)' != 'true' and '$(UseOpenSourceSign)' == 'true'" Inputs="@(IntermediateAssembly)" Outputs="%(IntermediateAssembly.Identity).oss_signed">
    <OpenSourceSign AssemblyPath="%(IntermediateAssembly.Identity)" />
    <Touch Files="%(IntermediateAssembly.Identity).oss_signed" AlwaysCreate="true" />
    <ItemGroup>
      <FileWrites Include="%(IntermediateAssembly.Identity).oss_signed" />
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <!-- 
    Import the tests.targets which controls the publishing and running of the tests, including code coverage options.
      
      Inputs:
        RunTestsForProject - Usually set at the project level to disable the tests for a single project.
        CoverageEnabledForProject - Usually set at the project level to disable code coverage for a single project. 
        SkipTests - Usually set at the root level for builds that want to disable all the tests.
        ProjectJson - If not set defaults to $(MSBuildProjectDirectory)\project.json
        CopyTestToTestDirectory - If not set defaults to $(IsTestProject)

      Depends on Properties:
        TestPath - Controls the root path from where the test assets are published and run from.
        NugetRestoreCommand - Used to restore the test runtime package
        DnuRestoreCommand - Used to restore the project packages from project.json
        PackagesDir - Packages are restored to and resolved from this location    
   -->
  <!--<Import Project="$(MSBuildThisFileDirectory)tests.targets" Condition="'$(IsTestProject)'=='true' and '$(ExcldueTestsImport)'!='true'" />-->
  <!-- 
    Import the PackageLibs.targets which exposes targets from library projects to report what
    assets they contribute to nuget packages.
      
      Optional Inputs:
        PackageSourcePath - Source path to the built output to be packaged, default is $(TargetPath)
                            Can be overridden.
        IsReferenceAssembly - true if this project is a reference assembly.
        PackageTargetPath - Destination subpath in the package at which all assets from this project
                            should be located.  Default is lib\dotnet for implementation assemblies,
                            ref\dotnet for reference assemblies.  Can be overridden.  When overridding
                            also override PackageTargetFramework.
        PackageTargetFramework - Target moniker to use for harvested dependencies, default is 'dotnet'.
                                 Can be overridden.  If PackageTargetFramework is overridden and PackageTargetPath
                                 is not, PackageTargetPath will be constructed based on PackageTargetFramework.
        PackageTargetRuntime - Runtime id to use for harvested dependencies, default is none.
                               Can be overridden.  If PackageTargetRuntime is overridden and PackageTargetPath
                               is not, PackageTargetPath will be constructed based on PackageTargetRuntime.
        @(PackageDestination) - List of items with TargetFramework metadata that represent destination 
                                subpaths in the package at which all assets from this project should be 
                                located.  When specified takes precedence over PackageTargetPath & 
                                PackageTargetFramework.
        DocumentationFile - location of xml doc produced by this project.
        XmlDocFileRoot - location to pre-authored localized xml doc files
        PackageIncludeDocs - true to include the docs next to this project's ouput.  Default
                             is true for reference assemblies, false for implementation.
   -->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)PackageLibs.targets" Condition="'$(ExclduePackageLibsImport)'!='true'">

e:\gh\chcosta\corefx\Tools\PackageLibs.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <PackagingTaskDir Condition="'$(PackagingTaskDir)' == ''">$(MSBuildThisFileDirectory)</PackagingTaskDir>
    <GenerationDefinitionFile Condition="'$(GenerationDefinitionFile)' == ''">$(MSBuildThisFileDirectory)Generations.json</GenerationDefinitionFile>
  </PropertyGroup>
  <UsingTask TaskName="ValidatePackageTargetFramework" AssemblyFile="$(PackagingTaskDir)Microsoft.DotNet.Build.Tasks.Packaging.dll" />
  <!-- Returns the set of files to be included in the nuget package
       with appropriate metadata.-->
  <Target Name="GetFilesToPackage" Returns="@(FilesToPackage)">
    <PropertyGroup>
      <PackagePath Condition="'$(PackagePath)' == ''">$(TargetPath)</PackagePath>
      <PackageIncludeDocs Condition="'$(PackageIncludeDocs)' == '' AND '$(IsReferenceAssembly)' == 'true'">true</PackageIncludeDocs>
      <PackageIncludeDocs Condition="'$(PackageIncludeDocs)' == '' AND '$(DocumentationFile)' != ''">true</PackageIncludeDocs>
    </PropertyGroup>
    <!-- XmlDocFileRoot should be defined externally since these are currently not
         part of the corefx repo. -->
    <!-- This isn't a straight mapping to an algorithm using CultureInfo.
         There are special cases for en-US and zh-* so we manually list
         the mapping.-->
    <ItemGroup>
      <XmlDocFile Include="$(XmlDocFileRoot)\1028\$(TargetName).xml">
        <SubFolder>/zh-hant</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1031\$(TargetName).xml">
        <SubFolder>/de</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1033\$(TargetName).xml">
        <SubFolder />
        <!-- en docs go in root as neutral fall back -->
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1036\$(TargetName).xml">
        <SubFolder>/fr</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1040\$(TargetName).xml">
        <SubFolder>/it</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1041\$(TargetName).xml">
        <SubFolder>/ja</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1042\$(TargetName).xml">
        <SubFolder>/ko</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\1049\$(TargetName).xml">
        <SubFolder>/ru</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\2052\$(TargetName).xml">
        <SubFolder>/zh-hans</SubFolder>
      </XmlDocFile>
      <XmlDocFile Include="$(XmlDocFileRoot)\3082\$(TargetName).xml">
        <SubFolder>/es</SubFolder>
      </XmlDocFile>
    </ItemGroup>
    <!-- currently behind a flag to avoid noise in the build -->
    <Warning Condition="'$(ValidateDocs)' == 'true' AND '$(PackageIncludeDocs)' == 'true' AND !Exists('%(XmlDocFile.Identity)')" Text="Documentation file %(XmlDocFile.Identity) was not found." />
    <!-- remove any missing docs-->
    <ItemGroup>
      <XmlDocFile Remove="@(XmlDocFile)" Condition="!Exists('%(XmlDocFile.Identity)')" />
    </ItemGroup>
    <!-- Desktop libraries that contain types in classic assemblies need to be included in ref
         so that the types unify with the classic assemblies from the targeting pack. -->
    <PropertyGroup>
      <PackageAsRefAndLib Condition="'$(PackageAsRefAndLib)' == '' AND '$(IsPartialFacadeAssembly)' == 'true' AND $(PackageTargetFramework.StartsWith('net4', StringComparison.OrdinalIgnoreCase))">true</PackageAsRefAndLib>
      <!-- A reference asset is any file contributed from a project that is contributing a reference,
           not just the file in the ref folder. -->
      <IsReferenceAsset>false</IsReferenceAsset>
      <IsReferenceAsset Condition="'$(IsReferenceAssembly)' == 'true' OR '$(PackageAsRefAndLib)' == 'true'">true</IsReferenceAsset>
    </PropertyGroup>
    <Error Condition="'$(IsReferenceAsset)' == 'true' AND '$(PackageTargetRuntime)' != ''" Text="Reference assemblies should not specify the PackageTargetRuntime property since runtimes cannot effect compile time assets." />
    <!-- PackageTargetRuntime Defaults -->
    <PropertyGroup Condition="'$(UsePackageTargetRuntimeDefaults)' == 'true' AND '$(PackageTargetRuntime)' == ''">
      <PackageTargetRuntime Condition=" '$(TargetsWindows)' == 'true'">win7</PackageTargetRuntime>
      <PackageTargetRuntime Condition="'$(TargetsUnix)' == 'true'">unix</PackageTargetRuntime>
    </PropertyGroup>
    <!-- *** determine destination path for assets *** -->
    <PropertyGroup>
      <_packageTargetRefLib>lib</_packageTargetRefLib>
      <_packageTargetRefLib Condition="'$(IsReferenceAssembly)' == 'true'">ref</_packageTargetRefLib>
      <!-- no path or runtime, but framework: lib/{txm}-->
      <PackageTargetPath Condition="'$(PackageTargetPath)' == '' AND '$(PackageTargetRuntime)' == '' AND '$(PackageTargetFramework)' != ''">$(_packageTargetRefLib)/$(PackageTargetFramework)</PackageTargetPath>
      <!-- no path but runtime and framework: runtimes/{rid}/lib/{txm}-->
      <PackageTargetPath Condition="'$(PackageTargetPath)' == '' AND '$(PackageTargetFramework)' != '' AND '$(PackageTargetRuntime)' != ''">runtimes/$(PackageTargetRuntime)/lib/$(PackageTargetFramework)</PackageTargetPath>
    </PropertyGroup>
    <!-- specifying $(PackageTargetPath) overrides defaults and project specific items -->
    <ItemGroup Condition="'$(PackageTargetPath)' != ''">
      <!-- remove anything specified by the project-->
      <PackageDestination Remove="@(PackageDestination)" />
      <!-- only use $(PackageTargetPath) -->
      <PackageDestination Include="$(PackageTargetPath)">
        <TargetFramework Condition="'$(PackageTargetFramework)' != ''">$(PackageTargetFramework)</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(PackageAsRefAndLib)' == 'true'" Include="ref/$(PackageTargetFramework)">
        <TargetFramework>$(PackageTargetFramework)</TargetFramework>
      </PackageDestination>
    </ItemGroup>
    <!-- default to dotnet if not specified by the project  -->
    <ItemGroup Condition="'@(PackageDestination)' == ''">
      <PackageDestination Include="$(_packageTargetRefLib)/dotnet">
        <TargetFramework>dotnet</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(PackageAsRefAndLib)' == 'true'" Include="ref/dotnet">
        <TargetFramework>dotnet</TargetFramework>
      </PackageDestination>
    </ItemGroup>
    <!-- *** include assets *** -->
    <ItemGroup>
      <!-- Include primary output -->
      <FilesToPackage Include="$(PackagePath)">
        <AssemblyVersion>$(AssemblyVersion)</AssemblyVersion>
        <TargetFramework>%(PackageDestination.TargetFramework)</TargetFramework>
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
        <IsReferenceAsset>$(IsReferenceAsset)</IsReferenceAsset>
      </FilesToPackage>
      <!-- Include doc output if it isn't centrally authored -->
      <FilesToPackage Include="$(DocumentationFile)" Condition="'$(DocumentationFile)' != '' AND '@(XmlDocFile)' == '' AND '$(PackageIncludeDocs)' == 'true'">
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
        <IsReferenceAsset>$(IsReferenceAsset)</IsReferenceAsset>
        <!-- intentionally omit TargetFramework: no dependencies for docs -->
      </FilesToPackage>
      <!-- Include pre-authored docs if available and required -->
      <FilesToPackage Include="@(XmlDocFile)" Condition="'$(PackageIncludeDocs)' == 'true'">
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
        <IsReferenceAsset>$(IsReferenceAsset)</IsReferenceAsset>
        <!-- intentionally omit TargetFramework: no dependencies for docs -->
      </FilesToPackage>
      <FilesToPackage Condition="'%(FilesToPackage.SubFolder)' != ''">
        <TargetPath>%(TargetPath)%(FilesToPackage.SubFolder)</TargetPath>
      </FilesToPackage>
    </ItemGroup>
  </Target>
  <Target Name="ValidatePackageTargetFramework" Inputs="$(MSBuildAllProjects);@(CustomAdditionalCompileInputs);@(ReferencePath)" Outputs="@(IntermediateAssembly)" Condition="'$(PackageTargetFramework)' != '' AND '$(SkipValidatePackageTargetFramework)' != 'true'" AfterTargets="ResolveReferences">
    <ItemGroup Condition="'@(ValidateIgnoreReference)' == ''">
      <ValidateIgnoreReference Include="mscorlib;System.Private.Uri;Windows" />
    </ItemGroup>
    <ValidatePackageTargetFramework AssemblyName="$(AssemblyName)" AssemblyVersion="$(AssemblyVersion)" GenerationDefinitionsFile="$(GenerationDefinitionFile)" PackageTargetFramework="$(PackageTargetFramework)" DirectReferences="@(ReferencePath)" CandidateReferences="@(ReferencePath);@(IndirectReference)" IgnoredReferences="@(ValidateIgnoreReference)" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\Tools\Build.Common.targets
============================================================================================================================================
-->
  <Target Name="CheckDesignTime">
    <!--
      Visual Studio does a number of background builds to do a variety of tasks such as resolving references and preparing for intellisense.
      These are called "design time" builds. You can only determine this state within a target as the properties VS sets are added at build time.

      To see design time logs set TRACEDESIGNTIME=true before launching Visual Studio. Logs will go to %TEMP%.

      Note that the existing $(DesignTimeBuild) is not set for all background builds.
    -->
    <PropertyGroup>
      <VSDesignTimeBuild Condition="'$(BuildingInsideVisualStudio)'=='true' and '$(BuildingOutOfProcess)'=='false'">true</VSDesignTimeBuild>
    </PropertyGroup>
  </Target>
  <!--
    Providing a definition for __BlockReflectionAttribute in an assembly is a signal to the .NET Native toolchain 
    to remove the metadata for all non-public APIs. This both reduces size and disables private reflection on those 
    APIs in libraries that include this. The attribute can also be applied to individual public APIs to similarly block them.
  -->
  <PropertyGroup>
    <BlockReflectionAttribute Condition="'$(BlockReflectionAttribute)'=='' and ('$(TargetGroup)'=='netcore50' or '$(TargetGroup)'=='netcore50aot')">true</BlockReflectionAttribute>
    <BlockReflectionAttribute Condition="'$(MSBuildProjectExtension)' == '.vbproj'">false</BlockReflectionAttribute>
  </PropertyGroup>
  <PropertyGroup Condition="'$(BlockReflectionAttribute)'=='true'">
    <CoreCompileDependsOn>$(CoreCompileDependsOn);AddBlockReflectionAttribute</CoreCompileDependsOn>
    <BlockReflectionAtributeFile>$(MSBuildThisFileDirectory)\BlockReflectionAttribute.cs</BlockReflectionAtributeFile>
  </PropertyGroup>
  <Target Name="AddBlockReflectionAttribute">
    <ItemGroup>
      <Compile Include="$(BlockReflectionAtributeFile)" />
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\dir.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\src\dir.targets
============================================================================================================================================
-->
  <!-- Returns the assembly version of the project for consumption
       by the NuGet package generation -->
  <Target Name="GetAssemblyVersion" Returns="$(AssemblyVersion)" />
  <!-- Returns the generated documentation file for consumption
       by the NuGet package generation -->
  <Target Name="GetDocumentationFile" Returns="$(DocumentationFile)" />
  <!--
============================================================================================================================================
  <Import Project="..\override.targets" Condition="Exists('..\override.targets')">

e:\gh\chcosta\corefx\override.targets
============================================================================================================================================
-->
  <!--
    Overrides for all other targets (including build tools) can go in this file.
  -->
  <!--<Import Project="mono.targets" Condition="'$(OsEnvironment)'=='Unix'" />-->
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\src\dir.targets
============================================================================================================================================
-->
  <Target Name="DumpTargets">
    <Message Text="$(MSBuildProjectName), OS=$(OSGroup), Target=$(TargetGroup)" Importance="High" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

e:\gh\chcosta\corefx\src\System.Net.NameResolution\pkg\System.Net.NameResolution.pkgproj
============================================================================================================================================
-->
</Project>