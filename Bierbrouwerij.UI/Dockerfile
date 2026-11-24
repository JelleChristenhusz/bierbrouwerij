# Bouwstap: compileer de applicatie
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Bierbrouwerij.UI/Bierbrouwerij.UI.csproj", "Bierbrouwerij.UI/"]
COPY ["Bierbrouwerij.Application/Bierbrouwerij.Application.csproj", "Bierbrouwerij.Application/"]
COPY ["Bierbrouwerij.Domain/Bierbrouwerij.Domain.csproj", "Bierbrouwerij.Domain/"]
COPY ["Bierbrouwerij.Infrastructure/Bierbrouwerij.Infrastructure.csproj", "Bierbrouwerij.Infrastructure/"]
RUN dotnet restore "Bierbrouwerij.UI/Bierbrouwerij.UI.csproj"

COPY . .
WORKDIR "/src/Bierbrouwerij.UI"
RUN dotnet publish "Bierbrouwerij.UI.csproj" -c Release -o /app/publish

# Runtimestap
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Maak de data map aan
RUN mkdir -p /app/data

ENTRYPOINT ["dotnet", "Bierbrouwerij.UI.dll"]