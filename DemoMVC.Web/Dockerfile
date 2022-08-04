#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoMVC.Web/DemoMVC.Web.csproj", "DemoMVC.Web/"]
RUN dotnet restore "DemoMVC.Web/DemoMVC.Web.csproj"
COPY . .
WORKDIR "/src/DemoMVC.Web"
RUN dotnet build "DemoMVC.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoMVC.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMVC.Web.dll"]