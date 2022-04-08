#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TicketMicroservice.Api/TicketMicroservice.Api.csproj", "TicketMicroservice.Api/"]
COPY ["TicketMicroservice.AppServices/TicketMicroservice.AppServices.csproj", "TicketMicroservice.AppServices/"]
COPY ["TicketMicroservice.Core/TicketMicroservice.Core.csproj", "TicketMicroservice.Core/"]
COPY ["TicketMicroservice.EntityFramework/TicketMicroservice.EntityFramework.csproj", "TicketMicroservice.EntityFramework/"]
RUN dotnet restore "TicketMicroservice.Api/TicketMicroservice.Api.csproj"
COPY . .
WORKDIR "/src/TicketMicroservice.Api"
RUN dotnet build "TicketMicroservice.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketMicroservice.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketMicroservice.Api.dll"]