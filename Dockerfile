# Use the official .NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore dependencies
COPY ["InsuranceQuoteApp.API/InsuranceQuoteApp.API.csproj", "InsuranceQuoteApp.API/"]
COPY ["InsuranceQuoteApp.BusinessLogic/InsuranceQuoteApp.BusinessLogic.csproj", "InsuranceQuoteApp.BusinessLogic/"]
COPY ["InsuranceQuoteApp.Data/InsuranceQuoteApp.Data.csproj", "InsuranceQuoteApp.Data/"]
RUN dotnet restore "InsuranceQuoteApp.API/InsuranceQuoteApp.API.csproj"

# Copy the entire application source code and build it
COPY . .
WORKDIR "/src/InsuranceQuoteApp.API"
RUN dotnet build "InsuranceQuoteApp.API.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "InsuranceQuoteApp.API.csproj" -c Release -o /app/publish

# Use the runtime image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceQuoteApp.API.dll"]
