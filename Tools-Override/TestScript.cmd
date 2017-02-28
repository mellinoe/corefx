@echo off
set __TIMESTAMP=
for /f "delims=" %%a in ('python DumplingHelper.py get_timestamp') do @set __TIMESTAMP=%%a
echo Before time: %__TIMESTAMP%
msbuild D:\oss\corefx\src\System.AppContext\tests\System.AppContext.Tests.csproj /t:rebuildandtest
python DumplingHelper.py collect_dump E:\crashdumps\dotnetexe %__TIMESTAMP%