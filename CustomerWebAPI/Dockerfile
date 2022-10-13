#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["CustomerWebAPI/CustomerWebAPI.csproj", "CustomerWebAPI/"]
RUN dotnet restore "CustomerWebAPI/CustomerWebAPI.csproj"
COPY . .
WORKDIR "/src/CustomerWebAPI"
RUN dotnet build "CustomerWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerWebAPI.dll"]