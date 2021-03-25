
# Build image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

#Copy the csproj file and restore any dependencies via nuget
COPY *.csproj  ./
RUN dotnet restore

#Copy the project files and build release

COPY . ./
RUN dotnet publish -c Release -o out

#Generate runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ConfigApi.dll"]


#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src
#COPY ConfigApi.csproj ./
#RUN dotnet restore "./ConfigApi.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "ConfigApi.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "ConfigApi.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ConfigApi.dll"]
