
#Stage 1: Define base image sdk that will be used for building the custom image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

#Stage 2: Build and publish the code
#Copy the csproj file and restore any dependencies via nuget
COPY *.csproj  ./
RUN dotnet restore

#Copy the project files and publish to specified folder
COPY . ./
RUN dotnet publish -c Release -o out


#Stage 3: Build the final image
#Generate runtime image and set up a working directory
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConfigApi.dll"]