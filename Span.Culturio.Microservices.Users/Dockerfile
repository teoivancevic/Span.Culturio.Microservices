#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Span.Culturio.Microservices.Users/Span.Culturio.Microservices.Users.csproj", "Span.Culturio.Microservices.Users/"]
COPY ["Span.Culturio.Microservices.Core/Span.Culturio.Microservices.Core.csproj", "Span.Culturio.Microservices.Core/"]
RUN dotnet restore "Span.Culturio.Microservices.Users/Span.Culturio.Microservices.Users.csproj"
COPY . .
WORKDIR "/src/Span.Culturio.Microservices.Users"
RUN dotnet build "Span.Culturio.Microservices.Users.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Span.Culturio.Microservices.Users.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Span.Culturio.Microservices.Users.dll"]
