
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/app/ZBlog.Api/ZBlog.Api.csproj", "src/app/ZBlog.Api/"]
COPY ["src/app/ZBlog.Infrastructure/ZBlog.Infrastructure.csproj", "src/app/ZBlog.Infrastructure/"]
COPY ["src/app/ZBlog.Application/ZBlog.Application.csproj", "src/app/ZBlog.Application/"]
COPY ["src/app/ZBlog.Domain/ZBlog.Domain.csproj", "src/app/ZBlog.Domain/"]
COPY ["src/core/ZBlog.Core.Repository/ZBlog.Core.Repository.csproj", "src/core/ZBlog.Core.Repository/"]
COPY ["src/core/ZBlog.Core.Entity/ZBlog.Core.Entity.csproj", "src/core/ZBlog.Core.Entity/"]
COPY ["src/core/ZBlog.Core/ZBlog.Core.csproj", "src/core/ZBlog.Core/"]
RUN dotnet restore "src/app/ZBlog.Api/ZBlog.Api.csproj"
COPY . .
WORKDIR "/src/src/app/ZBlog.Api"
RUN dotnet build "ZBlog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZBlog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZBlog.Api.dll"]
