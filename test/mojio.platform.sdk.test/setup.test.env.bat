echo off
    if exist appsettings.%1.json (
        echo "%1 settings file found"
        if exist appsettings.json del appsettings.json
        copy appsettings.%1.json appsettings.json
        goto end
    ) else (
        echo No environment settings file found, using default
    )
)

:end
cd
dir
type appsettings.json
copy appsettings.json ..\..\
dir ..\..\

