#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PurpleCow.Web/PurpleCow.Web.csproj", "PurpleCow.Web/"]
COPY ["PurpleCow.Data/PurpleCow.Data.csproj", "PurpleCow.Data/"]
COPY ["PurpleCow.Common/PurpleCow.Common.csproj", "PurpleCow.Common/"]
RUN dotnet restore "PurpleCow.Web/PurpleCow.Web.csproj"
COPY . .
WORKDIR "/src/PurpleCow.Web"
RUN dotnet build "PurpleCow.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PurpleCow.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PurpleCow.Web.dll"]