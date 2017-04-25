echo off
    if exist appsettings.%1.json (
        echo "%1 settings file found"
        if exist appsettings.environment.json del appsettings.environment.json
        copy appsettings.%1.json appsettings.environment.json
        goto end
    ) else (
        echo No environment settings file found, using default
    )
)

:end
dir
