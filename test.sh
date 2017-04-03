#!/usr/bin

# if on windows, do not use mono
case "$(uname -s)" in

   CYGWIN*|MINGW32*|MSYS*)
     echo 'MS Windows'
     packages\opencover\4.6.519\tools\OpenCover.Console.exe -target:"dotnet.exe" -targetargs:"test Core.Shogi.Tests\Core.Shogi.Tests.csproj" -output:coverage.xml -register:user -filter:"+[*]* -[xunit*]*" -oldStyle
	 ;;

   *)
     echo 'other OS' 
	 mono ./packages/opencover/4.6.519/tools/OpenCover.Console.exe -target:"/usr/share/dotnet/sdk/1.0.1/dotnet" -targetargs:"test Core.Shogi.Tests/Core.Shogi.Tests.csproj" -output:coverage.xml -register:user -filter:"+[*]* -[xunit*]*" -oldStyle
     ;;
esac

pause