REM - This file assumes that you have access to the application and that you have docker installed
REM : Setup your applications name below
SET APP_NAME="dojo-cgdf-api"

REM - Delete all files and folders in publish
del /q ".\bin\Release\netcoreapp3.1\publish\*"
FOR /D %%p IN (".\bin\Release\netcoreapp3.1\publish\*.*") DO rmdir "%%p" /s /q

dotnet clean --configuration Release
dotnet publish -c Release
copy Dockerfile .\bin\Release\netcoreapp3.1\publish\
mkdir .\bin\Release\netcoreapp3.1\publish\Uploads\
copy Uploads\ .\bin\Release\netcoreapp3.1\publish\Uploads\
cd .\bin\Release\netcoreapp3.1\publish\
docker rmi %APP_NAME%
docker rmi registry.heroku.com/%APP_NAME%/web
docker build -t %APP_NAME% .
docker tag %APP_NAME% registry.heroku.com/%APP_NAME%/web
call heroku container:login
call heroku container:push web -a %APP_NAME%
call heroku container:release web -a %APP_NAME%