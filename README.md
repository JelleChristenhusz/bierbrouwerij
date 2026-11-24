# Bierbrouwerij

Een webapplicatie in **ASP.NET Core Blazor (.NET 8)** voor het beheren van bieren en hun ingrediënten.

## Functies
- Overzicht van alle bieren
- Detailpagina per bier met de ingrediënten
- Nieuw bier aanmaken met ingrediënten

## Architectuur
Het project is opgedeeld in lagen:

| Project | Inhoud |
| --- | --- |
| `Bierbrouwerij.Domain` | Entities (`Bier`, `Ingredient`) en repository-interfaces |
| `Bierbrouwerij.Application` | DTO's, mapping-extensions en de `BierService` |
| `Bierbrouwerij.Infrastructure` | `DbContext`, migrations en repositories (generieke basis-repository) |
| `Bierbrouwerij.UI` | Blazor-pagina's en layout |
| `Bierbrouwerij.Tests` | Unit tests met xUnit en een fake repository |

## Gebruikte technieken
- C# / .NET 8, Blazor
- Entity Framework Core met SQLite
- Dependency injection en het repository-pattern
- xUnit voor unit tests
- Docker en Docker Compose

## Starten

**Met .NET**
```bash
dotnet run --project Bierbrouwerij.UI
```
De database wordt bij het opstarten automatisch aangemaakt.

**Met Docker**
```bash
docker compose up --build
```
Open daarna http://localhost:8080.

**Tests**
```bash
dotnet test
```
