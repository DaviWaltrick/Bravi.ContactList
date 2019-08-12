FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Bravi.ContactList.API/Bravi.ContactList.API.csproj", "Bravi.ContactList.API/"]
COPY ["Bravi.ContactList.Domain/Bravi.ContactList.Domain.csproj", "Bravi.ContactList.Domain/"]
COPY ["Bravi.ContactList.Infrastructure.Data.EF/Bravi.ContactList.Infrastructure.Data.EF.csproj", "Bravi.ContactList.Infrastructure.Data.EF/"]
RUN dotnet restore "Bravi.ContactList.API/Bravi.ContactList.API.csproj"
COPY . .
WORKDIR "/src/Bravi.ContactList.API"
RUN dotnet build "Bravi.ContactList.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Bravi.ContactList.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Bravi.ContactList.API.dll"]