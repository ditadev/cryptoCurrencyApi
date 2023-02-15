FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "../Currency.Api/Currency.Api.csproj" --disable-parallel 
RUN dotnet publish "../Currency.Api/Currency.Api.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5071

ENTRYPOINT ["dotnet", "Currency.Api.dll"]

