
# Giai đoạn 1: Build ứng dụng bằng .NET SDK 10
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore CourseCapacity.API.csproj

RUN dotnet publish CourseCapacity.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Giai đoạn 2: Chạy ứng dụng bằng ASP.NET Runtime 10
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "CourseCapacity.API.dll"]
