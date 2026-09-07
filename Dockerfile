# ===== Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Копируем csproj и восстанавливаем зависимости
COPY ["Films.csproj", "./"]
RUN dotnet restore "Films.csproj"

# Копируем весь код и публикуем
COPY . .
RUN dotnet publish "Films.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ===== Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Создаём папку для загруженных постеров
RUN mkdir -p /app/wwwroot/img

COPY --from=build /app/publish .

# Порт, на котором будет слушать приложение
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Films.dll"]
