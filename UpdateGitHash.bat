pushd .

FOR /F "tokens=* USEBACKQ" %%F IN (`git rev-parse HEAD`) DO (
SET var=%%F
)
ECHO %var%


Powershell.exe -Command  [System.IO.File]::WriteAllText('src\Mojio.Platform.SDK\Entities\Environments\GitEnvironment.cs', [System.IO.File]::ReadAllText('src\Mojio.Platform.SDK\Entities\Environments\GitEnvironment.cs').Replace('NOTSET','%var%'))

popd