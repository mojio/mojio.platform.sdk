echo off
    if exist appsettings.%1.json (
        echo "%1 settings file found"
        if exist appsettings.envrionment.json del appsettings.envrionment.json
        copy appsettings.%1.json appsettings.envrionment.json
        goto end
    ) else (
        echo No environment settings file found, using default
    )
)

:end
