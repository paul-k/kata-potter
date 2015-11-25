Task default -Depends Test

task Compile {
    msbuild kata-potter.sln /t:Rebuild /p:Configuration=Release /verbosity:quiet

    if($lastexitcode -ne 0) {
      throw "Rebuild Failed!"
    }  
}

Task Test -Depends Compile {
    & tools\NUnit\bin\nunit3-console.exe src\Kata.Potter.Tests\bin\Release\Kata.Potter.Tests.dll
}
