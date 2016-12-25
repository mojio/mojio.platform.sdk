pushd .

FOR /F "tokens=* USEBACKQ" %%F IN (`git rev-parse HEAD`) DO (
SET var=%%F
)
ECHO %var%


Powershell.exe -File UpdateGitHash.ps1 %var%

popd