#!/usr/bin/env bash 

#hack to get opencover to work on mono due to ColoredConsoleAppender issue.
rm ./packages/opencover/4.6.519/tools/log4net.config

mono ./packages/opencover/4.6.519/tools/OpenCover.Console.exe -target:"/usr/bin/dotnet" -targetargs:"test Core.Shogi.Tests/Core.Shogi.Tests.csproj" -output:coverage.xml -register:user -filter:"+[*]*" -excludebyfile:*Program.cs -oldStyle

exit 0