# ---------- Stage 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SchoolProject/SchoolProject.csproj", "SchoolProject/"]
RUN dotnet restore "./SchoolProject/SchoolProject.csproj"

COPY . .
WORKDIR /src/SchoolProject
RUN dotnet build "./SchoolProject.csproj" -c Release -o /app/build

# ---------- Stage 2: Publish ----------
FROM build AS publish
RUN dotnet publish "./SchoolProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ---------- Stage 3: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "SchoolProject.dll"]
