FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview as build
WORKDIR /src
COPY ["GrpcGreeterClient/GrpcGreeterClient.csproj", "GrpcGreeterClient/"]
RUN dotnet restore "GrpcGreeterClient/GrpcGreeterClient.csproj"
COPY ./GrpcGreeterClient ./GrpcGreeterClient
WORKDIR "/src/GrpcGreeterClient"
RUN dotnet build "GrpcGreeterClient.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "GrpcGreeterClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcGreeterClient.dll"]