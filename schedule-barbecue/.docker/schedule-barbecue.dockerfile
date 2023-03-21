FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
LABEL key="Rodrigo Vaz" 
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["../src/Api.Application/Api.Application.csproj", "src/Api.Application/"]
COPY ["../src/Api.Infra.CrossCutting/Api.Infra.CrossCutting.csproj", "src/Api.Infra.CrossCutting/"]
COPY ["../src/Api.Infra.Data/Api.Infra.Data.csproj", "src/Api.Infra.Data/"]
COPY ["../src/Api.Domain/Api.Domain.csproj", "src/Api.Domain/"]
COPY ["../src/Api.Service/Api.Service.csproj", "src/Api.Service/"]

RUN dotnet restore "src/Api.Application/Api.Application.csproj"
RUN dotnet restore "src/Api.Domain/Api.Domain.csproj"
RUN dotnet restore "src/Api.Infra.CrossCutting/Api.Infra.CrossCutting.csproj"
RUN dotnet restore "src/Api.Infra.Data/Api.Infra.Data.csproj"
RUN dotnet restore "src/Api.Service/Api.Service.csproj"

COPY . .

WORKDIR "/src/src/Api.Application"
RUN dotnet build "Api.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Application.dll"]

# RUN dotnet publish "/src/Api.Domain/Api.Domain.csproj" -c Release -o /app/publish  -r linux-arm64 --self-contained false --no-restore
