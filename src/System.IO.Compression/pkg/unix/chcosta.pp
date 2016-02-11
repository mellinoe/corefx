The target "CopyFilesToOutputDirectory" listed in an AfterTargets attribute at "E:\ProjectK\src\NDP\Common\inc\ProductFile.targets (280,94)" does not exist in the project, and will be ignored.
<?xml version="1.0" encoding="IBM437"?>
<!--
============================================================================================================================================
E:\ProjectK\src\NDP\FxCore\src\Packages\System.IO.Compression\unix\System.IO.Compression.nuproj
============================================================================================================================================
-->
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <!--
============================================================================================================================================
  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), Packaging.settings.targets))\Packaging.settings.targets">

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.settings.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <NuProjPath Condition=" '$(NuProjPath)' == '' ">$(MSBuildExtensionsPath)\NuProj\</NuProjPath>
    <PackagesPath>$(MSBuildThisFileDirectory)</PackagesPath>
    <SourcesPath>$(PackagesPath)..\</SourcesPath>
    <OpenSourcesPath>$(PackagesPath)..\..\Open\src\</OpenSourcesPath>
    <OpenPackagesPath>$(PackagesPath)..\..\Open\pkg\</OpenPackagesPath>
    <ContractsPath>$(PackagesPath)..\Contracts\</ContractsPath>
    <FacadesPath>$(PackagesPath)..\Contracts\TargetFrameworks\</FacadesPath>
    <ImportLibraryTargets>false</ImportLibraryTargets>
    <ExcludeDefaultReferences>true</ExcludeDefaultReferences>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="..\dir.settings.targets">

E:\ProjectK\src\NDP\FxCore\src\dir.settings.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="..\dir.settings.targets">

E:\ProjectK\src\NDP\FxCore\dir.settings.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <!--Defines unique ID for every project that is used to configure MsBuild FullTracking mode-->
    <MSBuildFullTrackingPath Condition="'$(BUILDCOP_TRACER_ENABLED)'=='1'">$(MSBuildProjectFullPath.ToLowerInvariant().GetHashCode().ToString("X"))</MSBuildFullTrackingPath>
  </PropertyGroup>
  <!-- Set $(EnlistmentRoot) to the top-level directory that parents cross-partition ExternalApis, InternalApis, tools, etc.
       Do not "improve" this to be "$(_NTDRIVE)$(_NTROOT)" like the CLR targets file do. Most of our managed projects
       are now buildable under VS (without being in a Razzle ghetto) and we like it that way.
    -->
  <PropertyGroup>
    <EnlistmentRootPath>$(MSBuildThisFileDirectory)..\..\</EnlistmentRootPath>
  </PropertyGroup>
  <PropertyGroup>
    <NoStdLib>true</NoStdLib>
    <NoExplicitReferenceToStdLib>true</NoExplicitReferenceToStdLib>
    <AddAdditionalExplicitAssemblyReferences>false</AddAdditionalExplicitAssemblyReferences>
    <GenerateTargetFrameworkAttribute>false</GenerateTargetFrameworkAttribute>
    <EnableUnmanagedDebugging>true</EnableUnmanagedDebugging>
    <UseVSHostingProcess>false</UseVSHostingProcess>
    <RunToolsOutsideOfRazzle Condition="'$(RUN_TOOLS_OUTSIDE_OF_RAZZLE)'=='1'">true</RunToolsOutsideOfRazzle>
    <TreatWarningsAsErrors Condition="'$(WARNINGS_AS_ERRORS)'!='0'">true</TreatWarningsAsErrors>
    <OutputType Condition="'$(OutputType)'==''">library</OutputType>
    <!-- Turn on build that challenges Bartok/UTC's optimization abilities. Replaces hand-optimized ninja code in hit paths with nice dumb C# code. -->
    <Test_Codegen_Optimization Condition="'$(Test_Codegen_Optimization)'!=''">true</Test_Codegen_Optimization>
    <!-- Tell msbuild to not copy any of my referenced assemblies to the output -->
    <UseCommonOutputDirectory>true</UseCommonOutputDirectory>
    <ShouldUnsetParentConfigurationAndPlatform>false</ShouldUnsetParentConfigurationAndPlatform>
  </PropertyGroup>
  <!-- Currently this target only supports arm, x86, amd64 | dbg, chk, ret if others are needed they will need to be handled below -->
  <PropertyGroup>
    <!-- If building from VS then Configuration and Platform should be set -->
    <!-- If running from razzle then default themt from _BuildType and _BuildArch -->
    <Configuration Condition="'$(Configuration)' ==''">Debug</Configuration>
    <Configuration Condition="'$(_BuildType)' =='ret'">Release</Configuration>
    <Platform Condition="'$(Platform)'==''">x86</Platform>
    <Platform Condition="'$(_BuildArch)'=='amd64'">amd64</Platform>
    <Platform Condition="'$(_BuildArch)'=='arm'">arm</Platform>
    <Platform Condition="'$(_BuildArch)'=='arm64'">arm64</Platform>
  </PropertyGroup>
  <!-- If _BuildType isn't set then assuming we are running outside razzle and so we need to set these variables -->
  <PropertyGroup Condition="'$(_BuildType)'==''">
    <_BuildType Condition="'$(_BuildType)'==''">chk</_BuildType>
    <_BuildType Condition="'$(Configuration)'=='Release'">ret</_BuildType>
    <_BuildArch Condition="'$(_BuildArch)'==''">x86</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='amd64'">amd64</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='arm'">arm</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='arm64'">arm64</_BuildArch>
  </PropertyGroup>
  <PropertyGroup>
    <!-- The IL libraries should always be Portable with AnyCPU unless they require to be specific to an architecture -->
    <PlatformTarget>AnyCPU</PlatformTarget>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildType)' == 'dbg'">
    <DebugSymbols Condition="'$(DebugSymbols)' == ''">true</DebugSymbols>
    <Optimize Condition="'$(Optimize)' == ''">false</Optimize>
    <DebugType Condition="'$(DebugType)' == ''">full</DebugType>
    <DefineConstants>$(DefineConstants);DEBUG</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildType)' == 'chk'">
    <DebugSymbols Condition="'$(DebugSymbols)' == ''">true</DebugSymbols>
    <Optimize Condition="'$(Optimize)' == ''">false</Optimize>
    <DebugType Condition="'$(DebugType)' == ''">full</DebugType>
    <DefineConstants>$(DefineConstants);DEBUG</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildType)' == 'ret'">
    <DebugSymbols Condition="'$(DebugSymbols)' == ''">true</DebugSymbols>
    <Optimize Condition="'$(Optimize)' == ''">true</Optimize>
    <DebugType Condition="'$(DebugType)' == ''">pdbonly</DebugType>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildArch)'=='x86'">
    <DefineConstants>$(DefineConstants);WIN32;X86</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildArch)'=='amd64'">
    <DefineConstants>$(DefineConstants);WIN64;AMD64;ALIGN_ACCESS</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildArch)'=='arm'">
    <DefineConstants>$(DefineConstants);WIN32;ARM</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(_BuildArch)'=='arm64'">
    <DefineConstants>$(DefineConstants);WIN64;ARM64</DefineConstants>
  </PropertyGroup>
  <PropertyGroup Condition="'$(Test_Codegen_Optimization)'!=''">
    <DefineConstants>$(DefineConstants);TEST_CODEGEN_OPTIMIZATION</DefineConstants>
  </PropertyGroup>
  <!-- Setup some common paths -->
  <PropertyGroup>
    <BinariesRootPath>$([System.IO.Path]::GetFullPath('$(_NTTREEBASE)\..'))\</BinariesRootPath>
    <CommonPath>$(MSBuildThisFileDirectory)\src\Common</CommonPath>
    <PackagesDir>$(BinariesRootPath)packages\</PackagesDir>
  </PropertyGroup>
  <!-- Setup various paths -->
  <PropertyGroup>
    <FxRootPath>$(MSBuildThisFileDirectory)</FxRootPath>
    <FxOpenSourceRootPath>$(FxRootPath)Open\src\</FxOpenSourceRootPath>
    <WcfOpenSourceRootPath Condition="'$(WcfOpenSourceRootPath)' == ''">$(FxRootPath)WcfOpen\src\</WcfOpenSourceRootPath>
    <ExternalAPIsPath>$(EnlistmentRootPath)ExternalApis</ExternalAPIsPath>
    <WindowsSDKPath>$(ExternalAPIsPath)\Windows\8.0\sdk</WindowsSDKPath>
    <WindowsSDKLibPath>$(WindowsSDKPath)\lib\$(_BuildArch)</WindowsSDKLibPath>
    <WindowsSDKLibPath Condition="'$(_BuildArch)'=='x86'">$(WindowsSDKPath)\lib\i386</WindowsSDKLibPath>
    <!-- ARM64TODO: WorkAround till DesktopArm64 sdk and tools are brought in-->
    <WindowsSDKLibPath Condition="'$(_BuildArch)'=='arm64'">$(ExternalAPIsPath)\Win9CoreSystem\sdk\lib\$(_BuildArch)</WindowsSDKLibPath>
    <WindowsSDKPath Condition="'$(_BuildArch)'=='arm64'">$(ExternalAPIsPath)\Win9CoreSystem;$(WindowsSDKPath)</WindowsSDKPath>
    <VCSDKPath>$(ExternalAPIsPath)\VisualStudio\11.0\VC</VCSDKPath>
    <VCSDKPath Condition="'$(_BuildArch)'=='arm64'">$(ExternalAPIsPath)\Win9CoreSystem\inc\crt;$(VCSDKPath)</VCSDKPath>
    <Framework45RefPath>$(ExternalAPIsPath)\NetFX\v4.5\ref</Framework45RefPath>
    <FrameworkPortableRootPath>$(ExternalAPIsPath)\NetFx\Portable</FrameworkPortableRootPath>
    <FrameworkPortableProfile3RefPath>$(FrameworkPortableRootPath)</FrameworkPortableProfile3RefPath>
    <WindowsSDKMetadataPath>$(ExternalAPIsPath)\Windows\Win8.1\ref</WindowsSDKMetadataPath>
    <ToolsPath>$(MsBuildThisFileDirectory)Tools</ToolsPath>
    <McgPath>$(ToolsPath)\mcg\mcg.exe</McgPath>
    <ResPath>$(ToolsPath)\Res\ResourceGenerator.exe</ResPath>
    <JsonToTxtPath>$(ToolsPath)\Res\JSonToTxt.exe</JsonToTxtPath>
    <PInvokeCheckerFolder>$(EnlistmentRootPath)\Tools\devdiv\PInvokeChecker\</PInvokeCheckerFolder>
    <PInvokeCheckerPath>$(PInvokeCheckerFolder)PInvokeChecker.exe</PInvokeCheckerPath>
    <ResourceUsageCheckerFolder>$(ToolsPath)\ResourceUsageChecker\</ResourceUsageCheckerFolder>
    <ResourceUsageCheckerPath>$(ResourceUsageCheckerFolder)ResourceUsageChecker.exe</ResourceUsageCheckerPath>
    <MakePriPath>$(ToolsPath)\MakePri\makepri.exe</MakePriPath>
    <NotImpFinderFolder>$(ToolsPath)\NotImpFinder\</NotImpFinderFolder>
    <NotImpFinderPath>$(NotImpFinderFolder)NotImpFinder.exe</NotImpFinderPath>
    <RCPath>$(EnlistmentRootPath)tools\x86\rc.exe</RCPath>
    <RCDllPath>$(EnlistmentRootPath)tools\x86\rcdll.dll</RCDllPath>
    <BuildWhitelistPath>$(EnlistmentRootPath)tools\x86\managed\v4.5\BuildWhitelist.exe</BuildWhitelistPath>
    <FxCoreToolsPath>$(ToolsPath)\FxCore\</FxCoreToolsPath>
    <GenFacadePath>$(FxCoreToolsPath)GenFacades.exe</GenFacadePath>
    <ApiCompatPath>$(FxCoreToolsPath)ApiCompat.exe</ApiCompatPath>
    <CreateFrameworkListPath>$(FxCoreToolsPath)CreateFrameworkList.exe</CreateFrameworkListPath>
  </PropertyGroup>
  <ItemGroup>
    <OpenSourceRootPath Include="$(FxOpenSourceRootPath)" />
    <OpenSourceRootPath Include="$(WcfOpenSourceRootPath)" />
  </ItemGroup>
  <!-- Setup the intermediate paths -->
  <PropertyGroup>
    <!-- Some razzle environments including official build will not have IntermediateRootPath set 
         as an environment variable. Use the same default as the standard devdiv targets in that 
         case. -->
    <IntermediateRootPath Condition="'$(IntermediateRootPath)'=='' and '$(_NTTREEBASE)'!=''">$(_NTTREEBASE)\Intermediate</IntermediateRootPath>
    <IntermediateRootPath Condition="'$(IntermediateRootPath)'==''">$(EnlistmentRootPath)..\Intermediate</IntermediateRootPath>
    <IntermediateRootPath Condition="!HasTrailingSlash('$(IntermediateRootPath)')">$(IntermediateRootPath)\</IntermediateRootPath>
    <IntermediateRootPath Condition="'$(OSGroup)'!='Windows_NT'">$(IntermediateRootPath)$(OSGroup)\</IntermediateRootPath>
    <IntermediateRootPath>$(IntermediateRootPath)FxCore\$(_BuildArch)$(_BuildType)\</IntermediateRootPath>
    <BaseIntermediateOutputPath>$(IntermediateRootPath)$(IntermediatePrefix)</BaseIntermediateOutputPath>
    <IntermediateOutputPath>$(BaseIntermediateOutputPath)$(MSBuildProjectName)</IntermediateOutputPath>
    <IntermediateOutputPath Condition="!HasTrailingSlash('$(IntermediateOutputPath)')">$(IntermediateOutputPath)\</IntermediateOutputPath>
    <IntermediateReflectionBlockerWhiteListDirectory>$(IntermediateRootPath)ReflectionBlockerWhiteList\</IntermediateReflectionBlockerWhiteListDirectory>
    <ReflectionBlockerWhiteListFile>$(IntermediateReflectionBlockerWhiteListDirectory)whitelist.txt</ReflectionBlockerWhiteListFile>
    <IntermediateValidationLogsPath>$(IntermediateRootPath)ValidationLogs</IntermediateValidationLogsPath>
  </PropertyGroup>
  <!-- Setup the output paths -->
  <PropertyGroup>
    <!-- $(BinaryRoot) looks unused from inspection of the msbuild files but environments such as ddenlist set them.
         In addition, for more mysterious reasons, it seems to make builds from within VS work. -->
    <BinaryRoot Condition="'$(BinaryRoot)'==''">$(EnlistmentRootPath)..\binaries</BinaryRoot>
    <BinaryRoot Condition="!HasTrailingSlash('$(BinaryRoot)')">$(BinaryRoot)\</BinaryRoot>
    <OutputRootPath>$(BinaryRoot)$(_BuildArch)$(_BuildType)</OutputRootPath>
    <!-- Override the default computed output root if _NTTree is set by razzle -->
    <OutputRootPath Condition="'$(_NTTree)'!=''">$(_NTTree)</OutputRootPath>
    <OutputRootPath Condition="!HasTrailingSlash('$(OutputRootPath)')">$(OutputRootPath)\</OutputRootPath>
    <!-- Set ContractOutputPath before any OS specific change to outputrootpath because we want to share the
         contracts independent of OS in our build. -->
    <ContractOutputPath>$(OutputRootPath)Contracts\</ContractOutputPath>
    <OutputRootPath Condition="'$(OSGroup)'!='Windows_NT'">$(OutputRootPath)$(OSGroup)\</OutputRootPath>
    <FrameworkILOutputPath>$(OutputRootPath)ProjectN\layout\ilc\lib\il\</FrameworkILOutputPath>
    <FacadeOutputPath>$(OutputRootPath)ProjectN\layout\ilc\lib\Facades</FacadeOutputPath>
    <!-- Every project under fx\src either sets OutputPath to something or overrides the normal
         copy-output logic making OutputPath irrelevant. We still need to set it to something valid
         though as the Microsoft.Common target files validate OutputPath on project initialization.
         Setting it to OutputRootPath for lack of a better place - if anyone drops files there,
         it'll get noticed pretty quickly. -->
    <OutputPath Condition="'$(OutputPath)'==''">$(OutputRootPath)</OutputPath>
    <FxOutputPath>$(OutputPath)NETCore\</FxOutputPath>
    <FxLibraryOutputPath>$(FxOutputPath)Libraries\</FxLibraryOutputPath>
    <FXInterIncCandidatePath>$(OutputRootPath)InterAPIsCandidates\FxCore\Inc</FXInterIncCandidatePath>
  </PropertyGroup>
  <PropertyGroup>
    <!-- property indicating if the build is happening on an official build machine -->
    <OfficialBuild Condition="'$(OFFICIAL_BUILD_MACHINE)' != ''">true</OfficialBuild>
    <OfficialBuild Condition="'$(OFFICIAL_BUILD_MACHINE)' == ''">false</OfficialBuild>
    <!-- property indicating if the build is happening on an OTG build machine -->
    <OtgBuild Condition="'$(OTG_BUILD_MACHINE)' != ''">true</OtgBuild>
    <OtgBuild Condition="'$(OTG_BUILD_MACHINE)' == ''">false</OtgBuild>
    <!-- Indicates that framework libraries should be restored from nuget packages instead of built from source -->
    <RestoreProjectNLibraries Condition="'$(RestoreProjectNLibraries)' == '' and ($(_BuildBranch.StartsWith('ProjN')) or $(_BuildBranch.StartsWith('ProjectN')))">true</RestoreProjectNLibraries>
    <RestoreProjectNLibraries Condition="'$(RestoreProjectNLibraries)' != 'true'">false</RestoreProjectNLibraries>
    <RestoreProjectNRootPath Condition="'$(RestoreProjectNRootPath)'==''">$(PackagesDir)RestoreProjectN\</RestoreProjectNRootPath>
    <RestoreProjectNRootPath Condition="!HasTrailingSlash('$(RestoreProjectNRootPath)')">$(RestoreProjectNRootPath)\</RestoreProjectNRootPath>
    <RestoreProjectNLibraryPath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\IL\</RestoreProjectNLibraryPath>
    <RestoreProjectNContractPath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\Contracts\</RestoreProjectNContractPath>
    <RestoreProjectNSymbolCachePath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\SymbolCache\</RestoreProjectNSymbolCachePath>
    <!-- In the ProjectN branch, when building all libraries, suppress building other than ProjectN libraries -->
    <OnlyBuildProjectNLibraries Condition="'$(OnlyBuildProjectNLibraries)'=='' and '$(BuildAllProjects)'=='true' and ($(_BuildBranch.StartsWith('ProjN')) or $(_BuildBranch.StartsWith('ProjectN')))">true</OnlyBuildProjectNLibraries>
    <OnlyBuildProjectNLibraries Condition="'$(OnlyBuildProjectNLibraries)'!='true'">false</OnlyBuildProjectNLibraries>
    <!--
      Indicates that a framework library should be picked from a local folder instead of the RestoreProjectNRootPath.
      For now we only allow enabling this in the ProjectN branches; this might change in the future though.
    -->
    <RestoreFromLocalFolder Condition="'$(RestoreFromLocalFolderPath)' != '' and ($(_BuildBranch.StartsWith('ProjN')) or $(_BuildBranch.StartsWith('ProjectN')))">true</RestoreFromLocalFolder>
    <RestoreFromLocalFolder Condition="'$(RestoreFromLocalFolder)' != 'true'">false</RestoreFromLocalFolder>
  </PropertyGroup>
  <PropertyGroup>
    <!-- default source control bindings -->
    <SccProjectName>SAK</SccProjectName>
    <SccLocalPath>SAK</SccLocalPath>
    <SccAuxPath>SAK</SccAuxPath>
    <SccProvider>SAK</SccProvider>
  </PropertyGroup>
  <PropertyGroup>
    <GenerateAssemblyInfo>true</GenerateAssemblyInfo>
    <GenerateNativeVersionInfo>true</GenerateNativeVersionInfo>
  </PropertyGroup>
  <!-- Fix delimiter in DefineConstants value for VB projects -->
  <PropertyGroup Condition="'$(MSBuildProjectExtension)' == '.vbproj'">
    <DefineConstants>$(DefineConstants.Replace(';', ','))</DefineConstants>
  </PropertyGroup>
  <!-- Clear default msbuild target framework properties to prevent it from finding things outside the enlistment -->
  <PropertyGroup>
    <TargetRuntime>None</TargetRuntime>
    <TargetFrameworkIdentifier />
    <TargetFrameworkVersion />
  </PropertyGroup>
  <!-- Roslyn FXCop Analyzers ... -->
  <PropertyGroup Condition="'$(ENABLE_ROSLYN_CODEANALYSIS)' == 'True'">
    <ErrorLog>$(OutputRootPath)\SDLScans\$(MSBuildProjectName)-SDL.json</ErrorLog>
    <CodeAnalysisRuleSet Condition="'$(CodeAnalysisRuleSet)' == ''">$(EnlistmentRootPath)\Tools\fxcop\Bin\Sdl\Sdl7.0.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>
  <ItemGroup Condition="'$(ENABLE_ROSLYN_CODEANALYSIS)' == 'True' And '$(MSBuildProjectExtension)' == '.csproj'">
    <Analyzer Include="$(ToolsPath)\Analyzers\Microsoft.SecurityDevelopmentLifecycle.Diagnostics.CSharp.dll" />
  </ItemGroup>
  <ItemGroup Condition="'$(ENABLE_ROSLYN_CODEANALYSIS)' == 'True' And '$(MSBuildProjectExtension)' == '.vbproj'">
    <Analyzer Include="$(ToolsPath)\Analyzers\Microsoft.SecurityDevelopmentLifecycle.Diagnostics.VisualBasic.dll" />
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\dir.settings.targets
============================================================================================================================================
-->
  <!-- Import OS configuration properties -->
  <!--
============================================================================================================================================
  <Import Project="OSConfig.props">

E:\ProjectK\src\NDP\FxCore\src\OSConfig.props
============================================================================================================================================
-->
  <!-- 
  Projects that have no OS-specific implementations just use Debug and Release for $(Configuration).
  Projects that do have OS-specific implementations use OS_Debug and OS_Release, for all OS's we support even
  if the code is the same between some OS's (so if you have some project that just calls POSIX APIs, we still have
  OSX_[Debug|Release] and Linux_[Debug|Release] configurations.  We do this so that we place all the output under
  a single binary folder and can have a similar experiance between the command line and Visual Studio.
  
  Since now have multiple *Debug and *Release configurations, ConfigurationGroup is set to Debug for any of the
  debug configurations, and to Release for any of the release configurations.
  -->
  <!-- Set default Configuration and Platform -->
  <PropertyGroup>
    <Platform Condition="'$(Platform)'==''">AnyCPU</Platform>
    <Configuration Condition="'$(Configuration)'==''">Debug</Configuration>
    <ConfigurationGroup Condition="$(Configuration.EndsWith('Debug'))">Debug</ConfigurationGroup>
    <ConfigurationGroup Condition="$(Configuration.EndsWith('Release'))">Release</ConfigurationGroup>
    <ConfigurationGroup Condition="'$(ConfigurationGroup)'==''">$(Configuration)</ConfigurationGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('Windows'))">Windows_NT</OSGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('Linux'))">Linux</OSGroup>
    <OSGroup Condition="'$(OSGroup)'=='' and $(Configuration.StartsWith('OSX'))">OSX</OSGroup>
    <OSGroup Condition="'$(OSGroup)'==''">Windows_NT</OSGroup>
    <TargetsWindows Condition="'$(OSGroup)' == 'Windows_NT'">true</TargetsWindows>
    <TargetsLinux Condition="'$(OSGroup)' == 'Linux'">true</TargetsLinux>
    <TargetsOSX Condition="'$(OSGroup)' == 'OSX'">true</TargetsOSX>
    <TargetsUnix Condition="'$(TargetsLinux)' == 'true' or '$(TargetsOSX)' == 'true'">true</TargetsUnix>
  </PropertyGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\dir.settings.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.settings.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <PackagePlatform>$(Platform)</PackagePlatform>
    <PackagePlatform Condition="'$(Platform)' == 'amd64'">x64</PackagePlatform>
    <FrameworkListsPath>$(EnlistmentRootPath)ExternalApis\NetFX\Contracts\FrameworkLists</FrameworkListsPath>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), dir.props))\dir.props">

E:\ProjectK\src\NDP\FxCore\dir.props
============================================================================================================================================
-->
  <PropertyGroup>
    <!-- %RazzleToolPath% is what Razzle.cmd uses to determine if it is running in Razzle -->
    <IsRazzle Condition="'$(RazzleToolPath)' == ''">false</IsRazzle>
    <IsRazzle Condition="'$(RazzleToolPath)' != ''">true</IsRazzle>
    <InternalNugetCache Condition="'$(InternalNugetCache)' == ''">//cpvsbuild/drops/dd/NuGet/</InternalNugetCache>
  </PropertyGroup>
  <ItemGroup Condition="'$(IsRazzle)' == 'true'">
    <ExcludeProjects Include="**\System.ServiceProcess.ServiceController.Tests.csproj" />
  </ItemGroup>
  <PropertyGroup Condition="'$(IsRazzle)' == 'true'">
    <!-- Force OSEnvironment to Windows_NT in Razzle to avoid conflicts with $OS being overridden. -->
    <OsEnvironment>Windows_NT</OsEnvironment>
    <!--
        SourcesRootPath and BinariesRootPath represent what people set in DDEnlist for sources and binaries.
        Using DDEnlist isn't mandatory and the flow of build inputs is complicated. Historically speaking Razzle
        is built on nmake, and as such using the '_NT' based environment variables is the 'lowest' and safest set
        of defines to base ours on. To clarify further, the build settings population is detailed below:

        DDEnlist creates EnlistmentInfo.xml in the root that Razzle translates directly to environment variables:
          "Sources Root"                     -> %DevelopmentRoot%
          "Sources Root" + '\src'            -> %DepotRoot%
          "Binaries Root" + '\binaries'      -> %BinaryRoot%
          "Binaries Root" + '\Intermediate'  -> %IntermediateRootPath%

        Razzle configures %_NTDRIVE% and %_NTROOT% based off the location of razzle.cmd.
          [Example is 'C:' and '\ProjectN\src']
        BaseBinariesDir is set to %BinaryRoot% if set, otherwise %_NTDRIVE%\binaries
          [Example is 'C:\ProjectN\binaries' otherwise 'C:\binaries']
        %_NTTREEBASE% is then set to BaseBinariesDir
        %_NTTREE% is set to BaseBinariesDir\ArchType [e.g. amd64chk]
        %_NTBINROOT% stores %_NTTREE% in case it is overridden

        %_NTBINDIR% is set to %_NTDRIVE%%_NTROOT% by ntenv.cmd (called by razzle.cmd)
    -->
    <SourcesRootPath>$([System.IO.Path]::GetFullPath('$(_NTBINDIR)\..'))\</SourcesRootPath>
    <BinariesRootPath>$([System.IO.Path]::GetFullPath('$(_NTTREEBASE)\..'))\</BinariesRootPath>
    <EnlistmentRootPath>$(_NTBINDIR)\</EnlistmentRootPath>
    <ExternalAPIsPath>$(EnlistmentRootPath)ExternalApis</ExternalAPIsPath>
    <Configuration Condition="'$(_BuildType)' =='ret'">Release</Configuration>
    <Platform Condition="'$(Platform)'=='' or '$(Platform)'=='AnyCPU'">x86</Platform>
    <Platform Condition="'$(_BuildArch)'=='amd64'">amd64</Platform>
    <Platform Condition="'$(_BuildArch)'=='arm'">arm</Platform>
    <Platform Condition="'$(_BuildArch)'=='arm64'">arm64</Platform>
    <_BuildType Condition="'$(_BuildType)'==''">chk</_BuildType>
    <_BuildType Condition="'$(Configuration)'=='Release'">ret</_BuildType>
    <_BuildArch Condition="'$(_BuildArch)'==''">x86</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='amd64'">amd64</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='arm'">arm</_BuildArch>
    <_BuildArch Condition="'$(Platform)'=='arm64'">arm64</_BuildArch>
    <ToolNugetRuntimeId>win7-x86</ToolNugetRuntimeId>
    <OutputRootPath>$(_NTTREE)</OutputRootPath>
    <OutputRootPath Condition="'$(OSGroup)'!='' and '$(OSGroup)'!='Windows_NT'">$(_NTTREE)\$(OSGroup)</OutputRootPath>
    <OutputRootPath Condition="!HasTrailingSlash('$(OutputRootPath)')">$(OutputRootPath)\</OutputRootPath>
    <!-- Override open source reference assemblies to build to the contracts folder -->
    <ReferenceAssemblyOutputPath>$(OutputRootPath)\Contracts\</ReferenceAssemblyOutputPath>
    <!-- Tell open source deployment projects to drop marker files -->
    <DeployMarkerExtension>.alreadysigned</DeployMarkerExtension>
    <!-- Tell open source reference assembly projects where to find the docs -->
    <XmlDocFileRoot>$(EnlistmentRootPath)\Redist\x86\retail\bin\i386\HelpDocs\intellisense\NETCore5</XmlDocFileRoot>
    <BaseOutputPath>$(_NTTREE)\Open\CoreFx\</BaseOutputPath>
    <BaseOutputPath Condition="'$(OSGroup)'!='' and '$(OSGroup)'!='Windows_NT'">$(_NTTREE)\$(OSGroup)\Open\CoreFx\</BaseOutputPath>
    <BinDir>$(BaseOutputPath)</BinDir>
    <IntermediateRootPath>$(BinariesRootPath)Intermediate</IntermediateRootPath>
    <BaseIntermediateOutputPath>$(IntermediateRootPath)\Open\CoreFx\</BaseIntermediateOutputPath>
    <ToolRuntimePath>$(BinariesRootPath)Intermediate\Open\CoreFx\ToolRuntime\</ToolRuntimePath>
    <!--
      Restoring packages can be costly over slow/unreliable connections. We therefore put the packages directory parallel to the
      binaries directory to facilitate cleaning packages separately from bin/intermediate.
    -->
    <PackagesDir>$(BinariesRootPath)packages\</PackagesDir>
    <!--
      Setting this variable so that Razzle builds use the net45 version of the tools task library since it doesn't support the NetCore version.
    -->
    <BuildToolsTargets45>true</BuildToolsTargets45>
    <!-- Set TargetFrameworkRootPath so that the GetReferenceAssembliesPath task in Microsoft.common.currentversion.targets knows where to look in razzle. -->
    <TargetFrameworkRootPath>$(ExternalAPIsPath)\NetFx</TargetFrameworkRootPath>
    <SkipTests>true</SkipTests>
    <CopyTestToTestDirectory>false</CopyTestToTestDirectory>
    <ImportGetNuGetPackageVersions>false</ImportGetNuGetPackageVersions>
    <!-- This property applies to open source only.  If we're building in razzle, then we want to skip using the
         open source signing method. -->
    <UseOpenSourceSign>false</UseOpenSourceSign>
    <SignAssembly Condition="'$(SignAssembly)' == ''">true</SignAssembly>
    <!-- NuGet.exe cache location. -->
    <NuGetCachedPath>$(InternalNugetCache)tools/latest/nuget.exe</NuGetCachedPath>
    <!-- We need to temporarily enable the internet feeds until we can update the InternalNugetCache with the correct packages -->
    <ExcludeInternetFeeds>false</ExcludeInternetFeeds>
    <!-- for razzle builds on corpnet don't hit nuget/myget.org -->
    <ExcludeInternetFeeds Condition="Exists('$(InternalNugetCache)') and '$(ExcludeInternetFeeds)' == ''">true</ExcludeInternetFeeds>
    <!-- property indicating if the build is happening on an official build machine -->
    <OfficialBuild Condition="'$(OFFICIAL_BUILD_MACHINE)' != ''">true</OfficialBuild>
    <OfficialBuild Condition="'$(OFFICIAL_BUILD_MACHINE)' == ''">false</OfficialBuild>
    <!-- property indicating if the build is happening on an OTG build machine -->
    <OtgBuild Condition="'$(OTG_BUILD_MACHINE)' != ''">true</OtgBuild>
    <OtgBuild Condition="'$(OTG_BUILD_MACHINE)' == ''">false</OtgBuild>
    <!-- property indicating if the build is happening on a ProjectN branch -->
    <ProjectNBranch Condition="$(_BuildBranch.StartsWith('ProjN')) or $(_BuildBranch.StartsWith('ProjectN'))">true</ProjectNBranch>
    <ProjectNBranch Condition="'$(ProjectNBranch)' != 'true'">false</ProjectNBranch>
    <ProjectKBranch Condition="$(_BuildBranch.StartsWith('ProjK')) or $(_BuildBranch.StartsWith('ProjectK'))">true</ProjectKBranch>
    <ProjectKBranch Condition="'$(ProjectKBranch)' != 'true'">false</ProjectKBranch>
    <!-- Indicates that framework libraries should be restored from nuget packages instead of built from source -->
    <RestoreProjectNLibraries Condition="'$(RestoreProjectNLibraries)' == '' and '$(ProjectNBranch)' == 'true'">true</RestoreProjectNLibraries>
    <RestoreProjectNLibraries Condition="'$(RestoreProjectNLibraries)' != 'true'">false</RestoreProjectNLibraries>
    <RestoreProjectNRootPath Condition="'$(RestoreProjectNRootPath)'==''">$(PackagesDir)RestoreProjectN\</RestoreProjectNRootPath>
    <RestoreProjectNRootPath Condition="!HasTrailingSlash('$(RestoreProjectNRootPath)')">$(RestoreProjectNRootPath)\</RestoreProjectNRootPath>
    <RestoreProjectNLibraryPath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\IL\</RestoreProjectNLibraryPath>
    <RestoreProjectNContractPath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\Contracts\</RestoreProjectNContractPath>
    <RestoreProjectNSymbolCachePath>$(RestoreProjectNRootPath)$(_BuildArch)$(_BuildType)\SymbolCache\</RestoreProjectNSymbolCachePath>
    <!-- TODO: for dev builds disable restoration of nuget packages
    <RestoreAllPackages Condition="'$(RestoreAllPackages)' == '' and '$(OfficialBuild)' == 'false' and '$(OtgBuild)' == 'false'">false</RestoreAllPackages>
    -->
    <!--The BuildAllProjects =='' when executing RestoreAllPackages.proj outside of an fxcore full build -->
    <RestoreAllPackages Condition="'$(RestoreAllPackages)'=='' and '$(RestoreProjectNLibraries)'=='true' and ('$(OnlyBuildProjectNLibraries)'=='true' or '$(BuildAllProjects)'=='')">false</RestoreAllPackages>
    <RestoreAllPackages Condition="'$(ProjectKBranch)' == 'true'">true</RestoreAllPackages>
    <!--New Dev Workflow is activated with RestoreDuringBuild=false -->
    <RestoreDuringBuild Condition="'$(RestoreDuringBuild)' == '' ">false</RestoreDuringBuild>
    <RestoreDuringBuild Condition="'$(OfficialBuild)' == 'true' or '$(OtgBuild)' == 'true'">true</RestoreDuringBuild>
  </PropertyGroup>
  <!-- importing this will turn on Roslyn by default -->
  <!--
============================================================================================================================================
  <Import Project="$(EnlistmentRootPath)Tools\Microsoft.DevDiv.Managed.Compiler.props" Condition="'$(IsRazzle)' == 'true'">

E:\ProjectK\src\Tools\Microsoft.DevDiv.Managed.Compiler.props
============================================================================================================================================
-->
  <!-- Common property file that can be shared between razzle and Airstream, and required as a minimal include for projects that don't want MS.DD.Native.Settings.targets -->
  <PropertyGroup>
    <CompilerPropsAlreadyImported>true</CompilerPropsAlreadyImported>
  </PropertyGroup>
  <!-- 
       Multi-targeting support for the managed compiler set; default is Roslyn. This support is needed
       by products that either require a downlevel compiler or must be built against a released product. 
       Example: NetFx
       This can be overridden at the partition or project level to target the classic C# and VB .Net compilers.
       New groups can be added below if more than 2 compiler toolset options are required in the future.
  -->
  <PropertyGroup>
    <CscToolExe>csc.exe</CscToolExe>
    <VbcToolExe>vbc.exe</VbcToolExe>
    <TargetManagedCompiler Condition="'$(TargetManagedCompiler)' == ''">Roslyn</TargetManagedCompiler>
  </PropertyGroup>
  <Choose>
    <When Condition="'$(TargetManagedCompiler)' == 'Roslyn'">
      <PropertyGroup>
        <WarningsNotAsErrors>$(WarningsNotAsErrors);472;8073;649;675;1570;1574;1584;1658;1701;1717;3002;3003</WarningsNotAsErrors>
        <DEVPATH>$(MANAGED_TOOLS_ROOT)\$(MANAGED_TOOLS_VERSION)\Roslyn;$(DEVPATH)</DEVPATH>
        <CscToolPath>$(MANAGED_TOOLS_ROOT)\$(MANAGED_TOOLS_VERSION)\Roslyn</CscToolPath>
        <VbcToolPath>$(MANAGED_TOOLS_ROOT)\$(MANAGED_TOOLS_VERSION)\Roslyn</VbcToolPath>
      </PropertyGroup>
    </When>
    <Otherwise>
      <PropertyGroup>
        <CscToolPath>$(MANAGED_TOOLS_ROOT)\$(MANAGED_TOOLS_VERSION)</CscToolPath>
        <VbcToolPath>$(MANAGED_TOOLS_ROOT)\$(MANAGED_TOOLS_VERSION)</VbcToolPath>
      </PropertyGroup>
    </Otherwise>
  </Choose>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\dir.props
============================================================================================================================================
-->
  <!-- add internal nuget cache to the nuget source list -->
  <ItemGroup>
    <NuGetSourceList Include="$(InternalNugetCache)" Condition="Exists('$(InternalNugetCache)')" />
  </ItemGroup>
  <!-- add internal nuget cache to the source list -->
  <ItemGroup>
    <NuGetSourceList Include="$(InternalNugetCache)NetFX" Condition="Exists('$(InternalNugetCache)NetFX')" />
  </ItemGroup>
  <!-- when building in a release branch use the release branch for package sources -->
  <PropertyGroup>
    <DnuSourceListBranch>ProjectK</DnuSourceListBranch>
    <DnuSourceListBranch Condition="$(BranchName.EndsWith('Rel')) or $(BranchName.Contains('GDR'))">$(DnuSourceListBranch)Rel</DnuSourceListBranch>
  </PropertyGroup>
  <!-- add internal nuget cache to the dnu source list -->
  <ItemGroup Condition="'$(DisableFileShareFeeds)' != 'true'">
    <DnuSourceList Include="$(InternalNugetCache)NetFX" Condition="Exists('$(InternalNugetCache)NetFX')" />
    <DnuSourceList Include="$(InternalNugetCache)NetFX_$(DnuSourceListBranch)" Condition="Exists('$(InternalNugetCache)NetFX_$(DnuSourceListBranch)')" />
  </ItemGroup>
  <!-- for razzle builds add fxcore\src -->
  <ItemGroup>
    <DnuRestoreDir Include="&quot;$(MSBuildThisFileDirectory)src&quot;" />
  </ItemGroup>
  <!--
    When we do a traversal build we get all packages up front, don't restore them again.
    Also skip restoring them if package restoration is disabled (the default for razzle builds).
  -->
  <PropertyGroup Condition="'$(BuildAllProjects)' == 'true' or '$(RestoreAllPackages)' == 'false'">
    <RestorePackages>false</RestorePackages>
  </PropertyGroup>
  <!-- Enable delay signing for all assemblies that don't opt of of signing -->
  <PropertyGroup Condition="'$(IsRazzle)' == 'true' and '$(SignAssembly)'!='false'">
    <DelaySign>true</DelaySign>
    <SignAssembly>true</SignAssembly>
    <AssemblyOriginatorKeyFile>$(EnlistmentRootPath)tools\devdiv\FinalPublicKey.snk</AssemblyOriginatorKeyFile>
    <AssemblyOriginatorKeyFile Condition="'$(AssemblyKeyType)'=='ECMA'">$(EnlistmentRootPath)tools\devdiv\EcmaPublicKey.snk</AssemblyOriginatorKeyFile>
  </PropertyGroup>
  <!-- This is to enable the package building were it expect this to be found in our open projects and it isn't -->
  <Target Condition="'$(IsRazzle)' == 'true'" Name="_NuProjGetProjectClosure" />
  <PropertyGroup>
    <!-- Set the File Version to 4.6 -->
    <MajorVersion Condition="'$(MajorVersion)'==''">4</MajorVersion>
    <MinorVersion Condition="'$(MinorVersion)'==''">6</MinorVersion>
    <BuildNumberSettingsFile>buildnumber.settings.targets</BuildNumberSettingsFile>
    <InternalAPIsCandidatesBuildNumberTarget>$(OutputRootPath)\InterAPIsCandidates\Version\$(BuildNumberSettingsFile)</InternalAPIsCandidatesBuildNumberTarget>
    <InternalAPIsBuildNumberTarget>$(EnlistmentRootPath)InternalAPIs\Version\$(BuildNumberSettingsFile)</InternalAPIsBuildNumberTarget>
  </PropertyGroup>
  <!-- Pull in the build numbers: BuildNumberMajor and BuildNumberMinor -->
  <!--
============================================================================================================================================
  <Import Project="$(InternalAPIsBuildNumberTarget)" Condition="Exists('$(InternalAPIsBuildNumberTarget)')">

E:\ProjectK\src\InternalAPIs\Version\buildnumber.settings.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <BuildNumberMajor>23604</BuildNumberMajor>
    <BuildNumberMinor>00</BuildNumberMinor>
  </PropertyGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\dir.props
============================================================================================================================================
-->
  <!-- Prefer the generated candidate if it exists over the checked in so importing after so it will override -->
  <!--<Import Project="$(InternalAPIsCandidatesBuildNumberTarget)" Condition="Exists('$(InternalAPIsCandidatesBuildNumberTarget)')" />-->
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.settings.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(NuProjPath)\NuProj.props" Condition="Exists('$(NuProjPath)\NuProj.props')">

E:\ProjectK\src\Tools\BuildProcess\MSBuild\NuProj\NuProj.props
============================================================================================================================================
-->
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
  </PropertyGroup>
  <PropertyGroup>
    <NoPackageAnalysis Condition=" '$(NoPackageAnalysis)' == '' ">False</NoPackageAnalysis>
    <NoDefaultExcludes Condition=" '$(NoDefaultExcludes)' == '' ">False</NoDefaultExcludes>
    <GenerateSymbolPackage Condition=" '$(GenerateSymbolPackage)' == '' ">True</GenerateSymbolPackage>
    <EmbedSourceFiles Condition=" '$(EmbedSourceFiles)' == '' ">False</EmbedSourceFiles>
    <RequireLicenseAcceptance Condition=" '$(RequireLicenseAcceptance)' == '' ">False</RequireLicenseAcceptance>
    <DevelopmentDependency Condition=" '$(DevelopmentDependency)' == '' ">False</DevelopmentDependency>
  </PropertyGroup>
  <PropertyGroup>
    <NuProjTasksPath Condition=" '$(NuProjTasksPath)' == '' ">$(MSBuildThisFileDirectory)NuProj.Tasks.dll</NuProjTasksPath>
    <NuProjToolPath Condition=" '$(NuProjToolPath)' == '' ">$(MSBuildThisFileDirectory)</NuProjToolPath>
    <NuGetToolPath Condition=" '$(NuGetToolPath)' == '' ">$(NuProjToolPath)</NuGetToolPath>
    <NuGetToolExe Condition=" '$(NuGetToolExe)' == '' ">NuGet.exe</NuGetToolExe>
  </PropertyGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.settings.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\System.IO.Compression\unix\System.IO.Compression.nuproj
============================================================================================================================================
-->
  <PropertyGroup>
    <PackageTargetRuntime>unix</PackageTargetRuntime>
    <PreventImplementationReference>true</PreventImplementationReference>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="$(OpenSourcesPath)System.IO.Compression\src\System.IO.Compression.csproj">
      <!-- the binary is not specific to Linux, but we only do a Linux & OSX pass, not Unix-specific pass -->
      <AdditionalProperties>OSGroup=Linux</AdditionalProperties>
    </ProjectReference>
    <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\System.IO.Compression.Native\System.IO.Compression.Native.nuproj" />
  </ItemGroup>
  <!--
============================================================================================================================================
  <Import Project="$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildThisFileDirectory), Packaging.targets))\Packaging.targets">

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!-- The following properties are expected to change as we transition from 
       Beta -> RC - RTM. We should set $(IncludeBuildNumberInPackageVersion)
       to false for the Beta/RC builds that get uploaded to NuGet.
  -->
  <PropertyGroup>
    <PreReleaseLabel Condition="'$(PreReleaseLabel)' == ''">rc2</PreReleaseLabel>
    <IncludeBuildNumberInPackageVersion>true</IncludeBuildNumberInPackageVersion>
  </PropertyGroup>
  <!-- 
       NuSpec configuration.
       
       NOTE: It's by design that these properties override the project. We don't
       want projects to specify any metadata, most of the metadata should be 
       the same for all packages, and the rest will be centralized.
  -->
  <PropertyGroup Condition="'$(IsRuntimePackage)' == 'true' or '$(PackageTargetRuntime)' != ''">
    <IdPrefix>runtime.</IdPrefix>
    <IdPrefix Condition="'$(PackageTargetRuntime)' != ''">$(IdPrefix)$(PackageTargetRuntime).</IdPrefix>
    <IdPrefix Condition="'$(PackageTargetFramework)' != ''">$(IdPrefix)$(PackageTargetFramework).</IdPrefix>
  </PropertyGroup>
  <PropertyGroup>
    <BaseId>$(MSBuildProjectName)</BaseId>
    <Id>$(IdPrefix)$(BaseId)</Id>
    <Title>$(Id)</Title>
    <!-- It is by design that the Title matches the Id. We want users to get an assembly view. -->
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
  <PropertyGroup>
    <PackageRevStableToPrerelease>false</PackageRevStableToPrerelease>
    <DependencyRevStableToPrerelease>false</DependencyRevStableToPrerelease>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="$(NuProjPath)\NuProj.targets">

E:\ProjectK\src\Tools\BuildProcess\MSBuild\NuProj\NuProj.targets
============================================================================================================================================
-->
  <!--<Import Project="$(CustomBeforeNuProjTargets)" Condition="'$(CustomBeforeNuProjTargets)' != '' and Exists('$(CustomBeforeNuProjTargets)')" />-->
  <PropertyGroup>
    <NuProjRulesDir>$(MSBuildThisFileDirectory)Rules\</NuProjRulesDir>
  </PropertyGroup>
  <ItemGroup>
    <PropertyPageSchema Include="$(NuProjRulesDir)\ProjectItemsSchema.xaml">
      <Context>Project</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\scc.xaml;">
      <Context>Invisible</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\general.xaml">
      <Context>Project;File</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\general.browseobject.xaml">
      <Context>BrowseObject</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\folder.xaml;&#xD;&#xA;                                 $(NuProjRulesDir)\none.xaml;&#xD;&#xA;                                 $(NuProjRulesDir)\content.xaml">
      <Context>File;BrowseObject</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\ResolvedProjectReference.xaml">
      <Context>ProjectSubscriptionService;BrowseObject</Context>
    </PropertyPageSchema>
    <PropertyPageSchema Include="$(NuProjRulesDir)\ProjectReference.xaml">
      <Context>;BrowseObject</Context>
    </PropertyPageSchema>
    <ProjectCapability Include="ProjectReferences;ReferencesFolder" />
    <ProjectCapability Include="ProjectConfigurationsDeclaredAsItems" />
    <ProjectCapability Include="NuProj" />
  </ItemGroup>
  <PropertyGroup>
    <AvailablePlatforms>Any CPU,x86,x64,ARM</AvailablePlatforms>
    <DefaultContentType>Content</DefaultContentType>
  </PropertyGroup>
  <!-- Set output and intermmediate output properties. -->
  <PropertyGroup>
    <OutputPath Condition="'$(OutputPath)' != '' and !HasTrailingSlash('$(OutputPath)')">$(OutputPath)\</OutputPath>
    <OutputPath Condition="'$(OutputPath)'==''">bin\$(Configuration)\</OutputPath>
    <OutDirWasSpecified Condition=" '$(OutDir)'!='' and '$(OutDirWasSpecified)'=='' ">true</OutDirWasSpecified>
    <OutDir Condition="'$(OutDir)' == ''">$(OutputPath)</OutDir>
    <OutDir Condition="'$(OutDir)' != '' and !HasTrailingSlash('$(OutDir)')">$(OutDir)\</OutDir>
    <BaseIntermediateOutputPath Condition="'$(BaseIntermediateOutputPath)'=='' ">obj\</BaseIntermediateOutputPath>
    <BaseIntermediateOutputPath Condition="!HasTrailingSlash('$(BaseIntermediateOutputPath)')">$(BaseIntermediateOutputPath)\</BaseIntermediateOutputPath>
    <IntermediateOutputPathWasSpecified Condition=" '$(IntermediateOutputPath)'!='' and '$(IntermediateOutputPathWasSpecified)'=='' ">true</IntermediateOutputPathWasSpecified>
    <IntermediateOutputPath Condition="$(IntermediateOutputPath) == ''">$(BaseIntermediateOutputPath)$(Configuration)\</IntermediateOutputPath>
    <IntermediateOutputPath Condition="!HasTrailingSlash('$(IntermediateOutputPath)')">$(IntermediateOutputPath)\</IntermediateOutputPath>
  </PropertyGroup>
  <!-- For projects that want a per-project output directory, update OutDir and IntermediateOutputPath to include the project name. -->
  <PropertyGroup>
    <ProjectName Condition=" '$(ProjectName)' == '' ">$(MSBuildProjectName)</ProjectName>
    <OutDir Condition="'$(OutDir)' != '' and '$(OutDirWasSpecified)' == 'true' and '$(GenerateProjectSpecificOutputFolder)' == 'true'">$(OutDir)$(ProjectName)\</OutDir>
    <IntermediateOutputPath Condition="'$(IntermediateOutputPath)' != '' and '$(IntermediateOutputPathWasSpecified)' == 'true' and '$(GenerateProjectSpecificOutputFolder)' == 'true'">$(IntermediateOutputPath)$(ProjectName)\</IntermediateOutputPath>
  </PropertyGroup>
  <PropertyGroup>
    <TargetDir Condition="'$(OutDir)' != ''">$([MSBuild]::Escape($([System.IO.Path]::GetFullPath(`$([System.IO.Path]::Combine(`$(MSBuildProjectDirectory)`, `$(OutDir)`))`))))</TargetDir>
  </PropertyGroup>
  <!--
      NUSPEC PATH
  -->
  <PropertyGroup>
    <NuSpecPath>$(IntermediateOutputPath)$(Id).nuspec</NuSpecPath>
  </PropertyGroup>
  <!--
      OUTPUT PATHS

      These properties aren't passed to NuGet.exe - they're implicit. However, we need to know the output paths
      at several occasions (e.g. incremental build or clean up) so we want a central spot to capture those.

      We set these properties in a Target so that other targets that determine what $(Version)
      should be can run first.
  -->
  <Target Name="EstablishNuGetPaths" DependsOnTargets="$(VersionDependsOn)">
    <PropertyGroup>
      <NuGetOutputPath>$(TargetDir)$(Id).$(Version).nupkg</NuGetOutputPath>
      <NuGetSymbolsOutputPath>$(TargetDir)$(Id).$(Version).symbols.nupkg</NuGetSymbolsOutputPath>
    </PropertyGroup>
  </Target>
  <!--
      Properties relevant to Visual Studio:

      $(BuildingInsideVisualStudio)       This will indicate whether this project is building inside the IDE. When
                                          building via MSBuild, this property will not be set.

      $(DesignTimeBuild)                  Visual Studio uses this property to indicate whether it's performing a
                                          design time build or a full build. A design time build is designed to do
                                          minimal amount of work; the intent of those builds is to expose information
                                          around resolved dependencies and properties back to Visual Studio without
                                          actually producing assets on disk.
  -->
  <PropertyGroup>
    <!-- We don't want to build in case we're performing a design time build as we are expected to not
         produce any assets.

         We also don't want to build the references in cases where we build inside the IDE. The reason
         is that Visual Studio already built our dependencies. Doing it again can regress performance.
         However, the real issue is that it impacts correctness as this can result in building the same
         project simultaneously from different projects.

         Most particularly on the correctness side, this shows up when VS is doing a "rebuild". NuProj
         will end up causing multiple build breaks being reported because it will re-delete outputs that
         VS just produced and that other project references that are building in parallel now expect to
         be there. -->
    <BuildProjectReferences Condition="'$(BuildProjectReferences)' == '' and ('$(BuildingInsideVisualStudio)' == 'true' or '$(DesignTimeBuild)' == 'true')">false</BuildProjectReferences>
    <!-- By default we will build (and if applicable, clean) all project references. But this can be used
         to disable that. -->
    <BuildProjectReferences Condition="'$(BuildProjectReferences)' == ''">true</BuildProjectReferences>
  </PropertyGroup>
  <!--
      MSBuildAllProjects is used to keep track of all projects the build depends on.
      We make all targets depending on it to make sure everything rebuilds.
  -->
  <PropertyGroup>
    <MSBuildAllProjects Condition="Exists('$(MSBuildProjectFullPath)')">$(MSBuildAllProjects);$(MSBuildProjectFullPath)</MSBuildAllProjects>
    <MSBuildAllProjects>$(MSBuildAllProjects);$(MSBuildThisFileFullPath)</MSBuildAllProjects>
  </PropertyGroup>
  <!--
      OUTPUT GROUPS

      These are the groups we are using to discover outputs from our project references.
  -->
  <PropertyGroup>
    <ProjectOutputGroups>
      BuiltProjectOutputGroup;
      BuiltProjectOutputGroupDependencies;
      DebugSymbolsProjectOutputGroup;
      DebugSymbolsProjectOutputGroupDependencies;
      DocumentationProjectOutputGroup;
      DocumentationProjectOutputGroupDependencies;
      SatelliteDllsProjectOutputGroup;
      SatelliteDllsProjectOutputGroupDependencies;
      SGenFilesOutputGroup;
      SGenFilesOutputGroupDependencies;
    </ProjectOutputGroups>
  </PropertyGroup>
  <!--
      PROJECT PROPERTIES

      These are the properties we forward to our project references.
  -->
  <PropertyGroup>
    <ProjectProperties>
      Configuration=$(Configuration);
      Platform=$(Platform)
    </ProjectProperties>
  </PropertyGroup>
  <!--
      ITEM DEFINITIONS
      
      Defines default metadata for our items.
  -->
  <ItemDefinitionGroup>
    <ProjectReference>
      <PackageDirectory>Lib</PackageDirectory>
      <TargetFramework />
    </ProjectReference>
  </ItemDefinitionGroup>
  <!--
      CUSTOM TASKS
  -->
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="GenerateNuSpec" />
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="NuGetPack" />
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="AssignTargetFramework" />
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="ReadPackagesConfig" />
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="ReadPdbSourceFiles" />
  <UsingTask AssemblyFile="$(NuProjTasksPath)" TaskName="AssignSourceTargetPaths" />
  <!--
    ============================================================
                                        PrepareForBuild

    Prepare the prerequisites for building.
    ============================================================
    -->
  <PropertyGroup>
    <PrepareForBuildDependsOn>EstablishNuGetPaths</PrepareForBuildDependsOn>
  </PropertyGroup>
  <Target Name="PrepareForBuild" DependsOnTargets="$(PrepareForBuildDependsOn)" />
  <!--
    ===================================================================================================================
    _NuProjGetProjectClosure
    ===================================================================================================================

    This target returns the closure of all project references.

    INPUTS:
        @(_MSBuildProjectReferenceExistent)   The project references that actually exist.

    OUTPUTS:
        @(_ProjectReferenceClosure)           The closure of all references. Doesn't include duplicates.

    =================================================================================================================== -->
  <Target Name="_NuProjGetProjectClosure" Inputs="%(ProjectReference.Identity)" Outputs="fake" Returns="@(_ProjectReferenceClosure)">
    <!-- First let's make sure that the project references have been fully built,
             unless building project references is disabled. -->
    <MSBuild Targets="Build" Condition="'$(BuildProjectReferences)' == 'true'" Projects="@(ProjectReference)" Properties="$(ProjectProperties)" ContinueOnError="WarnAndContinue" />
    <!-- Get closure of indirect references -->
    <MSBuild Projects="@(ProjectReference)" Targets="_NuProjGetProjectClosure" Properties="$(ProjectProperties)" ContinueOnError="WarnAndContinue">
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
  <!--
    ===================================================================================================================
    SplitProjectReferences
    ===================================================================================================================

    This target will split the project references into NuProj project references and non-NuProj references.

    INPUTS:
        @(ProjectReference)            The direct project references
        @(_ProjectReferenceClosure)    The direct and indirect project references

    OUTPUTS:
        @(_NuProjProjectReference)            Direct references to NuProj projects.
        @(_NonNuProjProjectReference)         Direct references to regular, i.e. non-NuProj projects.
        @(_NuProjProjectReferenceClosure)     Direct and indirect references to NuProj projects.
        @(_NonNuProjProjectReferenceClosure)  Direct and indirect references to regular, i.e. non-NuProj projects.

    =================================================================================================================== -->
  <Target Name="SplitProjectReferences" DependsOnTargets="_NuProjGetProjectClosure">
    <ItemGroup>
      <!-- Split direct and indirect project dependencies -->
      <_NuProjProjectReferenceClosure Include="@(_ProjectReferenceClosure)" Condition="'%(_ProjectReferenceClosure.Extension)' == '.nuproj'" />
      <_NonNuProjProjectReferenceClosure Include="@(_ProjectReferenceClosure)" Condition="'%(_ProjectReferenceClosure.Extension)' != '.nuproj'" />
      <!-- Split direct project dependencies -->
      <_NuProjProjectReference Include="@(_NuProjProjectReferenceClosure)" Condition="'%(DependencyKind)' == 'Direct'" />
      <_NonNuProjProjectReference Include="@(_NonNuProjProjectReferenceClosure)" Condition="'%(DependencyKind)' == 'Direct'" />
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    ResolveProjectReferencesDesignTime
    ===================================================================================================================

    This target is called by Visual Studio to get the project references

    OUTPUTS:
        @(_ResolvedProjectReference)         The resolved project references

    =================================================================================================================== -->
  <Target Name="ResolveProjectReferencesDesignTime" Returns="@(_ResolvedProjectReference)">
    <ItemGroup>
      <_ResolvedProjectReference Include="@(ProjectReference->'%(FullPath)')" Condition="Exists('%(FullPath)')">
        <OriginalItemSpec>%(Identity)</OriginalItemSpec>
        <ReferenceSourceTarget>ProjectReference</ReferenceSourceTarget>
      </_ResolvedProjectReference>
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    ExpandProjectReferences
    ===================================================================================================================

    This target will get the build outputs of the project references

    INPUTS:
        @(ProjectReference)         The project references

    OUTPUTS:
        @(ProjectReferenceOutput)   The output of all project references

    =================================================================================================================== -->
  <Target Name="ExpandProjectReferences" DependsOnTargets="SplitProjectReferences" Inputs="%(_NonNuProjProjectReference.Identity)" Outputs="fake">
    <!-- Ask for the output and all dependencies. -->
    <MSBuild Targets="$(ProjectOutputGroups)" Projects="@(_NonNuProjProjectReference)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_NonNuProjProjectOutput" />
    </MSBuild>
    <!-- Make sure we package the final output path of project references so that any post-compile step
             applied to the project's output (such as signing) is included in the version we package up. -->
    <ItemGroup>
      <_NonNuProjProjectOutput_ToReplace Include="@(_NonNuProjProjectOutput)" Condition=" '%(_NonNuProjProjectOutput.FinalOutputPath)' != '' " />
      <_NonNuProjProjectOutput Remove="@(_NonNuProjProjectOutput_ToReplace)" />
      <_NonNuProjProjectOutput Include="@(_NonNuProjProjectOutput_ToReplace->'%(FinalOutputPath)')" />
    </ItemGroup>
    <!-- Since the dependencies include platform assemblies, we'll filter
             out all files that don't exist in this project's output folder.
             First we need the project's output folder. The easiest way is
             to ask for the target path and then use a property function to
             get the directory name. -->
    <MSBuild Targets="GetTargetPath" Projects="@(_NonNuProjProjectReference)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" PropertyName="_NonNuProjProjectTargetPath" />
    </MSBuild>
    <PropertyGroup>
      <_NonNuProjProjectTargetPath>$([System.IO.Path]::GetDirectoryName($(_NonNuProjProjectTargetPath)))\</_NonNuProjProjectTargetPath>
    </PropertyGroup>
    <!-- Now we can filter the outputs based on whether they exist
             in the project's output folder. -->
    <ItemGroup>
      <_FilteredNonNuProjProjectOutput Include="@(_NonNuProjProjectOutput->'$(_NonNuProjProjectTargetPath)%(Filename)%(Extension)')" Condition=" Exists('$(_NonNuProjProjectTargetPath)%(_NonNuProjProjectOutput.Filename)%(_NonNuProjProjectOutput.Extension)') " />
      <_NonNuProjProjectOutput Remove="@(_NonNuProjProjectOutput)" Condition="!Exists('$(_NonNuProjProjectTargetPath)%(_NonNuProjProjectOutput.Filename)%(_NonNuProjProjectOutput.Extension)') " />
    </ItemGroup>
    <!-- In order to package the the files in the correct folder in the
             NuGet package we need need to know the target framework moniker. -->
    <MSBuild Targets="GetTargetFrameworkMoniker" Projects="@(_NonNuProjProjectReference)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" PropertyName="_NonNuProjProjectTargetFrameworkMoniker" />
    </MSBuild>
    <!-- In order to add custom metadata, we need to create a new item list -->
    <CreateItem Include="@(_FilteredNonNuProjProjectOutput)" AdditionalMetadata="TargetFrameworkMoniker=$(_NonNuProjProjectTargetFrameworkMoniker)">
      <Output TaskParameter="Include" ItemName="_NonNuProjProjectOutputWithTargetFrameworkMoniker" />
    </CreateItem>
    <!-- Now we can run the AssignTargetFramework task. It will use the
             %(TargetFrameworkMoniker) metadata to create the %(TargetPath).
             The target path will use the NuGet lib convention, e.g.
             lib\net40\foo.dll -->
    <AssignTargetFramework OutputsWithTargetFrameworkInformation="@(_NonNuProjProjectOutputWithTargetFrameworkMoniker)">
      <Output TaskParameter="PackageFiles" ItemName="ProjectReferenceOutput" />
    </AssignTargetFramework>
  </Target>
  <!--
    ===================================================================================================================
    ConvertItems
    ===================================================================================================================

    This target is converting specialized items groups into the general <File> item list that indicates what should
    be packaged.

    INPUTS:
        @(ProjectReferenceOutput)   Output of referenced projects to be packaged
        @(Content)                  Content items to be packaged

    OUTPUTS:
        @(File)                     The <File> elements to be packaged.

    =================================================================================================================== -->
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
  <!--
    ===================================================================================================================
    GenerateNuSpec
    ===================================================================================================================

    This target is creates the .nuspec file that is used to create the NuGet package (.nupkg).

    INPUTS:
        $(NuSpecPath)                  The path where the NuSpec should be written to.
        $(NuSpecTemplate)               (Optional) The path to the NuSpec template.

        $(Id),
        $(Version),
        $(Title),
        $(Authors),
        $(Owners),
        $(Description),
        $(ReleaseNotes),
        $(Summary),
        $(Language),
        $(ProjectUrl),
        $(IconUrl),
        $(LicenseUrl),
        $(Copyright),
        $(RequireLicenseAcceptance),
        $(Tags),
        $(DevelopmentDependency)       General properties of the NuSpec

        @(Dependency)                  (Optional) The NuGet package dependencies
        @(FrameworkReference)          (Optional) Framework assembly references
        @(Reference)                   (Optional) The assembly references
        @(File)                        (Optional) The files to be packaged

    =================================================================================================================== -->
  <Target Name="GenerateNuSpec" DependsOnTargets="GetPackageDependencies;GetPackageFiles;GetSourceFiles;$(VersionDependsOn)">
    <!-- Please Note:
         In order to avoid incremental build issues this target will always run.
         However, the task will make sure that it doesn't touch the file if the
         contents it would generate are identical to a previously generated
         nuspec. -->
    <GenerateNuSpec InputFileName="$(NuSpecTemplate)" OutputFileName="$(NuSpecPath)" MinClientVersion="$(MinClientVersion)" Id="$(Id)" Version="$(Version)" Title="$(Title)" Authors="$(Authors)" Owners="$(Owners)" Description="$(Description)" ReleaseNotes="$(ReleaseNotes)" Summary="$(Summary)" Language="$(Language)" ProjectUrl="$(ProjectUrl)" IconUrl="$(IconUrl)" LicenseUrl="$(LicenseUrl)" Copyright="$(Copyright)" RequireLicenseAcceptance="$(RequireLicenseAcceptance)" Tags="$(Tags)" DevelopmentDependency="$(DevelopmentDependency)" Dependencies="@(Dependency)" References="@(Reference)" FrameworkReferences="@(FrameworkReference)" Files="@(PackageFile)" />
  </Target>
  <!--
    ===================================================================================================================
    CreatePackage
    ===================================================================================================================

    This target creates the NuGet package from a .nuspec file

    INPUTS:
        $(NuSpecPath)                  The path to the NuSpec file.
        $(OutDir)                      The path to the directory where the .nupkg should be created
        $(NuGetToolPath)               The path of the directory that contains to NuGet.exe
        $(NuGetToolExe)                The name of NuGet.exe

    =================================================================================================================== -->
  <Target Name="CreatePackage" Inputs="$(MSBuildAllProjects);&#xD;&#xA;                  $(NuSpecPath);&#xD;&#xA;                  @(File)" Outputs="$(NuGetOutputPath)" DependsOnTargets="GenerateNuSpec;PrepareForBuild">
    <MakeDir Directories="$(OutDir)" Condition="!Exists('$(OutDir)')" />
    <NuGetPack OutputDirectory="$(OutDir)" NoPackageAnalysis="$(NoPackageAnalysis)" NoDefaultExcludes="$(NoDefaultExcludes)" Symbols="$(GenerateSymbolPackage)" ToolPath="$(NuGetToolPath)" ToolExe="$(NuGetToolExe)" NuSpecPath="$(NuSpecPath)" />
  </Target>
  <!--
    ===================================================================================================================
    GetPackageFiles
    ===================================================================================================================

    Gets the set of files that will be included in this package. This set will not include any files that are already
    provided by our NuGet dependencies.

    OUTPUTS:
        @(PackageFile)                        The files that will be included in this package.

    =================================================================================================================== -->
  <Target Name="GetPackageFiles" Returns="@(PackageFile)" DependsOnTargets="GetFiles;GetFileDependencies;$(VersionDependsOn)">
    <ItemGroup>
      <!-- We need to ensure that package libraries occur only once in their intended target path.
             Depending on referenced projects, single library can come from multiple locations,
             e.g target and intermediate output directories. -->
      <_RawLibraryTargetPath Include="@(File->'%(TargetPath)\%(FileName)%(Extension)')" Condition="'%(File.PackageDirectory)' == 'Lib'">
        <OriginalItemSpec>%(File.Identity)</OriginalItemSpec>
      </_RawLibraryTargetPath>
    </ItemGroup>
    <RemoveDuplicates Inputs="@(_RawLibraryTargetPath)">
      <Output TaskParameter="Filtered" ItemName="_FilteredLibraryTargetPath" />
    </RemoveDuplicates>
    <ItemGroup>
      <!-- We don't want to package libraries that come from dependencies.
             Please note that we do want to package non-library files regardless
             as we generally don't automatically pick those up from dependencies.

             This allows people to include binaries in their tools folder, for
             example.

             In order to filter based on the simple file name, we'll set the
             identity to the simple file name and record the original identity
             as new metadata that we'll use to restore afterwards.

             Since we want to only filer libraries we'll set the identity to an
             illegal file name if the packaged file isn't a library. -->
      <_FileTargetPath Include="@(_FilteredLibraryTargetPath->'%(FileName)%(Extension)')" />
      <_FileTargetPath Include="@(File->'::KEEP::')" Condition="'%(File.PackageDirectory)' != 'Lib'">
        <OriginalItemSpec>%(File.Identity)</OriginalItemSpec>
      </_FileTargetPath>
      <!-- Now we can remove all files from _FileTargetPath that come from
             dependencies. -->
      <_FileDependencyTargetPath Include="@(FileDependency->'%(FileName)%(Extension)')" />
      <_FileTargetPath Remove="@(_FileDependencyTargetPath)" />
      <!-- Remove references that request to be excluded. -->
      <_FileTargetPath Remove="@(_FileTargetPath)" Condition=" '%(_FileTargetPath.ExcludeFromNuPkg)' == 'true' " />
      <!-- In order to produce the final list we have to restore the original
             identity. -->
      <PackageFile Remove="@(PackageFile)" />
      <PackageFile Include="@(_FileTargetPath->'%(OriginalItemSpec)')" />
    </ItemGroup>
    <ItemGroup>
      <PackageFile Condition="'%(PackageFile.NuProjPackageId)' == ''">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
      </PackageFile>
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetFiles
    ===================================================================================================================

    Gets the set of candidate files to be packaged. This set will also contain any files that are already provided by
    our NuGet dependencies.

    OUTPUTS:
        @(File)                        The files that are being packaged

    =================================================================================================================== -->
  <Target Name="GetFiles" Returns="@(File)" DependsOnTargets="ConvertItems" />
  <!--
    ===================================================================================================================
    GetFileDependencies
    ===================================================================================================================

    Returns the files coming from the transitive closure of all NuGet dependencies from this package.

    OUTPUTS:
        @(FileDependency)               Files coming from dependencies

    =================================================================================================================== -->
  <Target Name="GetFileDependencies" DependsOnTargets="GetNuProjFileDependencies;GetNuGetFileDependencies" Returns="@(FileDependency)">
    <ItemGroup>
      <FileDependency Include="@(NuProjFileDependency)" />
      <FileDependency Include="@(NuGetFileDependency)" />
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetNuProjFileDependencies
    ===================================================================================================================

    Returns the files coming from the transitive closure of all NuGet dependencies from this package.

    OUTPUTS:
        @(FileDependency)               Files coming from dependencies

    =================================================================================================================== -->
  <Target Name="GetNuProjFileDependencies" Returns="@(NuProjFileDependency)" DependsOnTargets="SplitProjectReferences">
    <MSBuild Targets="GetPackageFiles" Projects="@(_NuProjProjectReferenceClosure)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="NuProjFileDependency" />
    </MSBuild>
  </Target>
  <!--
    ===================================================================================================================
    GetNuGetFileDependencies
    ===================================================================================================================

    Returns the files coming from the transitive closure of all NuGet dependencies from this package.

    OUTPUTS:
        @(NuGetFileDependency)               Files coming from dependencies

    =================================================================================================================== -->
  <Target Name="GetNuGetFileDependencies" DependsOnTargets="GetNuGetPackageDependencies" Returns="@(NuGetFileDependency)">
    <ItemGroup>
      <NuGetFileDependency Include="%(NuGetDependency.PackageDirectoryPath)\**\*" Condition="'%(NuGetDependency.PackageDirectoryPath)' != ''" />
    </ItemGroup>
  </Target>
  <!--
  ===================================================================================================================
  AssignNuProjPackageDependenciesTargetFramework
  ===================================================================================================================

  Assigns "TargetFramework" metadata to dependencies coming from NuProj projects based on referenced files that can be 
  removed from package.

  INPUTS:
      @(NuGetFileDependency)               Files coming from dependencies

  OUTPUTS:
      @(NuGetFileDependency)               Files coming from dependencies with target framework

  =================================================================================================================== -->
  <Target Name="AssignNuProjPackageDependenciesTargetFramework" Inputs="@(NuProjDependency)" Outputs="%(NuProjDependency.Identity)" DependsOnTargets="GetNuProjPackageDependencies;GetFiles">
    <ItemGroup>
      <!-- Clear temporary items. -->
      <_NuProjDependency Remove="@(_NuProjDependency)" />
      <_DependencyFile Remove="@(_DependencyFile)" />
      <!-- Get files that are library and have assigned target framework (so no debug symbols files). -->
      <_DependencyFile Include="@(File)" Condition="'%(File.PackageDirectory)' == 'Lib' &#xD;&#xA;                         and '%(File.TargetFramework)' != '' &#xD;&#xA;                         and '%(File.NuProjPackageId)' == '%(NuProjDependency.Identity)'" />
      <_NuProjDependency Include="@(NuProjDependency)">
        <TargetFramework>%(_DependencyFile.TargetFramework)</TargetFramework>
      </_NuProjDependency>
      <!-- Replace dependency item with ones that have target framework. -->
      <NuProjDependency Remove="@(_NuProjDependency)" />
      <NuProjDependency Include="@(_NuProjDependency)" />
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetPackageDependencies
    ===================================================================================================================

    Get the direct package dependencies of this package. It doesn't include dependencies of dependencies.

    OUTPUTS:
        @(Dependency)               The NuGet dependencies of this package.

    =================================================================================================================== -->
  <Target Name="GetPackageDependencies" DependsOnTargets="AssignNuProjPackageDependenciesTargetFramework;GetNuGetPackageDependencies" Returns="@(Dependency)">
    <ItemGroup>
      <Dependency Include="@(NuProjDependency)" Condition="'%(NuProjDependency.DependencyKind)' == 'Direct'" />
      <Dependency Include="@(NuGetDependency)" Condition="'%(NuGetDependency.DependencyKind)' == 'Direct'" />
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetNuProjPackageDependencies
    ===================================================================================================================

    Get the direct and indirect package dependencies that come from other .nuproj files.

    OUTPUTS:
        @(NuProjDependency)               The closure of NuGet dependencies of this package.

    =================================================================================================================== -->
  <Target Name="GetNuProjPackageDependencies" Returns="@(NuProjDependency)" Inputs="%(_NuProjProjectReferenceClosure.DependencyKind)" Outputs="fake" DependsOnTargets="SplitProjectReferences">
    <MSBuild Targets="GetPackageIdentity" Projects="@(_NuProjProjectReferenceClosure)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_NuProjDependency" />
    </MSBuild>
    <ItemGroup>
      <NuProjDependency Include="@(_NuProjDependency)">
        <DependencyKind>%(_NuProjProjectReferenceClosure.DependencyKind)</DependencyKind>
      </NuProjDependency>
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetNuGetPackageDependencies
    ===================================================================================================================

    Get the direct and indirect package dependencies that come from regular, i.e. non-.nuproj NuGet dependencies.

    OUTPUTS:
        @(NuGetDependency)               The closure of NuGet dependencies of this package.

    =================================================================================================================== -->
  <Target Name="GetNuGetPackageDependencies" Returns="@(NuGetDependency)">
    <!-- Read each project's packages.config file. -->
    <ReadPackagesConfig Projects="@(_ProjectReferenceClosure)" Condition="'%(PackageDirectory)' == 'Lib'">
      <Output TaskParameter="PackageReferences" ItemName="_PackageReference" />
    </ReadPackagesConfig>
    <!-- Turn all dependencies into NuGetDependency items with appropriate metadata. -->
    <ItemGroup Condition="'@(_PackageReference)' != ''">
      <NuGetDependency Include="@(_PackageReference)" Condition="!%(IsDevelopmentDependency)" RemoveMetadata="IsDevelopmentDependency;RequireReinstallation;VersionConstraint">
        <Version Condition="'%(_PackageReference.VersionConstraint)' != ''">%(_PackageReference.VersionConstraint)</Version>
      </NuGetDependency>
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    GetSourceFiles
    =================================================================================================================== -->
  <Target Name="GetSourceFiles" DependsOnTargets="GetPackageFiles" Condition="'$(EmbedSourceFiles)' == 'True'" Returns="@(_SourceFileWithTargetPath)">
    <ItemGroup>
      <_PdbFiles Include="@(PackageFile)" Condition="'%(Extension)' == '.pdb'" />
    </ItemGroup>
    <ReadPdbSourceFiles PdbPath="%(_PdbFiles.Identity)">
      <Output TaskParameter="SourcePaths" ItemName="_SourceFile" />
    </ReadPdbSourceFiles>
    <!-- Some compilers (like VB) have source files listed that don't actually exist.
         Since we can only package existing files we'll need to exclude those files. -->
    <ItemGroup>
      <_SourceFile Remove="@(_SourceFile)" Condition="!Exists(%(_SourceFile.Identity))" />
    </ItemGroup>
    <AssignSourceTargetPaths SourceFiles="@(_SourceFile)">
      <Output TaskParameter="SourceFilesWithTargetPath" ItemName="_SourceFileWithTargetPath" />
      <Output TaskParameter="SourceFilesWithTargetPath" ItemName="PackageFile" />
    </AssignSourceTargetPaths>
  </Target>
  <!--
    ===================================================================================================================
    GetPackageIdentity
    ===================================================================================================================

    Returns an item whose identity is the $(Id). The version is included in custom metadata item Version. This format
    is identical to the one used to describe package dependencies.

    OUTPUTS:
        $(_PackageIdentity)               The Id and Version of this package

    =================================================================================================================== -->
  <Target Name="GetPackageIdentity" Returns="@(_PackageIdentity)" DependsOnTargets="$(VersionDependsOn)">
    <ItemGroup>
      <_PackageIdentity Include="$(Id)">
        <Version>$(Version)</Version>
      </_PackageIdentity>
    </ItemGroup>
  </Target>
  <!--
    ===================================================================================================================
    Clean, Build, Rebuild
    ===================================================================================================================

    These are the standard targets to clean, build and rebuild a NuGet package.

    =================================================================================================================== -->
  <Target Name="Clean" DependsOnTargets="EstablishNuGetPaths">
    <!-- We should also clear our references.

         Note: We should forward calling the Clear target when building from the command line.
               Assuming, of course, we're not suppressing building project references. -->
    <MSBuild Targets="Clean" Condition="'$(BuildProjectReferences)' == 'true'" Projects="@(ProjectReference)" Properties="$(ProjectProperties)" />
    <!-- Delete our outputs and intermediates. -->
    <ItemGroup>
      <_ToBeDeleted Include="$(NuSpecPath)" />
      <_ToBeDeleted Include="$(NuGetOutputPath)" />
      <_ToBeDeleted Include="$(NuGetSymbolsOutputPath)" />
    </ItemGroup>
    <Delete Files="@(_ToBeDeleted)" />
  </Target>
  <Target Name="Build" DependsOnTargets="CreatePackage" Returns="@(_NuGetOutputFile)">
    <Message Text="$(MSBuildProjectName) -&gt; $(NuGetOutputPath)" Importance="high" />
    <ItemGroup>
      <_NuGetOutputFile Include="$(NuGetOutputPath)" />
      <_NuGetOutputFile Include="$(NuGetSymbolsOutputPath)" Condition=" '$(GenerateSymbolPackage)' == 'true' " />
    </ItemGroup>
  </Target>
  <Target Name="Rebuild" DependsOnTargets="Clean;Build" Returns="@(_NuGetOutputFile)" />
  <!--<Import Project="$(CustomAfterNuProjTargets)" Condition="'$(CustomAfterNuProjTargets)' != '' and Exists('$(CustomAfterNuProjTargets)')" />-->
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="..\open.targets">

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <CopyReferencedProject Condition="'$(ReferencedProjectRelativePath)'!=''">true</CopyReferencedProject>
    <CopyImportedProject Condition="'$(ImportedProjectRelativePath)'!=''">true</CopyImportedProject>
  </PropertyGroup>
  <Choose>
    <When Condition="('$(IsProjectNLibrary)' == 'true' AND '$(IsProjectKLibrary)' == 'true')&#xD;&#xA;                   OR '$(IsPortableOobLibrary)' == 'true'">
      <PropertyGroup>
        <TargetFrameworkIdentifier>.NETPortable</TargetFrameworkIdentifier>
        <TargetFrameworkVersion>v5.0</TargetFrameworkVersion>
        <TargetFrameworkProfile />
        <OutDir>$(FxLibraryOutputPath)</OutDir>
      </PropertyGroup>
    </When>
    <When Condition="'$(IsProjectKLibrary)' == 'true'">
      <PropertyGroup>
        <TargetFrameworkIdentifier>DNXCore</TargetFrameworkIdentifier>
        <TargetFrameworkVersion>v5.0</TargetFrameworkVersion>
        <TargetFrameworkProfile />
        <OutDir>$(FxLibraryOutputPath)\dnxcore\</OutDir>
      </PropertyGroup>
    </When>
    <When Condition="'$(IsProjectNLibrary)' == 'true'">
      <PropertyGroup>
        <TargetFrameworkIdentifier>.NETCore</TargetFrameworkIdentifier>
        <TargetFrameworkVersion>v5.0</TargetFrameworkVersion>
        <TargetFrameworkProfile />
        <OutDir>$(FxLibraryOutputPath)\netcore\</OutDir>
      </PropertyGroup>
    </When>
  </Choose>
  <!-- PackageTargetRuntime Defaults -->
  <PropertyGroup Condition="'$(UseWindowsPackageTargetRuntimeDefault)' == 'true' OR '$(UsePackageTargetRuntimeDefaults)' == 'true'">
    <PackageTargetRuntime Condition=" '$(TargetsWindows)' == 'true' AND '$(PackageTargetRuntime)' == ''">win7</PackageTargetRuntime>
  </PropertyGroup>
  <PropertyGroup Condition="'$(TargetFrameworkIdentifier)' != ''">
    <!-- We don't use any of MSBuild's resolution logic for resolving the framework, so just set these two 
             properties to any folder that exists to skip the GetReferenceAssemblyPaths task (not target) and 
             to prevent it from outputting a warning (MSB3644).
        -->
    <_TargetFrameworkDirectories>$(MSBuildThisFileDirectory)</_TargetFrameworkDirectories>
    <_FullFrameworkReferenceAssemblyPaths>$(MSBuildThisFileDirectory)</_FullFrameworkReferenceAssemblyPaths>
  </PropertyGroup>
  <!--<Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" Condition="'$(CopyReferencedProject)'=='true'" />-->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildExtensionsPath)\NuProj\Microsoft.Common.NuProj.targets" Condition="Exists('$(MSBuildExtensionsPath)\NuProj\Microsoft.Common.NuProj.targets')">

E:\ProjectK\src\Tools\BuildProcess\MSBuild\NuProj\Microsoft.Common.NuProj.targets
============================================================================================================================================
-->
  <!--
    ===================================================================================================================
    _NuProjGetProjectClosure
    ===================================================================================================================

    This target returns the closure of all project references.

    INPUTS:
        @(_MSBuildProjectReferenceExistent)   The project references that actually exist.

    OUTPUTS:
        @(_NuProjProjectReferenceClosure)     The closure of all references. Doesn't include duplicates.

    =================================================================================================================== -->
  <Target Name="_NuProjGetProjectClosure" DependsOnTargets="AssignProjectConfiguration;_SplitProjectReferencesByFileExistence" Returns="@(_NuProjProjectReferenceClosure)">
    <!-- Include our project references -->
    <ItemGroup>
      <_NuProjProjectReferenceClosureWithDuplicates Include="%(_MSBuildProjectReferenceExistent.FullPath)" />
    </ItemGroup>
    <!-- Include references from our references -->
    <MSBuild Projects="@(_MSBuildProjectReferenceExistent)" Targets="_NuProjGetProjectClosure" BuildInParallel="$(BuildInParallel)" Properties="%(_MSBuildProjectReferenceExistent.SetConfiguration); %(_MSBuildProjectReferenceExistent.SetPlatform)" Condition="'%(_MSBuildProjectReferenceExistent.BuildReference)' == 'true' and '@(ProjectReferenceWithConfiguration)' != '' and '@(_MSBuildProjectReferenceExistent)' != ''" ContinueOnError="WarnAndContinue" RemoveProperties="%(_MSBuildProjectReferenceExistent.GlobalPropertiesToRemove)">
      <Output TaskParameter="TargetOutputs" ItemName="_NuProjProjectReferenceClosureWithDuplicates" />
    </MSBuild>
    <!-- Remove duplicates -->
    <RemoveDuplicates Inputs="@(_NuProjProjectReferenceClosureWithDuplicates)">
      <Output TaskParameter="Filtered" ItemName="_NuProjProjectReferenceClosure" />
    </RemoveDuplicates>
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <PropertyGroup Condition="'$(CopyReferencedProject)'=='true'">
    <BuildDependsOn>SetupProductFilePaths;CopyProductFiles;CopyFilesToOutputDirectory</BuildDependsOn>
    <CleanDependsOn>CleanReferencedProjects</CleanDependsOn>
  </PropertyGroup>
  <!-- #################################### -->
  <!-- Disable library build if we are insted restoring from nuget -->
  <!-- #################################### -->
  <PropertyGroup>
    <RestoreProjectNThisLibrary Condition="'$(IsProjectNLibrary)'=='true' and '$(ShipWithProjectNToolset)'!='true' and '$(RestoreProjectNLibraries)'=='true'">true</RestoreProjectNThisLibrary>
  </PropertyGroup>
  <PropertyGroup Condition="'$(RestoreProjectNThisLibrary)'=='true'">
    <!-- Don't build this library, just copy it from the nuget package -->
    <BuildDependsOn>CopyProductFiles</BuildDependsOn>
    <CleanDependsOn />
    <ProductOutputFile>$(RestoreProjectNLibraryPath)$(AssemblyName).dll</ProductOutputFile>
    <ProductOutputPdb />
    <SkipPublishPdb>true</SkipPublishPdb>
    <RunFxTransforms>false</RunFxTransforms>
    <!-- If we restored a PDB from the symbol server for this library, copy it to the output directory -->
    <ProductOutputPdb Condition="Exists('$(RestoreProjectNLibraryPath)$(AssemblyName).pdb')">$(RestoreProjectNLibraryPath)$(AssemblyName).pdb</ProductOutputPdb>
    <SkipPublishPdb Condition="Exists('$(RestoreProjectNLibraryPath)$(AssemblyName).pdb')">false</SkipPublishPdb>
  </PropertyGroup>
  <!-- Suppress building and binplacing other than ProjectN libraries, if requested -->
  <PropertyGroup Condition="'$(OnlyBuildProjectNLibraries)'=='true'">
    <IsProjectKLibrary>false</IsProjectKLibrary>
    <IsPhoneLibrary>false</IsPhoneLibrary>
    <IsTestNetLibrary>false</IsTestNetLibrary>
    <IsNETCoreForCoreCLRLibrary>false</IsNETCoreForCoreCLRLibrary>
  </PropertyGroup>
  <PropertyGroup Condition="'$(OnlyBuildProjectNLibraries)'=='true' and&#xD;&#xA;    '$(IsProjectNLibrary)' != 'true' and&#xD;&#xA;    '$(IsReferenceAssembly)' != 'true'">
    <BuildDependsOn />
  </PropertyGroup>
  <!-- Copy library and PDBs from local path -->
  <PropertyGroup Condition="'$(RestoreFromLocalFolder)'=='true'">
    <!-- Don't build this library, just copy it from local path -->
    <ProductOutputFile Condition="Exists('$(RestoreFromLocalFolderPath)\$(AssemblyName).dll')">$(RestoreFromLocalFolderPath)\$(AssemblyName).dll</ProductOutputFile>
    <!-- Copy PDB from local path -->
    <ProductOutputPdb Condition="Exists('$(RestoreFromLocalFolderPath)\$(AssemblyName).pdb')">$(RestoreFromLocalFolderPath)\$(AssemblyName).pdb</ProductOutputPdb>
    <SkipPublishPdb Condition="Exists('$(RestoreFromLocalFolderPath)\$(AssemblyName).pdb')">false</SkipPublishPdb>
  </PropertyGroup>
  <Target Name="SetupProductFilePaths" DependsOnTargets="ResolveReferences">
    <PropertyGroup>
      <ReferencedOutputPath>%(_ResolvedProjectReferencePaths.RootDir)%(_ResolvedProjectReferencePaths.Directory)</ReferencedOutputPath>
      <ReferencedProductOutputFile>$(ReferencedOutputPath)$(TargetName)$(TargetExt)</ReferencedProductOutputFile>
      <ReferencedProductOutputPdb>$(ReferencedOutputPath)$(TargetName).pdb</ReferencedProductOutputPdb>
      <ProductOutputFile Condition="'$(ProductOutputFile)'==''">$(IntermediateOutputPath)$(TargetName)$(TargetExt)</ProductOutputFile>
      <ProductOutputPdb Condition="'$(ProductOutputPdb)'==''">$(IntermediateOutputPath)$(TargetName).pdb</ProductOutputPdb>
    </PropertyGroup>
    <Copy SourceFiles="$(ReferencedProductOutputFile);$(ReferencedProductOutputPdb)" DestinationFolder="$(IntermediateOutputPath)" SkipUnchangedFiles="true" />
  </Target>
  <!-- 
    Target that enables people to import a project from another directory and updates the relative
    paths for common items to be based on that directory.
  -->
  <PropertyGroup Condition="'$(CopyImportedProject)'=='true'">
    <CoreBuildDependsOn>UpdateImportedProjectRelativePaths;$(CoreBuildDependsOn)</CoreBuildDependsOn>
    <CoreCleanDependsOn>UpdateImportedProjectRelativePaths;$(CoreCleanDependsOn)</CoreCleanDependsOn>
  </PropertyGroup>
  <Target Name="UpdateImportedProjectRelativePaths" Condition="'$(CopyImportedProject)'=='true'">
    <ItemGroup>
      <RelCompile Include="@(Compile)" Condition="!$([System.IO.Path]::IsPathRooted('%(Identity)'))" />
      <Compile Remove="@(RelCompile)" />
      <Compile Include="@(RelCompile -> '$(ImportedProjectRelativePath)\%(Identity)')" />
      <RelNone Include="@(None)" Condition="!$([System.IO.Path]::IsPathRooted('%(Identity)'))" />
      <None Remove="@(RelNone)" />
      <None Include="@(RelNone -> '$(ImportedProjectRelativePath)\%(Identity)')" />
      <RelProjectReference Include="@(ProjectReference)" Condition="!$([System.IO.Path]::IsPathRooted('%(Identity)'))" />
      <ProjectReference Remove="@(RelProjectReference)" />
      <ProjectReference Include="@(RelProjectReference -> '$(ImportedProjectRelativePath)\%(Identity)')" />
      <RelEmbeddedResource Include="@(EmbeddedResource)" Condition="!$([System.IO.Path]::IsPathRooted('%(Identity)'))" />
      <EmbeddedResource Remove="@(RelEmbeddedResource)" />
      <EmbeddedResource Include="@(RelEmbeddedResource -> '$(ImportedProjectRelativePath)\%(Identity)')" />
    </ItemGroup>
  </Target>
  <PropertyGroup>
    <AssemblyVersion Condition="'$(AssemblyVersion)'==''">4.0.0.0</AssemblyVersion>
  </PropertyGroup>
  <PropertyGroup Condition="'$(ImportLibraryTargets)' == ''">
    <ImportLibraryTargets Condition="'$(IsProjectNLibrary)' == 'true' or '$(TargetProjectNFramework)' == 'true'">true</ImportLibraryTargets>
    <ImportLibraryTargets Condition="'$(IsProjectKLibrary)' == 'true' or '$(TargetProjectKFramework)' == 'true'">true</ImportLibraryTargets>
    <ImportLibraryTargets Condition="'$(IsTestNetLibrary)'  == 'true' or '$(TargetTestNetFramework)' == 'true'">true</ImportLibraryTargets>
    <ImportLibraryTargets Condition="'$(IsNetCoreForCoreCLRLibrary)'  == 'true' or '$(TargetNetCoreForCoreCLRFramework)' == 'true'">true</ImportLibraryTargets>
  </PropertyGroup>
  <!--
============================================================================================================================================
  <Import Project="packageLibs.targets">

E:\ProjectK\src\NDP\FxCore\src\packageLibs.targets
============================================================================================================================================
-->
  <!-- Returns the set of files to be included in the nuget package
       with appropriate metadata.-->
  <Target Name="GetFilesToPackage" Returns="@(FilesToPackage)">
    <PropertyGroup>
      <!-- treat a lib as purely portable if it is shared, desktop is explicitly omitted -->
      <IsPurePortableLibrary Condition="'$(IsProjectNLibrary)' == 'true' AND '$(IsProjectKLibrary)' == 'true' AND '$(IsNETCoreForCoreCLRLibrary)' == 'true'">true</IsPurePortableLibrary>
      <IsPurePortableLibrary Condition="'$(IsPortableOobLibrary)' == 'true'">true</IsPurePortableLibrary>
      <PackagePath Condition="'$(PackagePath)' == ''">$(TargetPath)</PackagePath>
      <IsReferenceAssembly Condition="'$(ContractStatus)' != ''">true</IsReferenceAssembly>
      <PackageIncludeDocs Condition="'$(PackageIncludeDocs)' == '' AND '$(IsReferenceAssembly)' == 'true'">true</PackageIncludeDocs>
      <PackageIncludeDocs Condition="'$(PackageIncludeDocs)' == '' AND '$(PackageBuildGeneratedDocumentation)' == 'true'">true</PackageIncludeDocs>
    </PropertyGroup>
    <!-- This isn't a straight mapping to an algorithm using CultureInfo, nor easily accessible from decatur targets 
         used for traditional MT packs. Given the special cases for en-US, zh-*, it seemed prudent not to generalize 
         and just have the supported set spelled out. -->
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
      <ExistingXmlDocFile Include="@(XmlDocFile)" Condition="Exists('%(Identity)')" />
    </ItemGroup>
    <!-- currently behind a flag to avoid noise in the build -->
    <Warning Condition="'$(ValidateDocs)' == 'true' AND '$(PackageIncludeDocs)' == 'true' AND !Exists('%(XmlDocFile.Identity)')" Text="Documentation file %(XmlDocFile.Identity) was not found." />
    <MSBuild Targets="GetAssemblyVersion" Projects="@(ProjectReference)" Properties="$(ProjectProperties)" Condition="'$(CopyReferencedProject)' == 'true'">
      <Output TaskParameter="TargetOutputs" PropertyName="AssemblyVersion" />
    </MSBuild>
    <MSBuild Targets="GetDocumentationFile" Projects="@(ProjectReference)" Properties="$(ProjectProperties)" Condition="'$(CopyReferencedProject)' == 'true' and '$(PackageBuildGeneratedDocumentation)' == 'true'">
      <Output TaskParameter="TargetOutputs" PropertyName="DocumentationFile" />
    </MSBuild>
    <Error Condition="'$(IsReferenceAssembly)' == 'true' AND '$(PackageTargetRuntime)' != ''" Text="Reference assemblies should not specify the PackageTargetRuntime property since runtimes cannot effect compile time assets." />
    <!-- PackageTargetRuntime Defaults -->
    <PropertyGroup Condition="'$(UsePackageTargetRuntimeDefaults)' == 'true' AND '$(PackageTargetRuntime)' == ''">
      <PackageTargetRuntime Condition="'$(TargetsWindows)' == 'true'">win7</PackageTargetRuntime>
      <PackageTargetRuntime Condition="'$(TargetsUnix)' == 'true'">unix</PackageTargetRuntime>
    </PropertyGroup>
    <!-- *** determine destination path for assets *** -->
    <PropertyGroup>
      <_packageTargetRefLib>lib</_packageTargetRefLib>
      <_packageTargetRefLib Condition="'$(IsReferenceAssembly)' == 'true'">ref</_packageTargetRefLib>
      <!-- use PackageTargetFramework if it is specified or no Is*LibraryProperties are specified -->
      <_usePackageTargetFramework Condition="'$(PackageTargetFramework)' != ''">true</_usePackageTargetFramework>
      <_usePackageTargetFramework Condition="'$(IsDesktopLibrary)' != 'true' AND '$(IsProjectKLibrary)' != 'true' AND '$(IsNETCoreForCoreCLRLibrary)' != 'true' AND '$(IsProjectNLibrary)' != 'true'">true</_usePackageTargetFramework>
      <!-- if not using legacy Is*Library properties and PackageTargetRuntime is specified, default to PackageTargetFramework = 'dotnet' -->
      <PackageTargetFramework Condition="'$(_usePackageTargetFramework)' == 'true' AND '$(PackageTargetFramework)' == '' AND '$(PackageTargetRuntime)' != ''">dotnet</PackageTargetFramework>
      <_packageTargetPathRuntimePrefix Condition="'$(PackageTargetRuntime)' != ''">runtimes/$(PackageTargetRuntime)/</_packageTargetPathRuntimePrefix>
      <PackageTargetPath Condition="'$(PackageTargetPath)' == '' AND '$(PackageTargetFramework)' != ''">$(_packageTargetPathRuntimePrefix)$(_packageTargetRefLib)/$(PackageTargetFramework)</PackageTargetPath>
      <PackageTargetPathRef Condition="'$(PackageTargetPathRef)' == '' AND '$(PackageTargetFramework)' != ''">ref/$(PackageTargetFramework)</PackageTargetPathRef>
    </PropertyGroup>
    <!-- specifying $(PackageTargetPath) overrides defaults and project specific items -->
    <ItemGroup Condition="'$(PackageTargetPath)' != ''">
      <!-- remove anything specified by the project-->
      <PackageDestination Remove="@(PackageDestination)" />
      <!-- only use $(PackageTargetPath) -->
      <PackageDestination Include="$(PackageTargetPath)">
        <TargetFramework Condition="'$(PackageTargetFramework)' != ''">$(PackageTargetFramework)</TargetFramework>
      </PackageDestination>
      <!-- if the implementation also needs to be treated as a desktop reference assembly, include in ref -->
      <PackageDestination Include="$(PackageTargetPathRef)" Condition="'$(IsDesktopReferenceAssembly)' == 'true'">
        <TargetFramework Condition="'$(PackageTargetFramework)' != ''">$(PackageTargetFramework)</TargetFramework>
      </PackageDestination>
    </ItemGroup>
    <!-- *** map our legacy Is*Library properties to the PackageDestination item *** -->
    <ItemGroup Condition="'@(PackageDestination)' == '' and &#xD;&#xA;                          '$(IsPurePortableLibrary)' == 'true'">
      <PackageDestination Include="$(_packageTargetPathRuntimePrefix)$(_packageTargetRefLib)/dotnet">
        <TargetFramework>dotnet</TargetFramework>
      </PackageDestination>
    </ItemGroup>
    <ItemGroup Condition="'@(PackageDestination)' == ''">
      <!-- Desktop is not a System.Runtime based framework, so facades must also
            be used at compile time to unify with implementation-based reference assemblies -->
      <PackageDestination Condition="'$(IsDesktopLibrary)' == 'true' and&#xD;&#xA;                                     '$(IsDesktopReferenceAssembly)' == 'true'" Include="ref/net46">
        <TargetFramework>net46</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(IsDesktopLibrary)' == 'true'" Include="$(_packageTargetPathRuntimePrefix)lib/net46">
        <TargetFramework>net46</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(IsProjectKLibrary)' == 'true'" Include="$(_packageTargetPathRuntimePrefix)lib/DNXCore50">
        <TargetFramework>dnxcore50</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(IsNETCoreForCoreCLRLibrary)' == 'true'" Include="$(_packageTargetPathRuntimePrefix)lib/netcore50">
        <TargetFramework>netcore50</TargetFramework>
      </PackageDestination>
      <PackageDestination Condition="'$(IsNETCoreForCoreCLRLibrary)' != 'true' and&#xD;&#xA;                                     '$(IsProjectNLibrary)' == 'true' and&#xD;&#xA;                                     '$(IsProjectNTestOnlyLibrary)' != 'true'" Include="runtimes/win8-aot/lib/netcore50">
        <TargetFramework>netcore50</TargetFramework>
      </PackageDestination>
    </ItemGroup>
    <!-- *** include assets *** -->
    <ItemGroup>
      <!-- Include primary output -->
      <FilesToPackage Include="$(PackagePath)">
        <AssemblyVersion>$(AssemblyVersion)</AssemblyVersion>
        <TargetFramework>%(PackageDestination.TargetFramework)</TargetFramework>
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
      </FilesToPackage>
      <!-- Include doc output -->
      <FilesToPackage Include="$(DocumentationFile)" Condition="'$(DocumentationFile)' != '' AND '$(PackageIncludeDocs)' == 'true'">
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
        <!-- intentionally omit TargetFramework: no dependencies for docs -->
      </FilesToPackage>
      <!-- Include pre-authored docs if available and required -->
      <FilesToPackage Include="@(ExistingXmlDocFile)" Condition="'$(PackageIncludeDocs)' == 'true'">
        <TargetPath>%(PackageDestination.Identity)</TargetPath>
        <!-- intentionally omit TargetFramework: no dependencies for docs -->
      </FilesToPackage>
      <FilesToPackage Condition="'%(FilesToPackage.SubFolder)' != ''">
        <TargetPath>%(TargetPath)%(FilesToPackage.SubFolder)</TargetPath>
      </FilesToPackage>
    </ItemGroup>
    <ItemGroup>
      <FilesToPackage>
        <SkipVersionCheck Condition="'$(SkipVersionCheck)' == 'true'">true</SkipVersionCheck>
      </FilesToPackage>
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="ibc.targets">

E:\ProjectK\src\NDP\FxCore\src\ibc.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <OptimizationDataFile>$(MSBuildThisFileDirectory)..\OptimizationData\$(TargetName).zip</OptimizationDataFile>
    <MergeOptimizationData Condition="'$(EnableMergeOptimizationData)'=='' and '$(Configuration)' == 'Release'">true</MergeOptimizationData>
    <MergeOptimizationData Condition="!Exists($(OptimizationDataFile))">false</MergeOptimizationData>
  </PropertyGroup>
  <UsingTask TaskName="Microsoft.Internal.Tools.OptimizationProfiler.MsBuild.PostLinkOptimize" AssemblyFile="$(EnlistmentRootPath)tools\devdiv\OptProf\Tasks.dll" />
  <Target Name="MergeOptimizationData" Condition="'$(MergeOptimizationData)'=='true'">
    <PropertyGroup>
      <IntermediatePreMergePath>$(IntermediateOutputPath)PreMergeOptimizationData\</IntermediatePreMergePath>
    </PropertyGroup>
    <!-- Move the input files to the unoptimized directory -->
    <MakeDir Directories="$(IntermediatePreMergePath)" />
    <Move SourceFiles="$(ProductOutputFile);$(ProductOutputPdb)" DestinationFolder="$(IntermediatePreMergePath)" />
    <PostLinkOptimize TempDirectory="$(IntermediateOutputPath)" DataZipPaths="$(OptimizationDataFile)" ModulePath="$(IntermediatePreMergePath)$(TargetName)$(TargetExt)" OutputPath="$(ProductOutputFile)" PDBNameAndPath="$(ProductOutputPdb)" StatisticsPath="$(IntermediateOutputPath)$(TargetName).optimizationstats.txt" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)\Contracts\TargetFrameworks.settings.targets">

E:\ProjectK\src\NDP\FxCore\src\Contracts\TargetFrameworks.settings.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <IncludeInternalContractAssemblies>true</IncludeInternalContractAssemblies>
  </PropertyGroup>
  <!-- Setup the internal contract root path which will allow both the resolution of 
    the internal contracts as well as provide a way to override some public contracts -->
  <ItemGroup>
    <ContractRootPaths Include="$(ContractOutputPath)" />
  </ItemGroup>
  <PropertyGroup>
    <TargetProjectNFramework Condition="'$(TargetProjectNFramework)'=='' and '$(IsProjectNLibrary)'=='true'">true</TargetProjectNFramework>
    <TargetNetCoreForCoreCLRFramework Condition="'$(TargetNetCoreForCoreCLRFramework)'=='' and '$(IsNETCoreForCoreCLRLibrary)'=='true'">true</TargetNetCoreForCoreCLRFramework>
    <TargetProjectKFramework Condition="'$(TargetProjectKFramework)'=='' and '$(IsProjectKLibrary)'=='true'">true</TargetProjectKFramework>
    <TargetTestNetFramework Condition="'$(TargetTestNetFramework)'=='' and '$(IsTestNetLibrary)'=='true'">true</TargetTestNetFramework>
    <TargetPhoneFramework Condition="'$(TargetPhoneFramework)'=='' and '$(IsPhoneLibrary)'=='true'">true</TargetPhoneFramework>
    <TargetDesktopFramework Condition="'$(TargetDesktopFramework)'=='' and '$(IsDesktopLibrary)'=='true'">true</TargetDesktopFramework>
    <!-- Used to determine if the ResolveSupportedContracts task should do extra validation around Implementation and OOB assemblies -->
    <IsLibraryForSpecificFramework Condition="'$(IsProjectNLibrary)'=='true' or '$(IsProjectKLibrary)'=='true' or '$(IsTestNetLibrary)'=='true' or '$(IsPhoneLibrary)'=='true'">true</IsLibraryForSpecificFramework>
  </PropertyGroup>
  <ItemGroup>
    <!-- These need to be set here as opposed to the [TF].setting.targets files because of sharing between those files -->
    <AllTargetFrameworks Include="ProjectN" Condition="'$(TargetProjectNFramework)'=='true'" />
    <AllTargetFrameworks Include="ProjectK" Condition="'$(TargetProjectKFramework)'=='true'" />
    <AllTargetFrameworks Include="TestNet" Condition="'$(TargetTestNetFramework)'=='true'" />
    <AllTargetFrameworks Include="Phone" Condition="'$(TargetPhoneFramework)'=='true'" />
    <AllTargetFrameworks Include="Desktop" Condition="'$(TargetDesktopFramework)'=='true'" />
  </ItemGroup>
  <!--<Import Project="$(MSBuildThisFileDirectory)\TargetFrameworks\ProjectN\ProjectN.settings.targets" Condition="'$(TargetProjectNFramework)'=='true'" />-->
  <!--<Import Project="$(MSBuildThisFileDirectory)\TargetFrameworks\ProjectK\ProjectK.settings.targets" Condition="'$(TargetProjectKFramework)'=='true'" />-->
  <!--<Import Project="$(MSBuildThisFileDirectory)\TargetFrameworks\Phone\Phone.settings.targets" Condition="'$(TargetPhoneFramework)'=='true'" />-->
  <!-- Import ProjectK and Phone targets before Test.Net because Test.Net also imports those conditionally and we want to avoid cycles -->
  <!--<Import Project="$(MSBuildThisFileDirectory)\TargetFrameworks\TestNet\TestNet.settings.targets" Condition="'$(TargetTestNetFramework)'=='true'" />-->
  <!--<Import Project="$(MSBuildThisFileDirectory)\TargetFrameworks\Desktop\Desktop.settings.targets" Condition="'$(TargetDesktopFramework)'=='true'" />-->
  <!--
============================================================================================================================================
  <Import Project="$(EnlistmentRootPath)ExternalApis\NetFX\Contracts\TargetFrameworks\Contracts.Resolve.targets">

E:\ProjectK\src\ExternalApis\NetFX\Contracts\TargetFrameworks\Contracts.Resolve.targets
============================================================================================================================================
-->
  <!-- Before importing this the assumption is that the set of allowed contracts will be defined like:
    <ItemGroup>
      <ContractAssembly Include="System.Runtime">
        <Version>4.0.10.0</Version>
      </ContractAssembly>
      ...
    </ItemGroup>
  -->
  <UsingTask TaskName="ResolveFilePathTask" AssemblyFile="$(MSBuildThisFileDirectory)CoreFx.Build.Tasks.dll" />
  <UsingTask TaskName="ResolveReferencedContracts" AssemblyFile="$(MSBuildThisFileDirectory)CoreFx.Build.Tasks.dll" />
  <UsingTask TaskName="ResolveSupportedContracts" AssemblyFile="$(MSBuildThisFileDirectory)CoreFx.Build.Tasks.dll" />
  <UsingTask TaskName="ConvertPackagesConfigToReferences" AssemblyFile="$(MSBuildThisFileDirectory)CoreFx.Build.Tasks.dll" />
  <PropertyGroup>
    <!-- version number to use if a Reference doesn't specify a version -->
    <DefaultContractVersion Condition="'$(DefaultContractVersion)'==''">4.0.0.0</DefaultContractVersion>
    <ContractRootPath Condition="'$(ContractRootPath)'==''">$([System.IO.Path]::GetFullPath('$(MSBuildThisFileDirectory)..'))</ContractRootPath>
  </PropertyGroup>
  <ItemGroup>
    <ContractRootPaths Include="$(ContractRootPath)" />
  </ItemGroup>
  <!-- Follow NuGet rules for locating packages.config -->
  <ItemGroup>
    <PackagesConfigCandidate Include="$(MSBuildProjectDirectory)\$(MSBuildProjectFile).packages.config" />
    <!-- MyProj.csproj.packages.config -->
    <PackagesConfigCandidate Include="$(MSBuildProjectDirectory)\$(MSBuildProjectName).packages.config" />
    <!-- MyProj.packages.config -->
    <PackagesConfigCandidate Include="$(MSBuildProjectDirectory)\packages.config" />
    <!-- packages.config -->
  </ItemGroup>
  <!-- Finds the first packages.config that exists in PackagesConfigCandidate item 
       and uses that as the packages.config
   -->
  <Target Name="FindPackagesConfig">
    <ItemGroup>
      <_PackagesConfigCandidate Include="@(PackagesConfigCandidate-&gt;Reverse())" Condition="Exists('%(Identity)')" />
    </ItemGroup>
    <PropertyGroup>
      <!-- Rely on the fact that the last item wins in the batch -->
      <PackagesConfigFile>%(_PackagesConfigCandidate.Identity)</PackagesConfigFile>
    </PropertyGroup>
  </Target>
  <!-- Resolves <Reference> items from a packages.config. 
       This enables us to share packages.config/project files with OSS
       even though we're not building against the packages. -->
  <Target Name="ResolveNuGetReferences" DependsOnTargets="FindPackagesConfig">
    <ConvertPackagesConfigToReferences PackagesConfigFile="$(PackagesConfigFile)" Condition="$(PackagesConfigFile) != ''">
      <Output TaskParameter="References" ItemName="Reference" />
    </ConvertPackagesConfigToReferences>
  </Target>
  <!-- Auto-adds default references if they aren't already added -->
  <Target Name="ResolveDefaultReferences" Condition="'$(ExcludeDefaultReferences)'!='true'">
    <ItemGroup>
      <Reference Include="@(DefaultReference)" Exclude="@(Reference)" />
    </ItemGroup>
  </Target>
  <Target Name="ResolveSupportedContracts" DependsOnTargets="ResolveNuGetReferences;ResolveDefaultReferences">
    <Error Condition="'@(AllTargetFrameworks)'==''" Text="You need to specify at least one TargetFramework either via IsXYXLibrary=true or directly via TargetXYZFramework=true" />
    <PropertyGroup Condition="'$(IsLibraryForSpecificFramework)'=='true'">
      <ResolveSupportedContractsTargetAssemblyName>$(AssemblyName)</ResolveSupportedContractsTargetAssemblyName>
    </PropertyGroup>
    <ResolveSupportedContracts ContractAssemblies="@(ContractAssembly)" ContractStoreRootPaths="@(ContractRootPaths)" DefaultContractVersion="$(DefaultContractVersion)" TargetFrameworks="@(AllTargetFrameworks)" TargetAssemblyName="$(ResolveSupportedContractsTargetAssemblyName)" ImplementationAssemblies="@(ImplementationAssembly)" OOBAssemblies="@(OOBAssembly)">
      <Output TaskParameter="ContractAssemblyWithPaths" ItemName="ContractAssemblyWithPath" />
      <Output TaskParameter="TargetAssemblyIsOOBAssembly" PropertyName="TargetAssemblyCanReferenceOOBAssembly" />
    </ResolveSupportedContracts>
  </Target>
  <Target Name="ResolveReferencedContracts" DependsOnTargets="ResolveSupportedContracts">
    <ResolveReferencedContracts ContractAssemblyWithPaths="@(ContractAssemblyWithPath)" ContractStoreRootPaths="@(ContractRootPaths)" DefaultContractVersion="$(DefaultContractVersion)" References="@(Reference)" CanReferenceOOBAssembly="$(TargetAssemblyCanReferenceOOBAssembly)">
      <Output TaskParameter="ReferencePaths" ItemName="ReferencePath" />
    </ResolveReferencedContracts>
    <ItemGroup>
      <Reference Remove="@(ReferencePath->'%(Filename)')" />
    </ItemGroup>
  </Target>
  <Target Name="ResolveSupportedDesignTimeFacades">
    <ItemGroup>
      <DesignTimeFacadePath Include="@(DesignTimeFacade->'$(ContractOutputPath)DesignTimeFacades\%(Identity).dll')">
        <Platform>%(DesignTimeFacade.Platform)</Platform>
      </DesignTimeFacadePath>
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Contracts\TargetFrameworks.settings.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(MSBuildThisFileDirectory)\RunPInvokeChecker.targets" Condition="'$(TargetsWindows)'=='true'">

E:\ProjectK\src\NDP\FxCore\src\RunPInvokeChecker.targets
============================================================================================================================================
-->
  <PropertyGroup Condition="'$(RunPInvokeChecker)'!='false' and '$(TargetsWindows)' == 'true' ">
    <PrepareForRunDependsOn>$(PrepareForRunDependsOn);RunPInvokeChecker</PrepareForRunDependsOn>
    <PInvokeCheckerSemaphoreFile>$(IntermediateOutputPath)RunPInvokeChecker.Complete</PInvokeCheckerSemaphoreFile>
  </PropertyGroup>
  <!-- Include RunPInvokeChecker for our referenced project open library builds -->
  <PropertyGroup Condition="'$(RunPInvokeChecker)'!='false' and '$(TargetsWindows)' == 'true' and '$(CopyReferencedProject)'=='true'">
    <BuildDependsOn>$(BuildDependsOn);RunPInvokeChecker</BuildDependsOn>
  </PropertyGroup>
  <ItemGroup>
    <PInvokeAPIList Include="ProjectNCheckModernAPI" Condition="'$(TargetProjectNFramework)' == 'true' or '$(TargetNetCoreForCoreCLRFramework)' == 'true'">
      <Windows>$(PInvokeCheckerFolder)OneCoreUWPApis.xml</Windows>
      <ProjectSpecific>$(MSBuildThisFileDirectory)OneCoreUWPApis_Manual.xml</ProjectSpecific>
    </PInvokeAPIList>
    <PInvokeAPIList Include="ProjectNCheckCoreSystemAPI" Condition="'$(TargetProjectNFramework)' == 'true' or '$(TargetNetCoreForCoreCLRFramework)' == 'true'">
      <Windows>$(PInvokeCheckerFolder)OneCoreApis.xml</Windows>
      <ProjectSpecific>$(MSBuildThisFileDirectory)OneCoreApis_Manual.xml</ProjectSpecific>
    </PInvokeAPIList>
    <PInvokeAPIList Include="ProjectK" Condition="'$(TargetProjectKFramework)' == 'true' or '$(TargetTestNetFramework)' == 'true'">
      <Windows>$(PInvokeCheckerFolder)OneCoreApis.xml</Windows>
      <ProjectSpecific>$(MSBuildThisFileDirectory)OneCoreApis_Manual.xml</ProjectSpecific>
      <OptionalFlag>checkForWin7Support</OptionalFlag>
    </PInvokeAPIList>
  </ItemGroup>
  <Target Name="RunPInvokeChecker" Condition="'@(PInvokeApiList)' != ''" Inputs="@(IntermediateAssembly);%(PInvokeAPIList.Windows);%(PInvokeAPIList.ProjectSpecific)" Outputs="$(PInvokeCheckerSemaphoreFile).%(PInvokeAPIList.Identity)">
    <Exec Command="$(PInvokeCheckerPath) @(IntermediateAssembly) %(PInvokeAPIList.Windows) %(PInvokeAPIList.ProjectSpecific) %(PInvokeAPIList.OptionalFlag)" StandardOutputImportance="Normal" IgnoreExitCode="true">
      <Output TaskParameter="ExitCode" PropertyName="ErrorCode" />
    </Exec>
    <Error Condition="'$(ErrorCode)'!='0'" Text="Platform API dependency violations have been detected. These need to be addressed by removing or changing API usage or getting exceptions approved and added to '%(PInvokeAPIList.ProjectSpecific)'." />
    <Touch Files="$(PInvokeCheckerSemaphoreFile).%(PInvokeAPIList.Identity)" AlwaysCreate="true" />
    <ItemGroup>
      <WriteFiles Include="$(PInvokeCheckerSemaphoreFile).%(PInvokeAPIList.Identity)" />
    </ItemGroup>
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="..\..\Common\inc\ProductFile.targets">

E:\ProjectK\src\NDP\Common\inc\ProductFile.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <RunCopyProductFilesAfterTargets Condition="'$(RunCopyProductFilesAfterTargets)'==''">CopyFilesToOutputDirectory</RunCopyProductFilesAfterTargets>
    <ProductOutputFile Condition="'$(ProductOutputFile)'==''">$(IntermediateOutputPath)$(TargetName)$(TargetExt)</ProductOutputFile>
    <ProductOutputPdb Condition="'$(ProductOutputPdb)'=='' and '$(SkipPublishPdb)'!='true'">$(IntermediateOutputPath)$(TargetName).pdb</ProductOutputPdb>
  </PropertyGroup>
  <PropertyGroup Condition="'$(ProjectLanguage)'=='native'">
    <RunCopyProductFilesAfterTargets Condition="'$(CopyAfterTargetsOverride)' == ''">Link</RunCopyProductFilesAfterTargets>
    <RunCopyProductFilesAfterTargets Condition="'$(CopyAfterTargetsOverride)' != ''">$(CopyAfterTargetsOverride)</RunCopyProductFilesAfterTargets>
    <ProductOutputFile Condition="'$(ProductOutputFileOverride)' == ''">@(Internal_LinkOutputFile)</ProductOutputFile>
    <ProductOutputFile Condition="'$(ProductOutputFileOverride)' != ''">$(ProductOutputFileOverride)</ProductOutputFile>
    <ProductOutputPdb Condition="'$(LinkResourceOnlyDll)'!='true' and '$(ProductOutputPdbOverride)'==''">@(Internal_ProgramDataBaseFileName)</ProductOutputPdb>
    <ProductOutputPdb Condition="'$(LinkResourceOnlyDll)'!='true' and '$(ProductOutputPdbOverride)'!=''">$(ProductOutputPdbOverride)</ProductOutputPdb>
    <ProductOutputPdb Condition="'$(LinkResourceOnlyDll)'=='true'" />
    <ProductOutputPath Condition="'$(ProductOutputPath)'==''">$(IntermediateOutputPath)</ProductOutputPath>
  </PropertyGroup>
  <Target Name="GatherProductFiles">
    <!-- Default Product Paths for ProjectK Libraries -->
    <ItemGroup Condition="'$(IsProjectKLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>ProjectK</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>ProjectK</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsDesktopLibrary)'=='true'">
      <!-- TFS: Work item 969116 : Currently, ToF needs all of the non-inbox desktop assemblies (facade or not),
             to live in the Desktop\Facades folder. -->
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>Desktop</ProductName>
        <ProductPath>Facades</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>Desktop</ProductName>
        <ProductPath>Facades</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(OneCoreToolsPath)'!=''">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools\$(OneCoreToolsPath)</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools\$(OneCoreToolsPath)</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for Phone Libraries -->
    <ItemGroup Condition="'$(IsPhoneLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>Phone</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>Phone</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for Test.Net Libraries -->
    <!-- Test.Net is meant to be the union of all CoreCLR profiles-->
    <PropertyGroup Condition="'$(IsTestNetLibrary)'=='true'">
      <IsCoreClrLibrary>true</IsCoreClrLibrary>
    </PropertyGroup>
    <ItemGroup Condition="'$(IsTestNetLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Libraries</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Libraries</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsCoreClrLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>IL</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>IL</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>\</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for Test.Net Dependencies -->
    <!-- Keeping these files separate from Test.Net assemblies allows users to easily grab 
           only Test.Net extensions (from TestNet\Libraries) or Test.Net with a complete
           CoreCLR (from TestNet\Libraries + TestNet\Runtime) depending on their scenario -->
    <PropertyGroup Condition="'$(IsTestNetCoreRuntimeLibrary)'=='true'">
      <IsCoreClrCoreRuntimeLibrary>true</IsCoreClrCoreRuntimeLibrary>
    </PropertyGroup>
    <ItemGroup Condition="'$(IsTestNetCoreRuntimeLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Runtime</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsCoreClrCoreRuntimeLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>IL</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>IL</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>OneCore</ProductName>
        <ProductPath>\</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsTestNetHost)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Host</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Host</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for ProjectN Libraries -->
    <ItemGroup Condition="'$(IsProjectNLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>ProjectN</ProductName>
        <ProductPath>layout\ilc\lib\IL\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''  and '$(ProjectLanguage)'!='native'">
        <ProductName>ProjectN</ProductName>
        <ProductPath>layout\ilc\lib\IL\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>ProjectN</ProductName>
        <ProductPath>layout\ILC\Lib\runtime\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''  and '$(ProjectLanguage)'=='native'">
        <ProductName>ProjectN</ProductName>
        <ProductPath>Symbols.Pri\retail\dll</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsNETCoreForCoreCLRLibrary)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'!='native'">
        <ProductName>NETCoreForCoreCLR</ProductName>
        <ProductPath>lib\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>NETCoreForCoreCLR</ProductName>
        <ProductPath>libPdb\</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!='' and '$(ProjectLanguage)'=='native'">
        <ProductName>NETCoreForCoreCLR</ProductName>
        <ProductPath>native\</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsDesktopTool)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools\Desktop</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools\Desktop</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'@(CoreClrDesktopTool)'!=''">
      <ProductFile Include="%(CoreClrDesktopTool.SrcOverRide)%(CoreClrDesktopTool.Identity)" Condition="'%(CoreClrDesktopTool.SrcOverRide)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools\Desktop</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for Phone Tools -->
    <ItemGroup Condition="'$(IsPhoneTool)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>Phone</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>Phone</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for ProjectK Tools -->
    <ItemGroup Condition="'$(IsProjectKTool)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>ProjectK</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>ProjectK</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
    </ItemGroup>
    <!-- Default Product Paths for TestNet Tools -->
    <ItemGroup Condition="'$(IsTestNetTool)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>TestNet</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>Tools</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsMDILCompileSDK)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>Phone</ProductName>
        <ProductPath>WindowsPhoneMDILCompilerSDK</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'$(IsCoreClrSDK)'=='true'">
      <ProductFile Include="$(ProductOutputFile)" Condition="'$(ProductOutputFile)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>SDK</ProductPath>
      </ProductFile>
      <ProductFile Include="$(ProductOutputPdb)" Condition="'$(ProductOutputPdb)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>SDK</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'@(CoreClrSDKLib)'!=''">
      <ProductFile Include="$(ProductOutputPath)%(CoreClrSDKLib.Identity)">
        <ProductName>OneCore</ProductName>
        <ProductPath>SDK\lib</ProductPath>
      </ProductFile>
    </ItemGroup>
    <ItemGroup Condition="'@(CoreClrSDKHeader)'!=''">
      <ProductFile Include="%(CoreClrSDKHeader.SrcOverRide)%(CoreClrSDKHeader.Identity)" Condition="'%(CoreClrSDKHeader.SrcOverRide)'!=''">
        <ProductName>OneCore</ProductName>
        <ProductPath>SDK</ProductPath>
      </ProductFile>
    </ItemGroup>
  </Target>
  <!-- Copy the ProductFiles to the correct location in the binary output -->
  <Target Name="CopyProductFiles" DependsOnTargets="GatherProductFiles;CoreCopyProductFiles" AfterTargets="$(RunCopyProductFilesAfterTargets)" />
  <Target Name="CoreCopyProductFiles" Condition="'@(ProductFile)' != ''">
    <Error Condition="'$(OutputRootPath)' == ''" Text="DropProductFiles.targets: OutputRootPath property must be defined." />
    <Error Condition="'%(ProductFile.ProductName)'==''" Text="Missing ProductFile.ProductName metadata for %(ProductFile.Identity)." />
    <Error Condition="'%(ProductFile.ProductPath)'==''" Text="Missing ProductFile.ProductPath metadata for %(ProductFile.Identity)." />
    <PropertyGroup>
      <OutputRootPath Condition="!HasTrailingSlash('$(OutputRootPath)')">$(OutputRootPath)\</OutputRootPath>
    </PropertyGroup>
    <ItemGroup>
      <ProductFile>
        <ProductFullPath Condition="'%(ProductFile.ProductPath)'=='root'">$(OutputRootPath)%(ProductName)\</ProductFullPath>
        <ProductFullPath Condition="'%(ProductFile.ProductPath)'!='root'">$(OutputRootPath)%(ProductName)\%(ProductPath)</ProductFullPath>
      </ProductFile>
      <ProductFile>
        <ProductFullPath Condition="'$(GenerateProjectSpecificOutputFolder)' == 'true'">%(ProductFile.ProductFullPath)\$(ProjectName)</ProductFullPath>
      </ProductFile>
    </ItemGroup>
    <Copy SourceFiles="@(ProductFile)" DestinationFolder="%(ProductFullPath)" SkipUnchangedFiles="true">
      <Output TaskParameter="CopiedFiles" ItemName="FileWrites" />
    </Copy>
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\open.targets
============================================================================================================================================
-->
  <!-- 
    IL2IL on FX libraries
    
    For the open libraries the only interesting transform is the ReflectionApiBlock which causes issues for
    some of the pn tool chain if we don't block them the APIs.
  -->
  <PropertyGroup>
    <RunFxTransforms Condition="'$(RunFxTransforms)'=='' and '$(CopyReferencedProject)'=='true'">$(IsProjectNLibrary)</RunFxTransforms>
    <FxTransformsDependsOn>
      FxTransforms_InitializeProperties;
      FxTransforms_CopyToIntermediate;
      FxTransforms_Core;
    </FxTransformsDependsOn>
  </PropertyGroup>
  <Target Name="PostCompilationTransforms" DependsOnTargets="FxTransforms;MergeOptimizationData" BeforeTargets="CopyProductFiles" AfterTargets="SetupProductFilePaths" />
  <UsingTask TaskName="ILTransformTask" AssemblyFile="$(ToolsPath)\ILTransforms\Microsoft.Build.ILTasks.dll" />
  <Target Name="FxTransforms" Condition="'$(RunFxTransforms)'=='true'" DependsOnTargets="$(FxTransformsDependsOn)" />
  <Target Name="FxTransforms_InitializeProperties">
    <PropertyGroup>
      <AssemblyToFxTransform>$(ProductOutputFile)</AssemblyToFxTransform>
      <AssemblyToFxTransformSymbols>$(ProductOutputPdb)</AssemblyToFxTransformSymbols>
      <IntermediatePreFxTransformPath>$(IntermediateOutputPath)PreFxTransformed\</IntermediatePreFxTransformPath>
      <IntermediatePostFxTransformPath>$(IntermediateOutputPath)PostFxTransformed\</IntermediatePostFxTransformPath>
      <PreFxTransformAssembly>$(IntermediatePreFxTransformPath)$(TargetName)$(TargetExt)</PreFxTransformAssembly>
      <PreFxTransformAssemblySymbols>$(IntermediatePreFxTransformPath)$(TargetName).pdb</PreFxTransformAssemblySymbols>
      <PostFxTransformAssembly>$(IntermediatePostFxTransformPath)$(TargetName)$(TargetExt)</PostFxTransformAssembly>
      <PostFxTransformAssemblySymbols>$(IntermediatePostFxTransformPath)$(TargetName).pdb</PostFxTransformAssemblySymbols>
    </PropertyGroup>
    <!--
      Adding an assembly to this list disables the BlockReflection transform, allowing apps to open up everything in your assembly
      (private or public) to app Reflection. Only for use by OOB libraries.

      This list will eventually be automatically populated once we have a central mechanism for marking libraries as OOB.
    -->
    <ItemGroup>
      <ReflectionBlockOptOut Include="System.IO.FileSystem" />
      <ReflectionBlockOptOut Include="System.Diagnostics.Tracing" />
    </ItemGroup>
    <PropertyGroup>
      <!-- Compute the LibPaths parameter to ILTransformTask -->
      <FxTransformsLibPaths>$(IntermediatePreFxTransformPath);$(OutputRootPath)\ref\ProjectN\</FxTransformsLibPaths>
      <!-- Compute the CoreAssemblyName parameter to ILTransformTask -->
      <FxTransformCoreAssemblyName Condition="'$(FxTransformCoreAssemblyName)' == ''">System.Runtime</FxTransformCoreAssemblyName>
      <ReflectionBlockApiListsDirectory>$(MSBuildThisFileDirectory)\..\src\ReflectionBlockApiLists\</ReflectionBlockApiListsDirectory>
      <RunReflectionApiBlockTransform Condition="'$(IsProjectNLibrary)'=='true'">true</RunReflectionApiBlockTransform>
      <RunReflectionApiBlockTransform Condition="'%(ReflectionBlockOptOut.Identity)' == '$(AssemblyName)'">false</RunReflectionApiBlockTransform>
    </PropertyGroup>
    <Error Condition="'$(RunReflectionApiBlockTransform)'=='true'and !Exists('$(ReflectionBlockerWhiteListFile)')" Text="You need to build $(ReflectionBlockApiListsDirectory)ReflectionBlockWhiteList.proj to get the whitelist '$(ReflectionBlockerWhiteListFile)' before trying run transforms on this library." />
    <Error Condition="!Exists('$(EnlistmentRootPath)InternalApis\FxCore\inc\Whitelist\Whitelist.WindowsStore.txt')" Text="You need to add InternalApis\FxCore\inc\* to your enlistment mappings." />
  </Target>
  <Target Name="FxTransforms_CopyToIntermediate">
    <MakeDir Directories="$(IntermediatePreFxTransformPath);$(IntermediatePostFxTransformPath)" />
    <!-- Copy the file we want to transform into a subdir -->
    <Copy SourceFiles="$(AssemblyToFxTransform);$(AssemblyToFxTransformSymbols)" DestinationFolder="$(IntermediatePreFxTransformPath)" SkipUnchangedFiles="true" />
  </Target>
  <Target Name="FxTransforms_Core" Inputs="$(PreFxTransformAssembly)" Outputs="$(PostFxTransformAssembly)">
    <ItemGroup>
      <!-- Annotate the Fx libraries with [__BlockReflectionAttribute] for Project N consumption -->
      <FxTransform Condition="'$(RunReflectionApiBlockTransform)'=='true'" Include="ReflectionApiBlock">
        <ExternallyBrowsables>$(ReflectionBlockerWhiteListFile);$(ReflectionBlockApiListsDirectory)NonWin8pWhitelist.txt</ExternallyBrowsables>
        <InternallyBrowsables>$(ReflectionBlockApiListsDirectory)InternalReflectionWhiteList.txt</InternallyBrowsables>
        <Uninvokables>$(ReflectionBlockApiListsDirectory)excludelist.txt</Uninvokables>
        <ExemptFromSignatureBasedBans>$(ReflectionBlockApiListsDirectory)unsafewhitelist.txt</ExemptFromSignatureBasedBans>
        <LogFile>$(IntermediateOutputPath)ReflectionBlock.log</LogFile>
      </FxTransform>
    </ItemGroup>
    <!-- Read in the moved file and output transformed file to the original location -->
    <ILTransformTask InputAssembly="$(PreFxTransformAssembly)" OutputAssembly="$(PostFxTransformAssembly)" ILTransforms="@(FxTransform)" CoreAssemblyName="$(FxTransformCoreAssemblyName)" LibPaths="$(FxTransformsLibPaths)" DeepCopyAssembly="True" />
    <!-- Copy the updated assembly back -->
    <Copy SourceFiles="$(PostFxTransformAssembly);$(PostFxTransformAssemblySymbols)" DestinationFiles="$(AssemblyToFxTransform);$(AssemblyToFxTransformSymbols)" SkipUnchangedFiles="true" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="contract.support.targets">

E:\ProjectK\src\NDP\FxCore\src\Packages\contract.support.targets
============================================================================================================================================
-->
  <ItemGroup>
    <ProjectN_ContractAssembly Include="System.Console">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <Desktop461_ContractAssembly Include="System.Diagnostics.Process">
      <Version>4.1.0.0</Version>
    </Desktop461_ContractAssembly>
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(EnlistmentRootPath)ExternalApis\NetFX\Contracts\TargetFrameworks\ProjectK.settings.targets">

E:\ProjectK\src\ExternalApis\NetFX\Contracts\TargetFrameworks\ProjectK.settings.targets
============================================================================================================================================
-->
  <!--
    This file is intended to contain the set of supported contracts and their versions for a given product.  
    It is shared between the tests and the product builds and should only contain things that are common to both
    if one side needs to override or provide additional contracts (i.e. internal) or properties they should go in
    the file importing this file not this file itself.
  -->
  <!-- Set of public Contracts -->
  <ItemGroup>
    <ProjectK_ContractAssembly Include="Microsoft.Win32.Registry">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="Microsoft.Win32.Registry.AccessControl">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="Microsoft.Win32.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.AppContext">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.Loader">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.DispatchProxy">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.TypeExtensions">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="Microsoft.CSharp">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="Microsoft.VisualBasic">
      <Version>10.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Collections">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Collections.Concurrent">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Collections.NonGeneric">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Collections.Specialized">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ComponentModel">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ComponentModel.Annotations">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ComponentModel.EventBasedAsync">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ComponentModel.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ComponentModel.TypeConverter">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Console">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Data.Common">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Data.SqlClient">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.Contracts">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.Debug">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.FileVersionInfo">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.Process">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.StackTrace">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.Tools">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.TraceSource">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.TextWriterTraceListener">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Diagnostics.Tracing">
      <Version>4.0.21.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Dynamic.Runtime">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Globalization">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Globalization.Calendars">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Globalization.Extensions">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.Compression">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.Compression.ZipFile">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.FileSystem">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.FileSystem.AccessControl">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.FileSystem.DriveInfo">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.FileSystem.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.FileSystem.Watcher">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.MemoryMappedFiles">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.Pipes">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.IO.UnmanagedMemoryStream">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Linq">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Linq.Expressions">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Linq.Parallel">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Linq.Queryable">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Http">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Http.WinHttpHandler" Condition="'$(OSGroup)' == '' or '$(OSGroup)' == 'Windows_NT'">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.NameResolution">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.NetworkInformation">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Primitives">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Requests">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Security">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Sockets">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.Utilities">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.WebHeaderCollection">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.WebSockets">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Net.WebSockets.Client">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Numerics.Vectors">
      <Version>4.1.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ObjectModel">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.Emit">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.Emit.ILGeneration">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.Emit.Lightweight">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.Extensions">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Reflection.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Resources.ResourceManager">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Resources.ReaderWriter">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime">
      <Version>4.0.21.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.Extensions">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.Handles">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.InteropServices">
      <Version>4.0.21.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.InteropServices.RuntimeInformation">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.Numerics">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.Serialization.Json">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Runtime.CompilerServices.VisualC">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.AccessControl">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Claims">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.Algorithms">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.Cng">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.Csp">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.Encoding">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.Primitives">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Cryptography.X509Certificates">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Principal">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.Principal.Windows">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Security.SecureString">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceModel.Duplex">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceModel.Http">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceModel.NetTcp">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceModel.Primitives">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceModel.Security">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.ServiceProcess.ServiceController">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Text.Encoding">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Text.Encoding.CodePages">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Text.Encoding.Extensions">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Text.RegularExpressions">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.AccessControl">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.Overlapped">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.ThreadPool">
      <Version>4.0.10.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.Thread">
      <Version>4.0.0.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.Tasks">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.Tasks.Parallel">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Threading.Timer">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.ReaderWriter">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XDocument">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XmlSerializer">
      <Version>4.0.11.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XmlDocument">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XPath">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XPath.XDocument">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
    <ProjectK_ContractAssembly Include="System.Xml.XPath.XmlDocument">
      <Version>4.0.1.0</Version>
    </ProjectK_ContractAssembly>
  </ItemGroup>
  <ItemGroup>
    <ProjectK_ContractAssembly_ExcludeFromTestNet Include="System.Runtime.Serialization.Primitives">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly_ExcludeFromTestNet>
    <ProjectK_ContractAssembly_ExcludeFromTestNet Include="System.Runtime.Serialization.Xml">
      <Version>4.1.0.0</Version>
    </ProjectK_ContractAssembly_ExcludeFromTestNet>
  </ItemGroup>
  <!-- Set of supported design time facades -->
  <ItemGroup>
    <!-- Not supported design-time facades -->
    <!--
    <ProjectK_DesignTimeFacade Include="mscorlib" />
    <ProjectK_DesignTimeFacade Include="System.Core" />
    <ProjectK_DesignTimeFacade Include="System" />
    <ProjectK_DesignTimeFacade Include="System.Net" />
    <ProjectK_DesignTimeFacade Include="System.Numerics" />
    <ProjectK_DesignTimeFacade Include="System.Runtime.Serialization" />
    <ProjectK_DesignTimeFacade Include="System.Windows" />
    <ProjectK_DesignTimeFacade Include="System.Xml" />
    <ProjectK_DesignTimeFacade Include="System.Xml.Linq" />
    <ProjectK_DesignTimeFacade Include="System.Xml.Serialization" />
    <ProjectK_DesignTimeFacade Include="System.ServiceModel" />
    <ProjectK_DesignTimeFacade Include="System.ServiceModel.Web" />
    <ProjectK_DesignTimeFacade Include="System.ComponentModel.DataAnnotations" />
-->
  </ItemGroup>
  <ItemGroup>
    <ContractAssembly Include="@(ProjectK_ContractAssembly)">
      <Platform>ProjectK</Platform>
    </ContractAssembly>
    <ContractAssembly Include="@(ProjectK_ContractAssembly_ExcludeFromTestNet)">
      <Platform>ProjectK</Platform>
    </ContractAssembly>
    <DesignTimeFacade Include="@(ProjectK_DesignTimeFacade)">
      <Platform>ProjectK</Platform>
    </DesignTimeFacade>
  </ItemGroup>
  <PropertyGroup>
    <!-- Given that TestNet is sharing this settings file this property is ued to ensure this file isn't imported more than once -->
    <ProjectKSettingsTargetsImported>true</ProjectKSettingsTargetsImported>
  </PropertyGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(EnlistmentRootPath)ExternalApis\NetFX\Contracts\TargetFrameworks\ProjectN.settings.targets">

E:\ProjectK\src\ExternalApis\NetFX\Contracts\TargetFrameworks\ProjectN.settings.targets
============================================================================================================================================
-->
  <!--
    This file is intended to contain the set of supported contracts and their versions for a given product.  
    It is shared between the tests and the product builds and should only contain things that are common to both
    if one side needs to override or provide additional contracts (i.e. internal) or properties they should go in
    the file importing this file not this file itself.
  -->
  <!-- Set of public Contracts -->
  <ItemGroup>
    <ProjectN_ContractAssembly Include="Microsoft.CSharp">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="Microsoft.VisualBasic">
      <Version>10.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="Microsoft.Win32.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.AppContext">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Collections.Concurrent">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Collections">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Collections.NonGeneric">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Collections.Specialized">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ComponentModel">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ComponentModel.Annotations">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ComponentModel.EventBasedAsync">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ComponentModel.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ComponentModel.TypeConverter">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Data.Common">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Diagnostics.Contracts">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Diagnostics.Debug">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Diagnostics.StackTrace">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Diagnostics.Tools">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Diagnostics.Tracing">
      <Version>4.0.21.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Dynamic.Runtime">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Globalization">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Globalization.Calendars">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Globalization.Extensions">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.Compression">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.Compression.ZipFile">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.FileSystem.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.FileSystem">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.UnmanagedMemoryStream">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Linq">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Linq.Expressions">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Linq.Queryable">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Linq.Parallel">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.Http">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.Http.Rtc">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.NetworkInformation">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.Primitives">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.Requests">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.Sockets">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.WebHeaderCollection">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.WebSockets">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Net.WebSockets.Client">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Numerics.Vectors">
      <Version>4.1.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ObjectModel">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.Context">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.DispatchProxy">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.Extensions">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.Primitives">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.TypeExtensions">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Resources.ResourceManager">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime">
      <Version>4.0.21.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Extensions">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.InteropServices">
      <Version>4.0.21.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.InteropServices.RuntimeInformation">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.InteropServices.WindowsRuntime">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Handles">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Numerics">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Serialization.Json">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Serialization.Primitives">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.Serialization.Xml">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.WindowsRuntime">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Runtime.WindowsRuntime.UI.Xaml">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Claims">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Cryptography.Algorithms">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Cryptography.Cng">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Cryptography.Encoding">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Cryptography.Primitives">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Cryptography.X509Certificates">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Security.Principal">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ServiceModel.Duplex">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ServiceModel.Http">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ServiceModel.NetTcp">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ServiceModel.Primitives">
      <Version>4.1.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.ServiceModel.Security">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Text.Encoding">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Text.Encoding.CodePages">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Text.Encoding.Extensions">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Text.RegularExpressions">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Threading">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Threading.Tasks">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Threading.Tasks.Parallel">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Threading.Timer">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Threading.Overlapped">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.ReaderWriter">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XDocument">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XmlDocument">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XmlSerializer">
      <Version>4.0.11.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XPath">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XPath.XDocument">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Xml.XPath.XmlDocument">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.IO.IsolatedStorage">
      <Version>4.0.1.0</Version>
    </ProjectN_ContractAssembly>
    <!-- Not supported contracts -->
    <!--
    <ProjectN_ContractAssembly Include="Microsoft.VisualBasic">
      <Version>10.0.0.0</Version>
    </ProjectN_ContractAssembly>
    <ProjectN_ContractAssembly Include="System.Reflection.Context">
      <Version>4.0.0.0</Version>
    </ProjectN_ContractAssembly>
-->
  </ItemGroup>
  <!-- Set of design-time facades that are supported by ProjectN and should be in the targeting pack -->
  <ItemGroup>
    <ProjectN_DesignTimeFacade Include="mscorlib" />
    <ProjectN_DesignTimeFacade Include="System.Core" />
    <ProjectN_DesignTimeFacade Include="System" />
    <ProjectN_DesignTimeFacade Include="System.Net" />
    <ProjectN_DesignTimeFacade Include="System.Numerics" />
    <ProjectN_DesignTimeFacade Include="System.Runtime.Serialization" />
    <ProjectN_DesignTimeFacade Include="System.Windows" />
    <ProjectN_DesignTimeFacade Include="System.Xml" />
    <ProjectN_DesignTimeFacade Include="System.Xml.Linq" />
    <ProjectN_DesignTimeFacade Include="System.Xml.Serialization" />
    <ProjectN_DesignTimeFacade Include="System.ComponentModel.DataAnnotations" />
    <ProjectN_DesignTimeFacade Include="System.ServiceModel" />
    <ProjectN_DesignTimeFacade Include="System.ServiceModel.Web" />
  </ItemGroup>
  <ItemGroup>
    <ContractAssembly Include="@(ProjectN_ContractAssembly)">
      <Platform>ProjectN</Platform>
    </ContractAssembly>
    <DesignTimeFacade Include="@(ProjectN_DesignTimeFacade)">
      <Platform>ProjectN</Platform>
    </DesignTimeFacade>
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="$(EnlistmentRootPath)ExternalApis\NetFX\Contracts\TargetFrameworks\Desktop.settings.targets">

E:\ProjectK\src\ExternalApis\NetFX\Contracts\TargetFrameworks\Desktop.settings.targets
============================================================================================================================================
-->
  <!-- Set of public Contracts -->
  <ItemGroup>
    <Desktop_ContractAssembly Include="Microsoft.CSharp">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="Microsoft.Win32.Registry">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="Microsoft.Win32.Registry.AccessControl">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="Microsoft.Win32.Primitives">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="Microsoft.VisualBasic">
      <Version>10.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.AppContext">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.TypeExtensions">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Collections">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Collections.Concurrent">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Collections.NonGeneric">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Collections.Specialized">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ComponentModel">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ComponentModel.Annotations">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ComponentModel.EventBasedAsync">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ComponentModel.Primitives">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ComponentModel.TypeConverter">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Console">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Data.Common">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Data.SqlClient">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.Contracts">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.Debug">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.FileVersionInfo">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.Process">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.StackTrace">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.Tools">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.TraceSource">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.TextWriterTraceListener">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Diagnostics.Tracing">
      <Version>4.0.21.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Dynamic.Runtime">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Globalization">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Globalization.Calendars">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Globalization.Extensions">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.Compression">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.Compression.ZipFile">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.FileSystem">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.FileSystem.AccessControl">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.FileSystem.DriveInfo">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.FileSystem.Primitives">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.FileSystem.Watcher">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.MemoryMappedFiles">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.Pipes">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.IO.UnmanagedMemoryStream">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Linq">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Linq.Expressions">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Linq.Parallel">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Linq.Queryable">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Http">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Http.WinHttpHandler">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.NameResolution">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.NetworkInformation">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Primitives">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Requests">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Security">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Sockets">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.Utilities">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.WebHeaderCollection">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.WebSockets">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Net.WebSockets.Client">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Numerics.Vectors">
      <Version>4.1.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ObjectModel">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Context">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.DispatchProxy">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Emit">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Emit.ILGeneration">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Emit.Lightweight">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Extensions">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Reflection.Primitives">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Resources.ResourceManager">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Resources.ReaderWriter">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime">
      <Version>4.0.21.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.CompilerServices.VisualC">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Extensions">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Handles">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.InteropServices">
      <Version>4.0.21.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.InteropServices.RuntimeInformation">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.InteropServices.WindowsRuntime">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Numerics">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Serialization.Json">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Serialization.Primitives">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.Serialization.Xml">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.WindowsRuntime">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Runtime.WindowsRuntime.UI.Xaml">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.AccessControl">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Claims">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.Algorithms">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.Cng">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.Csp">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.Encoding">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.Primitives">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Cryptography.X509Certificates">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Principal">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.Principal.Windows">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Security.SecureString">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceModel.Duplex">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceModel.Http">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceModel.NetTcp">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceModel.Primitives">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceModel.Security">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.ServiceProcess.ServiceController">
      <Version>4.1.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Text.Encoding">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Text.Encoding.CodePages">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Text.Encoding.Extensions">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Text.RegularExpressions">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.AccessControl">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.Overlapped">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.ThreadPool">
      <Version>4.0.10.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.Thread">
      <Version>4.0.0.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.Tasks">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.Tasks.Parallel">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Threading.Timer">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.ReaderWriter">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XDocument">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XmlSerializer">
      <Version>4.0.11.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XmlDocument">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XPath">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XPath.XDocument">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
    <Desktop_ContractAssembly Include="System.Xml.XPath.XmlDocument">
      <Version>4.0.1.0</Version>
    </Desktop_ContractAssembly>
  </ItemGroup>
  <ItemGroup>
    <ContractAssembly Include="@(Desktop_ContractAssembly)">
      <Platform>Desktop</Platform>
    </ContractAssembly>
  </ItemGroup>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <!--
============================================================================================================================================
  <Import Project="stable.packages.targets">

E:\ProjectK\src\NDP\FxCore\src\Packages\stable.packages.targets
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

E:\ProjectK\src\NDP\FxCore\src\Packages\Packaging.targets
============================================================================================================================================
-->
  <PropertyGroup>
    <VersionSuffix Condition="'$(PreReleaseLabel)' != ''">-$(PreReleaseLabel)</VersionSuffix>
    <VersionSuffix Condition="'$(IncludeBuildNumberInPackageVersion)' == 'true'">$(VersionSuffix)-$(BuildNumberMajor)</VersionSuffix>
    <!-- 
      Empty out the project properties because we want configuration and platform to come from the individual
      projects instead of being overridden by the value the packages have.
    -->
    <ProjectProperties />
  </PropertyGroup>
  <UsingTask TaskName="ApplyPreReleaseSuffix" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="GetAssemblyReferences" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="GenerateRuntimeDependencies" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="GetPackageDescription" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="GetInboxFrameworks" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="GetPackageVersion" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="EnsureOOBFramework" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="ValidatePackage" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <UsingTask TaskName="CreateTrimDependencyGroups" AssemblyFile="$(ToolsPath)\CoreFx.Build.Packaging.Tasks\CoreFx.Build.Packaging.Tasks.dll" />
  <!-- Shared properties -->
  <PropertyGroup>
    <OutputPath>$(FxOutputPath)Manifests\</OutputPath>
    <NuSpecPath>$(OutputPath)$(Id)$(NuspecSuffix).nuspec</NuSpecPath>
    <PlaceholderFile>$(MSBuildThisFileDirectory)_._</PlaceholderFile>
    <PackageDescriptionFile>$(MSBuildThisFileDirectory)descriptions.json</PackageDescriptionFile>
    <RuntimeIdGraphDefinitionFile>$(OpenPackagesPath)\Microsoft.NETCore.Platforms\Runtime.json</RuntimeIdGraphDefinitionFile>
    <GenerationDefinitionFile>$(ToolsPath)\CoreFx.Build.Packaging.Tasks\Generations.json</GenerationDefinitionFile>
    <ValidationSuppressionFile>ValidationSuppression.txt</ValidationSuppressionFile>
    <ValidationReferencePath>$(ContractOutputPath);$(PackagesDir);$(FxLibraryOutputPath)</ValidationReferencePath>
  </PropertyGroup>
  <!-- Don't build project references, we build all projects anyway and nuproj targets were having trouble
       with multiple nodes building the same project at the same time. -->
  <PropertyGroup>
    <BuildProjectReferences>false</BuildProjectReferences>
  </PropertyGroup>
  <!-- Determine if we actually need to build for this architecture -->
  <!-- Packages can specifically control their architecture by specifying the PackagePlatforms 
       property as a semi-colon delimited list.
       If this is not done then the package will build if the target runtime contains the current
       architecture or if we're building for x86. -->
  <PropertyGroup>
    <!-- build if the package specifically requests current architecture via PackagePlatforms -->
    <ShouldGenerateNuSpec Condition="$(PackagePlatforms.Contains('$(PackagePlatform);'))">true</ShouldGenerateNuSpec>
    <!-- build if PackagePlatforms is not specified and the PackageTargetRuntime contains the current architecture -->
    <ShouldGenerateNuSpec Condition="'$(PackagePlatforms)' == '' AND $(PackageTargetRuntime.Contains('-$(PackagePlatform)'))">true</ShouldGenerateNuSpec>
    <!-- build if PackagePlatforms is not specified and arch is x86 -->
    <ShouldGenerateNuSpec Condition="'$(PackagePlatforms)' == '' AND '$(PackagePlatform)' == 'x86'">true</ShouldGenerateNuSpec>
    <BuildDependsOn Condition="'$(ShouldGenerateNuSpec)' == 'true'">GenerateNuSpec</BuildDependsOn>
  </PropertyGroup>
  <!-- Redefine build to just create the NuSpec only, we'll create the package during ArcProjects phase -->
  <Target Name="Build" DependsOnTargets="$(BuildDependsOn)">
    <Message Text="$(MSBuildProjectName) -&gt; $(NuGetOutputPath)" Importance="high" />
  </Target>
  <!-- Native dependencies do not have a target framework set, here we gather the 
       native dependencies so that we can batch on TFM later and add these to each
       TFM group. -->
  <Target Name="GatherNativeDependencies" BeforeTargets="AddNativeDependenciesToDependencyGroups">
    <ItemGroup>
      <NativeDependency Condition="'%(Dependency.TargetFramework)' == ''" Include="@(Dependency)" />
    </ItemGroup>
  </Target>
  <!-- Add the native dependencies to each dependency TFM -->
  <Target Name="AddNativeDependenciesToDependencyGroups" BeforeTargets="GenerateNuSpec" Inputs="%(Dependency.TargetFramework)" Outputs="fake">
    <PropertyGroup>
      <_AddTargetFramework>%(Dependency.TargetFramework)</_AddTargetFramework>
    </PropertyGroup>
    <ItemGroup>
      <!-- Remove the dependencies which do not have a TargetFramework set -->
      <Dependency Remove="@(NativeDependency)" />
    </ItemGroup>
    <ItemGroup>
      <!-- Add native dependencies to each TFM dependency group -->
      <Dependency Include="@(NativeDependency)" Condition="'$(_AddTargetFramework)' != ''">
        <TargetFramework>$(_AddTargetFramework)</TargetFramework>
      </Dependency>
    </ItemGroup>
    <CreateItem Include="@(NuProjDependency)" />
  </Target>
  <Target Name="AddProjectReferenceProperties" BeforeTargets="_NuProjGetProjectClosure">
    <ItemGroup>
      <!-- list each append as a seperate item to force re-evaluation of AdditionalProperties metadata -->
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
      <ProjectReference>
        <AdditionalProperties Condition="'%(ProjectReference.Extension)' == '.proj'">FacadeAssemblyName=$(BaseId);%(ProjectReference.AdditionalProperties)</AdditionalProperties>
      </ProjectReference>
    </ItemGroup>
  </Target>
  <!-- Override the NuProj version -->
  <Target Name="ExpandProjectReferences" DependsOnTargets="SplitProjectReferences">
    <MSBuild Targets="GetFilesToPackage" BuildInParallel="$(BuildInParallel)" Projects="@(_NonNuProjProjectReference)" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_FilesToPackage" />
    </MSBuild>
    <ItemGroup>
      <File Include="@(_FilesToPackage)">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
        <!-- Some packages support legacy portable profiles where dependencies are provided by targeting pack -->
        <HarvestDependencies Condition="!$([System.String]::new('%(_FilesToPackage.TargetFramework)').StartsWith('portable-'))">true</HarvestDependencies>
      </File>
    </ItemGroup>
    <Error Condition="'$(SkipPackageFileCheck)' != 'true' AND&#xD;&#xA;                      '%(File.SkipPackageFileCheck)' != 'true' AND&#xD;&#xA;                      '%(File.FileName)' != '_' AND&#xD;&#xA;                      '%(File.FileName)%(File.Extension)' != 'runtime.json' AND&#xD;&#xA;                      !$(ID.Contains('%(File.FileName)'))" Text="Package $(ID) contains file with name %(File.FileName).  If this is expected you can disable this filename checking for this item or package by setting SkipPackageFileCheck = true" ContinueOnError="ErrorAndContinue" />
  </Target>
  <!-- Override the NuProj version  to permit setting TargetFramework-->
  <Target Name="GetPackageIdentity" Returns="@(_PackageIdentity)" DependsOnTargets="$(VersionDependsOn)">
    <ItemGroup>
      <_PackageIdentity Include="$(Id)">
        <Version>$(Version)</Version>
        <TargetFramework Condition="'$(PackageTargetFramework)' != ''">$(PackageTargetFramework)</TargetFramework>
        <TargetRuntime Condition="'$(PackageTargetRuntime)' != ''">$(PackageTargetRuntime)</TargetRuntime>
        <!-- If PackageTargetRuntime is set this package may be providing implementation assemblies to the parent package -->
        <ValidationCandidateTargetPaths Condition="'$(PackageTargetRuntime)' != ''">@(File->'%(TargetPath)/%(FileName)%(Extension)')</ValidationCandidateTargetPaths>
      </_PackageIdentity>
    </ItemGroup>
  </Target>
  <!-- Override the NuProj version.  Don't actually walk the closure all the time.  We don't use any of the 
       asset -> package mapping logic from nuproj so we don't need the full set of packages.  -->
  <Target Name="_NuProjGetProjectClosure" Returns="@(_ProjectReferenceClosure)">
    <!-- Get closure of indirect references if they opt-in -->
    <MSBuild Projects="@(ProjectReference)" Targets="_NuProjGetProjectClosure" Properties="$(ProjectProperties)" ContinueOnError="WarnAndContinue" BuildInParallel="$(BuildInParallel)" Condition="'%(ProjectReference.GetClosure)' == 'true'">
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
  <!-- Override the NuProj version.  Don't infer TFM from files.  Instead allow explicit definition of TFM by projects/references.-->
  <Target Name="AssignNuProjPackageDependenciesTargetFramework" DependsOnTargets="GetNuProjPackageDependencies;GetFiles">
    <ItemGroup>
      <!-- ensure that unconstrained dependencies are also expanded in constrained TFM groups -->
      <_NuProjDependencyWithoutTFM Include="@(NuProjDependency)" Condition="'%(NuProjDependency.TargetFramework)' == '' AND '%(NuProjDependency.DoNotExpand)' != 'true'" />
      <_AllNuProjTFMs Include="%(NuProjDependency.TargetFramework)" Condition="'%(NuProjDependency.DependencyKind)' == 'Direct'" />
      <!-- operate on nuproj dependencies and file dependencies -->
      <NuProjDependency Include="@(_NuProjDependencyWithoutTFM)">
        <TargetFramework>%(_AllNuProjTFMs.Identity)</TargetFramework>
      </NuProjDependency>
    </ItemGroup>
    <Message Text="_AllNuProjTFMs: @(_AllNuProjTFMs)" />
    <CreateItem Include="@(NuProjDependency)" />
    <CreateItem Include="@(File)" />
  </Target>
  <!-- Override the NuProj version.  Don't do any filtering. 
       We explicitly determine package content so we do not need to
     filter out files that come from dependent packages. -->
  <Target Name="GetPackageFiles" Returns="@(PackageFile)" DependsOnTargets="GetFiles;$(VersionDependsOn)">
    <ItemGroup>
      <PackageFile Include="@(File)" />
      <PackageFile Condition="'%(PackageFile.NuProjPackageId)' == ''">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
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
  <Target Name="DetermineFileDependencies" AfterTargets="EnsureOOBFramework" Condition="'$(OmitDependencies)' != 'true'" Inputs="%(File.Identity);%(File.TargetFramework)" Outputs="fake">
    <!-- nuproj's GetNuGetPackageDependencies will resolve packages from packages.config of dependencies,
         but our current build uses references -->
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
  <!-- Calculates the package version for output in the nuspec -->
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
  <Target Name="PinDependencies" DependsOnTargets="GetPackageDependencies" BeforeTargets="GenerateRuntimeDependencies">
    <ItemGroup>
      <DependenciesToPin Include="@(Dependency)" Condition="'@(PinDependency)' == '%(Identity)'" />
      <Dependency Remove="@(DependenciesToPin)" />
      <Dependency Include="@(DependenciesToPin)">
        <Version>[%(DependenciesToPin.Version)]</Version>
      </Dependency>
    </ItemGroup>
  </Target>
  <Target Name="DetermineRuntimeDependencies" DependsOnTargets="PinDependencies" Returns="@(RuntimeDependency)" BeforeTargets="GetPackageFiles">
    <!-- see if we have any runtime dependencies to write to runtime.json -->
    <ItemGroup>
      <RuntimeDependency Condition="'%(Dependency.TargetRuntime)' != ''" Include="@(Dependency)" />
      <!-- don't include runtime depdendencies in the dependency list, they'll be written to the runtime.json -->
      <Dependency Remove="@(RuntimeDependency)" />
    </ItemGroup>
    <Error Text="Packages that are constrained by runtime should not have runtime dependencies.  They will be ignored by nuget" Condition="'$(PackageTargetRuntime)' != '' AND '@(RuntimeDependency)' != ''" ContinueOnError="ErrorAndContinue" />
    <!-- determine if there is a file to be updated, and setup the output file -->
    <PropertyGroup>
      <RuntimeFileSource Condition="'%(File.FileName)%(File.Extension)' == 'runtime.json'">%(File.Identity)</RuntimeFileSource>
      <RuntimeFileDest Condition="'$(RuntimeFileDest)' == ''">$(OutputPath)$(Id)$(NuspecSuffix)\runtime.json</RuntimeFileDest>
    </PropertyGroup>
    <ItemGroup Condition="'@(RuntimeDependency)' != ''">
      <!-- if we are updating, remove it from the file group, we'll replace it with the generated version -->
      <File Condition="'$(RuntimeFileSource)' != ''" Remove="$(RuntimeFileSource)" />
      <File Include="$(RuntimeFileDest)">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
        <IsLibrary>false</IsLibrary>
      </File>
    </ItemGroup>
  </Target>
  <Target Name="EnsureEmptyPackage" BeforeTargets="GetPackageFiles">
    <!-- Nuget will include all files when nuspec is empty, ensure we have at least one file to avoid that -->
    <ItemGroup Condition="'@(File)' == ''">
      <File Include="$(PlaceholderFile)">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
        <IsLibrary>false</IsLibrary>
      </File>
    </ItemGroup>
  </Target>
  <!-- If the "PreventImplementationReference" property is true, then don't permit references to the 
    package implementation from lib.  This is used in the platform specific packages which should
    not be directly referenced by projects for implemtation dependencies. -->
  <Target Name="PreventImplementationReference" BeforeTargets="EnsureEmptyPackage">
    <ItemGroup Condition="'$(PreventImplementationReference)' == 'true'">
      <File Include="$(PlaceholderFile)">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
        <TargetPath>ref/dotnet</TargetPath>
      </File>
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
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
        <TargetPath Condition="'$(_targetRuntime)' != ''">runtimes/$(_targetRuntime)/lib/$(_target)</TargetPath>
        <TargetPath Condition="'$(_targetRuntime)' == ''">lib/$(_target)</TargetPath>
      </File>
      <File Include="$(PlaceholderFile)" Condition="'$(_targetRef)' == 'true'">
        <NuProjPackageId>$(Id)</NuProjPackageId>
        <NuProjPackageVersion>$(Version)</NuProjPackageVersion>
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
  <ItemGroup>
    <OutOfBoxFramework Include="netcore50" />
  </ItemGroup>
  <Target Name="EnsureOOBFramework" AfterTargets="AddPlaceholders">
    <EnsureOOBFramework Condition="'@(OutOfBoxFramework)' != ''" OOBFrameworks="@(OutOfBoxFramework)" Files="@(File)" RuntimeJson="$(RuntimeIdGraphDefinitionFile)" RuntimeId="$(PackageTargetRuntime)">
      <Output TaskParameter="AdditionalFiles" ItemName="File" />
    </EnsureOOBFramework>
  </Target>
  <Target Name="TrimInboxDependencies" BeforeTargets="GatherNativeDependencies" Condition="'$(PackageTargetRuntime)' == ''">
    <CreateTrimDependencyGroups Dependencies="@(Dependency)" GenerationDefinitionsFile="$(GenerationDefinitionFile)" FrameworkListsPath="$(MSBuildThisFileDirectory)../../../../ExternalApis/NetFX/Contracts/FrameworkLists" TrimFrameworks="@(InboxOnTargetFramework);@(NotSupportedOnTargetFramework);@(ExternalOnTargetFramework)" Files="@(File)" Condition="'@(Dependency)' != ''">
      <Output TaskParameter="TrimmedDependencies" ItemName="TrimmedDependency" />
    </CreateTrimDependencyGroups>
    <ItemGroup>
      <Dependency Include="@(TrimmedDependency)" />
    </ItemGroup>
  </Target>
  <!-- Generates a runtime.json file containing all dependencies with TargetPlatform-->
  <Target Name="GenerateRuntimeDependencies" DependsOnTargets="DetermineRuntimeDependencies" Condition="'@(RuntimeDependency)' != ''" BeforeTargets="GenerateNuspec">
    <!-- Lineups need to have all runtime dependencies to ensure that they are part of the compile graph -->
    <MSBuild Projects="@(ProjectReference)" Targets="DetermineRuntimeDependencies" Condition="'$(IsLineupPackage)' == 'true'" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="_indirectRuntimeDependencies" />
    </MSBuild>
    <!-- pass both RuntimeDependencies and regular dependencies.
         Only RuntimeDependencies will be generated, but Dependencies are required
         since they may be the target of a RuntimeDependency -->
    <GenerateRuntimeDependencies Dependencies="@(RuntimeDependency);@(Dependency);@(_indirectRuntimeDependencies)" PackageId="$(Id)" RuntimeJsonTemplate="$(RuntimeFileSource)" RuntimeJson="$(RuntimeFileDest)" EnsureBase="$(IsLineupPackage)" />
  </Target>
  <!-- The SyncInfoFile gets created by ndp\fxcore\tools\LogVersionInfoForBuild\LogVersionInfoForBuild.proj during
       build.  -->
  <PropertyGroup>
    <SyncInfoFile Condition="'$(SyncInfoFile)' == ''">$(_NTTREE)\OpenCoreFxSyncInfo.txt</SyncInfoFile>
  </PropertyGroup>
  <Target Name="GetSyncInfo" BeforeTargets="GetPackageDescription" Condition="Exists('$(SyncInfoFile)')">
    <ReadLinesFromFile File="$(SyncInfoFile)">
      <Output TaskParameter="Lines" ItemName="SyncInfoLines" />
    </ReadLinesFromFile>
  </Target>
  <Target Name="GetPackageDescription" BeforeTargets="GenerateNuspec">
    <GetPackageDescription DescriptionFile="$(PackageDescriptionFile)" PackageId="$(BaseId)">
      <Output TaskParameter="Description" PropertyName="Description" />
    </GetPackageDescription>
    <GetPackageDescription DescriptionFile="$(PackageDescriptionFile)" Condition="'$(PackageTargetRuntime)' != ''" PackageId="RuntimePackage">
      <Output TaskParameter="Description" PropertyName="RuntimeDisclaimer" />
    </GetPackageDescription>
    <PropertyGroup>
      <Description Condition="'$(RuntimeDisclaimer)' != ''">$(RuntimeDisclaimer) \r\n $(Description)</Description>
      <Description Condition="'@(SyncInfoLines)' != ''">$(Description) \r\n %(SyncInfoLines.Identity)</Description>
    </PropertyGroup>
  </Target>
  <!-- Walks every project gathering its AssemblyVersion, making sure that they all agree -->
  <!-- Skipped if the package explicitly defines a version -->
  <Target Name="GetAssemblyVersionFromProjects" Condition="$(Version) == ''" DependsOnTargets="ExpandProjectReferences">
    <GetPackageVersion Files="@(File)">
      <Output TaskParameter="Version" PropertyName="_AssemblyVersion" />
    </GetPackageVersion>
    <Error Condition="'$(_AssemblyVersion)' == ''" Text="No assembly version could be determined." ContinueOnError="ErrorAndContinue" />
  </Target>
  <ItemGroup>
    <ContractAssembly Include="@(Desktop_ContractAssembly)" Exclude="@(Desktop461_ContractAssembly)">
      <Platform>Desktop461</Platform>
    </ContractAssembly>
    <ContractAssembly Include="@(Desktop461_ContractAssembly)">
      <Platform>Desktop461</Platform>
    </ContractAssembly>
  </ItemGroup>
  <ItemGroup>
    <ContractSupport Include="@(ContractAssembly)">
      <TargetFramework Condition="'%(Platform)' == 'ProjectK'">dnxcore50</TargetFramework>
      <TargetFramework Condition="'%(Platform)' == 'Desktop'">net46</TargetFramework>
      <TargetFramework Condition="'%(Platform)' == 'Desktop461'">net461</TargetFramework>
      <TargetFramework Condition="'%(Platform)' == 'ProjectN'">netcore50</TargetFramework>
    </ContractSupport>
    <ValidateFramework Include="dnxcore50">
      <!-- todo: add unix RIDs once we have appropriate support -->
      <RuntimeIDs>win7-x86;win7-x64</RuntimeIDs>
    </ValidateFramework>
    <ValidateFramework Include="netcore50">
      <RuntimeIDs>win10-x86;win10-x86-aot;win10-x64;win10-x64-aot;win10-arm;win10-arm-aot</RuntimeIDs>
    </ValidateFramework>
    <ValidateFramework Include="net46" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <!-- add additional win7 RIDs to validate up-level authoring -->
      <RuntimeIDs>win-x86;win-x64;win7-x86;win7-x64</RuntimeIDs>
    </ValidateFramework>
    <ValidateFramework Include="net461" Condition="'$(ExcludeFromDesktopSupportValidation)' != 'true'">
      <!-- add additional win7 RIDs to validate up-level authoring -->
      <RuntimeIDs>win-x86;win-x64;win7-x86;win7-x64</RuntimeIDs>
    </ValidateFramework>
  </ItemGroup>
  <PropertyGroup>
    <!-- Skip validation of runtime packages, they will be validated in the context of their reference package -->
    <SkipValidatePackage Condition="'$(SkipValidateTargetFrameworks)' == '' AND '$(PackageTargetRuntime)' != ''">true</SkipValidatePackage>
    <SkipSupportCheck Condition="'$(SkipSupportCheck)' == '' AND ($(Id.StartsWith('System.Private.')) OR $(Id.StartsWith('Microsoft.NETCore.')))">true</SkipSupportCheck>
  </PropertyGroup>
  <Target Name="ValidatePackage" DependsOnTargets="GetPackageFiles" BeforeTargets="GenerateNuspec" Condition="'$(SkipValidatePackage)' != 'true'">
    <ItemGroup>
      <RuntimeDependencyProject Include="%(RuntimeDependency.OriginalItemSpec)" KeepDuplicates="false" />
      <!-- map back to the project references -->
      <RuntimeDependencyProjectFullPath Include="@(RuntimeDependencyProject->'%(FullPath)')" />
      <ProjectReferenceFullPath Include="@(ProjectReference->'%(FullPath)')" />
      <RuntimeProjectReference Include="@(ProjectReferenceFullPath)" Condition="'@(ProjectReferenceFullPath)' == '@(RuntimeDependencyProjectFullPath)' AND '%(Identity)' != ''" />
    </ItemGroup>
    <ItemGroup>
      <!-- assume an OOB package supports all fxs -->
      <ContractSupport Include="$(BaseId)" Condition="'$(OOBPackage)' == 'true'">
        <Version>$(_AssemblyVersion)</Version>
        <TargetFramework>%(ValidateFramework.Identity)</TargetFramework>
      </ContractSupport>
    </ItemGroup>
    <MSBuild Projects="@(RuntimeProjectReference)" Targets="GetPackageFiles" Properties="$(ProjectProperties)">
      <Output TaskParameter="TargetOutputs" ItemName="RuntimeFile" />
    </MSBuild>
    <ValidatePackage ContractName="$(BaseId)" PackageId="$(Id)" Files="@(PackageFile);@(RuntimeFile)" ContractSupport="@(ContractSupport)" ReferencePaths="$(ValidationReferencePath)" Frameworks="@(ValidateFramework)" GenerationDefinitionsFile="$(GenerationDefinitionFile)" RuntimeFile="$(RuntimeIdGraphDefinitionFile)" FrameworkListsPath="$(FrameworkListsPath)" SkipGenerationCheck="$(SkipGenerationCheck)" SkipSupportCheck="$(SkipSupportCheck)" SuppressionFile="$(ValidationSuppressionFile)" ContinueOnError="ErrorAndContinue" />
  </Target>
  <Target Name="ValidateMetaPackageFramework" Condition="'$(MetaPackageFramework)' != ''" BeforeTargets="GenerateNuspec">
    <ItemGroup>
      <_ExpectedMetaDependencies Include="@(ContractAssembly)" Condition="'%(ContractAssembly.Platform)' == '$(MetaPackageFramework)'">
        <Version>$([System.Version]::Parse('%(Version)').ToString(3))</Version>
      </_ExpectedMetaDependencies>
      <_ExpectedMetaDependencies Remove="@(ExcludePackage);@(NoPackage)" />
      <_ActualMetaDependencies Include="@(Dependency);@(RuntimeDependency)" />
      <!-- also consider indirect dependencies that may come from the core package, 
           TODO: right now this also picks up indirect dependencies other packages (eg: runtime pinning) -->
      <_ActualMetaDependencies Include="@(NuProjDependency)" Condition="'%(NuProjDependency.DependencyKind)' == 'Indirect'" />
      <_ActualMetaDependencies>
        <Version>$([System.String]::new('%(Version)').Replace('$(VersionSuffix)', ''))</Version>
      </_ActualMetaDependencies>
      <_MissingMetaDependencies Include="@(_ExpectedMetaDependencies)" Exclude="@(_ActualMetaDependencies)" />
      <_SatisfiedMetaDependencies Include="@(_ExpectedMetaDependencies)" Condition="'@(_ExpectedMetaDependencies)' == '@(_ActualMetaDependencies)' and '%(Identity)' != ''">
        <!-- Use transform here because we don't want to effect the batching -->
        <ActualVersion>@(_ActualMetaDependencies->'%(Version)')</ActualVersion>
      </_SatisfiedMetaDependencies>
      <_SatisfiedMetaDependencies>
        <!-- Compare and store the result in metadata -->
        <!-- This cannot be done in a condition because MSBuild logical ops aren't short 
             circuit and parse would throw on empty string as a result of empty _SatisfiedDependencies -->
        <CompareResult>$([System.Version]::Parse('%(ActualVersion)').CompareTo( $([System.Version]::Parse('%(Version)')) ))</CompareResult>
      </_SatisfiedMetaDependencies>
    </ItemGroup>
    <Error Text="Packages @(_MissingMetaDependencies->'%(Identity)-%(Version)') should be included." Condition="'@(_MissingMetaDependencies)' != ''" ContinueOnError="ErrorAndContinue" />
    <Error Text="Package @(_SatisfiedMetaDependencies)-%(ActualVersion) is higher version than %(Version) expected." Condition="'@(_SatisfiedMetaDependencies)' != '' AND  %(CompareResult) &gt; 0" ContinueOnError="ErrorAndContinue" />
  </Target>
  <!--
============================================================================================================================================
  </Import>

E:\ProjectK\src\NDP\FxCore\src\Packages\System.IO.Compression\unix\System.IO.Compression.nuproj
============================================================================================================================================
-->
</Project>